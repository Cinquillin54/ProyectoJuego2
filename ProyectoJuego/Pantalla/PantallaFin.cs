using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using Microsoft.Xna.Framework.Media;

namespace ProyectoJuego
{
    class PantallaFin : Pantalla
    {
        const string TEXTURAS_PATH = "Content/PantallaFinal.png";

        public PantallaFin()
        {
        }

        public override void Initialize(GraphicsDevice graphicsDevice)
        {
        }

        public override void LoadContent(GraphicsDevice graphicsDevice,List<Song> media)
        {
            music = media.ElementAt(1);

            try
            {
                Stream stream = TitleContainer.OpenStream(TEXTURAS_PATH);
                background = Texture2D.FromStream(graphicsDevice, stream);
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

        public override void Draw(SpriteBatch spriteBatch,SpriteFont font)
        {
            base.Draw(spriteBatch,font);
        }       

        public override void Update()
        {
            KeyboardState key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.Enter))
            {
                PantallaManager.actualPantalla = 1;
            }
        }
    }
}
