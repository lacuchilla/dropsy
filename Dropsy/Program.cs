﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dropsy
{
    public class Program
    {

        static void Main(string[] args)
        {
            var game = new Game(9);
            game.Play(25);
        }
    }
}
