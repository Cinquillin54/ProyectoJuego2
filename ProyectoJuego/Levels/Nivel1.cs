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
            protagonista = new Protagonista(20, 160, 60, 80);
            enemigo = new Enemigo(20, 0, 60, 80);

            spawnProtagonista[0] = 50;
            spawnProtagonista[1] = 160;

            spawnEnemigo[0] = 20;
            spawnEnemigo[1] = 0;
        }

        public override void Initialize(GraphicsDevice graphicsDevice)
        {
            base.Initialize(graphicsDevice);
        }
        public override void CrearEscenario()
        {
            muros.Add(new Muro(0,0,20,400));
            muros.Add(new Muro(0, 600,30, 600));
            muros.Add(new Muro(600, 0, 600, 600));
            objetos.Add(new Curacion(60, 700, 40, 40));
            objetos.Add(new Puerta(70,850,100,100,1));
            objetos.Add(new Llave(500, 700, 60, 60));
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
