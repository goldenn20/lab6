using System;
using System.Collections.Generic;
using System.IO;
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

namespace _2sem_3lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Dictionary<string, DateTime> timers_list = new Dictionary<string, DateTime>();
        public static string chosen_timer = "";

        public MainWindow()
        {
            InitializeComponent();
            
            

        }
        private void mnuNew_Click(object sender, RoutedEventArgs e)
        {
            //TB1.Text = "123123123";
            //создание нового окна (название класса – то, что было указано при добавлении окна)
            AddTimerWnd add_timer = new AddTimerWnd();
            //вызов окна + проверка, отработало ли окно корректно
            if (add_timer.ShowDialog() == true)
            {
                //поскольку переменная current, окна add_timer была объявлена как public
                //можно обратиться к ней напрямую и получить необходимые данные
                //DateTime st = add_timer.current;
            }
            else //если окно отработало с результатом false
            {
                //либо вывести сообщение, что данные не были получены
                //либо ничего не делать
            }

            LB1.Items.Add(AddTimerWnd.timer_name);
        }

        private void btn_gettime_Click(object sender, RoutedEventArgs e)
        {
            
            //TB1.Text = Convert.ToString(timers_list[AddTimerWnd.timer_name]);
        }
        //mnuGettime_Click
        private void mnuGettime_Click(object sender, RoutedEventArgs e)
        {
            chosen_timer = Convert.ToString(LB1.SelectedItem);
            //создание нового окна (название класса – то, что было указано при добавлении окна)
            GetTimeWnd get_time = new GetTimeWnd();
            //вызов окна + проверка, отработало ли окно корректно
            if (get_time.ShowDialog() == true)
            {
                //поскольку переменная current, окна add_timer была объявлена как public
                //можно обратиться к ней напрямую и получить необходимые данные
                //DateTime st = add_timer.current;
            }
            else //если окно отработало с результатом false
            {
                //либо вывести сообщение, что данные не были получены
                //либо ничего не делать
            }
        }
        private void mnuDelete_Click(object sender, RoutedEventArgs e)
        {
            timers_list.Remove(Convert.ToString(LB1.SelectedItem));
            LB1.Items.Remove(LB1.SelectedItem);
            
        }
        private void mnuEdit_Click(object sender, RoutedEventArgs e)
        {
            chosen_timer = Convert.ToString(LB1.SelectedItem);
            //создание нового окна (название класса – то, что было указано при добавлении окна)
            Edit_Timer_Wnd edit_time = new Edit_Timer_Wnd();
            //вызов окна + проверка, отработало ли окно корректно
            if (edit_time.ShowDialog() == true)
            {
                //поскольку переменная current, окна add_timer была объявлена как public
                //можно обратиться к ней напрямую и получить необходимые данные
                //DateTime st = add_timer.current;
            }
            else //если окно отработало с результатом false
            {
                //либо вывести сообщение, что данные не были получены
                //либо ничего не делать
            }
        }
        private void mnuSave_Click(object sender, RoutedEventArgs e)
        {
            chosen_timer = Convert.ToString(LB1.SelectedItem);
            string save_string = chosen_timer + "-" + Convert.ToString(timers_list[chosen_timer].Year) + "-" + Convert.ToString(timers_list[chosen_timer].Month) + "-" + Convert.ToString(timers_list[chosen_timer].Day) + "-" + Convert.ToString(timers_list[chosen_timer].Hour) + "-" + Convert.ToString(timers_list[chosen_timer].Minute) + "-" + Convert.ToString(timers_list[chosen_timer].Second);
            //TB1.Text = save_string;


            //создание диалога
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            //настройка параметров диалога
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension
                                                        //вызов диалога
            dlg.ShowDialog();
            //получение выбранного имени файла
            string path = dlg.FileName;

            //открытие файла test.txt для записи
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                outputFile.WriteLine(save_string);
            }
        }
        private void mnuOpen_Click(object sender, RoutedEventArgs e)
        {
            //создание диалога
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //настройка параметров диалога
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension
                                                        //вызов диалога
            dlg.ShowDialog();
            //получение выбранного имени файла
            string path = dlg.FileName;

            string[] mass = new string[7];
            string line;
            //открытие файла test.txt для чтения 
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            //построчное чтение файла 
            while ((line = file.ReadLine()) != null)
            {
                //операции над полученной строкой
                mass = line.Split('-');
            }
            //закрытие файла
            file.Close();
            LB1.Items.Add(mass[0]);
            DateTime load_time = new DateTime(Convert.ToInt32(mass[1]), Convert.ToInt32(mass[2]), Convert.ToInt32(mass[3]), Convert.ToInt32(mass[4]), Convert.ToInt32(mass[5]), Convert.ToInt32(mass[6]));
            timers_list.Add(mass[0], load_time);
        }

        private void LB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
