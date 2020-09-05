using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Repositories
{
    public interface IUnitOfWork
    {
        void Complete();
    }
}