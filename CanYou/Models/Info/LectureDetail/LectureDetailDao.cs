using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace CanYou.Models.Info.LectureDetail
{
    public class LectureDetailDao : AdoDaoSupport,ILectureDetailDao
    {
        public int Insert(LectureDetailItem item)
        {
            string query = "Insert into LectureDetail(accountId,lectureCategoryId,lectureTypeId,sectionId,name,credit,score) VALUES(@AccountId,@LectureCategoryId,@LectureTypeId,@SectionId,@Name,@Credit,@Score)";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("LectureCategoryId",item.LectureCategoryId).DbType = DbType.Int32;
            param.AddWithValue("LectureTypeId",item.LectureTypeId).DbType = DbType.Int32;
            param.AddWithValue("Name",item.Name).DbType = DbType.String;
            param.AddWithValue("Score",item.Score).DbType = DbType.String;
            param.AddWithValue("SectionId",item.SectionId).DbType = DbType.Int32;
            param.AddWithValue("AccountId",item.AccountId).DbType = DbType.Int32;
            param.AddWithValue("Credit",item.Credit).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text,query,param);
        }

        public int Update(LectureDetailItem item)
        {
            string query = "UPDATE LectureDetail SET accountId = @AccountId, lectureCategoryId = @LectureCategoryId, lectureTypeId = @LectureTypeId, name = @Name, score = @Score, sectionId=@SectionId, credit = @Credit where id = @Id";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", item.Id).DbType = DbType.Int32;
            param.AddWithValue("LectureCategoryId", item.LectureCategoryId).DbType = DbType.Int32;
            param.AddWithValue("LectureTypeId", item.LectureTypeId).DbType = DbType.Int32;
            param.AddWithValue("Name", item.Name).DbType = DbType.String;
            param.AddWithValue("Score", item.Score).DbType = DbType.String;
            param.AddWithValue("SectionId", item.SectionId).DbType = DbType.Int32;
            param.AddWithValue("AccountId", item.AccountId).DbType = DbType.Int32;
            param.AddWithValue("Credit", item.Credit).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query, param);
        }

        public int Delete(int id)
        {
            string query = "delete from LectureDetail where id= @Id";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", id).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query,param);
        }


        public IList<LectureDetailItem> FindByAccountId(int accountId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select a.*, isnull(b.name ,N'구분없음') lectureTypeName ,c.name lectureCategoryName, isnull(d.name ,N'구분없음') sectionName from LectureDetail a left outer join LectureType b on a.lectureTypeId=b.id ");
            builder.Append("inner join LectureCategory c on a.lectureCategoryId = c.id ");
            builder.Append("left outer join Section d on a.sectionId = d.id where accountId=@AccountId order by lectureCategoryId, lectureTypeId, sectionId");
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("AccountId", accountId).DbType = DbType.Int32;
            return AdoTemplate.QueryWithRowMapper<LectureDetailItem>(CommandType.Text, builder.ToString(), new LectureDetailMapper(), param);
        }


        public IList<LectureDetailItem> FindAll()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select a.*, isnull(b.name ,N'구분없음') lectureTypeName ,c.name lectureCategoryName, isnull(d.name,N'구분없음') sectionName from LectureDetail a left outer join LectureType b on a.lectureTypeId=b.id ");
            builder.Append("inner join LectureCategory c on a.lectureCategoryId = c.id ");
            builder.Append("left outer join Section d on a.sectionId = d.id order by lectureCategoryId, lectureTypeId, sectionId");
            return AdoTemplate.QueryWithRowMapper<LectureDetailItem>(CommandType.Text, builder.ToString(), new LectureDetailMapper());
        }


        public LectureDetailItem FindById(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select a.*, isnull(b.name ,N'구분없음') lectureTypeName ,c.name lectureCategoryName, isnull(d.name,N'구분없음') sectionName from LectureDetail a left outer join LectureType b on a.lectureTypeId=b.id ");
            builder.Append("inner join LectureCategory c on a.lectureCategoryId = c.id ");
            builder.Append("left outer join Section d on a.sectionId = d.id where a.id = @Id order by lectureCategoryId, lectureTypeId, sectionId");
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", id).DbType = DbType.Int32;
            IList<LectureDetailItem> list = AdoTemplate.QueryWithRowMapper<LectureDetailItem>(CommandType.Text, builder.ToString(), new LectureDetailMapper(), param);
            if (list.Count == 0) return null;
            return list[0];
        }


        public LectureDetailItem FindByAccountAndTitle(int accountId, string title)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select a.*, isnull(b.name ,N'구분없음') lectureTypeName ,c.name lectureCategoryName, isnull(d.name,N'구분없음') sectionName from LectureDetail a left outer join LectureType b on a.lectureTypeId=b.id ");
            builder.Append("inner join LectureCategory c on a.lectureCategoryId = c.id ");
            builder.Append("left outer join Section d on a.sectionId = d.id where a.accountId = @AccountId and a.Name = @Name order by lectureCategoryId, lectureTypeId, sectionId");
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("AccountId", accountId).DbType = DbType.Int32;
            param.AddWithValue("Name", title);
            IList<LectureDetailItem> list = AdoTemplate.QueryWithRowMapper<LectureDetailItem>(CommandType.Text, builder.ToString(), new LectureDetailMapper(), param);
            if (list.Count == 0) return null;
            return list[0];
        }
    }
}