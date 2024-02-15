using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace RPGAlpha_AdrianDorey
{
    internal class Program
    {
        static GameManager gameManager = new GameManager();

        static void Main(string[] args)
        {
            gameManager.Gameplay();
        }
    }
}
