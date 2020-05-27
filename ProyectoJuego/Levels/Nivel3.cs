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

            spawnEnemigo.Add(100);
            spawnEnemigo.Add(50);

            spawnEnemigo.Add(800);
            spawnEnemigo.Add(200);

            protagonista = new Protagonista(spawnProtagonista[0], spawnProtagonista[1], 60, 80);
            enemigos.Add(new Enemigo(spawnEnemigo[0], spawnEnemigo[1], 60, 80));
            enemigos.Add(new Enemigo(spawnEnemigo[2], spawnEnemigo[3], 60, 80));
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
            muros.Add(new Muro(880, 335, 180, 20));
            muros.Add(new Muro(370, 590, 130, 20));
            muros.Add(new Muro(370, 20, 20, 160));
            muros.Add(new Muro(530, 160, 350, 20));
            muros.Add(new Muro(690, 20, 20, 160));
            muros.Add(new Muro(370, 760, 160, 20));
            muros.Add(new Muro(510, 760, 20, 200));
            muros.Add(new Muro(880, 160, 20, 200));
            muros.Add(new Muro(880, 160, 20, 200));
            muros.Add(new Muro(535, 286, 180, 180));
            muros.Add(new Muro(670, 590, 200, 20));
            muros.Add(new Muro(660, 590, 20, 200));
            muros.Add(new Muro(870, 590, 200, 20));
            muros.Add(new Muro(1050, 590, 20, 200));
            muros.Add(new Muro(870, 590, 200, 20));
            muros.Add(new Muro(660, 770, 270, 20));

            //Objetos
            objetos.Add(new Curacion(590, 60, 60, 60));
            objetos.Add(new Curacion(410, 820, 60, 60));
            objetos.Add(new Puerta(50, 50, 90, 100, 2));
            objetos.Add(new Llave(720, 680, 50, 50));
            objetos.Add(new Llave(770, 60, 50, 50));
            objetos.Add(new Moneda(40, 660, 60, 60));
            objetos.Add(new Moneda(40, 840, 60, 60));
            objetos.Add(new Moneda(940, 230, 60, 60));
            objetos.Add(new Moneda(275, 520, 60, 60));
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
