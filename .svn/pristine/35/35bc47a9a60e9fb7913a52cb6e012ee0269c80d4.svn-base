using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanYou.Models.Info.SectionRequirement
{
    public class SectionRequirementMapper : IRowMapper<SectionRequirementItem>
    {
        public SectionRequirementItem MapRow(System.Data.IDataReader reader, int rowNum)
        {
            SectionRequirementItem sectionRequirement = new SectionRequirementItem();
            sectionRequirement.Id = reader.GetInt32(reader.GetOrdinal("id"));
            sectionRequirement.LectureTypeId = reader.GetInt32(reader.GetOrdinal("lectureTypeId"));
            sectionRequirement.AccountId = reader.GetInt32(reader.GetOrdinal("accountId"));
            sectionRequirement.Cutline = reader.GetInt32(reader.GetOrdinal("Cutline"));
            return sectionRequirement;
        }
    }
}