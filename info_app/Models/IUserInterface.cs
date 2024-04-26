﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace info_app.Models
{
    public interface IUserInterface
    {
        bool AuthenticateUser(NetworkCredential credential);
    }
}
