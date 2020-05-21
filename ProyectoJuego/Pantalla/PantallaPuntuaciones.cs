using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProyectoJuego
{
    class PantallaPuntuaciones : Pantalla
    {
        public static Dictionary<string, int> puntuaciones;
        public static int anteriorTecla;
        public static int seleccionActual;
        const string TEXTURAS_PATH = "Content/pantallaInicio.jpg";

        public PantallaPuntuaciones()
        {
            puntuaciones = new Dictionary<string, int>();
            anteriorTecla = 0;
            seleccionActual = 0;
        }

        public override void Initialize(GraphicsDevice graphicsDevice)
        {
        }

        public override void LoadContent(GraphicsDevice graphicsDevice, List<Song> media)
        {
            music = media.ElementAt(0);
            MediaPlayer.IsRepeating = true;

            if (File.Exists("Puntuaciones.txt"))
            {
                StreamReader reader = File.OpenText("Puntuaciones.txt");
                string linea;

                do
                {
                    linea = reader.ReadLine();

                    if (linea != null)
                    {
                        string[] datos = linea.Split('-');

                        puntuaciones.Add(datos[0], Convert.ToInt32(datos[1]));
                    }
                } while (linea != null);

                reader.Close();
            }
            else
            {
                StreamWriter writer = File.CreateText("Puntuaciones.txt");
                writer.Close();
            }

            try
            {
                Stream stream = TitleContainer.OpenStream(TEXTURAS_PATH);
                background = Texture2D.FromStream(graphicsDevice, stream);
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

            if (key.IsKeyDown(Keys.Enter) && anteriorTecla > 6)
            {
                PantallaManager.actualPantalla = 5;
                PantallaInicio.teclaTimer = 0;
                anteriorTecla = 0;
            }
            else
            {
                anteriorTecla++;
            }
        }

        public string PuntuacionesATexto(Dictionary<string,int> puntuaciones)
        {
            int cont = 0;
            string textoFinal = "";

            foreach (KeyValuePair<string,int> puntuacion in puntuaciones.OrderByDescending(key => key.Value))
            {
                if (cont <= 9)
                {
                    textoFinal += puntuacion.Key + "-" + puntuacion.Value + "\n";
                }

                cont++;
            }

            return textoFinal;
        }


        public override void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            base.Draw(spriteBatch, font);

            spriteBatch.DrawString(font, "TOP 1O", new Vector2(500, 20), Color.White);
            spriteBatch.DrawString(font, "Volver (Enter)", new Vector2(430, 850), Color.White);
            spriteBatch.DrawString(font, PuntuacionesATexto(puntuaciones), new Vector2(445, 80), Color.White);
        }
    }
}
