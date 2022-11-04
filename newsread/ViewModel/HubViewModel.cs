using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace newsread.ViewModel
{
   public partial class HubViewModel : Model.Bindable
    {
        SocketSingleton Connection = SocketSingleton.getInstance();
        private ObservableCollection<string> id = new();
        
        public ObservableCollection<string> ID
        {
            get { return id; }
            set { id = value; this.propertyIsChanged(); }
        }

        public HubViewModel()
        {
            ArticleCMD = new DelegateCommand(ArticleSelection);
            GroupsCMD = new DelegateCommand(GroupSelection);
        }
        public ICommand ArticleCMD { get; set; }
        public ICommand GroupsCMD { get; set; }


        public void ArticleSelection()
        {
            
        }
        public void GroupSelection()
        {
            ID = new ObservableCollection<string>(Connection.listFiller("list")); 
        }
    }
}
