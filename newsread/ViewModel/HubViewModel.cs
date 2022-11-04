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
        private ObservableCollection<string> Articles = new();
        private ObservableCollection<string> Articleinfo = new();
        private ObservableCollection<string> searchFilter = new();
        public string Searchbar { get; set; }
        public ObservableCollection<string> ID
        {
            get { return id; }
            set { id = value; this.propertyIsChanged(); }
        } 
        public ObservableCollection<string> savedOrFavoriteGrps
        {
            get { return SaveGrp; }
            set { SaveGrp = value; this.propertyIsChanged(); }
        }
        public ObservableCollection<string> listArticles
        {
            get { return Articles; }
            set { Articles = value; this.propertyIsChanged(); }
        }
        
        public ObservableCollection<string> ArticleInfo
        {
            get { return Articleinfo; }
            set { Articleinfo = value; this.propertyIsChanged(); }
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
        public ObservableCollection<string> Search
        {
            get { return searchFilter; }
            set
            {
                
                searchFilter = value;
                this.propertyIsChanged();
                
            }
        }

        public HubViewModel()
        {
            ArticleCMD = new DelegateCommand(ArticleSelection);
            GroupsCMD = new DelegateCommand(GroupSelection);
            SubscribeCMD = new DelegateCommand(Subscribe);
            ReadCMD = new DelegateCommand(Read);
            SearchCMD = new DelegateCommand(SearchbyText);
            ResetSearchCMD = new DelegateCommand(GroupSelection);

            if (ID.Count == 0)
            {
                ID = new ObservableCollection<string>(Connection.listFiller("list"));
            }
        }
        public ICommand ArticleCMD { get; set; }
        public ICommand GroupsCMD { get; set; }
        public ICommand SubscribeCMD { get; set; }
        public ICommand ReadCMD { get; set; }
        public ICommand SearchCMD { get; set; }
        public ICommand ResetSearchCMD { get; set; }
        public ICommand PostCMD { get; set; }

        public void ArticleSelection()
        {
            Console.WriteLine("yo "+Searchbar);
            string temp = Connection.getSelectedGroup();
            Console.WriteLine($"listgroup {temp}");
            listArticles = new ObservableCollection<string>(Connection.listFiller($"listgroup {temp}"));
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
            Console.WriteLine(Connection.getSelectedGroup());
            string temp = Connection.getSelectedGroup();
            Console.WriteLine(temp);
            //  SavedOrFavoriteGrps = new ObservableCollection<string>(Connection.getSelectedGroup());
            savedOrFavoriteGrps.Add(temp);

        }
        public void Read()
        {
            string temp = Connection.getSelectedArticle();
            Console.WriteLine($"listgroup {temp}");
            ArticleInfo = new ObservableCollection<string>(Connection.listFiller($"article {temp}"));
        }
        public void SearchbyText()
        {
            ID = new ObservableCollection<string>(ID.Where(x => x.Contains(Searchbar)));

        }
    }
}
