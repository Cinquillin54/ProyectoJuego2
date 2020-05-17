using Microsoft.Xna.Framework.Graphics;
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

        public void Ocultar(int confirmar)
        {
            if (confirmar == 1)
            {
                oculto = true;
            }
            else if (confirmar == 0)
            {
                oculto = false;
            }
        }
        public abstract void Funcion(Sprite protagonista);

        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
        }

        public override void Update()
        {
        }
    }
}
