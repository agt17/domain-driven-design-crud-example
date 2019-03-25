using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExam.Application.Business.Contract.ServiceLibrary;
using VuelingExam.Application.Business.Impl.ServiceLibrary.Exceptions;
using VuelingExam.Application.DTO;
using VuelingExam.Common.Automapper;
using VuelingExam.Common.Logic.Logging.Interfaces;
using VuelingExam.Domain.BusinessEntities;
using VuelingExam.Infrastructure.Contracts.Repository.Interfaces;
using VuelingExam.Infrastructure.DataModel;

namespace VuelingExam.Application.Business.Impl.ServiceLibrary
{
    public class UniversityApplication : IUniversityApplication
    {
        private readonly IStudentRepository<StudentEntity, Student> StudentRepository;
        private readonly ILogger log;

        public UniversityApplication(IStudentRepository<StudentEntity, Student> studentRepository, ILogger logger)
        {
            this.StudentRepository = studentRepository;
            this.log = logger;
        }

        public StudentDto AddStudent(StudentDto model)
        {
            log.Debug(StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().Name +
                StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            StudentDto studentDtoCreated;

            AutomapperClass map = new AutomapperClass();
            StudentEntity StudentEntity = map.Map<StudentDto, StudentEntity>(model);

            try
            {
                Student studentCreated = StudentRepository.Create(StudentEntity);
                StudentEntity studentEntityCreated = map.Map<Student, StudentEntity>(studentCreated);
                // calculated fields using domain with studentEntity

                studentDtoCreated = map.Map<StudentEntity, StudentDto>(studentEntityCreated);
            }
            catch (VuelingApplicationException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingApplicationException(
                    ex.Message, ex.InnerException);
            }

            log.Debug(studentDtoCreated +
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            return studentDtoCreated;
        }
    }
}
