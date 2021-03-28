using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Infrastructure.Application
{
    public interface UnitOfWork:IDisposable,IAsyncDisposable
    {
        Task Complate(); 
    }
}
