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
    class Nivel6 : Nivel
    {
        const string BACKGROUND_PATH = "Content/level1Background.png";
        public Nivel6() : base()
        {
            spawnProtagonista[0] = 700;
            spawnProtagonista[1] = 480;

            spawnEnemigo.Add(1000);
            spawnEnemigo.Add(80);

            spawnEnemigo.Add(675);
            spawnEnemigo.Add(100);

            spawnEnemigo.Add(50);
            spawnEnemigo.Add(340);

            protagonista = new Protagonista(spawnProtagonista[0], spawnProtagonista[1], 60, 80);
            enemigos.Add(new Enemigo(spawnEnemigo[0], spawnEnemigo[1], 100, 120));
            enemigos.Add(new Enemigo(spawnEnemigo[2], spawnEnemigo[3], 100, 120));
            enemigos.Add(new Enemigo(spawnEnemigo[4], spawnEnemigo[5], 100, 120));

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
            muros.Add(new Muro(0, 0, 200, 250));
            muros.Add(new Muro(0, 680, 200, 250));
            muros.Add(new Muro(200, 365, 100, 200));
            muros.Add(new Muro(500, 190, 20, 580));
            muros.Add(new Muro(500, 450, 300, 20));
            muros.Add(new Muro(800, 190, 200, 200));
            muros.Add(new Muro(800, 390, 50, 200));
            muros.Add(new Muro(800, 590, 200, 200));

            //Objetos
            objetos.Add(new Curacion(80, 420, 40, 40));
            objetos.Add(new Curacion(1100, 70, 40, 40));
            objetos.Add(new Puerta(545, 480, 80, 100, 3));
            objetos.Add(new Llave(920, 450, 50, 50));
            objetos.Add(new Llave(80, 265, 50, 50));
            objetos.Add(new Llave(675, 350, 50, 50));
            objetos.Add(new Moneda(550, 50, 60, 60));
            objetos.Add(new Moneda(850, 90, 60, 60));
            objetos.Add(new Moneda(80, 600, 60, 60));
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
