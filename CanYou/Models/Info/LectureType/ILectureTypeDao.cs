using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanYou.Models.Info.LectureType
{
    public interface ILectureTypeDao
    {
        int Insert(LectureTypeItem item);
        int Update(LectureTypeItem item);
        int Delete(int id);


        IList<LectureTypeItem> FindByCategoryId(int id);

        IList<LectureTypeItem> FindAll();
    }
}
