using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace ProyectoJuego
{
    public abstract class Nivel : Pantalla
    {
        const string TEXTURA_MURO_PATH = "Content/pared.jpg";
        protected int[] spawnProtagonista;
        protected int[] spawnEnemigo;
        protected Texture2D texturaMuro;
        protected List<Sprite> muros;
        protected Sprite protagonista;
        protected Sprite enemigo;
        protected List<Sprite> objetos;
        protected bool pausa;
        protected int pausaTemp;
        public Nivel()
        {
            spawnProtagonista = new int[2];
            spawnEnemigo = new int[2];

            muros = new List<Sprite>();
            objetos = new List<Sprite>();
        }

        public bool ComprobarDerrota()
        {
            if (((Protagonista)protagonista).GetVida() <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Initialize(GraphicsDevice graphicsDevice)
        {
            pausaTemp = 0;

            try
            {
                Stream stream = TitleContainer.OpenStream(TEXTURA_MURO_PATH);
                texturaMuro = Texture2D.FromStream(graphicsDevice, stream);
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

        public virtual void Resetear()
        {
            ((Protagonista)protagonista).SetX(spawnProtagonista[0]);
            ((Protagonista)protagonista).SetY(spawnProtagonista[1]);

            ((Enemigo)enemigo).SetX(spawnEnemigo[0]);
            ((Enemigo)enemigo).SetY(spawnEnemigo[1]);

            ((Protagonista)protagonista).ResetearInventario();
            ((Protagonista)protagonista).SetVida(100);

            foreach (Objeto objeto in objetos)
            {
                objeto.Ocultar(false);    
            }
        }

        public override void LoadContent(GraphicsDevice graphicsDevice,List<Song> media)
        {
            music = media[2];
            MediaPlayer.IsRepeating = true;

            CrearEscenario();

            protagonista.LoadContent(graphicsDevice);
            enemigo.LoadContent(graphicsDevice);

            foreach (Muro muro in muros)
            {
                muro.LoadContent(graphicsDevice);
            }

            foreach (Objeto objeto in objetos)
            {
                objeto.LoadContent(graphicsDevice);
            }
        }
        
        protected void UnloadContent()
        {
        }

        public override void Update()
        {
            KeyboardState key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.P) && pausa && pausaTemp > 7)
            {
                pausa = false;
                pausaTemp = 0;
            }
            else if (key.IsKeyDown(Keys.P) && pausaTemp > 7)
            {
                pausa = true;
                pausaTemp = 0;
            }
            else
            {
                pausaTemp++;
            }

            if (!pausa)
            {
                if (!ComprobarDerrota())
                {
                    ((Enemigo)enemigo).Perseguir(protagonista);
                    protagonista.Update();

                    if (enemigo.DetectarColision(protagonista))
                    {
                        protagonista.SetX(spawnProtagonista[0]);
                        protagonista.SetY(spawnProtagonista[1]);
                        enemigo.SetX(spawnEnemigo[0]);
                        enemigo.SetY(spawnEnemigo[1]);

                        ((Protagonista)protagonista).QuitarVida();
                    }
                    foreach (Muro muro in muros)
                    {
                        if (protagonista.DetectarColision(muro))
                        {
                            protagonista.SetX(protagonista.GetUltimaCoordenadaX());
                            protagonista.SetY(protagonista.GetUltimaCoordenadaY());
                        }

                        if (enemigo.DetectarColision(muro))
                        {
                            ((Enemigo)enemigo).CambiarDirección(muro);
                        }
                    }

                    foreach (Objeto objeto in objetos)
                    {
                        if (!objeto.GetOculto())
                        {
                            if (objeto.DetectarColision(protagonista))
                            {
                                objeto.Ocultar(true);

                                if (objeto.GetType().Name.Contains("Puerta"))
                                {
                                    Resetear();
                                }
                            }
                        }
                    }
                }
                else
                {
                    Resetear();
                    MediaPlayer.Stop();
                    Protagonista.puntuacion = 0;
                    PantallaManager.actualPantalla = 8;
                }
            }
        }

        public abstract void CrearEscenario();

        public override void Draw(SpriteBatch spriteBatch,SpriteFont font)
        {
            base.Draw(spriteBatch, font);

            foreach (Muro muro in muros)
            {
                muro.Draw(spriteBatch);
            }

            for (int i = 0; i < objetos.Count(); i++)
            {
                if (!((Objeto)objetos[i]).GetOculto())
                {
                    objetos[i].Draw(spriteBatch);
                }
            }
            
            protagonista.Draw(spriteBatch);
            enemigo.Draw(spriteBatch);

            spriteBatch.DrawString(font, "Vida:", new Vector2(800, 10), Color.White);
            spriteBatch.Draw(((Protagonista)protagonista).GetTexturaVida(), new Vector2(950, 20), Color.White);

            spriteBatch.DrawString(font, "Puntuacion:", new Vector2(100, 10), Color.White);
            spriteBatch.DrawString(font, Convert.ToString(((Protagonista)protagonista).GetPuntuacion()), new Vector2(500, 10), Color.White);

            if (pausa)
            {
                spriteBatch.DrawString(font,"PAUSE",new Vector2(480,400),Color.White);
            }
        }
    }
}
