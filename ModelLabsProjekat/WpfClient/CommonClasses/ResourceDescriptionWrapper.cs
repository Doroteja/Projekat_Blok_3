using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient.CommonClasses
{
    public class ResourceDescriptionWrapper
    {
        private string mc;
        private string value;
        
        public string Mc
        {
            get
            {
                return mc;
            }

            set
            {
                mc = value;
            }
        }

        public string Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public ResourceDescriptionWrapper(string mc, string value)
        {
            this.mc = mc;
            this.value = value;
        }

        public ResourceDescriptionWrapper() { }
    }
}
