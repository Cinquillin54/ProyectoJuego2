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
            muros.Add(new Muro(0, 0, 1100, 50));
            muros.Add(new Muro(0, 0, 50, 950));
            muros.Add(new Muro(600, 0, 600, 600));
            objetos.Add(new Curacion(60, 700, 40, 40));
            objetos.Add(new Puerta(70, 850, 100, 100, 1));
            objetos.Add(new Llave(500, 700, 60, 60));
            objetos.Add(new Moneda(800, 600, 60, 60));
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
