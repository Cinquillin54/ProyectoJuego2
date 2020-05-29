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
    class Nivel5 : Nivel
    {
        const string BACKGROUND_PATH = "Content/level1Background.png";
        public Nivel5() : base()
        {
            spawnProtagonista[0] = 50;
            spawnProtagonista[1] = 200;

            spawnEnemigo.Add(130);
            spawnEnemigo.Add(450);

            spawnEnemigo.Add(470);
            spawnEnemigo.Add(350);

            spawnEnemigo.Add(730);
            spawnEnemigo.Add(830);

            protagonista = new Protagonista(spawnProtagonista[0], spawnProtagonista[1], 60, 80);
            enemigos.Add(new Enemigo(spawnEnemigo[0], spawnEnemigo[1], 80, 100));
            enemigos.Add(new Enemigo(spawnEnemigo[2], spawnEnemigo[3], 80, 100));
            enemigos.Add(new Enemigo(spawnEnemigo[4], spawnEnemigo[5], 80, 100));

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
            muros.Add(new Muro(20, 400, 200, 20));
            muros.Add(new Muro(220, 400, 20, 300));
            muros.Add(new Muro(410, 20, 20, 680));
            muros.Add(new Muro(410, 300, 180, 20));
            muros.Add(new Muro(590, 200, 20, 120));
            muros.Add(new Muro(900, 20, 20, 200));
            muros.Add(new Muro(725, 200, 20, 200));
            muros.Add(new Muro(725, 400, 200, 20));
            muros.Add(new Muro(1050, 300, 20, 300));
            muros.Add(new Muro(725, 575, 340, 20));
            muros.Add(new Muro(640, 730, 200, 20));
            muros.Add(new Muro(1000, 720, 20, 400));
            muros.Add(new Muro(640, 730, 20, 200));

            //Objetos
            objetos.Add(new Curacion(900, 500, 40, 40));
            objetos.Add(new Puerta(70, 70, 80, 100, 3));
            objetos.Add(new Llave(490, 220, 50, 50));
            objetos.Add(new Llave(1050, 80, 50, 50));
            objetos.Add(new Llave(730, 830, 50, 50));
            objetos.Add(new Moneda(300, 70, 60, 60));
            objetos.Add(new Moneda(550, 820, 60, 60));
            objetos.Add(new Moneda(470, 350, 60, 60));
            objetos.Add(new Moneda(800, 330, 60, 60));
            objetos.Add(new Moneda(100, 600, 60, 60));
            objetos.Add(new Moneda(1080, 830, 60, 60));
        }
        public override void LoadContent(GraphicsDevice graphicsDevice, List<Song> media)
        {
            base.LoadContent(graphicsDevice, media);

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
    }
}
