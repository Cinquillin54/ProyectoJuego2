using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ProyectoJuego;

namespace ProyectoJuego
{
    class PantallaManager
    {
        Pantalla[] pantallas;
        public static int actualPantalla = 9;
        public int controlMusica;
        public PantallaManager()
        {
            controlMusica = 0;
            pantallas = new Pantalla[11];

            pantallas[0] = new Nivel1();
            pantallas[1] = new Nivel2();
            pantallas[2] = new Nivel3();
            pantallas[3] = new Nivel4();
            pantallas[4] = new Nivel5();
            pantallas[5] = new Nivel6();
            pantallas[6] = new PantallaPuntuaciones();
            pantallas[7] = new PantallaSalir();
            pantallas[8] = new PantallaFin();
            pantallas[9] = new PantallaInicio();
            pantallas[10] = new PantallaGuardado();
        }

        public void Update()
        {
            if (controlMusica != actualPantalla)
            {
                controlMusica = actualPantalla;

                pantallas[actualPantalla].PlaySong();
            }

            pantallas[actualPantalla].Update();
        }

        public void Initialize(GraphicsDevice graphicsDevice)
        {
            foreach (Pantalla pantalla in pantallas)
            {
                pantalla.Initialize(graphicsDevice);
            }
        }

        public void Draw(SpriteBatch spriteBatch ,SpriteFont font)
        {
            pantallas[actualPantalla].Draw(spriteBatch,font);
        }

        public void LoadContent(GraphicsDevice graphicsDevice,List<Song> media)
        {
            foreach (Pantalla pantalla in pantallas)
            {
                pantalla.LoadContent(graphicsDevice,media);
            }
        }

        public int GetActualPantalla()
        {
            return actualPantalla;
        }
    }
}
