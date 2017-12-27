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
    public class GetRelatedValuesCommand : Command
    {
        private GetRelatedValuesViewModel vm;


        public GetRelatedValuesCommand(GetRelatedValuesViewModel vm)
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

            ModelCode sourceModelCode;
            long sourceGid;
            ModelCode referenceModelCode;
            ModelCode childrenModelCode;
            List<ModelCode> m = new List<ModelCode>(); //propeetiji

            try
            {
                Object[] parameters = parameter as Object[];

                ModelCodeHelper.GetModelCodeFromString(parameters[0].ToString(), out sourceModelCode);

                sourceGid = (long)(parameters[1]);

                ModelCodeHelper.GetModelCodeFromString(parameters[2].ToString(), out referenceModelCode);

                ModelCodeHelper.GetModelCodeFromString(parameters[3].ToString(), out childrenModelCode);

                IList i = (IList)parameters[4];
                var properties = i.Cast<ModelCodeWrapper>();

                foreach (var item in properties)
                {
                    ModelCode mc1;
                    ModelCodeHelper.GetModelCodeFromString((item.ModelCode).ToString(), out mc1);
                    m.Add(mc1);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            Association association = new Association();
            association.PropertyId = referenceModelCode;
            association.Type = childrenModelCode;

            List<ResourceDescription> retVal = new List<ResourceDescription>();
            ObservableCollection<ResourceDescriptionWrapper> ocRd = new ObservableCollection<ResourceDescriptionWrapper>();
            try
            {
                retVal = Connection.Connection.Instance().GetRelatedValues(sourceGid, m, association);
                 //ocRd = new ObservableCollection<ResourceDescriptionWrapper>();

                foreach (var item in retVal)
                {
                    var modelCodeString = ((DMSType)ModelCodeHelper.ExtractTypeFromGlobalId(item.Id)).ToString();

                    ModelCode modelCode;
                    ModelCodeHelper.GetModelCodeFromString(modelCodeString, out modelCode);
                    string temp = String.Format("0x{0:x16}", (item.Id));
                    ResourceDescriptionWrapper rdw = new ResourceDescriptionWrapper(modelCodeString, temp);
                    ocRd.Add(rdw);

                    foreach (var prop in item.Properties)
                    {
                        string s = prop.ToString();
                        ResourceDescriptionWrapper rdw1 = new ResourceDescriptionWrapper((prop.Id).ToString(), s);
                        ocRd.Add(rdw1);
                    }
                    ResourceDescriptionWrapper empty = new ResourceDescriptionWrapper();
                    ocRd.Add(empty);
                }
                
            }
            catch
            {
                MessageBox.Show("Service host is not started.");
            }

            vm.ResourceDescriptions = ocRd;
        }
    }
}
