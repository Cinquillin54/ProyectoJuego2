using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace ProyectoJuego
{
    class Protagonista : Sprite
    {
        const string TEXTURAS_PATH = "Content/personajeTemp.png";

        public Protagonista(int x,int y,int ancho,int alto) : base(x,y,ancho,alto)
        {
        }

        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            if (textura == null)
            {
                try
                { 
                    Stream stream = TitleContainer.OpenStream(TEXTURAS_PATH);
                    textura = Texture2D.FromStream(graphicsDevice, stream);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found");
                }
                catch (IOException)
                {
                    Console.WriteLine("Error");
                }
            }
        }

        public override void Update()
        {
            Keys[] kState = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in kState)
            { 
                switch (key)
                {
                    case Keys.A:
                        hitbox.X -= velocidad;
                        break;
                    case Keys.W:
                        hitbox.Y -= velocidad;
                        break;
                    case Keys.S:
                        hitbox.Y += velocidad;
                        break;
                    case Keys.D:
                        hitbox.X += velocidad;
                        break;
                }

                if (hitbox.X < 0)
                {
                    hitbox.X = 0;
                }
                else if (hitbox.X > 1000)
                {
                    hitbox.X = 1000;
                }

                if (hitbox.Y < 0)
                {
                    hitbox.Y = 0;
                }
                else if (hitbox.Y > 500)
                {
                    hitbox.Y = 500;
                }
            }
        }
    }
}
