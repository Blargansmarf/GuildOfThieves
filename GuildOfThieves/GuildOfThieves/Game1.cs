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

namespace GuildOfThieves
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        MouseState prevMouseState, currMouseState;
        KeyboardState prevKeyState, currKeyState;
        GamePadState prevGamePadState, currGamePadState;

        Vector2 translation;

        Rectangle tempMapShape;

        public static float screenWidth, screenHeight;

        Player player;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
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
            player = new Player(graphics, Content);

            screenHeight = graphics.GraphicsDevice.Viewport.Height;
            screenWidth = graphics.GraphicsDevice.Viewport.Width;

            player.Initialize("WhiteSquare");

            translation = new Vector2();

            tempMapShape = new Rectangle((int)(screenWidth / 2) - 200, (int)(screenHeight / 2) - 200, 400, 400);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
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
            currMouseState = Mouse.GetState();
            currKeyState = Keyboard.GetState();
            currGamePadState = GamePad.GetState(PlayerIndex.One);

            ProcessMouse();
            ProcessKeyboard();
            ProcessGamePad();

            prevMouseState = currMouseState;
            prevKeyState = currKeyState;
            prevGamePadState = currGamePadState;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //translated
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Matrix.CreateTranslation(-translation.X, -translation.Y, 0));

            spriteBatch.Draw(player.texture, tempMapShape, Color.White);

            spriteBatch.End();

            //Not translated
            player.Draw(spriteBatch);

            base.Draw(gameTime);
        }

        private void ProcessMouse()
        {

        }

        private void ProcessKeyboard()
        {
            if (currKeyState.IsKeyDown(Keys.W) &&
                player.loc.Y > tempMapShape.Top)
            {
                translation.Y--;
                player.loc.Y--;
            }
            if (currKeyState.IsKeyDown(Keys.S) &&
                player.loc.Y + player.texture.Height < tempMapShape.Bottom)
            {
                translation.Y++;
                player.loc.Y++;
            }
            if (currKeyState.IsKeyDown(Keys.A) &&
                player.loc.X > tempMapShape.Left)
            {
                translation.X--;
                player.loc.X--;
            }
            if (currKeyState.IsKeyDown(Keys.D) &&
                player.loc.X + player.texture.Width < tempMapShape.Right)
            {
                translation.X++;
                player.loc.X++;
            }
        }

        private void ProcessGamePad()
        {
            if (currGamePadState.ThumbSticks.Left.Y > 0 &&
                player.loc.Y > tempMapShape.Top)
            {
                translation.Y--;
                player.loc.Y--;
            }
            if (currGamePadState.ThumbSticks.Left.Y < 0 &&
                player.loc.Y + player.texture.Height < tempMapShape.Bottom)
            {
                translation.Y++;
                player.loc.Y++;
            }
            if (currGamePadState.ThumbSticks.Left.X < 0 &&
                player.loc.X > tempMapShape.Left)
            {
                translation.X--;
                player.loc.X--;
            }
            if (currGamePadState.ThumbSticks.Left.X > 0 &&
                player.loc.X + player.texture.Width < tempMapShape.Right)
            {
                translation.X++;
                player.loc.X++;
            }
        }
    }
}
