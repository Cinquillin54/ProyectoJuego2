using System;
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
    class Nivel1 : Nivel
    {
        const string BACKGROUND_PATH = "Content/level1Background.png";
        public Nivel1() : base()
        {
            spawnProtagonista[0] = 40;
            spawnProtagonista[1] = 300;

            spawnEnemigo[0] = 40;
            spawnEnemigo[1] = 60;

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
            muros.Add(new Muro(0,0,1200,20));
            muros.Add(new Muro(0,0,20,950));
            muros.Add(new Muro(1180,0,20,950));
            muros.Add(new Muro(9, 950, 1180, 20));
            muros.Add(new Muro(0, 930, 1180, 20));
            //Muros particulares
            muros.Add(new Muro(180, 20, 20, 350));
            muros.Add(new Muro(570, 200, 210, 20));
            muros.Add(new Muro(180, 200, 200, 20));
            muros.Add(new Muro(180, 550, 20, 200));
            muros.Add(new Muro(180, 730, 200, 20));
            muros.Add(new Muro(380, 550, 240, 20));
            muros.Add(new Muro(380, 360, 450, 20));
            muros.Add(new Muro(600, 550, 20, 200));
            muros.Add(new Muro(1000, 20, 20, 300));
            muros.Add(new Muro(1000, 500, 20, 250));
            muros.Add(new Muro(800, 550, 20, 200));
            muros.Add(new Muro(800, 750, 220, 20));

            //Objetos
            objetos.Add(new Curacion(885, 650, 40, 40));
            objetos.Add(new Puerta(45,23,100,100,1));
            objetos.Add(new Llave(1080,130,40,40));
            objetos.Add(new Moneda(230, 90, 60, 60));
            objetos.Add(new Moneda(850, 90, 60, 60));
            objetos.Add(new Moneda(230, 600, 60, 60));
            objetos.Add(new Moneda(1080, 830, 60, 60));
        }
        public override void LoadContent(GraphicsDevice graphicsDevice,List<Song> media)
        {
            base.LoadContent(graphicsDevice,media);

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
