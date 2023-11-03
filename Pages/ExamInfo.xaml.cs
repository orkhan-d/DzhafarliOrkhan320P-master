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

namespace DzhafarliOrkhan320P.Pages
{
    /// <summary>
    /// Interaction logic for ExamInfo.xaml
    /// </summary>
    public partial class ExamInfo : Page
    {
        public ExamInfo(int exam_id)
        {
            dateTB.Text= exam_id.ToString();
            discTB.Text= exam_id.ToString();
            InitializeComponent();
        }
    }
}
