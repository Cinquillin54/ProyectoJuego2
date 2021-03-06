﻿using System;
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
    class PantallaInicio : Pantalla
    {
        public static int teclaTimer;
        public static int seleccionActual;
        const string TEXTURAS_PATH = "Content/PantallaInicio.jpg";
        const string CURSOR_PATH = "Content/cursor.png";
        Texture2D cursor;

        public PantallaInicio() : base()
        {
        }

        public override void Initialize(GraphicsDevice graphicsDevice)
        {
            teclaTimer = 0;
            seleccionActual = 0;
        }

        public override void LoadContent(GraphicsDevice graphicsDevice, List<Song> media)
        {
            music = media[0];
            MediaPlayer.IsRepeating = true;
            StreamWriter writer = null;

            try
            {
                Stream stream = TitleContainer.OpenStream(TEXTURAS_PATH);
                background = Texture2D.FromStream(graphicsDevice, stream);

                stream = TitleContainer.OpenStream(CURSOR_PATH);
                cursor = Texture2D.FromStream(graphicsDevice, stream);
            }
            catch (FileNotFoundException)
            {
                writer = File.AppendText("Errores.txt");

                writer.WriteLine("Error en " + GetType() + " no se encontró el archivo");
            }
            catch (IOException)
            {
                writer = File.AppendText("Errores.txt");

                writer.WriteLine("Error en " + GetType() + " no se encontró el archivo");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        public override void Update()
        {
            KeyboardState keys = Keyboard.GetState();

            if (teclaTimer > 6)
            {
                foreach (Keys key in keys.GetPressedKeys())
                {
                    switch (key)
                    {
                        case Keys.W:
                            seleccionActual--;
                            
                            if (seleccionActual < 0)
                            {
                                seleccionActual = 0;
                            }

                            teclaTimer = 0;
                            break;
                        case Keys.S:
                            seleccionActual++;

                            if (seleccionActual > 2)
                            {
                                seleccionActual = 2;
                            }

                            teclaTimer = 0;
                            break;
                        case Keys.Enter:

                            switch (seleccionActual)
                            {
                                case 2:
                                    PantallaSalir.anteriorTecla = 0;
                                    PantallaManager.anteriorPantalla = 10;
                                    PantallaManager.actualPantalla = 8;
                                    break;
                                case 1:
                                    PantallaPuntuaciones.anteriorTecla = 0;
                                    PantallaManager.anteriorPantalla = 10;
                                    PantallaManager.actualPantalla = 7;
                                    break;
                                case 0:
                                    PantallaPuntuaciones.anteriorTecla = 0;
                                    PantallaManager.anteriorPantalla = 10;
                                    PantallaManager.actualPantalla = 0;
                                    break;
                            }

                            break;
                    }
                }
            }
            else
            {
                teclaTimer++;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            base.Draw(spriteBatch,font);

            spriteBatch.DrawString(font, "Jugar", new Vector2(500, 100), Color.White);
            spriteBatch.DrawString(font, "Puntuaciones", new Vector2(400, 400), Color.White);
            spriteBatch.DrawString(font, "Salir", new Vector2(520, 700), Color.White);

            Vector2 vector = new Vector2(0,0);

            switch (seleccionActual)
            {
                case 0:
                    vector = new Vector2(650, 70);
                    break;
                case 1:
                    vector = new Vector2(800, 370);
                    break;
                case 2:
                    vector = new Vector2(630, 670);
                    break;
            }

            spriteBatch.Draw(cursor, vector, Color.White);
        }
    }
}
