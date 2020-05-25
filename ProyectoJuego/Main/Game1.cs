using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace ProyectoJuego
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        List<Song> media;
        SpriteFont font;
        PantallaManager pantallaManager;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            media = new List<Song>();
            pantallaManager = new PantallaManager();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            this.graphics.PreferredBackBufferWidth = 1200;
            this.graphics.PreferredBackBufferHeight = 950;

            IsMouseVisible = true;
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
            pantallaManager.Initialize(GraphicsDevice);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            Song musicaInicio = Content.Load<Song>("musicaInicio");
            Song musicaMuerte = Content.Load<Song>("musicaMuerte");
            Song musicaNivel = Content.Load<Song>("musicaNivel");
            Song musicaGuardado = Content.Load<Song>("musicaGuardado");
            Song musicaCurar = Content.Load<Song>("musicaCurar");

            media.Add(musicaInicio);
            media.Add(musicaMuerte);
            media.Add(musicaNivel);
            media.Add(musicaGuardado);
            media.Add(musicaCurar);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("font");

            pantallaManager.LoadContent(GraphicsDevice,media);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (PantallaSalir.salir)
                Exit();
            
            pantallaManager.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            
            pantallaManager.Draw(spriteBatch,font);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
