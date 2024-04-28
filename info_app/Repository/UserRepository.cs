using info_app.Models;
using info_app.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace info_app.Repository
{
    public class UserRepository : IUserInterface
    {
        public int AuthenticateUser(NetworkCredential credential)
        {
            int id = -1;
            NewsAppDBEntities db = new NewsAppDBEntities();
            var record = db.User.FirstOrDefault(x => x.username == credential.UserName);
            if(record != null)
            {
                if (record.password == credential.Password)
                {
                    id = record.UserId;
                }
            }
            return id;
        }
    }
}
