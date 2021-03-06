﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanYou.Models.Info.LectureTypeRequirement
{
    public class LectureTypeRequirementItem
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int LectureTypeId { get; set; }
        public int Cutline { get; set; }
        public string LectureTypeName { get; set; }
        public string LectureCategoryName { get; set; }
        public int LectureCategoryId { get; set; }
    }
}