using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanYou.Models.Info.LectureType
{
    public class LectureTypeMapper:IRowMapper<LectureTypeItem>
    {
        public LectureTypeItem MapRow(System.Data.IDataReader reader, int rowNum)
        {
            LectureTypeItem lectureType = new LectureTypeItem();
            lectureType.Id = reader.GetInt32(reader.GetOrdinal("id"));
            lectureType.LectureCategoryId = reader.GetInt32(reader.GetOrdinal("lectureCategoryId"));
            lectureType.Name = reader.GetString(reader.GetOrdinal("name"));
            return lectureType;
        }
    }
}