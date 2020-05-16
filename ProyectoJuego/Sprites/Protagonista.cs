using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace ProyectoJuego
{
    class Protagonista : Sprite
    {
        int vida;

        public Protagonista(int x,int y,int ancho,int alto) : base(x,y,ancho,alto)
        {
            vida = 100;
            velocidad = 4;
        }

        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            try
            {
                Stream stream;

                stream = TitleContainer.OpenStream("Content/Personaje/ABAJO_1.png");
                texturas.Add("abajo1",Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Personaje/ABAJO_2.png");
                texturas.Add("abajo2", Texture2D.FromStream(graphicsDevice, stream));
                
                stream = TitleContainer.OpenStream("Content/Personaje/ABAJO_3.png");
                texturas.Add("abajo3", Texture2D.FromStream(graphicsDevice, stream));
                
                stream = TitleContainer.OpenStream("Content/Personaje/ABAJO_4.png");
                texturas.Add("abajo4", Texture2D.FromStream(graphicsDevice, stream));
                
                stream = TitleContainer.OpenStream("Content/Personaje/ARRIBA_1.png");
                texturas.Add("arriba1",Texture2D.FromStream(graphicsDevice, stream));
                
                stream = TitleContainer.OpenStream("Content/Personaje/ARRIBA_2.png");
                texturas.Add("arriba2", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Personaje/ARRIBA_3.png");
                texturas.Add("arriba3", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Personaje/ARRIBA_4.png");
                texturas.Add("arriba4", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Personaje/DERECHA_1.png");
                texturas.Add("derecha1", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Personaje/DERECHA_2.png");
                texturas.Add("derecha2", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Personaje/DERECHA_3.png");
                texturas.Add("derecha3", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Personaje/DERECHA_4.png");
                texturas.Add("derecha4", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Personaje/IZQUIERDA_1.png");
                texturas.Add("izquierda1", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Personaje/IZQUIERDA_2.png");
                texturas.Add("izquierda2", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Personaje/IZQUIERDA_3.png");
                texturas.Add("izquierda3", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Personaje/IZQUIERDA_4.png");
                texturas.Add("izquierda4", Texture2D.FromStream(graphicsDevice, stream));

                texturaActual = texturas["abajo1"];
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

        public void QuitarVida()
        {
            vida -= 25;
        }

        public void Curar()
        {
            vida += 15;
        }

        public override void Animar(int direccion)
        {
            if (direccion == ARRIBA)
                direccionLetras = "arriba";
            else if (direccion == ABAJO)
                direccionLetras = "abajo";
            else if (direccion == DERECHA)
                direccionLetras = "derecha";
            else if (direccion == IZQUIERDA)
                direccionLetras = "izquierda";

            if (posicionActual == direccion)
            {
                spriteChange++;

                if (spriteChange >= 7)
                {
                    texturaActual = texturas[direccionLetras + frame];
                    frame++;
                    spriteChange = 0;

                    if (frame > 4)
                    {
                        frame = 1;
                    }
                }
            }
            else if (direccion >= 0 && direccion <= 3)
            {
                spriteChange = 0;
                frame = 1;
                posicionActual = direccion;
                texturaActual = texturas[direccionLetras + frame];
            }
            else
            {
                spriteChange = 0;
                frame = 1;
                texturaActual = texturas[direccionLetras + frame];
            }
        }

        public override void Update()
        {
            ultimaCoordenadaX = hitbox.X;
            ultimaCoordenadaY = hitbox.Y;

            KeyboardState key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.W))
            {
                Animar(ARRIBA);
                hitbox.Y -= velocidad;
            }
            else if (key.IsKeyDown(Keys.S))
            {
                Animar(ABAJO);
                hitbox.Y += velocidad;
            }
            else if (key.IsKeyDown(Keys.A))
            {
                Animar(IZQUIERDA);
                hitbox.X -= velocidad;
            }
            else if (key.IsKeyDown(Keys.D))
            {
                Animar(DERECHA);
                hitbox.X += velocidad;
            }
            else
            {
                Animar(QUIETO);
            }

            if (hitbox.X < 0)
            {
                hitbox.X = 0;
            }
            else if (hitbox.X > 1050)
            {
                hitbox.X = 1050;
            }

            if (hitbox.Y < 0)
            {
                hitbox.Y = 0;
            }
            else if (hitbox.Y > 500)
            {
                hitbox.Y = 500;
            }
        }
        public void SetVida(int vida)
        {
            this.vida = vida;
        }
        public int GetVida()
        {
            return vida;
        }
    }
}
