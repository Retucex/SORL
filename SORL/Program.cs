using System;
using SadConsole;
using Microsoft.Xna.Framework;
using SadConsole.Input;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework.Graphics;

namespace StarterProject
{
	class Program
	{
		const int MainConsoleWidth = 160;
		const int MainConsoleHeight = 90;

		static void Main(string[] args)
		{
			//SadConsole.Settings.UnlimitedFPS = true;
			//SadConsole.Settings.UseHardwareFullScreen = true;

			// Setup the engine and creat the main window.
			SadConsole.Game.Create("Fonts/Cheepicus12.font", MainConsoleWidth, MainConsoleHeight);
			//SadConsole.Engine.Initialize("IBM.font", 80, 25, (g) => { g.GraphicsDeviceManager.HardwareModeSwitch = false; g.Window.AllowUserResizing = true; });

			// Hook the start event so we can add consoles to the system.
			SadConsole.Game.OnInitialize = Init;

			// Hook the update event that happens each frame so we can trap keys and respond.
			SadConsole.Game.OnUpdate = Update;

			// Hook the "after render" even though we're not using it.
			SadConsole.Game.OnDraw = DrawFrame;

			// Start the game.
			SadConsole.Game.Instance.Run();

			//
			// Code here will not run until the game has shut down.
			//

			SadConsole.Game.Instance.Dispose();
		}

		private static void DrawFrame(GameTime time)
		{
			// Custom drawing. You don't usually have to do this.
		}

		private static void Update(GameTime time)
		{
			// Called each logic update.

			// As an example, we'll use the F5 key to make the game full screen
			if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F5))
			{
				SadConsole.Settings.ToggleFullScreen();
			}
		}

		private static void Init()
		{
			// Any custom loading and prep. We will use a sample console for now

			Console startingConsole = new Console(MainConsoleWidth, MainConsoleHeight);
			startingConsole.FillWithRandomGarbage();
			startingConsole.Fill(new Rectangle(3, 3, 27, 5), null, Color.Black, 0, SpriteEffects.None);
			startingConsole.Print(6, 5, "Hello from SadConsole", ColorAnsi.CyanBright);

			// Set our new console as the thing to render and process
			SadConsole.Global.CurrentScreen = startingConsole;
		}
	}
}