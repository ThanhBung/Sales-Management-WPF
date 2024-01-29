using SE1611_Group3_A2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE1611_Group3_A2.Controller
{
    internal class UserController
    {
        private MusicStoreContext context = new MusicStoreContext();
        public bool AccessLogin(string username, string password) {
            bool authen = false;
            if (context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password) != null)
            {
                authen = true;
            }
            return authen;
        }
        public User GetUserByUsername(string username) {
            return context.Users.FirstOrDefault(u => u.UserName == username);
        }
    }
}
