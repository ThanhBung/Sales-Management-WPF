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
    /// Interaction logic for CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        MusicStoreContext context = new MusicStoreContext();
        public CartWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            lsvCarts.Items.Clear();
            List<Cart> listCart = new CartController().GetAllCarts();
            float total = 0;
            foreach (var item in listCart)
            {
                lsvCarts.Items.Add(new
                {
                    AlbumId = item.AlbumId,
                    Album = context.Albums.FirstOrDefault(x => x.AlbumId == item.AlbumId),
                    Count = item.Count,
                    DateCreated = item.DateCreated
                });
                total += item.Count * (float)context.Albums.FirstOrDefault(x => x.AlbumId == item.AlbumId).Price;
            }
            txbTotal.Text = Math.Round(total, 2).ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int delId = int.Parse(btn.CommandParameter.ToString());
            Cart delCart = context.Carts.FirstOrDefault(x => x.AlbumId == delId);
            if (delCart.Count > 1)
            {
                delCart.Count -= 1;
            }
            else
            {
                context.Carts.Remove(delCart);
            }
            context.SaveChanges();
            LoadData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (float.Parse(txbTotal.Text) > 0)
            {
                this.Close();
                CheckoutWindow ckwindow = new CheckoutWindow();
                ckwindow.SetTotal(txbTotal.Text);
                ckwindow.Show();
            }
        }
    }
}
