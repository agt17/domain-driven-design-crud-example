using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExam.Application.DTO;

namespace VuelingExam.Application.Business.Contract.ServiceLibrary
{
    public interface IUniversityApplication
    {
        StudentDto AddStudent(StudentDto model);
    }
}
