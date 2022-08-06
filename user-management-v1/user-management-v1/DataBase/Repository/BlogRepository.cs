using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_management_v1.DataBase.Enums;
using user_management_v1.DataBase.Models;

namespace user_management_v1.DataBase.Repository
{
    public class BlogRepository : Common.Repository<Blog , int>
    {
        
        public BlogRepository()
        {
            //Entries.Add(new Blog( "Elave deyer askjjagskajs" , 1));
        }

        public static Blog AddBlog(User owner, string title, string content)
        {
            Blog blog = new Blog(owner, BlogStatus.Sended, title, content);
            Entries.Add(blog);
            return blog;
        }

      


    }
}
