﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    public class Fork
    {
        public int Id { get; private set; }
        public Fork(int id)
        {
            Id = id;
        }
    }
}
