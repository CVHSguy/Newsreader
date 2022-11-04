using newsread.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace newsread.ViewModel
{
    class PostWindowModel : Model.Bindable
    {


        public PostWindowModel()
        {
        }


        public ICommand BacktoHubCMD { get; set; } = new DelegateCommand(() => { ((App)App.Current).ChangeControl(typeof(HubView)); });



    }
}
