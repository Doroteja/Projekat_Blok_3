using FTN.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            List<ResourceDescription> rds = Connection.Connection.Instance().GetExtentValues(mc, m);

            ObservableCollection<ResourceDescriptionWrapper> ocRd = new ObservableCollection<ResourceDescriptionWrapper>();
            
            foreach (var item in rds)
            {
                var modelCodeString = ((DMSType)ModelCodeHelper.ExtractTypeFromGlobalId(item.Id)).ToString();

                ModelCode modelCode;
                ModelCodeHelper.GetModelCodeFromString(modelCodeString, out modelCode);
                ResourceDescriptionWrapper rdw = new ResourceDescriptionWrapper(modelCode, (item.Id).ToString());
                ocRd.Add(rdw);

                foreach (var prop in item.Properties)
                {
                    string s = prop.ToString();
                    ResourceDescriptionWrapper rdw1 = new ResourceDescriptionWrapper(prop.Id, s);
                    ocRd.Add(rdw1);
                }
                ResourceDescriptionWrapper empty = new ResourceDescriptionWrapper();
                ocRd.Add(empty);
            }
            vm.ResourceDescriptions = ocRd;
        }
    }
}
