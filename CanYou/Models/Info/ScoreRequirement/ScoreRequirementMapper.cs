using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanYou.Models.Info.ScoreRequirement
{
    public class ScoreRequirementMapper:IRowMapper<ScoreRequirementItem>
    {
        public ScoreRequirementItem MapRow(System.Data.IDataReader reader, int rowNum)
        {
            ScoreRequirementItem scoreRequirement = new ScoreRequirementItem();
            scoreRequirement.AccountId = reader.GetInt32(reader.GetOrdinal("accountId"));
            scoreRequirement.Cutline = reader.GetInt32(reader.GetOrdinal("cutline"));
            scoreRequirement.Id = reader.GetInt32(reader.GetOrdinal("id"));
            return scoreRequirement;
        }
    }
}