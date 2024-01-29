using SE1611_Group3_A2.Controller;
using SE1611_Group3_A2.Models;
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

namespace SE1611_Group3_A2.ResourceXAML
{
    /// <summary>
    /// Interaction logic for CheckoutWindow.xaml
    /// </summary>
    public partial class CheckoutWindow : Window
    {
        MusicStoreContext context = new MusicStoreContext();
        public CheckoutWindow()
        {
            InitializeComponent();
        }

        public void SetTotal(string total)
        {
            txtTotal.Text = total;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Enter FirstName");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Enter LastName");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Enter Address");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("Enter City");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtState.Text))
            {
                MessageBox.Show("Enter State");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCountry.Text))
            {
                MessageBox.Show("Enter Country");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Enter Phone");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Enter Email");
                return;
            }

            // add order
            Order order = new Order
            {
                OrderDate = DateTime.Today,
                UserName = "user",
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Address = txtAddress.Text,
                City = txtCity.Text,
                State = txtState.Text,
                Country = txtCountry.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                Total = decimal.Parse(txtTotal.Text)
            };
            try
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            int orderID = context.Orders.Select(o => o.OrderId).Max();

            // add order details
            List<Cart> lstCart = new CartController().GetAllCarts();
            foreach (Cart item in lstCart)
            {
                decimal Price = context.Albums.FirstOrDefault(x => x.AlbumId == item.AlbumId).Price;
                OrderDetail orderDetail = new OrderDetail
                {
                    AlbumId = item.AlbumId,
                    OrderId = orderID,
                    UnitPrice = Price,
                    Quantity = item.Count
                };
                try
                {
                    context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            MessageBox.Show($"Order id = {orderID} is saved!");
            foreach (Cart cart in context.Carts)
            {
                context.Carts.Remove(cart);
            }
            context.SaveChanges();

        }
    }
}
