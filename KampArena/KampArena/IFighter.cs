using System;
using System.Collections.Generic;
using System.Text;

namespace KampArena
{
    interface IFighter
    {
        //Denne property skal angive hvor mange forsvarspoint den
        // pågældende fighter har tilbage
        int DefenseLeft { get; }
        //Denne metode kaldes når fighteren skal forsvare sig
        void Defend(int attack);
        //return true hvis fighteren stikker af
        bool HasEscaped();
        //Denne metode kaldes når fighteren skal angribe
        //og returnere e
        int Attack();
    }
}
