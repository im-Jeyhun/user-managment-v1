using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_management_v1.DataBase.Enums;
using user_management_v1.DataBase.Models.Common;
using user_management_v1.DataBase.Repository;

namespace user_management_v1.DataBase.Models
{
    public class Blog : Entity<int>
    {
        //public int Id { get; set; }

        public  User Owner { get; set; }

        public string Title { get; set; }

        public  BlogStatus BlogStatus { get; set; }

        public  string Content { get; set; }

        //public DateTime CreatedAt { get; set; }

        public Blog(User owner, BlogStatus blogStatus  , string title ,string content , int? id = null )
        {
            Owner = owner;
            Title = title;
            Content = content;
            if(id != null)
            {
                Id = id.Value;
            }
            else
            {

            Id = UserRepository.IdCounter;
            }
            CreatedAt = DateTime.Now;
            BlogStatus = blogStatus;

        }

        public string GetBlogInfo()
        {
            return "Blog id : " + Id + " " + "Blog owner :" + Owner.Name + " " + "Blog title :" + Title + " " + "Blog content :" + Content + " " + "Blog creating time :" + CreatedAt + "Blog status : " + BlogStatus ;
        }


    }
}
