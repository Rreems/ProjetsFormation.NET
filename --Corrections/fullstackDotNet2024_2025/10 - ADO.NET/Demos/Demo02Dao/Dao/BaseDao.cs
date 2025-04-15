using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02Dao.Dao
{
    internal abstract class BaseDAO<T>
    {
        protected string request = "";

        public abstract T Save(T element);
        public abstract T Update(/*int id,*/ T element);
        public abstract List<T> GetAll();
        public abstract T? GetOneById(int id);
    }
}
