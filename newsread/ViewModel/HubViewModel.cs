using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace newsread.ViewModel
{
     class HubViewModel : Model.Bindable
    {
        private string id = "Hub";

        public string ID
        {
            get { return id; }
            set { id = value; this.propertyIsChanged(); }
        }

        public HubViewModel()
        {

        }
        
    


    }
}
