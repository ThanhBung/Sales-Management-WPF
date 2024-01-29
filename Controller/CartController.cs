using SE1611_Group3_A2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SE1611_Group3_A2.Controller
{
    internal class CartController
    {
        MusicStoreContext context = new MusicStoreContext();
        public List<Cart> GetAllCarts()
        {
            return context.Carts.ToList();
        }
        public void AddCart(Cart cart)
        {
            try
            {
                Cart found = context.Carts.FirstOrDefault(x => x.AlbumId == cart.AlbumId);
                if (found == null) context.Carts.Add(cart);
                else found.Count++;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }


    }
}
