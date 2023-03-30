﻿namespace Order_Food_Online.Repository
{
    public interface ICRUDRepository<T>
    {
        public List<T> GetAll();

        public T GetDetails(int id);

        public void Insert(T item);

        public void Update(int id, T updatedItem);

        public void Delete(T item);
    }
}