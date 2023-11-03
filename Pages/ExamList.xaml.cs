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
    /// Interaction logic for ExamList.xaml
    /// </summary>
    public partial class ExamList : Page
    {
        public static workers worker;
        public ExamList(workers w)
        {
            InitializeComponent();
            worker = w;
        }
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                //NavigationService.Navigate(new Pages.ExamInfo(sender.exam_id));
            }
        }
    }
}
