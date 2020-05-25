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
    class Nivel3 : Nivel
    {
        const string BACKGROUND_PATH = "Content/level1Background.png";
        public Nivel3() : base()
        {
            spawnProtagonista[0] = 80;
            spawnProtagonista[1] = 280;

            spawnEnemigo[0] = 100;
            spawnEnemigo[1] = 50;

            protagonista = new Protagonista(spawnProtagonista[0], spawnProtagonista[1], 60, 80);
            enemigo = new Enemigo(spawnEnemigo[0], spawnEnemigo[1], 60, 80);
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
            muros.Add(new Muro(20, 200, 210, 20));
            muros.Add(new Muro(220, 200, 20, 130));
            muros.Add(new Muro(220, 480, 20, 130));
            muros.Add(new Muro(20, 590, 220, 20));
            muros.Add(new Muro(20, 760, 220, 20));
            muros.Add(new Muro(240, 310, 130, 20));
            muros.Add(new Muro(240, 480, 130, 20));
            muros.Add(new Muro(370, 480, 20, 130));
            muros.Add(new Muro(370,590,130,20));

            //Objetos
            objetos.Add(new Curacion(1100, 70, 40, 40));
            objetos.Add(new Puerta(545, 390, 80, 100, 1));
            objetos.Add(new Llave(950, 190, 50, 50));
            objetos.Add(new Moneda(550, 50, 60, 60));
            objetos.Add(new Moneda(850, 90, 60, 60));
            objetos.Add(new Moneda(230, 600, 60, 60));
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
