﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Domain.Impl.Services.Interfaces
{
    public interface ICreate<T>
    {
        T Create(T model);
    }
}
