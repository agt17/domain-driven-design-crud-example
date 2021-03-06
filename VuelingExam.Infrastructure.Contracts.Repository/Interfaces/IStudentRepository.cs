﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Infrastructure.Contracts.Repository.Interfaces
{
    public interface IStudentRepository<T, U> : ICreate<T, U>, IReadAll<U>, IReadById<U>
    {
    }
}
