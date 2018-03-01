using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CanYou.Models.Info.LectureCategoryRequirement;
using CanYou.Models.Info.LectureTypeRequirement;
using CanYou.Models.Info.ScoreRequirement;
using CanYou.Models.Info.SectionRequirement;
using CanYou.Models.Info.LectureDetail;
using CanYou.Models.Info.Section;

namespace CanYou.Models.Service
{
    public class ResultService
    {
        public IList<LectureCategoryRequirementItem> CategoryRequirements { set; get; }
        public IList<LectureTypeRequirementItem> TypeRequirements { set; get; }
        public ScoreRequirementItem ScoreRequirement { set; get; }
        public SectionRequirementItem SectionRequirement { set;get; }
        public IList<LectureDetailItem> LectureDetails{set;get;}

        public IList<SectionItem> Sections { set; get; }
        public IList<ResultDetailItem> GetResults()
        {
            IList<ResultDetailItem> list = new List<ResultDetailItem>();
            foreach (LectureCategoryRequirementItem item in CategoryRequirements)
            {
                AddCategoryRequirement(list, item);
                AddTypeRequirement(list,item);
            }
            AddScoreRequirement(list);
            return list;
        }

        private void AddScoreRequirement(IList<ResultDetailItem> list)
        {
            if (ScoreRequirement == null) return;
            ResultDetailItem result = new ResultDetailItem();
            result.Name = "총학점";
            result.Requirement = ScoreRequirement.Cutline;
            result.Score = GetTotalScore();
            list.Add(result);
        }

        private int GetTotalScore()
        {
            int score = 0;
            foreach(LectureDetailItem item in LectureDetails)
            {
                score += item.Credit;
            }
            return score;
        }

        private void AddCategoryRequirement(IList<ResultDetailItem> list, LectureCategoryRequirementItem categoryItem)
        {
            ResultDetailItem result = new ResultDetailItem();
            result.Name = categoryItem.LectureCategoryName;
            result.Requirement = categoryItem.Cutline;
            result.Score = GetScoreByCategory(categoryItem.LectureCategoryId);
            list.Add(result);
        }

        private void AddTypeRequirement(IList<ResultDetailItem> list, LectureCategoryRequirementItem categoryItem)
        {
            foreach (LectureTypeRequirementItem item in TypeRequirements)
            {
                if (item.LectureCategoryId != categoryItem.LectureCategoryId) continue;
                ResultDetailItem result = new ResultDetailItem();
                result.Name = categoryItem.LectureCategoryName + " " + item.LectureTypeName;
                result.Requirement = item.Cutline;
                result.Score = GetScoreByType(item.LectureTypeId);
                list.Add(result);
                AddSectionResult(list, categoryItem, item);
            }
        }

        private void AddSectionResult(IList<ResultDetailItem> list, LectureCategoryRequirementItem categoryItem, LectureTypeRequirementItem typeItem)
        {
            if (SectionRequirement == null) return;
            if (typeItem.LectureTypeId!= SectionRequirement.LectureTypeId) return;
            ResultDetailItem result = new ResultDetailItem();
            result.Name = categoryItem.LectureCategoryName + " " + typeItem.LectureTypeName + " 이수 영역 수";
            result.Requirement = SectionRequirement.Cutline;
            result.Score = GetCountBySection();
            list.Add(result);
        }

        private int GetCountBySection()
        {
            IList<int> sectionids = new List<int>();
            foreach (LectureDetailItem item in LectureDetails)
            {
                if (!IsSection(item.SectionId)) continue;
                if (sectionids.Contains(item.SectionId)) continue;
                sectionids.Add(item.SectionId);
            }
            return sectionids.Count;
        }

        private bool IsSection(int sectionId)
        {
            foreach (SectionItem item in Sections)
            {
                if (sectionId == item.Id) return true;
            }
            return false;
        }
        private int GetScoreByType(int typeId)
        {
            int score = 0;
            foreach (LectureDetailItem item in LectureDetails)
            {
                if (item.LectureTypeId != typeId) continue;
                score += item.Credit;
            }
            return score;
        }

        private int GetScoreByCategory(int categoryId)
        {
            int score = 0;
            foreach (LectureDetailItem item in LectureDetails)
            {
                if (item.LectureCategoryId != categoryId) continue;
                score += item.Credit;
            }
            return score;
        }
    }
}