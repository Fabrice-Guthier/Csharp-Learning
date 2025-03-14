using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tp_POO_Genericite_1902
{
    class ListFifo<T>: MainList<T>
    {
        const int INDEX_ACCESSIBLE = 0;//constante pour l'index du premier element de la liste
        public override T Get()
        {
            return elements[INDEX_ACCESSIBLE];//on retourne le premier element de la liste
        }
        public override void Remove()
        {
            elements.RemoveAt(INDEX_ACCESSIBLE);//on supprime le premier element de la liste
        }
        public override T GetAndRemove()
        {
            element = Get();//on stocke l'element à retourner via la méthode Get

            Remove();//on supprime l'element de la liste via la méthode Remove

            return element;//on retourne l'element
        }

        
    }
}
