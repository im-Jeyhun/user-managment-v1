using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_management_v1.DataBase.Models
{
    public class Report
    {
        public static int _sira = 1;
        public int Sira { get; set; }
        public string FromWho { get; set; }

        public string ToWho { get; set; }
        public string Text { get; set; }

        public bool IsReporterAdmin { get; set; }
        public DateTime ReportTime { get; set; }

        public Report(string fromWho, string toWho, string text, bool ısReporterAdmin = false)
        {
            Sira = _sira++;
            FromWho = fromWho;
            ToWho = toWho;
            Text = text;
            ReportTime = DateTime.Now;
            IsReporterAdmin = ısReporterAdmin;
        }

        public virtual string GetReportInfoForUser()
        {
            return $"Sira No {Sira} , Kimden : {FromWho} , Kime : {ToWho} , Text : {Text} ,Sikayet olunan admindir mi {IsReporterAdmin} Report time : {ReportTime}";

        }
        public string GetReportInfoForAdmn()
        {
            return $"Sira No {Sira} , Kimden : {FromWho} , Kime : {ToWho} , Text : {Text} ,Sikayet olunan admindir mi {IsReporterAdmin = true} Report time : {ReportTime}";

        }
    }
}
