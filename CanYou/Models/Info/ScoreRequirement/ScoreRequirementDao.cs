using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace CanYou.Models.Info.ScoreRequirement
{
    public class ScoreRequirementDao : AdoDaoSupport,IScoreRequirementDao
    {
        public int Insert(ScoreRequirementItem item)
        {
            string query = "Insert into ScoreRequirement(accountId,cutline) VALUES(@AccountId, @Cutline)";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("AccountId",item.AccountId).DbType = DbType.Int32;
            param.AddWithValue("Cutline",item.Cutline).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query,param);
        }

        public int Update(ScoreRequirementItem item)
        {
            string query = "UPDATE ScoreRequirement SET accountId = @AccountId, cutline=@Cutline where id = @Id";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", item.Id).DbType = DbType.Int32;
            param.AddWithValue("AccountId", item.AccountId).DbType = DbType.Int32;
            param.AddWithValue("Cutline", item.Cutline).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query, param);
        }           

        public int Delete(int id)
        {
            string query = "delete from ScoreRequirement where id=@Id";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", id).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query, param);
        }


        public IList<ScoreRequirementItem> FindByAccountId(int accountId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *from ScoreRequirement where accountId=@AccountId");
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("AccountId", accountId).DbType = DbType.Int32;
            return AdoTemplate.QueryWithRowMapper<ScoreRequirementItem>(CommandType.Text, builder.ToString(), new ScoreRequirementMapper(), param);
        }


        public ScoreRequirementItem FindById(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *from ScoreRequirement where id=@Id");
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", id).DbType = DbType.Int32;
            IList<ScoreRequirementItem> list = AdoTemplate.QueryWithRowMapper<ScoreRequirementItem>(CommandType.Text, builder.ToString(), new ScoreRequirementMapper(), param);
            if (list.Count == 0) return null;
            return list[0];
        }


        public ScoreRequirementItem FindByAccountIdForCheck(int accountId)
        {
            IList<ScoreRequirementItem> list = FindByAccountId(accountId);
            if (list.Count == 0) return null;
            return list[0];
        }
    }
}