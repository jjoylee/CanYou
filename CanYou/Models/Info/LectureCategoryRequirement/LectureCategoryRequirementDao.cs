﻿
using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace CanYou.Models.Info.LectureCategoryRequirement
{
    public class LectureCategoryRequirementDao : AdoDaoSupport,ILectureCategoryRequirementDao
    {
        public int Insert(LectureCategoryRequirementItem item)
        {
            string query = "Insert into LectureCategoryRequirement(accountId,lectureCategoryId,cutline) VALUES(@AccountId,@LectureCategoryId,@Cutline)";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("AccountId", item.AccountId).DbType = DbType.Int32;
            param.AddWithValue("Cutline",item.Cutline).DbType = DbType.Int32;
            param.AddWithValue("LectureCategoryId", item.LectureCategoryId).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query, param);
        }

        public int Update(LectureCategoryRequirementItem item)
        {
            string query = "UPDATE LectureCategoryRequirement SET accountId = @AccountId, cutline = @Cutline, lectureCategoryId = @LectureCategoryId where id = @Id";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("AccountId", item.AccountId).DbType = DbType.Int32;
            param.AddWithValue("Cutline", item.Cutline).DbType = DbType.Int32;
            param.AddWithValue("Id", item.Id).DbType = DbType.Int32;
            param.AddWithValue("LectureCategoryId", item.LectureCategoryId).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query, param);
        }

        public int Delete(int id)
        {
            string query = "delete from LectureCategoryRequirement where id=@Id";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", id).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query, param);
        }
        
        public IList<LectureCategoryRequirementItem> FindByAccountId(int accountId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select a.*,b.name lectureCategoryName from lectureCategoryRequirement a inner join lectureCategory b on a.lectureCategoryId=b.id where accountId=@AccountId");

            IDbParameters param = CreateDbParameters();
            param.AddWithValue("AccountId", accountId).DbType = DbType.Int32;
            return AdoTemplate.QueryWithRowMapper<LectureCategoryRequirementItem>(CommandType.Text, builder.ToString(), new LectureCategoryRequirementMapper(),param);
        }


        public LectureCategoryRequirementItem FindByAccountAndCategoryId(int accountId, int category)
        {
            string query = "select a.*,b.name lectureCategoryName from lectureCategoryRequirement a inner join lectureCategory b on a.lectureCategoryId=b.id where accountId=@AccountId and lectureCategoryId = @Category";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("AccountId", accountId);
            param.AddWithValue("Category", category);
            IList<LectureCategoryRequirementItem> list = AdoTemplate.QueryWithRowMapper<LectureCategoryRequirementItem>(CommandType.Text, query, new LectureCategoryRequirementMapper(), param);
            if (list.Count == 0) return null;
            return list[0];
        }


        public LectureCategoryRequirementItem FindById(int id)
        {
            string query = " select a.*,b.name lectureCategoryName from lectureCategoryRequirement a inner join lectureCategory b on a.lectureCategoryId=b.id where a.id = @Id";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", id);
            IList<LectureCategoryRequirementItem> list = AdoTemplate.QueryWithRowMapper<LectureCategoryRequirementItem>(CommandType.Text, query, new LectureCategoryRequirementMapper(), param);
            if (list.Count == 0) return null;
            return list[0];
        }
    }
}