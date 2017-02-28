using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanYou.Models.Info.Section
{
    public class SectionMapper:IRowMapper<SectionItem>
    {
        public SectionItem MapRow(System.Data.IDataReader reader, int rowNum)
        {
            SectionItem section = new SectionItem();
            section.Id = reader.GetInt32(reader.GetOrdinal("id"));
            section.LectureTypeId = reader.GetInt32(reader.GetOrdinal("lectureTypeId"));
            section.Name = reader.GetString(reader.GetOrdinal("name"));
            return section;
        }
    }
}