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
    /// Interaction logic for SotrudInfo.xaml
    /// </summary>
    public partial class SotrudInfo : Page
    {
        public static workers ww;
        public SotrudInfo(workers w)
        {
            ww = w;
            InitializeComponent();
            if(w is null)
            {
                surnameTB.Text = "";
                salaryTB.Text = "";
            }
            else
            {
                surnameTB.Text = w.fio;
                salaryTB.Text = w.salary.ToString();
                kafCB.SelectedItem = w.kafedra_code;
                posCB.SelectedItem = w.wpos;
            }
            kafCB.ItemsSource = App.DB.kafedras.toList().Select(x => x.code);
            posCB.ItemsSource = App.DB.workers.GroupBy(x => x.wpos).toList(x => x.Key);
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(tabInTB.Text.Length<1 || surnameTB.Text.Length<1 || kafCB.SelectedIndex<0 || posCB.SelectedIndex<0 || salaryTB.Text.Length < 1)
            {
                MessageBox.Show("Неверно введены данные!");
            }
            else
            {
                if (ww is null)
                {
                    App.DB.workers.Add(new workers
                    {
                        id=Convert.ToInt32(tabInTB.Text),
                        fio=surnameTB.Text,
                        kafedra_code=kafCB.Text,
                        wpos=posCB.Text,
                        salary=Convert.ToInt32(salaryTB.Text),

                    });
                }
                else
                {
                    ww.fio = surnameTB.Text;
                    ww.kafedra_code = kafCB.Text;
                    ww.wpos = posCB.Text;
                    ww.salary = Convert.ToInt32(salaryTB.Text);
                }
                App.DB.SaveChanges();
                NavigationService.Navigate(new SotrudsList());
            }
        }
    }
}
