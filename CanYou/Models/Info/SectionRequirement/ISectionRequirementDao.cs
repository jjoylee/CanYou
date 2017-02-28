﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanYou.Models.Info.SectionRequirement
{
    public interface ISectionRequirementDao
    {
        int Insert(SectionRequirementItem item);
        int Update(SectionRequirementItem item);
        int Delete(int id);

        IList<SectionRequirementItem> FindByAccountId(int accountId);

        IList<SectionRequirementItem> FindByLectureTypeId(int lectureTypeId);

        SectionRequirementItem FindById(int id);

        SectionRequirementItem FindByAccountIdForCheck(int accountId);
    }
}
