using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using ProyectoJuego;

namespace ProyectoJuego
{
    class Protagonista : Sprite
    {
        public List<Objeto> inventario;
        public static int puntuacion;
        Texture2D vidaActual;
        const string TEXTURA_VIDA_LLENA = "Content/vidaPersonaje_llena.png";
        const string TEXTURA_VIDA_MEDIA = "Content/vidaPersonaje_media.png";
        const string TEXTURA_VIDA_BAJA = "Content/vidaPersonaje_baja.png";
        int vida;

        public Protagonista(int x,int y,int ancho,int alto) : base(x,y,ancho,alto)
        {
            inventario = new List<Objeto>();
            puntuacion = 0;
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

                stream = TitleContainer.OpenStream(TEXTURA_VIDA_LLENA);
                texturas.Add("vida_llena", Texture2D.FromStream(graphicsDevice,stream));

                stream = TitleContainer.OpenStream(TEXTURA_VIDA_MEDIA);
                texturas.Add("vida_media", Texture2D.FromStream(graphicsDevice, stream));

                stream = TitleContainer.OpenStream(TEXTURA_VIDA_BAJA);
                texturas.Add("vida_baja", Texture2D.FromStream(graphicsDevice, stream));

                texturaActual = texturas["abajo1"];
                vidaActual = texturas["vida_llena"];
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

            if (vida == 100)
            {
                vidaActual = texturas["vida_llena"];
            }
            else if (vida < 100 && vida >= 50)
            {
                vidaActual = texturas["vida_media"];
            }
            else if (vida < 50 && vida > 0)
            {
                vidaActual = texturas["vida_baja"];
            }
        }

        public void Curar()
        {
            vida += 25;

            if (vida == 100)
            {
                vidaActual = texturas["vida_llena"];
            }
            else if (vida < 100 && vida >= 50)
            {
                vidaActual = texturas["vida_media"];
            }
            else if (vida < 50 && vida > 0)
            {
                vidaActual = texturas["vida_baja"];
            }
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

        public Texture2D GetTexturaVida()
        {
            return vidaActual;
        }

        public int Llaves()
        {
            int cont = 0;

            foreach (Objeto objeto in inventario)
            {
                if (objeto.GetType().Name.Contains("Llave"))
                {
                    cont++;
                }
            }

            return cont;
        }

        public void Disparar()
        {
            foreach (Objeto objeto in inventario)
            {
                if (objeto.GetType().Name.Contains("Pistola"))
                {
                    objeto.Funcion(this);
                }
            }
        }

        public bool TienePistola()
        {
            bool encontrado = false;

            foreach (Objeto objeto in inventario)
            {
                if (objeto.GetType().Name.Contains("Pistola"))
                {
                    encontrado = true;
                }
            }

            return encontrado;
        }

        public void DibujarPistola(SpriteBatch spriteBatch,List<Muro> muros,Sprite enemigo)
        {
            foreach (Objeto objeto in inventario)
            {
                if (objeto.GetType().Name.Contains("Pistola"))
                {
                    ((Pistola)objeto).DibujarBala(spriteBatch,muros,enemigo);
                }
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

            if (key.IsKeyDown(Keys.Space))
            {
                Disparar();
            }
        }

        public void SetVida(int vida)
        {
            this.vida = vida;

            if (vida == 100)
            {
                vidaActual = texturas["vida_llena"];
            }
            else if (vida < 100 && vida >= 50)
            {
                vidaActual = texturas["vida_media"];
            }
            else if (vida < 50 && vida > 0)
            {
                vidaActual = texturas["vida_baja"];
            }
        }
        public int GetVida()
        {
            return vida;
        }

        public int GetPuntuacion()
        {
            return puntuacion;
        }

        public void ResetearInventario()
        {
            foreach (Objeto objeto in inventario)
            {
                if (objeto.GetType().Name.Contains("Pistola"))
                {
                    ((Pistola)objeto).Reseteo();
                }
            }

            inventario.Clear();
        }

        public void EnemigoImpactado(Sprite enemigo)
        {
            List<Rectangle> balas = new List<Rectangle>();

            foreach (Objeto objeto in inventario)
            {
                if (objeto.GetType().Name.Contains("Pistola"))
                {
                    balas = ((Pistola)objeto).GetBalas();
                }
            }

            foreach (Rectangle bala in balas)
            {
                if (bala.Intersects(enemigo.GetHitbox()))
                {
                    ((Enemigo)enemigo).Impacto();
                }
            }
        }

        public void AumentarPuntuacion()
        {
            puntuacion += 50;
        }
    }
}
