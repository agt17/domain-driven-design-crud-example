using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Infrastructure.Contracts.Repository.Interfaces
{
    public interface IReadAll<U>
    {
        List<U> ReadAll();
    }
}
