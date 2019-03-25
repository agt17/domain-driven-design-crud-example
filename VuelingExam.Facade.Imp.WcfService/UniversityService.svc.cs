using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VuelingExam.Application.Business.Contract.ServiceLibrary;
using VuelingExam.Application.DTO;
using VuelingExam.Common.Logic.Logging.Interfaces;

namespace VuelingExam.Facade.Imp.WcfService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UniversityService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UniversityService.svc o UniversityService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UniversityService : IUniversityService
    {
        private readonly ILogger Log;
        private readonly IUniversityApplication universityApplication;
        public UniversityService(ILogger Log,
            IUniversityApplication universityApplication)
        {
            this.Log = Log;
            this.universityApplication = universityApplication;
        }

        public StudentDto AddStudent(StudentDto model)
        {
            Log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            return universityApplication.AddStudent(model);
        }
        
    }
}
