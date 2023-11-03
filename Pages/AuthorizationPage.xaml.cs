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
using DzhafarliOrkhan320P.Pages;

namespace DzhafarliOrkhan320P.Pages
{
    /// <summary>
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            workers user = App.DB.workers.FirstOrDefault(x => x.id.ToString() == loginTB.Text && x.id.ToString() == pwdTB.Password);
            if (user is null)
            {
                MessageBox.Show("Неверный логин и/или пароль (оба должны быть id");
            }
            else
            {
                switch (user.wpos)
                {
                    case "зав. кафедрой":
                        NavigationService.Navigate(new DepartamentsList());
                        break;
                    case "преподаватель":
                        NavigationService.Navigate(new ExamList(user));
                        break;
                    case "инженер":
                        NavigationService.Navigate(new SotrudsList());
                        break;
                    default:
                        break;
                }
                MessageBox.Show($"Вы {user.wpos}!");
            }
        }

        private void guestBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DisciplinesList(null));
        }
    }
}
