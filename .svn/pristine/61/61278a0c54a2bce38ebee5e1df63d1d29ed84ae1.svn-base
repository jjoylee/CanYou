using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace CanYou.Models.Info.Section
{
    public class SectionDao : AdoDaoSupport,ISectionDao
    {
        public int Insert(SectionItem item)
        {
            string query = "Insert into Section(lectureTypeId,name) VALUES(@LectureTypeId, @Name)";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id",item.Id).DbType = DbType.Int32;
            param.AddWithValue("LectureTypeId",item.LectureTypeId).DbType = DbType.Int32;
            param.AddWithValue("Name",item.Name).DbType = DbType.String;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text,query,param);
        }

        public int Update(SectionItem item)
        {
            string query = "UPDATE Section SET lectureTypeId = @LectureTypeId, name=@Name where id = @Id";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", item.Id).DbType = DbType.Int32;
            param.AddWithValue("LectureTypeId", item.LectureTypeId).DbType = DbType.Int32;
            param.AddWithValue("Name", item.Name).DbType = DbType.String;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query, param);
        }

        public int Delete(int id)
        {
            string query = "delete from Section where id= @Id";
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("Id", id).DbType = DbType.Int32;
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, query, param);
        }


        public IList<SectionItem> FindAll()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from Section");
            return AdoTemplate.QueryWithRowMapper<SectionItem>(CommandType.Text, builder.ToString(), new SectionMapper());
        }


        public IList<SectionItem> FindByTypeId(int typeId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from Section where lectureTypeId = @LectureTypeId");
            IDbParameters param = CreateDbParameters();
            param.AddWithValue("LectureTypeId", typeId).DbType = DbType.Int32;
            return AdoTemplate.QueryWithRowMapper<SectionItem>(CommandType.Text, builder.ToString(), new SectionMapper(),param);
        }
    }
}