using CanYou.Models.Info.LectureCategory;
using CanYou.Models.Info.LectureDetail;
using CanYou.Models.Info.LectureType;
using CanYou.Models.Info.Section;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CanYou.Controllers
{
    [Authorize]
    public class LectureController : AbstractController
    {
        
        public ActionResult List()
        {
            IList<LectureDetailItem> list = LectureDetailDao.FindByAccountId(accountItem.Id);
            ViewBag.list = list;
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            // IList<LectureDetailItem> list = LectureDetailDao.FindAll();
            // ViewBag.Detail = list;

            IList<LectureCategoryItem> categoryList = LectureCategoryDao.FindAll();
            ViewBag.Category = categoryList;

            IList<LectureTypeItem> typeList = LectureTypeDao.FindByCategoryId(categoryList[0].Id);
            ViewBag.Type = typeList;

            IList<SectionItem> sectionList = SectionDao.FindByTypeId(typeList[0].Id);
            ViewBag.Section = sectionList;
            return View();
        }
        [HttpPost]
        public ActionResult Register(string title, int credit, string score, int category, [DefaultValue(0)]int section, [DefaultValue(0)]int type)
        {
            if (ExistLectureDetail(title)) return Json(new { result = "fail", message = "이미 존재합니다." }, JsonRequestBehavior.AllowGet);
            LectureDetailItem item = new LectureDetailItem();
            item.Score = score;
            item.Credit = credit;
            item.Name = title;
            item.AccountId = accountItem.Id;
            item.LectureTypeId = type;
            item.LectureCategoryId = category;
            item.SectionId = section;

            try
            {
                LectureDetailDao.Insert(item);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "fail", message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        private bool ExistLectureDetail(string title)
        {
            LectureDetailItem item = LectureDetailDao.FindByAccountAndTitle(accountItem.Id, title);
            return item != null;
        }

        public ActionResult LectureDelete(int id)
        {
            try
            {
                LectureDetailDao.Delete(id);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "fail", message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            LectureDetailItem item = LectureDetailDao.FindById(id);
            IList<LectureCategoryItem> categoryList = LectureCategoryDao.FindAll();
            IList<LectureTypeItem> typeList = LectureTypeDao.FindByCategoryId(item.LectureCategoryId);
            IList<SectionItem> sectionList = SectionDao.FindByTypeId(item.LectureTypeId);
            ViewBag.categoryList = categoryList;
            ViewBag.Item = item;
            ViewBag.typeList = typeList;
            ViewBag.sectionList = sectionList;
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, string score, int category, [DefaultValue(0)]int type, string title, [DefaultValue(0)]int section, int credit)
        {
            LectureDetailItem beforeItem = LectureDetailDao.FindById(id);
            if (!title.Equals(beforeItem.Name) && ExistLectureDetail(title)) return Json(new { result = "fail", message = "이미 존재합니다." }, JsonRequestBehavior.AllowGet);
            LectureDetailItem item = new LectureDetailItem();
            item.LectureCategoryId = category;
            item.LectureTypeId = type;
            item.Score = score;
            item.Name = title;
            item.SectionId = section;
            item.Credit = credit;
            item.AccountId = accountItem.Id;
            item.Id = id;
            try
            {
                LectureDetailDao.Update(item);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "fail", message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult SectionPartial(int typeId)
        {
            IList<SectionItem> sectionList = SectionDao.FindByTypeId(typeId);
            ViewBag.Section = sectionList;
            ViewBag.Count = sectionList.Count;
            return PartialView("~/Views/Lecture/SectionPartial.cshtml");
        }
	}
}