using FTN.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfClient.CommonClasses;
using WpfClient.ViewModel;

namespace WpfClient.Commands
{
    public class GetValuesCommand : Command
    {
        private GetValuesViewModel vm;

        public GetValuesCommand(GetValuesViewModel vm)
        {
            this.vm = vm;
        }

        public override void Execute(object parameter)
        {
            if (parameter == null || !(parameter is Object[]))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            long globalId;
            List<ModelCode> m = new List<ModelCode>();

            try
            {
                Object[] parameters = parameter as Object[];
                globalId = (long)parameters[0];

                IList i = (IList)parameters[1];
                var properties = i.Cast<ModelCodeWrapper>();
               
                foreach (var item in properties)
                {
                    ModelCode mc1;
                    ModelCodeHelper.GetModelCodeFromString((item.ModelCode).ToString(), out mc1);
                    m.Add(mc1);
                }
            }
            catch
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            ObservableCollection<ResourceDescriptionWrapper> ocRd = new ObservableCollection<ResourceDescriptionWrapper>();
            try
            {
                ResourceDescription rd = Connection.Connection.Instance().GetValues(globalId, m);
                
                var modelCodeString = ((DMSType)ModelCodeHelper.ExtractTypeFromGlobalId(rd.Id)).ToString();

                ModelCode modelCode;
                ModelCodeHelper.GetModelCodeFromString(modelCodeString, out modelCode);
                string temp = String.Format("0x{0:x16}", (rd.Id));
                ResourceDescriptionWrapper rdw = new ResourceDescriptionWrapper(modelCodeString, temp);
                ocRd.Add(rdw);

                foreach (var prop in rd.Properties)
                {
                    ResourceDescriptionWrapper rdw1 = new ResourceDescriptionWrapper((prop.Id).ToString(), prop.ToString());
                    ocRd.Add(rdw1);
                }

            }
            catch
            {
                MessageBox.Show("Service host is not started.");
            }

            vm.ResourceDescription = ocRd;
        }
    }
}
