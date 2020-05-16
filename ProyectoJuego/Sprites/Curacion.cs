using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace ProyectoJuego.Personaje
{
    class OCuracion : Sprite
    {
        const string TEXTURAS_PATH = "Content/Curación.png";

        public OCuracion(int x, int y, int ancho, int alto) : base(x, y, ancho, alto)
        {
        }
        public override void Animar()
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

        }
    }
}
*/