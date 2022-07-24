using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_management_v1.DataBase.Models;

namespace user_management_v1.DataBase.Repository
{
    public class UserRepository
    {
        private static int _idCounter;

        public static int IdCounter
        {
            get
            {
                _idCounter++;
                return _idCounter;
            }

        }
        private static List<Report> reports = new List<Report>()
        {
            new Report("ceyhunhaciada@gmail.com", "elieliyev@gmail.com" , "yatib qalmisan yene pulek")
        };
        private static List<User> Users { get; set; } = new List<User>()
        {
            new Admin("Super","Admin", "admin@gmail.com","123321" /*, false, true*/ ),
            new Admin ("Ceyhun" , "Hacizada" , "ceyhun@gmail.com", "123456Az"),
            new User ("Eli" , "Eliyev" , "elieliyev@gmail.com", "123321Eli"),
            

        };
        //normal user elave etmek.
        public static User Add(string name, string lastName, string email, string password)
        {

            User user = new User(name, lastName, email, password, IdCounter);
            Users.Add(user);
            return user;
        }

        //admin silinenden sonra user kimi liste elave edilmekdir.
        public static User Add(string name, string lastName, string email, string password, int id)
        {

            User user = new User(name, lastName, email, password, id);
            Users.Add(user);
            return user;
        }



        public static User Add(User user)
        {
            Users.Add(user);
            return user;
        }


        public static User Add(Admin admin)
        {
            Users.Add(admin);
            return admin;
        }
        public static Report AddReport(string fromwho, string towho, string text)
        {

            List<Report> reports = new List<Report>();
            Report report = new Report(fromwho, towho, text);
            reports.Add(report);
            return report;
        }


        public static void Remove(string email)
        {
            foreach (User user1 in Users)
            {
                if (user1.Email == email)
                {
                    Users.Remove(user1);
                }
            }
        }
        public static void Delete(User user)
        {
            Users.Remove(user);
        }
        public static void DeleteAdmin(Admin admin)
        {
            Users.Remove(admin);
        }
        public static bool IsEmailExists(string email)
        {
            foreach (User user in Users)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public static User GetByEmail(string email)
        {
            foreach (User user in Users)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }

        public static Admin GetByEmailForAdmin(string email)
        {
            foreach (Admin admin in Users)
            {
                if (admin.Email == email)
                {
                    return admin;
                }
            }
            return null;
        }

        public static bool IsUserExistsByEmailAndPassword(string email, string password)
        {
            foreach (User user in Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true;
                }
            }
            return false;

        }
        public static List<Report> GetReports()
        {
            return reports;
        }
        public static List<User> GetAll()
        {
            return Users;
        }

        public static User UpdateForUser(string email, User user)
        {
            User findedUser = UserRepository.GetByEmail(email);

            findedUser.Name = user.Name;
            findedUser.LastName = user.LastName;


            return findedUser;
        }

        public static User UpdateForAdmin(string email, Admin admin)
        {
            User findedAdmin = UserRepository.GetByEmail(email);
            findedAdmin.Name = admin.Name;
            findedAdmin.LastName = admin.LastName;

            return findedAdmin;

        }
    }
}
