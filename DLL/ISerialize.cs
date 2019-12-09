using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISerialize<T> where T : class
    {
        void Save(T[] Date);
        T[] Load();
    }
}

