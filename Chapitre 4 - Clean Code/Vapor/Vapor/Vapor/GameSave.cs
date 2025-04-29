using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vapor
{
    public class GameSave : IDownloadable
    {
        public void Download()
        {
            Console.WriteLine("Downloading your save from the cloud");
        }

        public void Update()
        {
            Console.WriteLine("Update your save from the cloud");
        }

        public void Upload()
        {
            Console.WriteLine("Uploading your save into the cloud");
        }
    }
}
