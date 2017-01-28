using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using F2J2A.Core;

namespace F2J2A.Core
{
	public class Simulator : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		TickCounter tickCounter;
		//We could use gameComponents
		List<Simulation> simulations;
		Simulation currentSimulation;

		public Simulator ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";
			tickCounter = new TickCounter ();
		}

		protected override void Initialize ()
		{
			base.Initialize ();
		}

		protected override void LoadContent ()
		{
			spriteBatch = new SpriteBatch (GraphicsDevice);
			//Ici on chargera toutes les scenes à partir du simulatorGenerator 
			//On lui passera le spritebatch pour qu'il charge les ressources
			//Et on mettra les simulations dans la List "simulations"

			//On generera une classe selecteur de simulation pour choisir la simulation
			//à partir de la liste simulation et on met le selecteur de simulation dans currentSimulation
			currentSimulation = new AntSimulation();
		}

		protected override void Update (GameTime gameTime)
		{

			if (Keyboard.GetState ().IsKeyDown (Keys.Escape))
				Exit ();

			Console.WriteLine (gameTime.TotalGameTime);
			if(tickCounter.IsNextTick(currentSimulation.TimeBeetwenTicksInMs(), gameTime))
				currentSimulation.NextTick ();

			base.Update (gameTime);
		}

		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);

			//graphics.BeginDraw ();
			//currentSimulation.Draw ();
			//graphics.EndDraw ();

			base.Draw (gameTime);
		}
	}
}


