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
    /// Interaction logic for ExamInfo.xaml
    /// </summary>
    public partial class ExamInfo : Page
    {
        public static exams exam;
        public ExamInfo(exams ex)
        {
            exam = ex;
            InitializeComponent();

            dateTB.Text = exam.date.ToString();
            discTB.Text = App.DB.disciplines.FirstOrDefault(x => x.code == exam.code).dname;

            var studs = App.DB.exams.Where(x => x.date == exam.date && x.code == exam.code).Select(x => x.students).ToList();
            studentsLW.ItemsSource = studs;
            studsCB.ItemsSource = App.DB.students.Select(x => new { id=x.id, fio=x.fio}).ToList().Select(x => $"{x.id}/{x.fio}");
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (studsCB.SelectedIndex < 0)
                MessageBox.Show("Выберите студента");
            else
            {
                int sstud_id = Convert.ToInt32(studsCB.Text.Split('/').First());
                App.DB.exams.Add(new exams
                {
                    date=exam.date,
                    cabinet=exam.cabinet,
                    teacher_id=exam.teacher_id,
                    code=exam.code,
                    stud_id=sstud_id,
                    score=null
                });
                App.DB.SaveChanges();
                var studs = App.DB.exams.Where(x => x.date == exam.date && x.code == exam.code).Select(x => x.students).ToList();
                studentsLW.ItemsSource = studs;
                MessageBox.Show("Готово!");
            }
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach(students stud in studentsLW.SelectedItems)
            {
                exams row = App.DB.exams.Where(x => x.date == exam.date && x.code == exam.code && x.stud_id == stud.id).FirstOrDefault();
                App.DB.exams.Remove(row);
                App.DB.SaveChanges();

                var studs = App.DB.exams.Where(x => x.date == exam.date && x.code == exam.code).Select(x => x.students).ToList();
                studentsLW.ItemsSource = studs;
                MessageBox.Show("Готово!");
            }
        }
    }
}
