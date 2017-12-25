using FTN.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfClient.Commands;
using WpfClient.CommonClasses;

namespace WpfClient.ViewModel
{
    public class GetRelatedValuesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<DMSType> modelCodes = new List<DMSType>();

        private List<string> ids = new List<string>();

        private List<ModelCode> propertyReferences = new List<ModelCode>();
        private List<ModelCode> propertyReferencesTemp = new List<ModelCode>();


        private ObservableCollection<ModelCodeWrapper> properties = new ObservableCollection<ModelCodeWrapper>();

        public GetRelatedValuesCommand GetRVCommand { get; set; }

        private DMSType chosenDMSType;

        private ModelCode chosenPropertyReference;

        private ModelCode chosenId;

        public List<DMSType> ModelCodes
        {
            get
            {
                return modelCodes;
            }

            set
            {
                modelCodes = value; OnPropertyChanged("ModelCodes");
            }
        }

        public DMSType ChosenDMSType
        {
            get
            {
                return chosenDMSType;
            }

            set
            {
                chosenDMSType = value;
                OnPropertyChanged("ChosenDMSType");
                OnPropertyChanged("Ids");
                OnPropertyChanged("Properties");
                OnPropertyChanged("PropertyReferences");
            }
        }

        public ObservableCollection<ModelCodeWrapper> Properties
        {
            get
            {
                if (chosenDMSType != 0)
                {
                    return FindProperties(chosenDMSType);
                }
                return null;
            }

            set
            {
                properties = value; OnPropertyChanged("Properties");
            }
        }

        public List<string> Ids
        {
            get
            {
                if (chosenDMSType != 0)
                {
                    return FindIds(chosenDMSType);
                }
                return null;
            }

            set
            {
                ids = value; OnPropertyChanged("Ids");
            }
        }

        public ModelCode ChosenId
        {
            get
            {
                return chosenId;
            }

            set
            {
                chosenId = value;
               
            }
        }

        public List<ModelCode> PropertyReferences
        {
            get
            {
                if (chosenDMSType != 0)
                {
                    ModelCode mc;
                    ModelCodeHelper.GetModelCodeFromString(chosenDMSType.ToString(), out mc);
                    propertyReferencesTemp = new List<ModelCode>();
                    FindPropertyReferences(mc);
                    FindParentsReferences(mc);
                    return propertyReferencesTemp;
                }
                return null;
            }

            set
            {
                propertyReferences = value; OnPropertyChanged("PropertyReferences");
            }
        }

        public ModelCode ChosenPropertyReference
        {
            get
            {
                return chosenPropertyReference;
            }

            set
            {
                chosenPropertyReference = value;
            }
        }

        public GetRelatedValuesViewModel()
        {
            FindModelCodes();
            this.GetRVCommand = new GetRelatedValuesCommand();
        }

        private void FindModelCodes()
        {
            modelCodes = Enum.GetValues(typeof(DMSType)).Cast<DMSType>().ToList().FindAll(t => t != DMSType.MASK_TYPE);
        }

        private List<string> FindIds(DMSType chosenDMSType)
        {
            ModelCode mc;
            ModelCodeHelper.GetModelCodeFromString(chosenDMSType.ToString(), out mc);
            List<ModelCode> properties = Connection.Connection.Instance().ModelResourceDesc.GetAllPropertyIds(chosenDMSType);
            List<ResourceDescription> rds = Connection.Connection.Instance().GetExtentValues(mc, properties);

            List<string> ids = new List<string>();
            foreach (ResourceDescription rd in rds)
            {
                ids.Add(String.Format("0x{0:x16}", rd.Id));
            }

            return ids;
        }

        private ObservableCollection<ModelCodeWrapper> FindProperties(DMSType chosenDMSType)
        {
            List<ModelCode> lista = Connection.Connection.Instance().ModelResourceDesc.GetAllPropertyIds(chosenDMSType);
            //List <ModelCode> lista = modelResourcesDesc.GetAllPropertyIds(chosenDMSType);

            ObservableCollection<ModelCodeWrapper> list = new ObservableCollection<ModelCodeWrapper>();

            foreach (var m in lista)
            {
                list.Add(new ModelCodeWrapper(m));
            }
            return list;

        }

        private void FindPropertyReferences(ModelCode chosenType)
        {
            //find direct references
            foreach (ModelCode modelCode in Enum.GetValues(typeof(ModelCode)))
            {
                if ((modelCode.ToString()).StartsWith(String.Format("{0}_", chosenType.ToString())))
                {
                    long lmc = (long)modelCode;
                    string smc = String.Format("0x{0:x16}", lmc);
                    if (smc.EndsWith("9"))
                    {
                        propertyReferencesTemp.Add(modelCode);
                    }
                }
            }
                        
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void FindParentsReferences(ModelCode chosenType)
        {
            ModelCode parent = ModelResourcesDesc.FindFirstParent(chosenType);

            if (parent != 0)
            {
                FindPropertyReferences(parent);

                FindParentsReferences(parent);
            }
        }

    }
}
