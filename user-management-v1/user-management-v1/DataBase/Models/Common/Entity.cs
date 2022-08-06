using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_management_v1.DataBase.Models.Common
{
    public abstract class Entity<TId>
    {
        public TId Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
