using VShop.Model;
using VShop.Repository;

namespace VShop.Service
{
    public class LogService : ILogService
    {
        private ILogErrorRepository _repository;
        private IUnitOfWork _unitOfWork;

        public LogService(ILogErrorRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public LogError CreateLog(LogError log)
        {
            return _repository.Add(log);
        }
    }
}