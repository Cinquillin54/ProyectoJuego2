using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJuego
{
    abstract class Objeto : Sprite
    {
        protected bool oculto;

        public Objeto(int x,int y,int ancho,int alto) : base(x,y,ancho,alto)
        {
        }

        public override void Animar(int direccion)
        {
        }

        public bool GetOculto()
        {
            return oculto;
        }

        public void Ocultar(bool confirmar)
        {
            if (confirmar == true)
            {
                oculto = true;
            }
            else if (confirmar == false)
            {
                oculto = false;
            }
        }
        public abstract void Funcion(Sprite protagonista);

        public override bool DetectarColision(Sprite sprite2)
        {
            if (hitbox.Intersects(sprite2.GetHitbox()))
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
        }

        public override void Update()
        {
        }
    }
}
