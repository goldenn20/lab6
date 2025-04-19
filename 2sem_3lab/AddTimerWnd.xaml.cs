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
using System.Windows.Shapes;

namespace _2sem_3lab
{
    /// <summary>
    /// Логика взаимодействия для AddTimerWnd.xaml
    /// </summary>
    public partial class AddTimerWnd : Window
    {

        DateTime time = DateTime.Now;
        public static string timer_name = "";
        public AddTimerWnd()
        {
            InitializeComponent();
            
        }

        private void btn_Add_Timer_Click(object sender, RoutedEventArgs e)
        {
            time = Timer_Calendar.SelectedDate.Value;
            time = time.AddHours(Convert.ToDouble(TB_Timer_Hours.Text));
            time = time.AddMinutes(Convert.ToDouble(TB_Timer_Minutes.Text));
            time = time.AddSeconds(Convert.ToDouble(TB_Timer_Seconds.Text));


            MainWindow.timers_list.Add(TB_Timer_Name.Text, time);
            TB_Test.Text = Convert.ToString(MainWindow.timers_list[TB_Timer_Name.Text]);
            timer_name = TB_Timer_Name.Text;
            this.DialogResult = true;
        }
    }
}
