using Spring.Data;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanYou.Models.Info.Account
{
    public class AccountMapper : IRowMapper<AccountItem>
    {
        public AccountItem MapRow(System.Data.IDataReader reader, int rowNum)
        {
            AccountItem account = new AccountItem();
            account.Id = reader.GetInt32(reader.GetOrdinal("id"));
            account.Email = reader.GetString(reader.GetOrdinal("email"));
            account.Password = reader.GetString(reader.GetOrdinal("password"));
            account.State = reader.GetString(reader.GetOrdinal("state"));

            return account;
        }
    }
}