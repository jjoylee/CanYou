using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanYou.Models.Info.LectureDetail
{
    public interface ILectureDetailDao
    {
        int Insert(LectureDetailItem item);
        int Update(LectureDetailItem item);
        int Delete(int id);

        IList<LectureDetailItem> FindByAccountId(int accountId);

        IList<LectureDetailItem> FindAll();

        LectureDetailItem FindById(int id);

        LectureDetailItem FindByAccountAndTitle(int accountId, string title);
    }
}
