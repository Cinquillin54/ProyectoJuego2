using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Diagnostics.Contracts;

namespace ProyectoJuego
{
    class Enemigo : Sprite
    {
        const string TEXTURAS_PATH = "Content/minotauro.png";
        bool temp;
        public Enemigo(int x,int y,int ancho,int alto) : base(x,y,ancho,alto)
        {
            temp = true;
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

        public void Perseguir(Sprite protagonista)
        {
            if (protagonista.GetX() > hitbox.X)
            {
                hitbox.X++;
            }
            else
            {
                hitbox.X--;
            }

            if (protagonista.GetY() > hitbox.Y)
            {
                hitbox.Y++;
            }
            else
            {
                hitbox.Y--;
            }
        }
        public override void Update()
        {
            
        }
    }
}
