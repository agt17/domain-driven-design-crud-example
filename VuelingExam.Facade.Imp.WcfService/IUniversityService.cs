using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VuelingExam.Application.DTO;

namespace VuelingExam.Facade.Imp.WcfService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUniversityService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUniversityService
    {
        [OperationContract]
        StudentDto AddStudent(StudentDto model);
    }
}
