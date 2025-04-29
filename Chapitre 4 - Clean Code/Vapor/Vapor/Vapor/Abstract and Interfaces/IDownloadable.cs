using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vapor
{
    public interface IDownloadable
    {

        // découper cette interface en 2, download et upload
        void Download();
        void Update();
        void Upload();
    }
}
