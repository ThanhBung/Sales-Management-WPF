using SE1611_Group3_A2.Controller;
using SE1611_Group3_A2.Models;
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
using System.Windows.Shapes;

namespace SE1611_Group3_A2.ResourceXAML
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private MainWindow mainWindow;
        private UserController controller = new UserController();

        public LoginWindow()
        {
        }
        public LoginWindow(MainWindow main)
        {
            InitializeComponent();
            mainWindow = main;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUsername.Text.Trim().ToString();
            string pass = txtPassword.Password.Trim().ToString();

            if (controller.AccessLogin(user, pass))
            {
                User u = controller.GetUserByUsername(user);
                int role = u.Role;
                string roleName = role == 0 ? "user" : "admin";

                mainWindow.Close();
                mainWindow = new MainWindow();
                mainWindow.accessed = true;
                mainWindow.setAccessed(roleName);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Don't have that user");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
