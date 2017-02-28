using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanYou.Models.Info.LectureTypeRequirement
{
    public class LectureTypeRequirementMapper:IRowMapper<LectureTypeRequirementItem>
    {
        public LectureTypeRequirementItem MapRow(System.Data.IDataReader reader, int rowNum)
        {
            LectureTypeRequirementItem lectureTypeRequirement = new LectureTypeRequirementItem();
            lectureTypeRequirement.AccountId = reader.GetInt32(reader.GetOrdinal("accountId"));
            lectureTypeRequirement.Cutline = reader.GetInt32(reader.GetOrdinal("cutline"));
            lectureTypeRequirement.Id = reader.GetInt32(reader.GetOrdinal("id"));
            lectureTypeRequirement.LectureTypeId = reader.GetInt32(reader.GetOrdinal("lectureTypeId"));
            lectureTypeRequirement.LectureTypeName = reader.GetString(reader.GetOrdinal("lectureTypeName"));
            lectureTypeRequirement.LectureCategoryName = reader.GetString(reader.GetOrdinal("lectureCategoryName"));
            lectureTypeRequirement.LectureCategoryId = reader.GetInt32(reader.GetOrdinal("lectureCategoryId"));
            return lectureTypeRequirement;
        }
    }
}