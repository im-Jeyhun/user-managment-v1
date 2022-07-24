using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_management_v1.DataBase.Models
{
    public class Admin : User
    {
        public static int _sira = 1;
        public int Sira { get; set; }
        //normal admin elave elemek ucun.
        public Admin(string name, string lastName, string email, string password)
            : base(name, lastName, email, password)
        {
            Sira = _sira++;
        }

        //sildikden sonra admin elave etmek ucun
        public Admin(string name, string lastName, string email, string password, int id)
            : base(name, lastName, email, password, id)
        {
            Sira = _sira++;

        }

        //Update etmek ucun
        public Admin(string name, string lastName)
            : base(name, lastName)
        {

        }

        public override string GetUserInfo()
        {
            return $"Sira no : {Sira}, Istifadeci id : {Id} , Istifadeci adi : {Name} , soyadi : {LastName} , emaili : {Email} , qeydiyyat tarixi : {RegistrationDate}";

        }
    }
}
