namespace VShop.Repository
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        /// <exception>
        /// return false
        /// </exception>
        bool Commit();

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception>
        /// return -1
        /// </exception>
        int SaveChanges();
    }
}