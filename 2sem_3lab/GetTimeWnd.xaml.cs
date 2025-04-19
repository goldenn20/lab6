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
    /// Логика взаимодействия для GetTimeWnd.xaml
    /// </summary>
    public partial class GetTimeWnd : Window
        
    {
        public static TimeSpan time_show = new TimeSpan(0,0,0);
        public GetTimeWnd()
        {
            InitializeComponent();
            DateTime time_now = DateTime.Now;
            time_show = MainWindow.timers_list[MainWindow.chosen_timer].Subtract(time_now);
            if (time_show.Seconds > 10)
            {
                LBL_Remain.Content = ("Дни: " + time_show.Days + " Время: " + time_show.Hours + ":" + time_show.Minutes + ":" + time_show.Seconds);
            }
            else
            {
                LBL_Remain.Content = ("Дни: " + time_show.Days + " Время: " + time_show.Hours + ":" + time_show.Minutes + ":0" + time_show.Seconds);
            }
            
        }


        private void BTN_View_2_Click(object sender, RoutedEventArgs e) // второй вариант отображения
        {
            LBL_Remain.Content = ("Часов: " + Math.Floor(time_show.TotalHours) + " Минут: " + time_show.Minutes + " Секунд: " + time_show.Seconds);
        }

        private void BTN_View_1_Click(object sender, RoutedEventArgs e) // снова первый
        {
            if (time_show.Seconds > 10)
            {
                LBL_Remain.Content = ("Дни: " + time_show.Days + " Время: " + time_show.Hours + ":" + time_show.Minutes + ":" + time_show.Seconds);
            }
            else
            {
                LBL_Remain.Content = ("Дни: " + time_show.Days + " Время: " + time_show.Hours + ":" + time_show.Minutes + ":0" + time_show.Seconds);
            }
        }

        private void BTN_View_3_Click(object sender, RoutedEventArgs e) // третий
        {
            LBL_Remain.Content = ("Минут: " + Math.Floor(time_show.TotalMinutes) + " Секунд: " + time_show.Seconds);
        }

        private void BTN_View_4_Click(object sender, RoutedEventArgs e)
        {
            LBL_Remain.Content = ("Секунд: " + Math.Floor(time_show.TotalSeconds));
        }
    }
}
