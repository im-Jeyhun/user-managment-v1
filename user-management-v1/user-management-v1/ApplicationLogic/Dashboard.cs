using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_management_v1.ApplicationLogic.Validation;
using user_management_v1.DataBase.Models;
using user_management_v1.DataBase.Repository;
using user_management_v1.UI;

namespace user_management_v1.ApplicationLogic
{
    public partial class Dashboard
    {
        public static void AdminPanel(string email)
        {
            User user = UserRepository.GetByEmail(email);
            Console.WriteLine($"Welcome admin : {user.GetUserInfo()}");
            while (true)
            {


                Console.WriteLine("Admin commands are : /add-user , /update-user ," +
                    " /remove-user , /reports, /add-admin," +
                    "/show-admins,/update-admin, /make-admin , /remove-admin, /show-users, /logout");

                Console.Write("Enter suitable command : ");
                string command = Console.ReadLine();

                if (command == "/add-user")
                {
                    Authentication.Register();
                }
                else if (command == "/update-user")
                {
                    while (true)
                    {
                        Console.WriteLine("Enter email who u want to update");
                        string updatedUserEmail = Console.ReadLine();
                        User updatedUser = UserRepository.GetByEmail(updatedUserEmail);

                        if (updatedUser.Email == email)
                        {
                            Console.WriteLine("Deyismek isediyiniz admin ile daxil olmusunuz");
                        }
                        else if (updatedUser == null)
                        {
                            Console.WriteLine("Admin tapilmadi");
                        }
                        else
                        {

                            if (updatedUser is User)
                            {
                                User uppUser = new User(UserValidation.GetName(), UserValidation.GetLastName());
                                UserRepository.UpdateForUser(updatedUserEmail, uppUser);
                                Console.WriteLine("User update olundu");
                                break;
                            }
                            else if (updatedUser is Admin)
                            {
                                Console.WriteLine("Bu emaile mexsus istifadeci Admindir...");
                            }

                        }
                    }
                }
                else if (command == "/remove-user")
                {
                    while (true)
                    {
                        Console.Write("Enter email who u want to delete : ");
                        string deletedEmail = Console.ReadLine();
                        User deletedUser = UserRepository.GetByEmail(deletedEmail);
                        if (deletedUser == null)
                        {
                            Console.WriteLine("Emaile gore istifadeci tapilmadi");
                        }
                        else if (deletedUser is Admin)
                        {
                            Console.WriteLine("Emaile gore tapilan istifadeci admindir ...");
                        }
                        else
                        {
                            UserRepository.Delete(deletedUser);
                            Console.WriteLine("User deleted succesfully");
                            break;
                        }
                    }
                }
                else if (command == "/reports")
                {
                    List<Report> reportList = UserRepository.GetReports();

                    foreach (Report report in reportList)
                    {
                        Console.WriteLine(report.GetReportInfoForAdmn());
                    }
                }
                else if (command == "/add-admin")
                {
                    Admin newAdmin = new Admin(UserValidation.GetName(), UserValidation.GetLastName(), UserValidation.GetEmail(), UserValidation.GetPassword());
                    UserRepository.Add(newAdmin);
                    Console.WriteLine($"New admin added succesfully {newAdmin.GetUserInfo()} ");
                }
                else if (command == "/show-admins")
                {
                    List<User> admin = UserRepository.GetAll();

                    foreach (User admins in admin)
                    {
                        if (admins is Admin)
                        {
                            Console.WriteLine(admins.GetUserInfo());
                        }
                    }
                }
                else if (command == "/update-admin")
                {
                    while (true)
                    {
                        Console.WriteLine("Enter admin email which u want to update admin's details");
                        string updatedAdmin = Console.ReadLine();
                        User admin = UserRepository.GetByEmail(updatedAdmin);
                        if (admin.Email == email)
                        {
                            Console.WriteLine("Deyismek isediyiniz admin ile daxil olmusunuz");
                        }
                        else if (admin == null)
                        {
                            Console.WriteLine("Admin tapilmadi");
                        }
                        else
                        {

                            if (admin is Admin)
                            {
                                Admin uppAdmin = new Admin(UserValidation.GetName(), UserValidation.GetLastName());
                                UserRepository.UpdateForAdmin(updatedAdmin, uppAdmin);
                                Console.WriteLine("Admin update olundu");
                                break;
                            }
                            else if (admin is User)
                            {
                                Console.WriteLine("Bu emaile mexsus istifadeci Userdir...");
                            }

                        }
                    }
                }
                else if (command == "/remove-admin")
                {
                    while (true)
                    {
                        Console.WriteLine("Enter Admin email for remove Admin : ");
                        string removedAdminEmail = Console.ReadLine();

                        Admin findedAdmin = UserRepository.GetByEmailForAdmin(removedAdminEmail);
                        //User findedAdmin = UserRepository.GetByEmail(removedAdminEmail);

                        if (findedAdmin.Email == removedAdminEmail)
                        {
                            Console.WriteLine("Silmek istediyiniz admin istifadecisindesiz");
                        }
                        else if (findedAdmin == null)
                        {

                            Console.WriteLine("Admin tapilmadi bu emaile");
                        }
                        else
                        {

                            if (findedAdmin is User)
                            {
                                Console.WriteLine("Istifadeci Adi userdi");
                            }
                            else if (findedAdmin is Admin)
                            {
                                UserRepository.Delete(findedAdmin);
                                Console.WriteLine("Admin silindi");
                                break ;
                            }
                    }
                }
                }
                else if (command == "/make-admin")
                {
                    Console.WriteLine("Insert emial who u want do make admin");
                    string userEmail = Console.ReadLine();
                    User user1 = UserRepository.GetByEmail(userEmail);
                    if (user1 == null)
                    {
                        Console.WriteLine("Email ile istifadeci tapilmadi");
                    }
                    else
                    {
                        UserRepository.Delete(user1);

                        Admin admin1 = new Admin(user1.Name, user1.LastName, user1.Email, user1.Password, user1.Id);

                        UserRepository.Add(admin1);
                    }
                }
                else if (command == "/show-users")
                {
                    List<User> showedUser = UserRepository.GetAll();
                    foreach (User users in showedUser)
                    {
                        if (users is User)
                        {
                            Console.WriteLine(users.GetUserInfo());
                        }

                    }
                }

                else if (command == "/logout")
                {
                    Program.Main(new string[] { });
                    break;
                }
            }
        }
    }
    public partial class Dashboard
    {
        public static void UserPanel(string email)
        {
            User user = UserRepository.GetByEmail(email);
            Console.WriteLine($"User succesfully joined : {user.GetUserInfo()}");
            while (true)
            {
                Console.WriteLine("User commands are : /update-info , /report-user , /logout");
                string command = Console.ReadLine();

                if (command == "/update-info")
                {
                    if (user.Email == email)
                    {
                        User updateUser = new User(UserValidation.GetName(), UserValidation.GetLastName());
                        UserRepository.UpdateForUser(email, updateUser);
                    }
                }
                else if (command == "/report-user")
                {
                    Console.WriteLine("Enter report etmek istediyin adamin mailini");
                    string reporingEmail = Console.ReadLine();
                    Console.WriteLine("Enter report text : ");
                    string reportText = ReportValidation.GetReportText();
                    User reporter = UserRepository.GetByEmail(reporingEmail);

                    if (reporter.Email == email)
                    {
                        Console.WriteLine("User ozu ozunu report ede bilmez");
                    }
                    else
                    {

                        Report reporT = UserRepository.AddReport(email, reporter.Email, reportText);


                    }
                }
                else if (command == "/logout")
                {
                    Program.Main(new string[] { });
                    break;
                }
                else
                {
                    Console.WriteLine("Command not found...");
                }
            }


        }
    }
}
