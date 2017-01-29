using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace F2J2A.Core
{
	public class Simulator : Game
	{

	    private static Simulator simulatorInstance;

	    public static Simulator Instance
	    {
	        get
	        {
	            if(simulatorInstance == null)
	                throw new ApplicationException();

	            return simulatorInstance;
	        }
	    }

		public SpriteBatch SpriteBatch { get; private set; }
	    public Dictionary<string, Texture2D> Textures;

	    GraphicsDeviceManager graphics;
	    TickCounter tickCounter;
		Simulation currentSimulation;

		public Simulator ()
		{
		    simulatorInstance = this;
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";
			tickCounter = new TickCounter ();
		    Textures = new Dictionary<string, Texture2D>();
		}

	    protected override void LoadContent ()
		{
			SpriteBatch = new SpriteBatch (GraphicsDevice);
			//Ici on chargera toutes les scenes à partir du simulatorGenerator 
			//On lui passera le spritebatch pour qu'il charge les ressources
			//Et on mettra les simulations dans la List "simulations"

			//On generera une classe selecteur de simulation pour choisir la simulation
			//à partir de la liste simulation et on met le selecteur de simulation dans currentSimulation

		    Textures.Add("dirt", Content.Load<Texture2D>("dirt.png"));
		    Textures.Add("nest", Content.Load<Texture2D>("nest.png"));

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

		    SpriteBatch.Begin();
		    currentSimulation.Draw(gameTime);
		    SpriteBatch.End();

			base.Draw (gameTime);
		}
	}
}


