using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_management_v1.DataBase.Models
{
    public class Admin : User
    {
        
        //normal admin elave elemek ucun.
        public Admin(string name, string lastName, string email, string password)
            : base(name, lastName, email, password)
        {
        }

        //sildikden sonra admin elave etmek ucun
        public Admin(string name, string lastName, string email, string password, int id)
            : base(name, lastName, email, password, id)
        {

        }

        //Update etmek ucun
        public Admin(string name, string lastName)
            : base(name, lastName)
        {

        }

        public override string GetUserInfo()
        {
            return $"Istifadeci id : {Id} , Istifadeci adi : {Name} , soyadi : {LastName} , emaili : {Email} , qeydiyyat tarixi : {RegistrationDate}";

        }
    }
}
