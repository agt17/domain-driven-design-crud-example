using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Domain.Impl.Services.Interfaces
{
    public interface IDomainRepository<T> : ICreate<T>, IReadAll<T>, IReadById<T>, IUpdate<T>, IDelete<T>
    {
    }
}
