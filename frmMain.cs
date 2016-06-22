using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace CleanTileEditor
{
    public partial class frmMain : Form
    {
        SpriteBatch spriteBatch;
        ContentManager content;

        List<Texture2D> tileTextures = new List<Texture2D>();

        int[,] tileMap = new int[,] {
            { 0, 0, 1, 0, 0 ,0 ,0 ,0 },
            { 0, 0, 1, 2, 0 ,0 ,0 ,0 },
            { 0, 0, 1, 1, 1 ,1 ,2 ,0 },
            { 0, 0, 2, 2, 2 ,1 ,0 ,0 },
            { 0, 0, 0, 0, 0 ,1 ,0 ,0 },
            { 0, 0, 0, 0, 0 ,1 ,0 ,0 },
            { 0, 0, 0, 1, 1 ,1 ,1 ,1 },
            { 0, 0, 0, 1, 0 ,0 ,0 ,1 },
        };

        int tileWidth = 40;
        int tileHeight = 40;

        public GraphicsDevice graphicsDevice
        {
            get { return tileDisplay1.GraphicsDevice; }
        }

        public ServiceContainer services
        {
            get { return tileDisplay1.Services; }
        }

        public frmMain()
        {
            InitializeComponent();

            tileDisplay1.Initialize += TileDisplay1_Initialize;
            tileDisplay1.Draw += TileDisplay1_Draw;
        }

        private void TileDisplay1_Initialize()
        {
            content = new ContentManager(services, "Content");
            spriteBatch = new SpriteBatch(graphicsDevice);

            Texture2D texture;

            texture = content.Load<Texture2D>("dirt");
            tileTextures.Add(texture);

            texture = content.Load<Texture2D>("grass");
            tileTextures.Add(texture);

            texture = content.Load<Texture2D>("rock");
            tileTextures.Add(texture);
        }

        private void TileDisplay1_Draw()
        {
            graphicsDevice.Clear(Color.CornflowerBlue);

            int tileMapWidth = tileMap.GetLength(1);
            int tileMapHeight = tileMap.GetLength(0);

            spriteBatch.Begin();

            for (int x = 0; x < tileMapWidth; x++) {
                for (int y = 0; y < tileMapHeight; y++)
                {
                    int textureIndex = tileMap[y, x];
                    Texture2D texture = tileTextures[textureIndex];

                    spriteBatch.Draw(
                        texture,
                        new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight),
                        Color.White);
                }
            }

            spriteBatch.End();
        }
    }
}
