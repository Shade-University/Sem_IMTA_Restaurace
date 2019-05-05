﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sem_IMTA_Restaurace.Services
{
    interface IDataStore<T>
    {
        void AddItem(T item);
        void UpdateItem(T item);
        void DeleteItem(string id);
        T GetItem(string id);
        IEnumerable<T> GetAllItems();

        void RemoveAll();
    }
}
