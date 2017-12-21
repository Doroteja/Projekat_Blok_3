using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient.CommonClasses
{
    public class ModelCodeWrapper
    {
        private ModelCode modelCode;

        public ModelCodeWrapper(ModelCode code)
        {
            this.modelCode = code;
        }

        public ModelCode ModelCode
        {
            get { return modelCode; }
            set { modelCode = value; }
        }
    }
}
