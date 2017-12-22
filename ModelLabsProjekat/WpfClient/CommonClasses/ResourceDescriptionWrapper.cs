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
        private ModelCode mc;
        private string value;
        
        public ModelCode Mc
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

        public ResourceDescriptionWrapper(ModelCode mc, string value)
        {
            this.mc = mc;
            this.value = value;
        }

        public ResourceDescriptionWrapper() { }
    }
}
