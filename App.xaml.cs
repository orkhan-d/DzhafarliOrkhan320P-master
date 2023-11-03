using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DzhafarliOrkhan320P.DB;

namespace DzhafarliOrkhan320P
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static uchebka_orkhanEntities DB = new uchebka_orkhanEntities();
    }
}
