﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple
{
    public class Falcon : BirdFlying
    {
        public Falcon(string featherColor) : base(featherColor)
        {
        }

        public override void Fly()
        {
            //flip flap
        }
    }
}
