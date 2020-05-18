using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJuego
{
    class PantallaSalir : Pantalla
    {
        public static bool salir;
        public static int anteriorTecla;
        public static int seleccionActual;
        const string TEXTURAS_PATH = "Content/PantallaInicio.jpg";
        const string CURSOR_PATH = "Content/cursor.png";
        Texture2D cursor;

        public override void Initialize(GraphicsDevice graphicsDevice)
        {
            salir = false;
            anteriorTecla = 0;
            seleccionActual = 1;
        }

        public override void LoadContent(GraphicsDevice graphicsDevice, List<Song> media)
        {
            try
            {
                Stream stream = TitleContainer.OpenStream(TEXTURAS_PATH);
                background = Texture2D.FromStream(graphicsDevice, stream);

                stream = TitleContainer.OpenStream(CURSOR_PATH);
                cursor = Texture2D.FromStream(graphicsDevice, stream);
            }
            catch (FileNotFoundException)
            {
                StreamWriter writer = File.CreateText("Errores.txt");

                writer.WriteLine("Error en " + GetType() + " no se encontró el archivo");
            }
            catch (IOException)
            {
                StreamWriter writer = File.CreateText("Errores.txt");

                writer.WriteLine("Error en " + GetType() + " no se encontró el archivo");
            }
        }

        public override void Update()
        {
            KeyboardState key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.W) && anteriorTecla > 6)
            {
                seleccionActual--;

                if (seleccionActual < 0)
                {
                    seleccionActual = 0;
                }

                anteriorTecla = 0;
            }
            else if (key.IsKeyDown(Keys.S) && anteriorTecla > 6)
            {
                seleccionActual++;

                if (seleccionActual > 1)
                {
                    seleccionActual = 1;
                }

                anteriorTecla = 0;
            }
            else if (key.IsKeyDown(Keys.Enter) && anteriorTecla > 6)
            {
                if (seleccionActual == 1)
                {
                    PantallaInicio.teclaTimer = 0;
                    PantallaManager.actualPantalla = 4;
                }
                else
                {
                    salir = true;
                }
            }
            else
            {
                anteriorTecla++;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            base.Draw(spriteBatch, font);

            spriteBatch.DrawString(font, "Seguro que quieres salir", new Vector2(260, 100), Color.White);
            spriteBatch.DrawString(font, "Si", new Vector2(500, 400), Color.White);
            spriteBatch.DrawString(font, "No", new Vector2(500, 700), Color.White);

            Vector2 vector = new Vector2(0, 0);

            if (seleccionActual == 0)
            {
                vector = new Vector2(600,370);
            }
            else if (seleccionActual == 1)
            {
                vector = new Vector2(600,660);
            }

            spriteBatch.Draw(cursor, vector, Color.White);
        }
    }
}
