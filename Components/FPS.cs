#region Using
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

public class FPS
{
    #region Variables
    private static double accumulator = 0;
    private static int idleCounter = 0;
    public static string fps { get; private set; }
    public static int intFps { get; private set; }
    public static bool visible { get; set; } = true;
    public static Vector2 position { get; set; }
    private static int padding { get; set; } = 7;
    private static float scale = 0.5f;
    #endregion

    public static double ComputeTimeSlice(Stopwatch sw)
    {
        sw.Stop();
        double timeslice = sw.Elapsed.TotalMilliseconds;
        sw.Reset();
        sw.Start();
        return timeslice;
    }
    public static void Accumulate(double milliseconds)
    {
        idleCounter++;
        accumulator += milliseconds;
        if (accumulator > 1000)
        {
            intFps = idleCounter;
            fps = "FPS: " + idleCounter.ToString();
            accumulator -= 1000;
            idleCounter = 0; // reset the counter
        }
    }
    // Option to Draw to render window. Currently Not Implemented
    public static void Draw(SpriteFont font, SpriteBatch spriteBatch, string fps)
    {
        spriteBatch.DrawString(font, fps, new Vector2(position.X + padding, position.Y + padding), Color.Yellow, 0f, new Vector2(0, 0), scale, SpriteEffects.None, 0.1f);
    }
}
