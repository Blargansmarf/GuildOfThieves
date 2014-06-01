using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace GuildOfThieves
{
    public class World
    {
        GraphicsDeviceManager graphics;
        ContentManager content;

        public Rectangle room;

        public struct platform
        {
            public Rectangle shape;
            public bool soft;
        }

        public List<platform> platforms;

        public World(GraphicsDeviceManager g, ContentManager c)
        {
            graphics = g;
            content = c;
        }

        public Vector2 Initialize(string filename)
        {
            Vector2 startLoc = new Vector2();
            platforms = new List<platform>();
            room = new Rectangle();

            StreamReader sr = new StreamReader(filename);
            String s = sr.ReadToEnd();
            String[] infile = s.Split(new string[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            for (int x = 0; x < infile.Length; x++)
            {
                if (infile[x] == "Start")
                {
                    startLoc.X = Convert.ToInt32(infile[++x]);
                    startLoc.Y = Convert.ToInt32(infile[++x]);
                }

                if (infile[x] == "SolidPlat")
                {
                    platform temp1 = new platform();
                    temp1.soft = false;
                    temp1.shape = new Rectangle();

                    temp1.shape.X = Convert.ToInt32(infile[++x]);
                    temp1.shape.Y = Convert.ToInt32(infile[++x]);
                    temp1.shape.Width = Convert.ToInt32(infile[++x]);
                    temp1.shape.Height = Convert.ToInt32(infile[++x]);

                    platforms.Add(temp1);
                }

                if (infile[x] == "SoftPlat")
                {
                    platform temp1 = new platform();
                    temp1.soft = true;
                    temp1.shape = new Rectangle();

                    temp1.shape.X = Convert.ToInt32(infile[++x]);
                    temp1.shape.Y = Convert.ToInt32(infile[++x]);
                    temp1.shape.Width = Convert.ToInt32(infile[++x]);
                    temp1.shape.Height = Convert.ToInt32(infile[++x]);

                    platforms.Add(temp1);
                }

                if (infile[x] == "Room")
                {
                    room.X = Convert.ToInt32(infile[++x]);
                    room.Y = Convert.ToInt32(infile[++x]);
                    room.Width = Convert.ToInt32(infile[++x]);
                    room.Height = Convert.ToInt32(infile[++x]);
                }
            }

            return startLoc;
        }
    }
}
