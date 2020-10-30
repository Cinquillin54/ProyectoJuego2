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
using System.Security.Policy;

namespace ProyectoJuego
{
    class Enemigo : Sprite
    {
        private Random r;
        private bool oculto;
        private int vida;
        private int direccionActual;
        private int tempDireccion;

        public Enemigo(int x, int y, int ancho, int alto) : base(x, y, ancho, alto)
        {
            oculto = false;
            tempDireccion = 10;
            r = new Random();
            vida = 100;
            velocidad = 3;
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

        public void SetVelocidad(int velocidad)
        {
            this.velocidad = velocidad;
        }
        public int GetTempDireccion()
        {
            return tempDireccion;
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

        public void CambiarDirección(Muro muro)
        {
            tempDireccion = 10;

            while (!PoderMoverse(muro, direccionActual))
            {
                direccionActual = r.Next(0,4);
            }

            Moverse(direccionActual);
        }

        public void Moverse(int direccion)
        {
            ultimaCoordenadaX = hitbox.X;
            ultimaCoordenadaY = hitbox.Y;

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

            tempDireccion--;
        }

        public bool PoderMoverse(Muro muro, int direccion)
        {
            bool colisionado = true;
            Rectangle temp = hitbox;

            if (direccion == ARRIBA)
            {
                temp.Y-=velocidad;
            }
            else if (direccion == DERECHA)
            {
                temp.X += velocidad;
            }
            else if (direccion == ABAJO)
            {
                temp.Y += velocidad;
            }
            else if (direccion == IZQUIERDA)
            {
                temp.X -= velocidad;
            }

            if (temp.Intersects(muro.GetHitbox()))
            {
                colisionado = false;
            }

            return colisionado;
        }

        public void Impacto()
        {
            if (!oculto)
            {
                if (PantallaManager.actualPantalla == 6)
                {
                    if (vida <= 50)
                    {
                        velocidad++;
                    }

                    if (vida <= 0)
                    {
                        Nivel7.enemigosCont--;
                        oculto = true;
                    }
                }
                else
                {
                    if (vida <= 50)
                    {
                        velocidad++;
                    }

                    if (vida <= 0)
                    {
                        PantallaManager.actualPantalla++;
                    }
                }

                vida -= 15;
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

        public bool GetOculto()
        {
            return oculto;
        }

        public void SetOculto(bool oculto)
        {
            this.oculto = oculto;
        }

        public override bool DetectarColision(Sprite sprite2)
        {
            if (hitbox.Intersects(sprite2.GetHitbox()))
            {
                hitbox.X = ultimaCoordenadaX;
                hitbox.Y = ultimaCoordenadaY;

                return true;
            }
            else
            {
                return false;
            }
        }

        public void Perseguir(Sprite protagonista,List<Muro> muros)
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
