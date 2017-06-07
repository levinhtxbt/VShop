using System;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using VShop.Common;
using VShop.Data;

namespace VShop.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private VShopDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public VShopDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public bool Commit()
        {
            try
            {
                DbContext.SaveChanges();
                return true;
            }
            catch (OptimisticConcurrencyException ex)
            {
                Log.Entity(ex);
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Log.Entity(String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Log.Entity(String.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }

                Log.Entity(ex);
                return false;
            }
            catch (Exception ex)
            {
                Log.Entity(ex);
                return false;
            }
        }
    }
}