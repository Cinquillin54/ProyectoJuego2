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
    class Pistola : Objeto
    {
        List<Rectangle> balas;
        List<int> posicionesBalas;
        int retardoBalas;

        public Pistola(int x,int y,int ancho,int alto) : base(x,y,ancho,alto)
        {
            retardoBalas = 0;
            balas = new List<Rectangle>();
            posicionesBalas = new List<int>();
        }

        public override void Funcion(Sprite protagonista)
        {
            if (!((Protagonista)protagonista).TienePistola())
            {
                ((Protagonista)protagonista).inventario.Add(this);
            }
            else if (retardoBalas < 0)
            {
                retardoBalas = 10;
                balas.Add(new Rectangle(protagonista.GetHitbox().X, protagonista.GetHitbox().Y, 20, 30));
                posicionesBalas.Add(protagonista.GetPosicionActual());
            }
            else
            {
                retardoBalas--;
            }
        }

        public void Reseteo()
        {
            balas.Clear();
        }

        public void DibujarBala(SpriteBatch spriteBatch,List<Muro> muros,Sprite enemigo)
        {
            for (int i=0;i<balas.Count();i++)
            {
                switch (posicionesBalas[i])
                {
                    case 0:
                        balas[i] = new Rectangle(balas[i].X, balas[i].Y - 5, 20, 30);
                        break;
                    case 1:
                        balas[i] = new Rectangle(balas[i].X, balas[i].Y + 5, 20, 30);
                        break;
                    case 2:
                        balas[i] = new Rectangle(balas[i].X + 5, balas[i].Y, 20, 30);
                        break;
                    case 3:
                        balas[i] = new Rectangle(balas[i].X - 5, balas[i].Y, 20, 30);
                        break;
                }

                spriteBatch.Draw(texturas["bala"], balas[i], Color.White);
            }

            List<int> eliminar = new List<int>();
            int cont = 0;

            foreach (Rectangle bala in balas)
            {
                foreach (Muro muro in muros)
                {
                    if (muro.GetHitbox().Intersects(bala))
                    {
                        eliminar.Add(cont);
                    }
                }

                if (bala.Intersects(enemigo.GetHitbox()))
                {
                    ((Enemigo)enemigo).Impacto();
                    eliminar.Add(cont);
                }

                cont++;
            }
            
            foreach (int num in eliminar)
            {
                balas.Remove(balas[num]);
                posicionesBalas.Remove(posicionesBalas[num]);
            }
        }

        public List<Rectangle> GetBalas()
        {
            return balas;
        }

        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            base.LoadContent(graphicsDevice);

            Stream stream;
            try
            {
                stream = TitleContainer.OpenStream("Content/pistola.png");
                texturas.Add("pistola", Texture2D.FromStream(graphicsDevice, stream));
                stream = TitleContainer.OpenStream("Content/bala.png");
                texturas.Add("bala", Texture2D.FromStream(graphicsDevice, stream));

                texturaActual = texturas["pistola"];
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
    }
}
