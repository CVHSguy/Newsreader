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
        private ObservableCollection<string> SaveGrp = new();
        public ObservableCollection<string> ID
        {
            get { return id; }
            set { id = value; this.propertyIsChanged(); }
        } 
        public ObservableCollection<string> SavedOrFavoriteGrps
        {
            get { return SaveGrp; }
            set { SaveGrp = value; this.propertyIsChanged(); }
        }


        private string SelectedItem = "";
        public string selected
        {
            get { return SelectedItem; }
            set
            {
                SelectedItem = value;
                this.propertyIsChanged();
                
            }
        }

        public HubViewModel()
        {
            ArticleCMD = new DelegateCommand(ArticleSelection);
            GroupsCMD = new DelegateCommand(GroupSelection);
        }
        public ICommand ArticleCMD { get; set; }
        public ICommand GroupsCMD { get; set; }
        public ICommand SubscribeCMD { get; set; }

        public void ArticleSelection()
        {
            var test = "";
            test = this.SelectedItem;
            Console.WriteLine("another test: "+test);
            Console.WriteLine("the selected list item: " + this.selected);
            Console.WriteLine("the selected list item: " + this.SelectedItem);
        }
        public void GroupSelection()
        {
            ID.Clear();
            Console.WriteLine(ID.Count);
  
            if (ID.Count == 0)
            {
                ID = new ObservableCollection<string>(Connection.listFiller("list"));
            }
            Console.WriteLine(ID.Count);


        } 
        public void Subscribe()
        {
            string
            SaveGrp = new ObservableCollection<string>(Connection.listFiller(""))


        }
    }
}
