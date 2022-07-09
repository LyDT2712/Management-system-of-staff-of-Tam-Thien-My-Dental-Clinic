using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace PROJECT1.BusinessLayer.Interface
{
    interface CRUD<T>
    {
        List<T> GetList();

        void Add(T myObject);

        void Update(string id, T newInfo);

        void Delete(string id);

        int Find(string id);

        void SaveAll(List<T> list);
    }
}
