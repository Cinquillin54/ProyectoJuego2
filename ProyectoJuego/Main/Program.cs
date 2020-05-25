﻿using System;

namespace ProyectoJuego
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Game1 game = new Game1();
            game.Run();
        }
    }
#endif
}
