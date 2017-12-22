using FTN.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfClient.CommonClasses;
using WpfClient.ViewModel;

namespace WpfClient.Commands
{
    public class GetExtentValuesCommand : Command
    {
        private GetExtentValuesViewModel vm;

        public GetExtentValuesCommand(GetExtentValuesViewModel vm)
        {
            this.vm = vm;
        }

        public override void Execute(object parameter)
        {
            Object[] parameters = parameter as Object[];
            ModelCode mc;
            ModelCodeHelper.GetModelCodeFromString(parameters[0].ToString(), out mc);

            IList i = (IList)parameters[1];
            var properties = i.Cast<ModelCodeWrapper>();
            List<ModelCode> m = new List<ModelCode>();
            foreach (var item in properties)
            {
                ModelCode mc1;
                ModelCodeHelper.GetModelCodeFromString((item.ModelCode).ToString(), out mc1);
                m.Add(mc1);
            }
            List<long> modelCodes = Connection.Connection.Instance().GetExtentValues(mc, m);

            vm.ModelCodes = modelCodes;
        }
    }
}
