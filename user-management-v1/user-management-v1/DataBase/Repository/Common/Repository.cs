using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_management_v1.DataBase.Models.Common;

namespace user_management_v1.DataBase.Repository.Common
{
    public class Repository<T, TId>
        where T : Entity<TId>
    {
        protected static List<T> Entries { get; set; } = new List<T>()
        {


        };

        public T Add(T entry)
        {
            Entries.Add(entry);
            return entry;
        }

        public void Delete(T entry)
        {
            Entries.Remove(entry);
        }

        public List<T> GetAll()
        {
            return Entries;
        }

        public T GetById(TId id)
        {
            foreach (T entry in Entries)
            {

                if (Equals(entry.Id, id))
                {
                    return entry;
                }
            }
            return default(T);
        }

        public T Get (Predicate<T> expression)
        {
            foreach(T entry in Entries)
            {
                if(expression(entry))
                {
                    return entry;
                }
            }
            return null;
        }
        public T Update(TId id, T newentry)
        {
            //T dbentry = GetById(id);

            //if (dbentry != default(T))
            //{
            //    dbentry = newentry;

            //    dbentry.Id = id;

            //}

            T entry = GetById(id);
            newentry.CreatedAt = entry.CreatedAt;
            newentry.Id = entry.Id;
            entry = newentry;

           
      

            return entry;

        }
    }
}
