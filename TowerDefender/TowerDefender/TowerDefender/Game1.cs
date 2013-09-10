using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TowerDefender
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public enum direccion {izquierda, derecha, arriba, abajo}

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Alien alien;
        int[] ruta = new int[5];
        direccion[] direccionRuta = new direccion[5];
        bool[] activo = new bool[5];

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 1000;

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            alien = new Alien (new Vector2(0,0));
            ruta[0] = 300;
            direccionRuta[0] = direccion.derecha;
            activo[0] = true;
            ruta[1] = 400;
            direccionRuta[1] = direccion.abajo;
            activo[1] = false;
            ruta[2] = 200;
            direccionRuta[2] = direccion.derecha;
            activo[2] = false;
            ruta[3] = 100;
            direccionRuta[3] = direccion.arriba;
            activo[3] = false;
            ruta[4] = 250;
            direccionRuta[4] = direccion.derecha;
            activo[4] = false;
            base.Initialize();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected void actualizarPosicion(GameTime gameTime)
        {
            if ((alien.PosicionActual.X <= ruta[0]) && activo[0])
            {
                alien.avanzar(1, direccion.derecha, gameTime);
            }
            else if(activo[0])
            {
                activo[0] = false;
                activo[1] = true;
            }
            if ((alien.PosicionActual.Y <= ruta[1]) && activo[1])
            {
                alien.avanzar(1, direccion.abajo, gameTime);
            }
            else if (activo[1])
            {
                activo[1] = false;
                activo[2] = true;
            }
            if ((alien.PosicionActual.X <= ruta[0] + ruta[2]) && activo[2])
            {
                alien.avanzar(1, direccion.derecha, gameTime);
            }
            else if (activo[2])
            {
                activo[2] = false;
                activo[3] = true;
            }
            if ((alien.PosicionActual.Y >= ruta[1] - ruta[3]) && activo[3])
            {
                alien.avanzar(1, direccion.arriba, gameTime);
            }
            else if (activo[3])
            {
                activo[3] = false;
                activo[4] = true;
            } 
            if ((alien.PosicionActual.X <= ruta[0] + ruta[2] + ruta[4]) && activo[4])
            {
                alien.avanzar(1, direccion.derecha, gameTime);
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            alien.LoadContent(this.Content, "volador");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            actualizarPosicion(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            alien.dibujarAlien(this.spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
