#region File Description

//-----------------------------------------------------------------------------
// GraphicsDeviceControl.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------

#endregion

#region Using Statements

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Collections.Generic;
using XKeys = Microsoft.Xna.Framework.Input.Keys;

#endregion

namespace CleanTileEditor
{
    public class GraphicsDeviceControl : System.Windows.Forms.Control
    {
        private bool designMode
        {
            get
            {
                System.Diagnostics.Process process = System.Diagnostics.Process.GetCurrentProcess();
                bool res = process.ProcessName == "devenv" || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
                process.Dispose();
                return res;
            }
        }

        private Stopwatch sw;
        private SwapChainRenderTarget _chain;
        private GraphicsDeviceService _graphicsDeviceService;
        private Microsoft.Xna.Framework.Color _clearColor;
        public GraphicsDevice GraphicsDevice => _graphicsDeviceService.GraphicsDevice;
        public ServiceContainer Services { get; } = new ServiceContainer();
        public System.Drawing.Color ClearColor
        {
            get
            {
                return System.Drawing.Color.FromArgb(_clearColor.A, _clearColor.R, _clearColor.G, _clearColor.B);
            }
            set
            {
                _clearColor = new Microsoft.Xna.Framework.Color(value.R, value.G, value.B, value.A);
            }
        }
        //Read only access to frames per second.
        public string fps { get; private set; }

        public bool AutoDraw { get; set; } = true;
        private bool isResized { get; set; } = false;

        protected override void OnCreateControl()
        {
            sw = new Stopwatch();
            _keys = new List<Microsoft.Xna.Framework.Input.Keys>();

            if (!designMode)
            {
                SizeChanged += GraphicsDeviceControl_SizeChanged; //If resizing the form this will fire, updating to our new size.

                _graphicsDeviceService = GraphicsDeviceService.AddRef(Handle, ClientSize.Width, ClientSize.Height);

                _chain = new SwapChainRenderTarget(_graphicsDeviceService.GraphicsDevice, Handle, ClientSize.Width,
                    ClientSize.Height);

                Services.AddService<IGraphicsDeviceService>(_graphicsDeviceService);

                Initialize?.Invoke(); // Gives us an Initialize Method: Invoked after graphics device service is instantiated AND after services is created.

                LoadContent?.Invoke(); // Gives us a LoadContent Method

                if (AutoDraw)
                    //Gives us an Update() loop
                    Application.Idle += delegate { InsideUpdate(); };
            }
            base.OnCreateControl();
        }

        private void InsideUpdate()
        {
            Update?.Invoke(); //Gives us an Update Method

            //Update FPS
            double milliseconds = FPS.ComputeTimeSlice(sw);
            FPS.Accumulate(milliseconds);

            //Invalidate to flag this control as needing updating.
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (_graphicsDeviceService != null)
            {
                _graphicsDeviceService.Release(disposing);
                _graphicsDeviceService = null;
            }
            base.Dispose(disposing);
        }

        protected override void OnResize(EventArgs e)
        {
            isResized = true;
            base.OnResize(e);
        }

        private string BeginDraw()
        {
            if (_graphicsDeviceService == null)
                return Text + "\n\n" + GetType();

            var deviceResetError = HandleDeviceReset();
            if (!string.IsNullOrEmpty(deviceResetError))
            {
                return deviceResetError;
            }

            var viewport = new Viewport
            {
                X = 0,
                Y = 0,
                Width = ClientSize.Width,
                Height = ClientSize.Height,
                MinDepth = 0,
                MaxDepth = 1
            };

            if (isResized)
            {
                Resized();
            }

            if (GraphicsDevice.Viewport.Equals(viewport) == false)
                GraphicsDevice.Viewport = viewport;

            _graphicsDeviceService.GraphicsDevice.SetRenderTarget(_chain);

            return null;
        }
        private void Resized()
        {
            _chain = new SwapChainRenderTarget(_graphicsDeviceService.GraphicsDevice, Handle, ClientSize.Width,
                ClientSize.Height);
            isResized = false;
        }


        private string HandleDeviceReset()
        {
            var deviceNeedsReset = false;
            switch (GraphicsDevice.GraphicsDeviceStatus)
            {
                case GraphicsDeviceStatus.Lost:
                    return "Graphics device lost";
                case GraphicsDeviceStatus.NotReset:
                    deviceNeedsReset = true;
                    break;
                case GraphicsDeviceStatus.Normal:
                    break;
                default:
                    var pp = GraphicsDevice.PresentationParameters;
                    deviceNeedsReset = (ClientSize.Width > pp.BackBufferWidth) ||
                                       (ClientSize.Height > pp.BackBufferHeight);
                    break;
            }
            if (!deviceNeedsReset) return null;
            try
            {
                _graphicsDeviceService.ResetDevice(ClientSize.Width,
                    ClientSize.Height);
            }
            catch (Exception e)
            {
                return "Graphics device reset failed\n\n" + e;
            }
            return null;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            InputManager.SetKeys(_keys); //

            var beginDrawError = BeginDraw();
            if (string.IsNullOrEmpty(beginDrawError))
            {
                GraphicsDevice.Clear(_clearColor);
                Draw?.Invoke();

                _chain.Present();
            }
            else
            {
                PaintUsingSystemDrawing(e.Graphics, beginDrawError);
            }
        }

        protected virtual void PaintUsingSystemDrawing(System.Drawing.Graphics graphics, string text)
        {
            graphics.Clear(System.Drawing.Color.DimGray);
            using (Brush brush = new SolidBrush(System.Drawing.Color.CornflowerBlue))
            {
                using (var format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    graphics.DrawString(text, Font, brush, ClientRectangle, format);
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        private void GraphicsDeviceControl_SizeChanged(object sender, EventArgs e)
        {
            // If we have a reference to the GraphicsDeviceService, we must reset it based on our updated size
            if (_graphicsDeviceService != null)
                _graphicsDeviceService.ResetDevice(ClientSize.Width, ClientSize.Height);
        }

        #region Input

        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;

        private List<Microsoft.Xna.Framework.Input.Keys> _keys;

        // We would like to just override ProcessKeyMessage, but our control would only intercept it
        // if it had explicit focus.  Focus is a messy issue, so instead we're going to let the parent
        // form override ProcessKeyMessage instead, and pass it along to this method.

        internal new void ProcessKeyMessage(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN)
            {
                XKeys xkey = KeyboardUtil.ToXna((Keys)m.WParam);
                if (!_keys.Contains(xkey))
                    _keys.Add(xkey);
            }
            else if (m.Msg == WM_KEYUP)
            {
                Microsoft.Xna.Framework.Input.Keys xnaKey = KeyboardUtil.ToXna((Keys)m.WParam);
                if (_keys.Contains(xnaKey))
                    _keys.Remove(xnaKey);
            }
        }

        #endregion

        public delegate void NullEventArgs();
        public event NullEventArgs Initialize;
        public event NullEventArgs LoadContent;
        public new event NullEventArgs Update;
        public event NullEventArgs Draw;
    }
}