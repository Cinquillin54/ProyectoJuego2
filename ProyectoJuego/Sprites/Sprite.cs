using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProyectoJuego
{
    public abstract class Sprite
    {
        protected string direccionLetras;
        protected const int ARRIBA = 0;
        protected const int ABAJO = 1;
        protected const int DERECHA = 2;
        protected const int IZQUIERDA = 3;
        protected const int QUIETO = 4;
        protected Dictionary<string,Texture2D> texturas;
        protected Rectangle hitbox;
        protected Texture2D texturaActual;
        protected int posicionActual;
        protected int velocidad;
        protected int ultimaCoordenadaX;
        protected int ultimaCoordenadaY;
        protected int spriteChange;
        protected int frame;
        public Sprite(int x,int y,int ancho,int alto)
        {
            direccionLetras = "abajo";
            frame = 1;
            posicionActual = 1;
            texturas = new Dictionary<string, Texture2D>();
            hitbox = new Rectangle(x,y,ancho,alto);
            velocidad = 3;
            ultimaCoordenadaX = x;
            ultimaCoordenadaY = y;
            spriteChange = 0;
        }

        public abstract void Animar(int direccion);

        public bool DetectarColision(Sprite sprite2)
        {
            if (hitbox.Intersects(sprite2.hitbox))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetX()
        {
            return hitbox.X;
        }

        public int GetY()
        {
            return hitbox.Y;
        }

        public void SetX(int x)
        {
            this.hitbox.X = x;
        }

        public void SetY(int y)
        {
            this.hitbox.Y = y;
        }
        public int GetUltimaCoordenadaX()
        {
            return ultimaCoordenadaX;
        }

        public int GetUltimaCoordenadaY()
        {
             return ultimaCoordenadaY;
        }

        public Rectangle GetHitbox()
        {
            return hitbox;
        }

        public abstract void LoadContent(GraphicsDevice graphicsDevice);

        public abstract void Update();

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texturaActual, hitbox, Color.White);
        }
    }
}
