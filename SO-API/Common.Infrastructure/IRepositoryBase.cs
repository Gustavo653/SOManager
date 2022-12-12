namespace Common.Infrastructure
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetEntities();
        IQueryable<T> GetTrackedEntities();
        Task<IEnumerable<T>> GetListAsync();
        void Insert(T entity);
        void InsertRange(IEnumerable<T> entity);
        Task InsertAsync(T entity);
        void Update(T entity);
        void UpdateRange(T[] entity);
        void Delete(T entity);
        void DeleteRange(T[] entity);
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
        T Clone(T entity);
        void Attach(T entity);
        void AttachRange(IEnumerable<T> entity);
        void GetChanges();
    }
}
