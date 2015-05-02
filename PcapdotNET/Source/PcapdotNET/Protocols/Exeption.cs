using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcapdotNET.Protocols
{
    class Exeption
    {
        public string GetExeptionFromEndOfFile()
        {
            return "Problem with read text!";
        }

        public string GetExeptionFileNotFound()
        {
            return "File not found!";
        }
    }
}
