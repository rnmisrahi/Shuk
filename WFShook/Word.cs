using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WFShook
{
    public class Word
    {
        const string EXT = ".png";
        private string PATH = Directory.GetCurrentDirectory() + @"\images\";

        private string _definition;
        public string Definition {
            get { return _definition; }
            set { _definition = value; }
        }

        private string _path;
        public string Path {
            get
            {
                if (string.IsNullOrEmpty(_path))
                    return PATH + _definition + ".png";
                return _path;
            }
            set { _path = value; }
        }

        private string _name;
        public string Name {
            get {
                if (string.IsNullOrEmpty(_name))
                    return _definition.ToUpper();
                return _name;

            }
            set { _name = value; }
        }

    }
}
