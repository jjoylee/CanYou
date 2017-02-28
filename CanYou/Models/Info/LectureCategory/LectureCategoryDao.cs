using Spring.Data.Generic;
using Spring.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;

namespace CanYou.Models.Info.LectureCategory
{
    public class LectureCategoryDao : AdoDaoSupport,ILectureCategoryDao
    {
        public int Insert(LectureCategoryItem item)
        {
            string query = "Insert into LectureCategory(name) VALUES(@Name)";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", item.Id).DbType = DbType.Int32;
            param.AddWithValue("Name", item.Name).DbType = DbType.String;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query,param);
        }

        public int Update(LectureCategoryItem item)
        {
            string query = "UPDATE LectureCategory SET name = @Name where id = @Id";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", item.Id).DbType = DbType.Int32;
            param.AddWithValue("Password", item.Name).DbType = DbType.String;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query, param);
        }

        public int Delete(int id)
        {
            string query = "delete from LectureCategory where id= @Id";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", id).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query, param);
        }


        public IList<LectureCategoryItem> FindAll()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from LectureCategory");
            return AdoTemplate.QueryWithRowMapper<LectureCategoryItem>(CommandType.Text, builder.ToString(), new LectureCategoryMapper());
        }


        public IList<LectureCategoryItem> FindLectureTypeExist()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from LectureCategory where id in (select distinct lectureCategoryId from LectureType)");
            return AdoTemplate.QueryWithRowMapper<LectureCategoryItem>(CommandType.Text, builder.ToString(), new LectureCategoryMapper());
        }
    }
}