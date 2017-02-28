using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanYou.Models.Service
{
    public class ResultDetailItem
    {
        public string Name { get; set; }
        public int Requirement { get; set; }
        public int Score { get; set; }
        public string GetResult(){
            string type = Name.Contains("영역") ? "개의 영역" : "학점";
            if (Score > Requirement)
            {
                return (Score - Requirement).ToString() + type + " 초과 이수하였습니다.";
            }
            else if(Score == Requirement)
            {
                return "이수 요건을 만족하였습니다.";
            }
            else
            {
                return (Requirement - Score).ToString() + type + " 이 부족합니다.";
            }
        }

        
        public bool IsPassed()
        {
            return (Score >= Requirement);
        }
    }
}
