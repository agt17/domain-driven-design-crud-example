using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Infrastructure.Contracts.Repository.Interfaces
{
    public interface IReadById<out T>
    {
        T ReadById(int id);
    }
}
