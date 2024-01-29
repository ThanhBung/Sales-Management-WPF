using SE1611_Group3_A2.Controller;
using SE1611_Group3_A2.Models;
using SE1611_Group3_A2.ResourceXAML;
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

namespace SE1611_Group3_A2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CartController controller = new CartController();
        public bool accessed = false;
        public string role = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void viewAllCarts()
        {
            int size = controller.GetAllCarts().Count;
            btnCart.Content = $"Cart ({size})";
        }
        public void setAccessed(string roleName)
        {
            if (accessed)
            {
                btnLogin.Content = $"Logout ({roleName})";
                role = roleName;
                if (roleName.Equals("admin"))
                {
                    btnAlbum.IsEnabled = true;
                    viewAllCarts();
                }
                else
                {
                    btnAlbum.IsEnabled = false;
                }
            }
        }

        private void btnShopping_Click(object sender, RoutedEventArgs e)
        {
            if (accessed)
            {
                ShoppingWindow shoppingWindow = new ShoppingWindow(this);
                shoppingWindow.Show();
            }
            else
            {
                ShoppingWindow shoppingWindow = new ShoppingWindow();
                shoppingWindow.Show();
            }
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            if (accessed && role.Equals("admin"))
            {
                CartWindow cartWindow = new CartWindow();
                cartWindow.Show();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (accessed)
            {
                btnLogin.Content = "Login";
                new MainWindow().Show();
                this.Close();
            }
            else
            {

                LoginWindow loginWindow = new LoginWindow(this);
                loginWindow.Show();
            }
        }

        private void btnAlbum_Click(object sender, RoutedEventArgs e)
        {
            AlbumWindow albumWindow = new AlbumWindow();
            albumWindow.Show();
        }
    }
}
