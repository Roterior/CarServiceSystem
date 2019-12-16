namespace CarServiceSystem.src.util
{
    interface ICrudService<T, K>
    {
        T Create(T entity);

        T Update(T entity);

        T GetById(K id);
    }
}
