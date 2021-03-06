﻿using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace CanYou.Models.Info.SectionRequirement
{
    public class SectionRequirementDao : AdoDaoSupport, ISectionRequirementDao
    {
        public int Insert(SectionRequirementItem item)
        {
            string query = "Insert into SectionRequirement(accountId,lectureTypeId,cutline) VALUES(@AccountId,@LectureTypeId, @Cutline)";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("AccountId", item.AccountId).DbType = DbType.Int32;
            param.AddWithValue("LectureTypeId", item.LectureTypeId).DbType = DbType.Int32;
            param.AddWithValue("Cutline", item.Cutline).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query, param);
        }

        public int Update(SectionRequirementItem item)
        {
            string query = "UPDATE SectionRequirement SET lectureTypeId = @LectureTypeId, accountId=@AccountId, cutline = @Cutline where id = @Id";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", item.Id).DbType = DbType.Int32;
            param.AddWithValue("LectureTypeId", item.LectureTypeId).DbType = DbType.Int32;
            param.AddWithValue("AccountId", item.AccountId).DbType = DbType.Int32;
            param.AddWithValue("Cutline", item.Cutline).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query, param);
        }

        public int Delete(int id)
        {
            string query = "delete from SectionRequirement where id= @Id";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", id).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query, param);
        }


        public IList<SectionRequirementItem> FindByAccountId(int accountId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from SectionRequirement where accountId=@AccountId");
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("AccountId", accountId).DbType = DbType.Int32;
            return AdoTemplate.QueryWithRowMapper<SectionRequirementItem>(CommandType.Text, builder.ToString(), new SectionRequirementMapper(), param);
        }


        public IList<SectionRequirementItem> FindByLectureTypeId(int lectureTypeId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *from SectionRequirement where lectureTypeId = @Id");
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", lectureTypeId).DbType = DbType.Int32;
            return AdoTemplate.QueryWithRowMapper<SectionRequirementItem>(CommandType.Text, builder.ToString(), new SectionRequirementMapper(), param);
        }


        public SectionRequirementItem FindById(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *from SectionRequirement where id = @Id");
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", id).DbType = DbType.Int32;
            IList<SectionRequirementItem> list = AdoTemplate.QueryWithRowMapper<SectionRequirementItem>(CommandType.Text, builder.ToString(), new SectionRequirementMapper(), param);
            if (list.Count == 0) return null;
            return list[0];
        }


        public SectionRequirementItem FindByAccountIdForCheck(int accountId)
        {
            IList<SectionRequirementItem> list = FindByAccountId(accountId);
            if (list.Count == 0) return null;
            return list[0];
        }
    }
}