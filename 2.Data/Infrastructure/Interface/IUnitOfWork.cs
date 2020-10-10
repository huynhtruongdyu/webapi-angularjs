namespace _2.Data.Repository.Implement
{
    public interface IUnitOfWork
    {
        void CreateTransaction();

        void Commit();

        void RollBack();
    }
}