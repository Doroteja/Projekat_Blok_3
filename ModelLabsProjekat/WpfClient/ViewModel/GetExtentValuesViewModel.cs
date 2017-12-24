using FTN.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfClient.Commands;
using WpfClient.CommonClasses;

namespace WpfClient.ViewModel
{
    
    public class GetExtentValuesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ModelResourcesDesc modelResourcesDesc = new ModelResourcesDesc();
       
        private List<DMSType> modelCodes = new List<DMSType>();
        private ObservableCollection<ModelCodeWrapper> properties = new ObservableCollection<ModelCodeWrapper>();

        public GetExtentValuesCommand GetEVCommand { get; set; }

        private DMSType chosenDMSType;

        private ObservableCollection<ResourceDescriptionWrapper> resourceDescriptions;

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
                OnPropertyChanged("Properties");
            }
        }

        public ObservableCollection<ModelCodeWrapper> Properties
        {
            get
            {
                if (chosenDMSType != 0)
                {
                  return  FindProperties();
                }
                return null;
            }

            set
            {
                properties = value; OnPropertyChanged("Properties");
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

        

        public GetExtentValuesViewModel()
        {
            ResourceDescriptions = new ObservableCollection<ResourceDescriptionWrapper>();
            FindModelCodes();
            this.GetEVCommand = new GetExtentValuesCommand(this);
        }

        public void FindModelCodes()
        {
            modelCodes = Enum.GetValues(typeof(DMSType)).Cast<DMSType>().ToList().FindAll(t => t != DMSType.MASK_TYPE);
        }

        public ObservableCollection<ModelCodeWrapper> FindProperties()
        {
            
            List<ModelCode> lista = modelResourcesDesc.GetAllPropertyIds(chosenDMSType);

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
