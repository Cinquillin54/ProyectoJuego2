using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using ProyectoJuego.Level;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace ProyectoJuego
{
    public abstract class Nivel : Pantalla
    {
        const string TEXTURA_MURO_PATH = "Content/pared.jpg";
        protected Texture2D texturaMuro;
        protected List<Sprite> muros;
        protected Sprite protagonista;
        protected Sprite enemigo;
        public Nivel()
        {
            muros = new List<Sprite>();
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

        public void Resetear()
        {
            ((Protagonista)protagonista).SetVida(100);
        }

        public override void LoadContent(GraphicsDevice graphicsDevice,List<Song> media)
        {
            music = media.ElementAt(2);
            protagonista.LoadContent(graphicsDevice);
            enemigo.LoadContent(graphicsDevice);
        }
        
        protected void UnloadContent()
        {

        }

        public override void Update()
        {
            if (!ComprobarDerrota())
            {
                ((Enemigo)enemigo).Perseguir(protagonista);
                protagonista.Update();

                if (enemigo.DetectarColision(protagonista))
                {
                    protagonista.SetX(20);
                    protagonista.SetY(180);
                    enemigo.SetX(20);
                    enemigo.SetY(0);

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
            }
            else
            {
                Resetear();
                MediaPlayer.Stop();
                PantallaManager.actualPantalla = 2;
            }
        }

        public abstract void CrearEscenario();

        public override void Draw(SpriteBatch spriteBatch,SpriteFont font)
        {
            base.Draw(spriteBatch,font);

            foreach (Muro muro in muros)
            {
                spriteBatch.Draw(texturaMuro, muro.GetHitbox(), Color.White);
            }

            protagonista.Draw(spriteBatch);
            enemigo.Draw(spriteBatch);
        }
    }
}
