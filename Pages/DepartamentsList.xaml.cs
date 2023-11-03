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
        public DepartamentsList()
        {

            InitializeComponent();
            DepsLW.ItemsSource = App.DB.kafedras.ToList();
            facultsCB.ItemsSource = App.DB.facults.Select(
                (x) => x.abbr
            ).ToList();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in DepsLW.SelectedItems)
            {
                kafedras kaf = (kafedras)item;
                App.DB.kafedras.Remove(kaf);
            }
            App.DB.SaveChanges();
            MessageBox.Show("Готово!");
            DepsLW.ItemsSource = App.DB.kafedras.ToList();
        }

        private void DepsLW_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var kaf = (kafedras)DepsLW.SelectedItem;
            NavigationService.Navigate(new DisciplinesList(kaf));
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DepsLW.SelectedItems.Count >= 1)
            {
                if (DepsLW.SelectedItems.Count > 1)
                {
                    MessageBox.Show("Выберите только 1 строку для изменения!");
                }
                else
                {
                    if (depTB.Text.Length < 1 || facultsCB.SelectedIndex < 0)
                        MessageBox.Show("Заполните все поля!");
                    else
                    {
                        kafedras kaf = ((kafedras)DepsLW.SelectedItem);
                        kaf = App.DB.kafedras.Where(x => x.code == kaf.code).First();
                        kaf.kname = depTB.Text;
                        kaf.facult_abbr = facultsCB.Text;
                        App.DB.SaveChanges();
                        MessageBox.Show("Готово!");
                        DepsLW.ItemsSource = App.DB.kafedras.ToList();
                    }
                }
            }
            else
            {
                if (depTB.Text.Length < 1 || facultsCB.SelectedIndex < 0)
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    App.DB.kafedras.Add(new kafedras
                    {
                        code = depTB.Text.Substring(0, 2),
                        kname = depTB.Text,
                        facult_abbr = facultsCB.Text
                    });
                    App.DB.SaveChanges();
                    MessageBox.Show("Готово!");
                    DepsLW.ItemsSource = App.DB.kafedras.ToList();
                }
            }
        }
    }
}
