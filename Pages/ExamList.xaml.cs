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
        //public static Exam[] exams = { };
        public ExamList(workers w)
        {
            InitializeComponent();
            worker = w;
            var dates = App.DB.exams.Where(x => x.teacher_id == w.id).GroupBy(y => y.date).Select(x => new
            {
                id=x.FirstOrDefault().id,
                date = x.Key,
                discipline = App.DB.disciplines.FirstOrDefault(z => z.code == x.FirstOrDefault().code).dname
            }
            );

            /*foreach (var date in dates)
            {
                foreach (var exam in date)
                {
                    Exam ex = new Exam(App.DB.disciplines.FirstOrDefault(x => x.code == exam.code).dname, date.Key.Value);
                    exams.Add(ex);
                    //examsLW.Items.Add(ex);
                    break;
                }
            }*/
            //examsLW.ItemsSource = exams;
            examsLW.ItemsSource = dates.ToList();
        }

        private void examsLW_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var obj = examsLW.SelectedItem;
            int id = Convert.ToInt32(obj.GetType().GetProperties().First(o => o.Name == "id").GetValue(obj, null));
            var exam = App.DB.exams.FirstOrDefault(x => x.id == id);
            NavigationService.Navigate(new ExamInfo(exam));
        }
    }
}
