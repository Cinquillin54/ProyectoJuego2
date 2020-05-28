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
    public abstract class Pantalla
    {
        public Song music;
        protected Texture2D background;

        public Pantalla(Texture2D background)
        {
            this.background = background;
        }
        public Pantalla()
        {
        }

        public abstract void LoadContent(GraphicsDevice graphicsDevice, List<Song> media);

        public abstract void Update();

        public abstract void Initialize(GraphicsDevice graphicsDevice);

        public virtual void Draw(SpriteBatch spriteBatch,SpriteFont font)
        {
            spriteBatch.Draw(background, new Vector2(0,0), Color.White);
        }

        public virtual void PlaySong()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(music);
        }
    }
}
