﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanYou.Models.Info.LectureCategoryRequirement
{
    public interface ILectureCategoryRequirementDao
    {
        int Insert(LectureCategoryRequirementItem item);
        int Update(LectureCategoryRequirementItem item);
        int Delete(int id);
        IList<LectureCategoryRequirementItem> FindByAccountId(int accountId);

        LectureCategoryRequirementItem FindByAccountAndCategoryId(int accountId, int category);

        LectureCategoryRequirementItem FindById(int id);
    }
}
