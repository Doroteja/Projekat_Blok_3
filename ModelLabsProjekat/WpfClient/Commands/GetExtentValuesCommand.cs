using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfClient.ViewModel;

namespace WpfClient.Commands
{
    public class GetExtentValuesCommand : Command
    {
        GetExtentValuesViewModel vm;

        public GetExtentValuesCommand(GetExtentValuesViewModel vm)
        {
            this.vm = new GetExtentValuesViewModel();
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
