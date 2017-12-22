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

        private List<DMSType> modelCode = new List<DMSType>();

        private ObservableCollection<ModelCodeWrapper> properties = new ObservableCollection<ModelCodeWrapper>();

        public GetValuesCommand GetVcommand { get; set; }

        private DMSType chosenDMSType;
        
        public List<DMSType> ModelCode
        {
            get { return modelCode; }
            set { modelCode = value; OnPropertyChanged("ModelCode"); }
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
                    return FindProperties();
                }
                return null;
            }

            set
            {
                properties = value; OnPropertyChanged("Properties");
            }
        }

        public GetValuesViewModel()
        {
            FindModelCodes();
            
            //this.GetEVcommand = new GetExtentValuesCommand(this);
        }

        public void FindModelCodes()
        {
            modelCode = Enum.GetValues(typeof(DMSType)).Cast<DMSType>().ToList().FindAll(t => t != DMSType.MASK_TYPE);
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
