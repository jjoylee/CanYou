using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanYou.Models.Info.LectureCategory
{
    public interface ILectureCategoryDao
    {
        int Insert(LectureCategoryItem item);
        int Update(LectureCategoryItem item);
        int Delete(int id);

        IList<LectureCategoryItem> FindAll();
        IList<LectureCategoryItem> FindLectureTypeExist();
    }
}
