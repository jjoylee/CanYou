using CanYou.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CanYou.Controllers
{
    [Authorize]
    public class ResultController : AbstractController
    {
        //
        // GET: /Result/
        public ActionResult Index()
        {
            ResultService service = new ResultService();
            service.CategoryRequirements = LectureCategoryRequirementDao.FindByAccountId(accountItem.Id);
            service.LectureDetails = LectureDetailDao.FindByAccountId(accountItem.Id);
            service.ScoreRequirement = ScoreRequirementDao.FindByAccountIdForCheck(accountItem.Id);
            service.SectionRequirement = SectionRequirementDao.FindByAccountIdForCheck(accountItem.Id);
            service.Sections = SectionDao.FindAll();
            service.TypeRequirements = LectureTypeRequirementDao.FindByAccountId(accountItem.Id);
            ViewBag.Results = service.GetResults();
            ViewBag.IsAllPassed = IsAllPassed(ViewBag.Results);
            return View();
        }
        private bool IsAllPassed(IList<ResultDetailItem> results)
        {
            if (results.Count == 0) return false;
            foreach(ResultDetailItem item in results)
            {
                if(!item.IsPassed()) return false;
            }
            return true;
        }
	}
}