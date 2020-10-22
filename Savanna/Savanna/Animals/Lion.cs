﻿using Savanna;
using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna.Savanna.Animals
{
    public class Lion : Hunters
    {
        public Lion(Playground playground):base(playground)
        {
            maximumHealth = 20;
            Health = maximumHealth;
            VisionRange = 6;
        }
    }
}
