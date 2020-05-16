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
        protected Rectangle hitbox;
        protected Texture2D textura;
        protected int velocidad;

        public Sprite(int x,int y,int ancho,int alto)
        {
            hitbox = new Rectangle(x,y,ancho,alto);
            velocidad = 3;
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

        public Rectangle GetHitbox()
        {
            return hitbox;
        }

        public abstract void LoadContent(GraphicsDevice graphicsDevice);

        public abstract void Update();

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, hitbox, Color.White);
        }
    }
}
