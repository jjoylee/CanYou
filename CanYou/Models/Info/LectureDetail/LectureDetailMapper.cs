using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanYou.Models.Info.LectureDetail
{
    public class LectureDetailMapper:IRowMapper<LectureDetailItem>
    {
        public LectureDetailItem MapRow(System.Data.IDataReader reader, int rowNum)
        {
            LectureDetailItem lectureDetail = new LectureDetailItem();
            lectureDetail.Id = reader.GetInt32(reader.GetOrdinal("id"));
            lectureDetail.LectureCategoryId = reader.GetInt32(reader.GetOrdinal("lectureCategoryId"));
            lectureDetail.LectureTypeId = reader.GetInt32(reader.GetOrdinal("lectureTypeId"));
            lectureDetail.Name = reader.GetString(reader.GetOrdinal("name"));
            lectureDetail.Score = reader.GetString(reader.GetOrdinal("score"));
            lectureDetail.SectionId = reader.GetInt32(reader.GetOrdinal("sectionId"));
            lectureDetail.AccountId = reader.GetInt32(reader.GetOrdinal("accountId"));
            lectureDetail.Credit = reader.GetInt32(reader.GetOrdinal("credit"));
            lectureDetail.LectureCategoryName = reader.GetString(reader.GetOrdinal("lectureCategoryName"));
            lectureDetail.LectureTypeName = reader.GetString(reader.GetOrdinal("lectureTypeName"));
            lectureDetail.SectionName = reader.GetString(reader.GetOrdinal("sectionName"));
            return lectureDetail;
        }
    }
}