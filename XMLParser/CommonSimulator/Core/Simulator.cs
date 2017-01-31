using System;
using System.Collections.Generic;
using F2J2A.AntSimulator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace F2J2A.CommonSimulator.Core
{
	public class Simulator : Game
	{

	    private static Simulator _simulatorInstance;

	    public static Simulator Instance
	    {
	        get
	        {
	            //should never be null upon access
	            if(_simulatorInstance == null)
	                throw new ApplicationException();

	            return _simulatorInstance;
	        }
	    }

		public SpriteBatch SpriteBatch { get; private set; }
	    public Dictionary<string, Texture2D> Textures;

	    private GraphicsDeviceManager _graphics;
	    private TickCounter _tickCounter;
		private Simulation _currentSimulation;

		public Simulator ()
		{
		    _simulatorInstance = this;
			_graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";
			_tickCounter = new TickCounter ();
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
		    Textures.Add("background", Content.Load<Texture2D>("background.png"));
		    Textures.Add("food", Content.Load<Texture2D>("food.png"));
		    Textures.Add("nest", Content.Load<Texture2D>("nest.png"));
		    Textures.Add("ant", Content.Load<Texture2D>("ant.png"));
		    Textures.Add("antwithfood", Content.Load<Texture2D>("antwithfood.png"));
		    Textures.Add("antqueen", Content.Load<Texture2D>("antqueen.png"));

		    _currentSimulation = new AntSimulation();
		}

		protected override void Update (GameTime gameTime)
		{

			if (Keyboard.GetState ().IsKeyDown (Keys.Escape))
				Exit ();

			if(_tickCounter.IsNextTick(_currentSimulation.TimeBeetwenTicksInMs, gameTime))
				_currentSimulation.NextTick ();

			base.Update (gameTime);
		}

		protected override void Draw (GameTime gameTime)
		{
			_graphics.GraphicsDevice.Clear (Color.CornflowerBlue);

		    SpriteBatch.Begin();
		    _currentSimulation.Draw(gameTime);
		    SpriteBatch.End();

			base.Draw (gameTime);
		}
	}
}


