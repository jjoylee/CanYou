using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanYou.Models.Info.LectureTypeRequirement
{
    public interface ILectureTypeRequirementDao
    {
        int Insert(LectureTypeRequirementItem item);
        int Update(LectureTypeRequirementItem item);
        int Delete(int id);

        IList<LectureTypeRequirementItem> FindByAccountId(int id);

        LectureTypeRequirementItem FindById(int id);

        LectureTypeRequirementItem FindByAccountAndTypeId(int accountId, int type);
    }
}
