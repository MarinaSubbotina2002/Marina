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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        testEntities1 conn = new testEntities1();

        public Window1()
        {
            InitializeComponent();

            Admin_DB.ItemsSource = conn.Admin.ToList();


            //Role select = conn.Role;
            //Role_box.Text = select.RoleId;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Insert_button_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Jobnumber = Jobnumber_textbox.Text;
            admin.Name = Name_textbox.Text;
            admin.Passwords = Password_textbox.Text;
            admin.Gender = Gender_box.Text;
            admin.DateOfBirth = Data.SelectedDate.Value;
            admin.Phone = Phone_textbox.Text;
            admin.Email = Email_textbox.Text;
            admin.RoleId = Role_box.Text;
            conn.Admin.Add(admin);
            conn.SaveChanges();
        }

        private void Update_button_Click(object sender, RoutedEventArgs e)
        {
            Admin_DB.ItemsSource = conn.Admin.ToList();
        }

        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {

            Admin delete = conn.Admin.Where(c => c.Jobnumber == Jobnumber_textbox.Text).First();
            conn.Admin.Remove(delete);
            conn.SaveChanges();
        }

        private void Edit_button_Click(object sender, RoutedEventArgs e)
        {
            conn.SaveChanges();
        }

        private void Search_button_Click(object sender, RoutedEventArgs e)
        {
            Admin_DB.ItemsSource = conn.Admin.Where(c => c.Name.Contains(Search_textbox.Text)).ToList();
        }
    }
}
