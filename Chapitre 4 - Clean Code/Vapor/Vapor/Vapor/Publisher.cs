using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vapor
{
    public class Publisher : ContentCreator
    {
        public bool VerifiedPublisher { get; set; }

        public Publisher(string name) : base(name)
        {
        }
    }
}
