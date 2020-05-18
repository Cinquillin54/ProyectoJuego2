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
    class Llave : Objeto
    {
        public Llave(int x,int y,int ancho,int alto) : base(x,y,ancho,alto)
        {
        }

        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            Stream stream;
            try
            {
                stream = TitleContainer.OpenStream("Content/Llave.png");
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

        public override void Funcion(Sprite protagonista)
        {
            ((Protagonista)protagonista).inventario.Add(this);
        }
    }
}
