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

namespace WpfHello
{
    /// <summary>
    /// Логика взаимодействия для MyWindow.xaml
    /// </summary>
    public partial class MyWindow : Window
    {
        MainWindow wnd1 = null;
        private bool _close;
        public MyWindow()
        {
            InitializeComponent();


        }
        public new void Close()
        {
            _close = true;
            base.Close();
        }
        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_close) return;
            e.Cancel = true;
            Hide();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Window_Closed(object sender, EventArgs e)
        {
            wnd1 = Owner as MainWindow;
            if (wnd1 != null)
            {
                wnd1.myWin = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // a. Инициализируем ссылку wnd1 с помощью свойства Owner
            wnd1 = Owner as MainWindow;

            // b. Присваиваем свойству Text текстового блока txtBlock главного окна
            // текст текстового поля второго окна
            if (wnd1 != null)
            {
                // Здесь нужна проверка, что txtBlock существует в MainWindow
                // Добавим текстовый блок в MainWindow если его нет
                wnd1.txtBlock.Text = textBox.Text;
            }
            wnd1.txtBlock.Text = textBox.Text;
            PrintLogFile();
            Close();
        }
        private void PrintLogFile()
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("log.txt", true))
            {
                writer.WriteLine("Внесено {0}: {1} ", textBox.Text,
                    DateTime.Now.ToShortDateString() + ", время: " +
                    DateTime.Now.ToLongTimeString());
                writer.Flush();
            }
        }
    }
}
