using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJuego
{
    class Puerta : Objeto
    {
        public int llaves;

        public Puerta(int x,int y,int ancho,int alto,int llaves) : base(x,y,ancho,alto)
        {
            this.llaves = llaves;    
        }

        public override void Funcion(Sprite protagonista)
        {
            
        }

        public int LlavesNecesarias()
        {
            return llaves;
        }

        public override bool DetectarColision(Sprite sprite2)
        {
            if (hitbox.Intersects(sprite2.GetHitbox()) && ((Protagonista)sprite2).Llaves() >= llaves)
            {
                Funcion(sprite2);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            Stream stream;
            try
            {
                stream = TitleContainer.OpenStream("Content/Puerta_cerrada.png");
                texturas.Add("puertaAbierta", Texture2D.FromStream(graphicsDevice, stream));

                texturaActual = texturas["puertaAbierta"];
            }
            catch (FileNotFoundException e)
            {
                StreamWriter writer = File.AppendText("Errores.txt");
                writer.WriteLine(e.Message);
                writer.Close();
            }
            catch (IOException e)
            {
                StreamWriter writer = File.AppendText("Errores.txt");
                writer.WriteLine(e.Message);
                writer.Close();
            }
        }    

        public override void Update()
        {
            
        }
    }
}
