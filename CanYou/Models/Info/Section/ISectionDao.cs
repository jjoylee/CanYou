using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanYou.Models.Info.Section
{
    public interface ISectionDao
    {
        int Insert(SectionItem item);
        int Update(SectionItem item);
        int Delete(int id);

        IList<SectionItem> FindAll();

        IList<SectionItem> FindByTypeId(int typeId);
    }
}
