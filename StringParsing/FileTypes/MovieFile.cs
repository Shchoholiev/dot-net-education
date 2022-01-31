using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParsing.FileTypes
{
    public class MovieFile : FileBase
    {
        public MovieFile(string name, string extension, string size, string resoluion, string length)
            : base(name, extension, size)
        {
            Resolution = resoluion;
            Length = length;
        }

        public string Resolution { get; set; }

        public string Length { get; set; }
    }
}
