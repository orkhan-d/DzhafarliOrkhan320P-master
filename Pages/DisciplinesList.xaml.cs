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
    /// Логика взаимодействия для DisciplinesList.xaml
    /// </summary>
    public partial class DisciplinesList : Page
    {
        static kafedras kaf;
        public DisciplinesList(kafedras k)
        {
            InitializeComponent();
            if(k is null)
            {
                DiscsLW.ItemsSource = App.DB.disciplines.ToList();
                depNameTB.Visibility = Visibility.Hidden;
                addBtn.Visibility = Visibility.Hidden;
                delBtn.Visibility = Visibility.Hidden;
                discTB.Visibility = Visibility.Hidden;
                hoursTB.Visibility = Visibility.Hidden;
                return;
            }
            kaf = k;
            depNameTB.Text = k.kname;
            DiscsLW.ItemsSource = App.DB.disciplines.Where(x => x.kafedra_code == k.code).ToList();
            discTB.Text = "Название дисциплины";
            hoursTB.Text = "Часы";
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in DiscsLW.SelectedItems)
            {
                disciplines disc = (disciplines)item;
                App.DB.disciplines.Remove(disc);
            }
            App.DB.SaveChanges();
            MessageBox.Show("Готово!");
            DiscsLW.ItemsSource = App.DB.disciplines.Where(x => x.kafedra_code == kaf.code).ToList();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            int hours;
            if (DiscsLW.SelectedItems.Count >= 1)
            {
                if (DiscsLW.SelectedItems.Count > 1)
                {
                    MessageBox.Show("Выберите только 1 строку для изменения!");
                }
                else
                {
                    if (discTB.Text.Length < 1 || hoursTB.Text.Length < 1 || !int.TryParse(hoursTB.Text, out hours))
                        MessageBox.Show("Заполните все поля верно!");
                    else
                    {
                        disciplines ds = ((disciplines)DiscsLW.SelectedItem);
                        ds = App.DB.disciplines.Where(x => x.code == ds.code).First();
                        ds.dname = discTB.Text;
                        ds.hours = hours;
                        App.DB.SaveChanges();
                        MessageBox.Show("Готово!");
                        DiscsLW.ItemsSource = App.DB.disciplines.Where(x => x.kafedra_code == kaf.code).ToList();
                    }
                }
            }
            else
            {
                if (discTB.Text.Length < 1 || hoursTB.Text.Length < 1 || !int.TryParse(hoursTB.Text, out hours))
                    MessageBox.Show("Заполните все поля верно!");
                else
                {
                    App.DB.disciplines.Add(new disciplines
                    {
                        dname = discTB.Text,
                        kafedra_code = kaf.code,
                        hours = hours
                    });
                    App.DB.SaveChanges();
                    MessageBox.Show("Готово!");
                    DiscsLW.ItemsSource = App.DB.disciplines.Where(x => x.kafedra_code == kaf.code).ToList();

                }
            }
        }
    }
}
