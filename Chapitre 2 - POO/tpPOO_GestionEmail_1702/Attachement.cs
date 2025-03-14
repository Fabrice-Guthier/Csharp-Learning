using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpPOO_GestionEmail_1702
{
    public class Attachement
    {
        public string Name { get; set; }
        public byte[] Content { get; set; } // Contenu en tableau d'octets
        public int Size { get; set; }
        public AttachementType AttachementType { get; set; }

        public Attachement(string name, byte[] content, int size, AttachementType attachementType)
        {
            Name = name;
            Content = content;
            Size = size;
            AttachementType = attachementType;
        }
    }
}