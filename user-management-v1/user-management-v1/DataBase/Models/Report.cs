using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_management_v1.DataBase.Models.Common;
using user_management_v1.DataBase.Repository;

namespace user_management_v1.DataBase.Models
{
    public class Report : Entity<Guid>
    {
        //public int Id { get; set; }

        public User From { get; set; }

        public User To { get; set; }

        public string Text { get; set; }

        public DateTime ReportTime { get; set; }

        public Report(User fromWho, User toWho, string text)
        {

            From = fromWho;
            To = toWho;
            Text = text;
            ReportTime = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public string GetReportInfo()
        {
            return $"Kimden : {From.Email} , Kime : {To.Email} , Text : {Text} , Sikayet olunan admindir mi {To is Admin} Report time : {ReportTime}";

        }
      
    }
}
