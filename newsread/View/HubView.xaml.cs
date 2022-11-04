using newsread.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace newsread.View
{
    /// <summary>
    /// Interaction logic for HubView.xaml
    /// </summary>
    public partial class HubView : UserControl
    {
        SocketSingleton Connection = SocketSingleton.getInstance();
        public HubView()
        {
            DataContext = this;

            InitializeComponent();

        }

        private void ListBoxSelection(object sender, SelectionChangedEventArgs e)
        {
            //ripped from mr marpond
            if (sender is not ListBox listBox)
            {
                return;
            }

            var selecteditem = listBox.SelectedItem + "";
            //pass off the selected item to the singleton
            Connection.setSelectedGroup(selecteditem+"");
        }
    }
}
