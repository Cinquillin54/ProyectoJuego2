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
            PantallaManager.actualPantalla++;
            
            if (PantallaManager.actualPantalla == 2)
            {
                PantallaManager.actualPantalla = 6;
            }
        }

        public int LlavesNecesarias()
        {
            return llaves;
        }

        public override bool DetectarColision(Sprite sprite2)
        {
            if (hitbox.Intersects(sprite2.GetHitbox()))
            {
                if (((Protagonista)sprite2).Llaves() >= llaves)
                {
                    Funcion(sprite2);
                    return true;
                }
                else
                {
                    ((Protagonista)sprite2).SetX(((Protagonista)sprite2).GetUltimaCoordenadaX());
                    ((Protagonista)sprite2).SetY(((Protagonista)sprite2).GetUltimaCoordenadaY());
                    return false;
                }   
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
