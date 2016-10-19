using System;
using SwinGameSDK;
using System.Threading;

namespace BattleShips
{

	/// <summary>
	/// The EndingGameController is responsible for managing the interactions at the end
	/// of a game.
	/// </summary>

	static class EndingGameController
	{

		/// <summary>
		/// Draw the end of the game screen, shows the win/lose state
		/// </summary>
		public static void DrawEndOfGame()
		{
			UtilityFunctions.DrawField(GameController.ComputerPlayer.PlayerGrid, GameController.ComputerPlayer, true);
			UtilityFunctions.DrawSmallField(GameController.HumanPlayer.PlayerGrid, GameController.HumanPlayer);

            //For some reason, this doesn't get displayed for long enough. I didn't even know it existed.

            //Therefore, my task is to convert this to a better form.

            SwinGame.FillRectangle(Color.Black, 75, 75, SwinGame.ScreenWidth() - 150, SwinGame.ScreenHeight() - 150);

            if (GameController.HumanPlayer.IsDestroyed)
                SwinGame.DrawTextLines("YOU LOSE!", Color.Cyan, Color.Transparent, GameResources.GameFont("ArialLarge"), FontAlignment.AlignCenter, 0, 200, SwinGame.ScreenWidth(), SwinGame.ScreenHeight());
            else
                SwinGame.DrawTextLines("YOU WON!", Color.Cyan, Color.Transparent, GameResources.GameFont("ArialLarge"), FontAlignment.AlignCenter, 0, 200, SwinGame.ScreenWidth(), SwinGame.ScreenHeight());


            //Display Human Score:
            SwinGame.DrawTextLines(String.Format("Your Score: {0}", GameController.HumanPlayer.Score), Color.White, Color.Transparent, GameResources.GameFont("ArialLarge"), FontAlignment.AlignCenter, 0, 260, SwinGame.ScreenWidth(), SwinGame.ScreenHeight());


            //Display AI Score:
            SwinGame.DrawTextLines(String.Format("Enemy Score: {0}", GameController.ComputerPlayer.Score), Color.White, Color.Transparent, GameResources.GameFont("ArialLarge"), FontAlignment.AlignCenter, 0, 320, SwinGame.ScreenWidth(), SwinGame.ScreenHeight());

            SwinGame.RefreshScreen();

            //Wait 10 seconds.
            Thread.Sleep(10000);
        }

        /// <summary>
        /// Handle the input during the end of the game. Any interaction
        /// will result in it reading in the highsSwinGame.
        /// </summary>
        public static void HandleEndOfGameInput()
		{
			if (SwinGame.MouseClicked(MouseButton.LeftButton) || SwinGame.KeyTyped(KeyCode.vk_RETURN) || SwinGame.KeyTyped(KeyCode.vk_ESCAPE)) {
				HighScoreController.ReadHighScore(GameController.HumanPlayer.Score);
				GameController.EndCurrentState();
			}
		}

	}
}
