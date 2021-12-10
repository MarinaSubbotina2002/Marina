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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        testEntities1 conn = new testEntities1();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Open_button_Click(object sender, RoutedEventArgs e)
        {
            int count = conn.Admin.Where(c => c.Jobnumber == Username_label.Text && c.Passwords == Passwordbox.Password).Count();
            if (count == 1)
            {
                var Role = (from c in conn.Admin
                            where c.Jobnumber == Username_label.Text
                            select c.RoleId).FirstOrDefault();
                if (Role == "1")
                {
                    Window1 window1 = new Window1();
                    window1.Show();
                    this.Close();
                }
                else if (Role == "2")
                {
                    Window2 window2 = new Window2();
                    window2.Show();
                    this.Close();
                }
            }
            else MessageBox.Show("Неверный логин или пароль!");
        }
    
    }
}
