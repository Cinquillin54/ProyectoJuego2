using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJuego
{
    public class Muro : Sprite
    {
        const string TEXTURAS_PATH = "Content/Pared.jpg";

        public Muro(int x, int y, int ancho, int alto) : base(x,y,ancho,alto)
        {
        }

        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            if (texturaActual == null)
            {
                try
                {
                    Stream stream = TitleContainer.OpenStream(TEXTURAS_PATH);
                    texturaActual = Texture2D.FromStream(graphicsDevice, stream);
                }
                catch (FileNotFoundException)
                {
                    StreamWriter writer = File.CreateText("Errores.txt");

                    writer.WriteLine("Error en " + GetType() + " no se encontró el archivo");
                    writer.Close();
                }
                catch (IOException)
                {
                    StreamWriter writer = File.CreateText("Errores.txt");

                    writer.WriteLine("Error");
                    writer.Close();
                }
            }
        }
        public override void Update()
        {
        }
        public override void Animar(int direccion)
        {
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texturaActual,hitbox,Color.White);
        }
    }
}
