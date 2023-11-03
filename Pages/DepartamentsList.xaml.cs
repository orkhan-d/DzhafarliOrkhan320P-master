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
    /// Interaction logic for DepartamentsList.xaml
    /// </summary>
    public partial class DepartamentsList : Page
    {
        public DepartamentsList(bool can_edit)
        {

            InitializeComponent();
            DepsLW.ItemsSource = App.DB.kafedras.ToList();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DepsLW_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var kaf = (kafedras)DepsLW.SelectedItem;
            MessageBox.Show(kaf.code);


            //MessageBox.Show("double click!");
        }
    }
}
