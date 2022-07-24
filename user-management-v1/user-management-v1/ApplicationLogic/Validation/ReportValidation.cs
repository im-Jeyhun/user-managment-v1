using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_management_v1.ApplicationLogic.Validation
{
    public class ReportValidation
    {
        public static bool IsReportTextValid(string name, int start, int end)
        {
            if (Validations.IsLengthCorrect(name, start, end))
            {
                return true;
            }
            Console.WriteLine("Report text must be between 3 and 30 chars");
            return false;
        }

        public static string GetReportText()
        {
            bool isEceptionValid;
            string text = null;
            do
            {

                try
                {
                    Console.Write("Insert Report Text : ");
                    text = Console.ReadLine();
                    if (text == "null")
                    {
                        throw new Exception();
                    }
                    isEceptionValid = false;
                }
                catch (Exception)
                {

                    isEceptionValid = true;
                    Console.WriteLine("Seflik var");
                }

            } while (isEceptionValid || !ReportValidation.IsReportTextValid(text, 3, 30));


            return text;
        }
    }
}
