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
    class Nivel2 : Nivel
    {
        const string BACKGROUND_PATH = "Content/level1Background.png";
        public Nivel2() : base()
        {            
            spawnProtagonista[0] = 70;
            spawnProtagonista[1] = 200;

            spawnEnemigo.Add(50);
            spawnEnemigo.Add(50);
            spawnEnemigo.Add(800);
            spawnEnemigo.Add(800);
            spawnEnemigo.Add(180);
            spawnEnemigo.Add(160);
            spawnEnemigo.Add(800);
            spawnEnemigo.Add(640);

            protagonista = new Protagonista(spawnProtagonista[0], spawnProtagonista[1], 60, 80);

            enemigos.Add(new Enemigo(spawnEnemigo[0], spawnEnemigo[1], 80, 100));
            enemigos.Add(new Enemigo(spawnEnemigo[2], spawnEnemigo[3], 80, 100));
            enemigos.Add(new Enemigo(spawnEnemigo[4], spawnEnemigo[5], 60, 80));
            enemigos.Add(new Enemigo(spawnEnemigo[6], spawnEnemigo[7], 60, 80));
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
            muros.Add(new Muro(150, 140, 380, 20));
            muros.Add(new Muro(650, 140, 380, 20));
            muros.Add(new Muro(150, 140, 20, 250));
            muros.Add(new Muro(150, 520, 20, 250));
            muros.Add(new Muro(150, 520, 20, 250));
            muros.Add(new Muro(1030, 140, 20, 250));
            muros.Add(new Muro(1030, 520, 20, 250));
            muros.Add(new Muro(150, 750, 380, 20));
            muros.Add(new Muro(650, 745, 380, 20));
            muros.Add(new Muro(300, 270, 230, 20));
            muros.Add(new Muro(650, 270, 250, 20));
            muros.Add(new Muro(300, 600, 230, 20));
            muros.Add(new Muro(650, 600, 250, 20));
            muros.Add(new Muro(300, 270, 20, 120));
            muros.Add(new Muro(300, 510, 20, 110));
            muros.Add(new Muro(900, 270, 20, 120));
            muros.Add(new Muro(900, 510, 20, 110));
            muros.Add(new Muro(520, 270, 20, 350));
            muros.Add(new Muro(630, 270, 20, 350));

            //Objetos
            objetos.Add(new Curacion(750, 480, 40, 40));
            objetos.Add(new Curacion(1100, 70, 40, 40));
            objetos.Add(new Puerta(545, 390, 80, 100, 2));
            objetos.Add(new Llave(750, 410, 50, 50));
            objetos.Add(new Llave(400, 410, 50, 50));
            objetos.Add(new Moneda(400, 310, 60, 60));
            objetos.Add(new Moneda(400, 520, 60, 60));
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
