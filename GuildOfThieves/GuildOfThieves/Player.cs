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
    public class Player
    {
        public Vector2 startLoc;
        public Vector2 loc;

        public Texture2D texture;

        GraphicsDeviceManager graphics;
        ContentManager content;

        public Player(GraphicsDeviceManager g, ContentManager c)
        {
            graphics = g;
            content = c;
        }

        public void Initialize(string s)
        {
            texture = content.Load<Texture2D>(s);


            startLoc = new Vector2(Game1.screenWidth / 2 - texture.Width / 2, Game1.screenHeight / 2 - texture.Height - 2);
            new Vector2(startLoc.X, startLoc.Y);
        }

        public void LoadContent()
        {
            
        }

        public void Draw(SpriteBatch sBatch)
        {
            sBatch.Begin();

            sBatch.Draw(texture, startLoc, Color.Red);
            
            sBatch.End();
        }
    }
}
