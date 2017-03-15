using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;

namespace CleanTileEditor
{
    static class TileEngine
    {
        #region Updating
        public static void Update()
        {
            UpdateCameraMovement();
        }
        private static void UpdateCameraMovement() {
            // accumulate the desired direction from user input
            if (InputManager.IsActionPressed(InputManager.Action.MoveCharacterUp))
            {

            }
            if (InputManager.IsActionPressed(InputManager.Action.MoveCharacterDown))
            {

            }
            if (InputManager.IsActionPressed(InputManager.Action.MoveCharacterLeft))
            {

            }
            if (InputManager.IsActionPressed(InputManager.Action.MoveCharacterRight))
            {

            }
        }
        #endregion
    }
}
