using Spring.Data;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanYou.Models.Info.LectureCategory
{
    public class LectureCategoryMapper:IRowMapper<LectureCategoryItem>
    {
        public LectureCategoryItem MapRow(System.Data.IDataReader reader, int rowNum)
        {
            LectureCategoryItem lectureCategory = new LectureCategoryItem();
            lectureCategory.Id = reader.GetInt32(reader.GetOrdinal("id"));
            lectureCategory.Name = reader.GetString(reader.GetOrdinal("name"));
            return lectureCategory;
        }
    }
}