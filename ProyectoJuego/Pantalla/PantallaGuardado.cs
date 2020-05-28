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
    class PantallaGuardado : Pantalla
    {
        string nombre;
        public static int anteriorTecla;
        const string TEXTURAS_PATH = "Content/pantallaInicio.jpg";

        public PantallaGuardado()
        {
        }

        public override void Initialize(GraphicsDevice graphicsDevice)
        {
            anteriorTecla = 0;
            nombre = "";
        }

        public override void LoadContent(GraphicsDevice graphicsDevice, List<Song> media)
        {
            music = media[3];
            MediaPlayer.IsRepeating = true;

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

        public void SobreescribirDatos()
        {
            StreamWriter writer = File.CreateText("Puntuaciones.txt");

            foreach (KeyValuePair<string,int> puntuacion in PantallaPuntuaciones.puntuaciones)
            {
                writer.WriteLine(puntuacion.Key + "-" + puntuacion.Value);
            }

            writer.Close();
        }

        public void CargarDatos()
        {
            StreamWriter writer = File.AppendText("Puntuaciones.txt");

            writer.WriteLine(nombre + "-" + Protagonista.puntuacion);
                
            writer.Close();
        }

        public override void Update()
        {
            KeyboardState key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.Space) && anteriorTecla > 8)
            {
                nombre += " ";
                anteriorTecla = 0;
            }
            else if (key.IsKeyDown(Keys.Back) && anteriorTecla > 6 && nombre.Length > 0)
            {
                nombre = nombre.Substring(0, nombre.Length - 1);
                anteriorTecla = 0;
            }
            else if (key.IsKeyDown(Keys.Enter) && anteriorTecla > 3)
            {
                if (PantallaPuntuaciones.ComprobarNombre(nombre))
                {
                    PantallaPuntuaciones.puntuaciones[nombre] = Protagonista.puntuacion;
                    SobreescribirDatos();
                }
                else
                {
                    PantallaPuntuaciones.puntuaciones.Add(nombre, Protagonista.puntuacion);
                    CargarDatos();
                }

                PantallaManager.actualPantalla = 10;
                PantallaInicio.teclaTimer = 0;
                Protagonista.puntuacion = 0;
                anteriorTecla = 0;
            }
            else if (key.IsKeyDown(Keys.Escape) && anteriorTecla > 3)
            {
                PantallaManager.actualPantalla = 10;
                PantallaInicio.teclaTimer = 0;
                Protagonista.puntuacion = 0;
                anteriorTecla = 0;
            }
            else if (anteriorTecla > 8 && key.GetPressedKeys().Length > 0)
            {
                foreach (Keys k in key.GetPressedKeys())
                {
                    if (k.GetHashCode() >= 65 && k.GetHashCode() <= 90)
                    {
                        nombre += k.ToString();
                        anteriorTecla = 0;
                    }
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

            Vector2 vectorNombre;

            if (nombre.Length < 6)
            {
                vectorNombre = new Vector2(500, 300);
            }
            else
            {
                vectorNombre = new Vector2(300,300);
            }

            spriteBatch.DrawString(font, "Nombre", new Vector2(500, 100), Color.White);
            spriteBatch.DrawString(font, nombre, vectorNombre, Color.White);
            spriteBatch.DrawString(font, "Enter [Guardar]", new Vector2(300,500), Color.White);
            spriteBatch.DrawString(font, "ESC [Volver al Menu]", new Vector2(300, 700), Color.White);
        }
    }
}
