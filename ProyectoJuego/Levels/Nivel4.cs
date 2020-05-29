using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJuego
{
    class Nivel4 : Nivel
    {
        const string BACKGROUND_PATH = "Content/level1Background.png";
        public Nivel4() : base()
        {
            spawnProtagonista[0] = 500;
            spawnProtagonista[1] = 800;

            spawnEnemigo.Add(100);
            spawnEnemigo.Add(50);

            protagonista = new Protagonista(spawnProtagonista[0], spawnProtagonista[1], 60, 80);
            enemigos.Add(new Enemigo(spawnEnemigo[0], spawnEnemigo[1], 150, 180));
            ((Enemigo)enemigos[0]).SetVelocidad(2);
        }

        public override void Initialize(GraphicsDevice graphicsDevice)
        {
            base.Initialize(graphicsDevice);
        }
        public override void CrearEscenario()
        {
            //Bordes standard
            muros.Add(new Muro(0, 0, 1200, 20));
            muros.Add(new Muro(0, 0, 20, 950));
            muros.Add(new Muro(1180, 0, 20, 950));
            muros.Add(new Muro(9, 950, 1180, 20));
            muros.Add(new Muro(0, 930, 1180, 20));
            //Muros particulares


            //Objetos
            objetos.Add(new Curacion(1100, 70, 40, 40));
            objetos.Add(new Moneda(550, 50, 60, 60));
            objetos.Add(new Moneda(850, 90, 60, 60));
            objetos.Add(new Moneda(230, 600, 60, 60));
            objetos.Add(new Moneda(1080, 830, 60, 60));
            objetos.Add(new Pistola(500,600,70,70));
        }

        public override void Update()
        {
            base.Update();

            if (((Enemigo)enemigos[0]).GetVida() <= 0)
            {
                Resetear();
                PantallaManager.actualPantalla++;
            }
        }

        public override void LoadContent(GraphicsDevice graphicsDevice, List<Song> media)
        {
            base.LoadContent(graphicsDevice, media);

            music = media[5];

            MediaPlayer.IsRepeating = true;

            if (background == null)
            {
                try
                {
                    Stream stream = TitleContainer.OpenStream(BACKGROUND_PATH);
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
        }

        public override void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            base.Draw(spriteBatch, font);

            if (((Protagonista)protagonista).TienePistola())
            {
                spriteBatch.DrawString(font, "Espacio - Disparar", new Vector2(330,800), Color.White);
            }
        }
    }
}
