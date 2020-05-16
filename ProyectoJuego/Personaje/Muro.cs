using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJuego.Level
{
    public class Muro : Sprite
    {
        const string TEXTURAS_PATH = "Content/Pared.png";

        public Muro(int x, int y, int ancho, int alto) : base(x,y,ancho,alto)
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
        public bool DetectarColision()
        {
            return true;
        }
        public override void Update()
        {
        }
    }
}
