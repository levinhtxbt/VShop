using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VShop.Model;

namespace VShop.Service
{
    public interface ILogService
    {
        LogError CreateLog(LogError log);
    }
}
