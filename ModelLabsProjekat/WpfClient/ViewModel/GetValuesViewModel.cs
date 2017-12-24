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
    public class GetValuesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ModelResourcesDesc modelResourcesDesc = new ModelResourcesDesc();

        private List<DMSType> modelCodes = new List<DMSType>();

        private List<long> ids = new List<long>();

        private ObservableCollection<ModelCodeWrapper> properties = new ObservableCollection<ModelCodeWrapper>();

        public GetValuesCommand GetVCommand { get; set; }

        private DMSType chosenDMSType;

        private ModelCode chosenId;

        private ObservableCollection<ResourceDescriptionWrapper> resourceDescription;

        public List<DMSType> ModelCodes
        {
            get { return modelCodes; }
            set { modelCodes = value; OnPropertyChanged("ModelCodes"); }
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
            get
            {
                return chosenId;
            }

            set
            {
                chosenId = value;
            }
        }

        public ObservableCollection<ResourceDescriptionWrapper> ResourceDescription
        {
            get
            {
                return resourceDescription;
            }

            set
            {
                resourceDescription = value; OnPropertyChanged("ResourceDescription");
            }
        }

        public GetValuesViewModel()
        {
            FindModelCodes();
            
            this.GetVCommand = new GetValuesCommand(this);
        }

        public void FindModelCodes()
        {
            modelCodes = Enum.GetValues(typeof(DMSType)).Cast<DMSType>().ToList().FindAll(t => t != DMSType.MASK_TYPE);
        }

        public List<long> FindIds(DMSType chosenDMSType)
        {
            ModelCode mc;
            ModelCodeHelper.GetModelCodeFromString(chosenDMSType.ToString(), out mc);
            List<ModelCode> properties = Connection.Connection.Instance().ModelResourceDesc.GetAllPropertyIds(chosenDMSType);
            List <ResourceDescription> rds = Connection.Connection.Instance().GetExtentValues(mc, properties);

            List<long> ids = new List<long>();
            foreach (ResourceDescription rd in rds)
            {
                ids.Add(rd.Id);
            }

            return ids;
        }

        public ObservableCollection<ModelCodeWrapper> FindProperties(DMSType chosenDMSType)
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
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
