using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Diagnostics.Contracts;

namespace ProyectoJuego
{
    class Enemigo : Sprite
    {
        private int direccionActual;
        private int cambioDireccion;

        public Enemigo(int x,int y,int ancho,int alto) : base(x,y,ancho,alto)
        {
            cambioDireccion = 0;
            velocidad = 1;
        }

        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            try
            {
                Stream stream;

                stream = TitleContainer.OpenStream("Content/Enemigo/ABAJO_1.png");
                texturas.Add("abajo1", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Enemigo/ABAJO_2.png");
                texturas.Add("abajo2", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Enemigo/ABAJO_3.png");
                texturas.Add("abajo3", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Enemigo/ABAJO_4.png");
                texturas.Add("abajo4", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Enemigo/ARRIBA_1.png");
                texturas.Add("arriba1", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Enemigo/ARRIBA_2.png");
                texturas.Add("arriba2", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Enemigo/ARRIBA_3.png");
                texturas.Add("arriba3", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Enemigo/ARRIBA_4.png");
                texturas.Add("arriba4", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Enemigo/DERECHA_1.png");
                texturas.Add("derecha1", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Enemigo/DERECHA_2.png");
                texturas.Add("derecha2", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Enemigo/DERECHA_3.png");
                texturas.Add("derecha3", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Enemigo/DERECHA_4.png");
                texturas.Add("derecha4", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Enemigo/IZQUIERDA_1.png");
                texturas.Add("izquierda1", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Enemigo/IZQUIERDA_2.png");
                texturas.Add("izquierda2", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Enemigo/IZQUIERDA_3.png");
                texturas.Add("izquierda3", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream("Content/Enemigo/IZQUIERDA_4.png");
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
        public override void Animar(int direccion)
        {
            if (direccion == 0)
                direccionLetras = "arriba";
            else if (direccion == 1)
                direccionLetras = "abajo";
            else if (direccion == 2)
                direccionLetras = "derecha";
            else if (direccion == 3)
                direccionLetras = "izquierda";

            if (posicionActual == direccion)
            {
                spriteChange++;

                if (spriteChange >= 5)
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
            else
            {
                spriteChange = 0;
                frame = 1;
                posicionActual = direccion;
                texturaActual = texturas[direccionLetras + frame];
            }
        }
        public void Moverse(int direccion)
        {
            switch (direccion)
            {
                case ARRIBA:
                    Animar(ARRIBA);
                    hitbox.Y-=velocidad;
                    break;
                case DERECHA:
                    Animar(DERECHA);
                    hitbox.X+=velocidad;
                    break;
                case ABAJO:
                    Animar(ABAJO);
                    hitbox.Y+=velocidad;
                    break;
                case IZQUIERDA:
                    Animar(IZQUIERDA);
                    hitbox.X-=velocidad;
                    break;
            }
        }

        public bool PoderMoverse(Muro muro, int direccion)
        {
            Rectangle temp = hitbox;

            if (direccion == ARRIBA)
            {
                temp.Y-=5;

                if (temp.Intersects(muro.GetHitbox()))
                {
                    return false; 
                }
                else
                {
                    return true;
                }
            }
            else if (direccion == DERECHA)
            {
                temp.X+=5;

                if (temp.Intersects(muro.GetHitbox()))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (direccion == ABAJO)
            {
                temp.Y +=5;

                if (temp.Intersects(muro.GetHitbox()))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (direccion == IZQUIERDA)
            {
                temp.X-=5;

                if (temp.Intersects(muro.GetHitbox()))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public void CambiarDirección(Muro muro)
        {
            direccionActual = 0;

            while (!PoderMoverse(muro,direccionActual))
            {
                direccionActual++;
            }

            Moverse(direccionActual);
        }

        public void Perseguir(Sprite protagonista)
        {
            if (protagonista.GetX() > hitbox.X)
            {
                Moverse(DERECHA);
            }
            else if (protagonista.GetX() < hitbox.X)
            {
                Moverse(IZQUIERDA);
            }
            
            if (protagonista.GetY() > hitbox.Y)
            {
                Moverse(ABAJO);
            }
            else if (protagonista.GetY() < hitbox.Y)
            {
                Moverse(ARRIBA);
            }
        }
        public override void Update()
        {
        }
    }
}
