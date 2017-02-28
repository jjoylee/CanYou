using Spring.Data;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanYou.Models.Info.LectureCategoryRequirement
{
    public class LectureCategoryRequirementMapper:IRowMapper<LectureCategoryRequirementItem>
    {
        public LectureCategoryRequirementItem MapRow(System.Data.IDataReader reader, int rowNum)
        {
            LectureCategoryRequirementItem lectureCategoryRequirement = new LectureCategoryRequirementItem();
            lectureCategoryRequirement.Id = reader.GetInt32(reader.GetOrdinal("id"));
            lectureCategoryRequirement.AccountId = reader.GetInt32(reader.GetOrdinal("accountId"));
            lectureCategoryRequirement.LectureCategoryId = reader.GetInt32(reader.GetOrdinal("lectureCategoryId"));            
            lectureCategoryRequirement.LectureCategoryName = reader.GetString(reader.GetOrdinal("lectureCategoryName"));
            lectureCategoryRequirement.Cutline = reader.GetInt32(reader.GetOrdinal("cutline"));
            return lectureCategoryRequirement;
        }
    }
}