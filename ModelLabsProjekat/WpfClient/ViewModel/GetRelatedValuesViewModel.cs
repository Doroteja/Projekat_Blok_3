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

        private List<long> ids = new List<long>();

        private List<ModelCode> propertyReferences = new List<ModelCode>();
        private List<ModelCode> propertyReferencesTemp = new List<ModelCode>();
        private List<ModelCode> childrenType = new List<ModelCode>();

        private ObservableCollection<ModelCodeWrapper> properties = new ObservableCollection<ModelCodeWrapper>();

        public GetRelatedValuesCommand GetRVCommand { get; set; }
        private ObservableCollection<ResourceDescriptionWrapper> resourceDescriptions;

        private DMSType chosenDMSType;

        private ModelCode chosenPropertyReference;

        private ModelCode chosenId;
        private ModelCode chosenChildrenType;

        public List<DMSType> ModelCodes
        {
            get { return modelCodes; }
            set { modelCodes = value; OnPropertyChanged("ModelCodes"); }
        }

        public DMSType ChosenDMSType
        {
            get { return chosenDMSType; }
            set
            {
                chosenDMSType = value;
                OnPropertyChanged("ChosenDMSType");

                OnPropertyChanged("Ids");
                OnPropertyChanged("PropertyReferences");
            }
        }

        public ObservableCollection<ModelCodeWrapper> Properties
        {
            get
            {
                if (chosenChildrenType != 0)
                {
                    DMSType dmsType = ModelCodeHelper.GetTypeFromModelCode(chosenChildrenType);
                    return FindProperties(dmsType);
                }
                return null;
            }

            set
            {
                properties = value; OnPropertyChanged("Properties"); 
            }
        }

        public List<long> Ids
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
            get { return chosenId; }
            set { chosenId = value;  }
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
                OnPropertyChanged("ChosenPropertyReference");

                FindPropertyModelCode(chosenPropertyReference);
                OnPropertyChanged("Properties");
                OnPropertyChanged("ChildrenType");
            }
        }

        public List<ModelCode> ChildrenType
        {
            get
            {
                return childrenType;
            }

            set
            {
                childrenType = value; OnPropertyChanged("ChildrenType"); 
            }
        }

        public ModelCode ChosenChildrenType
        {
            get
            {
                return chosenChildrenType;
            }

            set
            {
                chosenChildrenType = value; OnPropertyChanged("ChosenChildrenType"); OnPropertyChanged("Properties");
            }
        }

        public ObservableCollection<ResourceDescriptionWrapper> ResourceDescriptions
        {
            get
            {
                return resourceDescriptions;
            }

            set
            {
                resourceDescriptions = value;
                OnPropertyChanged("ResourceDescriptions");
            }
        }

        public GetRelatedValuesViewModel()
        {
            FindModelCodes();
            this.GetRVCommand = new GetRelatedValuesCommand(this);
        }

        private void FindModelCodes()
        {
            modelCodes = Enum.GetValues(typeof(DMSType)).Cast<DMSType>().ToList().FindAll(t => t != DMSType.MASK_TYPE);
        }

        private List<long> FindIds(DMSType chosenDMSType)
        {
            ModelCode mc;
            ModelCodeHelper.GetModelCodeFromString(chosenDMSType.ToString(), out mc);
            List<ModelCode> properties = Connection.Connection.Instance().ModelResourceDesc.GetAllPropertyIds(chosenDMSType);
            List<ResourceDescription> rds = Connection.Connection.Instance().GetExtentValues(mc, properties);

            List<long> ids = new List<long>();
            foreach (ResourceDescription rd in rds)
            {
                ids.Add(rd.Id);
            }

            return ids;
        }

        private ObservableCollection<ModelCodeWrapper> FindProperties(DMSType chosenDMSType)
        {
            List<ModelCode> lista = Connection.Connection.Instance().ModelResourceDesc.GetAllPropertyIds(chosenDMSType);
        
            ObservableCollection<ModelCodeWrapper> list = new ObservableCollection<ModelCodeWrapper>();

            foreach (var m in lista)
            {
                list.Add(new ModelCodeWrapper(m));
            }
            return list;

        }

        private void FindPropertyReferences(ModelCode chosenType)
        {
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
        
        private void FindParentsReferences(ModelCode chosenType)
        {
            ModelCode parent = ModelResourcesDesc.FindFirstParent(chosenType);

            if (parent != 0)
            {
                FindPropertyReferences(parent);

                FindParentsReferences(parent);
            }
        }

        private void FindPropertyModelCode(ModelCode property)
        {
            string[] props = (property.ToString()).Split('_');

            props[1] = props[1].TrimEnd('S');
            DMSType propertyCode = ModelResourcesDesc.GetTypeFromModelCode(property);
            // DMSType propertyCode = ModelCodeHelper.GetDMSTypeFromString(property);

            ModelCode mc;
            ModelCodeHelper.GetModelCodeFromString(propertyCode.ToString(), out mc);

            foreach (ModelCode modelCode in Enum.GetValues(typeof(ModelCode)))
            {

                if ((String.Compare(modelCode.ToString(), mc.ToString()) != 0) && (String.Compare(property.ToString(), modelCode.ToString()) != 0) && (String.Compare(props[1] , modelCode.ToString())) == 0)
                {
                    DMSType type = ModelCodeHelper.GetTypeFromModelCode(modelCode);
                    if (type == 0)
                    {
                        FindChildren(modelCode);
                    }
                    else
                    {
                        childrenType = new List<ModelCode>();
                        childrenType.Add(modelCode);
                    }

                }
            }
        }

        private void FindChildren(ModelCode modelCode)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("0x");
            List<ModelCode> retCodes = new List<ModelCode>();

            long lmc = (long)modelCode;
            string smc = String.Format("0x{0:x16}", lmc);

            string[] newS = smc.Split('x');
            char[] c = (newS[1]).ToCharArray();

           
            foreach (char ch in c)
            {
               if (ch != '0')
                {
                    sb.Append(ch);
                }
               else
                {
                    break;
                }

            }

            foreach(ModelCode mc in Enum.GetValues(typeof(ModelCode)))
            {
                DMSType type = ModelCodeHelper.GetTypeFromModelCode(mc);
                short sh = (short)mc;
                if ((modelCode != mc) && (sh == 0) && (type != 0))
                {
                    lmc = (long)mc;
                    smc = String.Format("0x{0:x16}", lmc);
                    if (smc.StartsWith(sb.ToString()))
                    {
                        retCodes.Add(mc);

                    }
                }
            }

            childrenType = retCodes;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
