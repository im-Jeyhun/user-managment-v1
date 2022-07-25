using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_management_v1.DataBase.Repository;

namespace user_management_v1.DataBase.Models
{
    public class User
    {

        public int Id { get; private set; }
 
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public static List<Report> Reports { get; set; } = new List<Report>();
        protected DateTime RegistrationDate { get; } = DateTime.Now;

      
        public User(List<Report> report)
        {
            Reports = report;
        }

        //bu sildikden sonra elavet etmek ucun
        public User(string name, string lastName, string email, string password, int id)
        {
          
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Id = id;       

        }
        // bu normal elave etmek ucun.
        public User(string name, string lastName, string email, string password)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Id = UserRepository.IdCounter;
        }

        public User(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public virtual string GetUserInfo()
        {
            return $"Istifadeci adi : {Name} , soyadi : {LastName} , emaili : {Email} ";

        }

    }
}
