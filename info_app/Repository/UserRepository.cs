using info_app.Models;
using info_app.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace info_app.Repository
{
    public class UserRepository : IUserInterface
    {
        public int AuthenticateUser(NetworkCredential credential)
        {
            int id = -1;
            using (NewsAppDBEntities db = new NewsAppDBEntities())
            {
                var record = db.User.FirstOrDefault(x => x.username == credential.UserName);
                if (record != null)
                {
                    if (record.password == credential.Password)
                    {
                        id = record.UserId;
                    }
                }
                return id;
            }
        }

        public bool RegisterUser(NetworkCredential credential, string email)
        {
            using (NewsAppDBEntities db = new NewsAppDBEntities())
            {
                bool valid;
                bool isEmailUnique = !db.User.Any(u => u.email == email);
                bool isUsernameUnique = !db.User.Any(u => u.username == credential.UserName);
                if (isEmailUnique && isUsernameUnique)
                {
                    valid = true;
                }
                else
                    valid = false;
                return valid;
            }
        }

        public Models.User GetByUsername(string username)
        {
            Models.User user = null;
            user = new Models.User()
            {
                username = username,
                email = "",
                UserId = 0,
                password = ""
            };
            return user;
        }
    }
}
