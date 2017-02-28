﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanYou.Models.Info.LectureDetail
{
    public class LectureDetailItem
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int LectureCategoryId { get; set; }
        public int LectureTypeId { get; set; }
        public int SectionId { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public string Score { get; set; }
        public string LectureCategoryName { get; set; }
        public string LectureTypeName { get; set; }
        public string SectionName { get; set; }

    }
}