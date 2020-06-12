namespace Core.InterFace
{
    public interface IUnitOfWork <T> where T: class
    {
        IGenericRepository<T> Entity { get; }
            void save();
    }
}
