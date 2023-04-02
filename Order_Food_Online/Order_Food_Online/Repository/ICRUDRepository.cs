namespace Order_Food_Online.Repository
{
    public interface ICRUDRepository<T>
    {
        public List<T> GetAll();
        public List<T> GetAll(int id);


        public T GetDetails(int id);

        public void Insert(T item);

        public void Update(int id, T updatedItem);

        public void Delete(T item);

        public T GetbyID(int id);
    }
}
