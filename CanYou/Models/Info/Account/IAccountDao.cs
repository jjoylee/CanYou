using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanYou.Models.Info.Account
{
    public interface IAccountDao
    {
        int Insert(AccountItem item);
        int Update(AccountItem item);
        AccountItem FindByEmail(string email);

        int UpdateState(int accountId, string state);
    }
}
