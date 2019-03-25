using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Infrastructure.Contracts.Repository.Interfaces
{
    public interface IUpdate<in T, out U>
    {
        U Update(int id, T model);
    }
}
