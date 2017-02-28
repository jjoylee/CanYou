using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanYou.Models.Info.Account
{
    public class AccountItem
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
    }
}