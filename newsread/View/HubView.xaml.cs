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
            Connection.setSelectedGroup(selecteditem + "");
        }

        private void Savedgrp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is not ListBox listBox)
            {
                return;
            }

            var selecteditem = listBox.SelectedItem + "";
            Console.WriteLine(selecteditem + "");
            //pass off the selected item to the singleton
            Connection.setSelectedGroup(selecteditem + "");
            ListBox.SelectedIndex = -1;
            //ListBox.IsEnabled = false;
            ListBox.Visibility = Visibility.Collapsed;
            ArticleBox.Visibility = Visibility.Visible;
            Console.WriteLine(Connection.getSelectedGroup());

        }
        private void ArticleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is not ListBox listBox)
            {
                return;
            }

            var selecteditem = listBox.SelectedItem + "";
            Connection.setSelectedArticle(selecteditem + "");
            Console.WriteLine(selecteditem + "");
            Console.WriteLine(Connection.getSelectedArticle());
        }

        private void Sort_by_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = Sort_by.SelectedItem as ComboBoxItem;
            if (item?.Content+"" == "Sort by group")
            {
                if (ListBox.Visibility == Visibility.Collapsed)
                {
                    ListBox.Visibility = Visibility.Visible;
                    ArticleBox.Visibility = Visibility.Collapsed;
                }
            }else if(item?.Content+"" == "Sort by article")
            {
                if (ListBox.Visibility == Visibility.Visible)
                {
                    ListBox.Visibility = Visibility.Collapsed;
                    ArticleBox.Visibility = Visibility.Visible;
                }
            }


        }
    }
}
