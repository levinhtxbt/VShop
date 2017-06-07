namespace VShop.Repository
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}