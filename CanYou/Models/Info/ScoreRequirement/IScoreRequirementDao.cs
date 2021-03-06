﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanYou.Models.Info.ScoreRequirement
{
    public interface IScoreRequirementDao
    {
        int Insert(ScoreRequirementItem item);
        int Update(ScoreRequirementItem item);
        int Delete(int id);

        IList<ScoreRequirementItem> FindByAccountId(int accountId);

        ScoreRequirementItem FindById(int id);

        ScoreRequirementItem FindByAccountIdForCheck(int accountId);
    }
}
