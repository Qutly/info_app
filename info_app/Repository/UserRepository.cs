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
            NewsAppDBEntities2 db = new NewsAppDBEntities2();
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
