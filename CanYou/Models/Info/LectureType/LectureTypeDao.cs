using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace CanYou.Models.Info.LectureType
{
    public class LectureTypeDao : AdoDaoSupport,ILectureTypeDao
    {
        public int Insert(LectureTypeItem item)
        {
            string query = "Insert into LectureType(lectureCategoryId,name) VALUES(@LectureCategoryId,@Name)";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id",item.Id).DbType = DbType.Int32;
            param.AddWithValue("LectureCategoryId",item.LectureCategoryId).DbType = DbType.Int32;
            param.AddWithValue("Name",item.Name).DbType = DbType.String;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text,query,param);
        }

        public int Update(LectureTypeItem item)
        {
            string query = "UPDATE LectureType SET name = @Name, lectureCategoryId = @LectureCategoryId where id = @Id";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", item.Id).DbType = DbType.Int32;
            param.AddWithValue("LectureCategoryId", item.LectureCategoryId).DbType = DbType.Int32;
            param.AddWithValue("Name", item.Name).DbType = DbType.String;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query, param);
        }

        public int Delete(int id)
        {
            string query = "delete from LectureType where id= @Id";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", id).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query, param);
        }

        public IList<LectureTypeItem> FindByCategoryId(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from LectureType where lectureCategoryId = @Id");
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", id).DbType = DbType.Int32;
            return AdoTemplate.QueryWithRowMapper<LectureTypeItem>(CommandType.Text, builder.ToString(), new LectureTypeMapper(),param);
        }
        public IList<LectureTypeItem> FindAll()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from LectureType");
            return AdoTemplate.QueryWithRowMapper<LectureTypeItem>(CommandType.Text, builder.ToString(), new LectureTypeMapper());
        }
    }
}