using System;
using System.Collections.Generic;
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
using DzhafarliOrkhan320P.DB;

namespace DzhafarliOrkhan320P.Pages
{
    /// <summary>
    /// Логика взаимодействия для SotrudsList.xaml
    /// </summary>
    public partial class SotrudsList : Page
    {
        public SotrudsList()
        {
            InitializeComponent();
            DiscsLW.ItemsSource = App.DB.workers.ToList();
        }

        private void DiscsLW_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            workers disc = (workers)DiscsLW.SelectedItems;
            NavigationService.Navigate(new SotrudInfo());
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in DiscsLW.SelectedItems)
            {
                workers disc = (workers)item;
                App.DB.workers.Remove(disc);
            }
            App.DB.SaveChanges();
            MessageBox.Show("Готово!");
            DiscsLW.ItemsSource = App.DB.workers.ToList();
        }
    }
}
