using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace CanYou.Models.Info.LectureTypeRequirement
{
    public class LectureTypeRequirementDao : AdoDaoSupport,ILectureTypeRequirementDao
    {
        public int Insert(LectureTypeRequirementItem item)
        {
            string query = "Insert into LectureTypeRequirement(accountId,lectureTypeId,cutline) VALUES(@AccountId,@LectureTypeId, @Cutline)";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id",item.Id).DbType = DbType.Int32;
            param.AddWithValue("LectureTypeId",item.LectureTypeId).DbType = DbType.Int32;
            param.AddWithValue("AccountId",item.AccountId).DbType = DbType.Int32;
            param.AddWithValue("Cutline",item.Cutline).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query,param);
        }

        public int Update(LectureTypeRequirementItem item)
        {
            string query = "UPDATE LectureTypeRequirement SET lectureTypeId = @LectureTypeId, accountId = @AccountId, cutline=@Cutline where id = @Id";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", item.Id).DbType = DbType.Int32;
            param.AddWithValue("LectureTypeId", item.LectureTypeId).DbType = DbType.Int32;
            param.AddWithValue("AccountId", item.AccountId).DbType = DbType.Int32;
            param.AddWithValue("Cutline", item.Cutline).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query, param);
        }

        public int Delete(int id)
        {
            string query = "delete from LectureTypeRequirement where id=@Id";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", id).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query, param);
        }


        public IList<LectureTypeRequirementItem> FindByAccountId(int accountId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select a.*, b.name lectureTypeName ,c.name lectureCategoryName, c.id lectureCategoryId from lectureTypeRequirement a inner join lectureType b on a.lectureTypeId=b.id ");
            builder.Append("inner join lectureCategory c on b.lectureCategoryId = c.id where accountId=@AccountId");
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("AccountId", accountId).DbType = DbType.Int32;
            return AdoTemplate.QueryWithRowMapper<LectureTypeRequirementItem>(CommandType.Text, builder.ToString(), new LectureTypeRequirementMapper(),param);
        }


        public LectureTypeRequirementItem FindById(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select a.*, b.name lectureTypeName ,c.name lectureCategoryName, c.id lectureCategoryId from lectureTypeRequirement a inner join lectureType b on a.lectureTypeId=b.id inner join lectureCategory c on b.lectureCategoryId = c.id where a.id = @Id");
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", id).DbType = DbType.Int32;
            IList<LectureTypeRequirementItem> list = AdoTemplate.QueryWithRowMapper<LectureTypeRequirementItem>(CommandType.Text, builder.ToString(), new LectureTypeRequirementMapper(), param);
            if (list.Count == 0) return null;
            return list[0];
        }


        public LectureTypeRequirementItem FindByAccountAndTypeId(int accountId, int type)
        {
            string query = "select a.*, b.name lectureTypeName ,c.name lectureCategoryName, c.id lectureCategoryId from lectureTypeRequirement a inner join lectureType b on a.lectureTypeId=b.id inner join lectureCategory c on b.lectureCategoryId = c.id where a.accountId = @AccountId and a.lectureTypeId = @Type";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("AccountId", accountId);
            param.AddWithValue("Type", type);
            IList<LectureTypeRequirementItem> list = AdoTemplate.QueryWithRowMapper<LectureTypeRequirementItem>(CommandType.Text, query, new LectureTypeRequirementMapper(), param);
            if (list.Count == 0) return null;
            return list[0];
        }
    }
}