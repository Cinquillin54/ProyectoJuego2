using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJuego
{
    class Curacion : Objeto
    {
        const string TEXTURAS_PATH = "Content/Curacion.jpg";

        public Curacion(int x, int y, int ancho, int alto) : base(x, y, ancho, alto)
        {
        }
        public override void Animar(int direccion)
        {
        }

        public override void Funcion(Sprite protagonista)
        {
            ((Protagonista)protagonista).Curar();
        }

        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            try
            {
                Stream stream;

                stream = TitleContainer.OpenStream(TEXTURAS_PATH);
                texturas.Add("textura", Texture2D.FromStream(graphicsDevice, stream));

                texturaActual = texturas["textura"];
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

        public override bool DetectarColision(Sprite sprite2)
        {
            if (hitbox.Intersects(sprite2.GetHitbox()))
            {
                Funcion(sprite2);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Update()
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
