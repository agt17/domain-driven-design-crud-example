using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExam.Common.Logic.Logging.Interfaces;
using VuelingExam.Domain.BusinessEntities;
using VuelingExam.Domain.Impl.Services.Exceptions;
using VuelingExam.Domain.Impl.Services.Interfaces;
using VuelingExam.Infrastructure.Contracts.Repository.Interfaces;
using VuelingExam.Infrastructure.DataModel;

namespace VuelingExam.Domain.Impl.Services
{
    public class EnrollmentCrudDomain : IDomainRepository<EnrollmentEntity>
    {
        private readonly IRepository<Enrollment> Repository;
        private readonly ILogger log;

        public EnrollmentCrudDomain(IRepository<Enrollment> repository, ILogger logger)
        {
            this.Repository = repository;
            this.log = logger;
        }

        public Enrollment Create(Enrollment model)
        {
            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Enrollment EnrollmentCreated = null;

            try
            {
                EnrollmentCreated = Repository.Create(model);
            }
            catch (VuelingDomainException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingDomainException(
                    ex.Message, ex.InnerException);
            }

            log.Debug(EnrollmentCreated +
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            return EnrollmentCreated;
        }

        public List<Enrollment> ReadAll()
        {
            List<Enrollment> EnrollmentsList;

            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            try
            {
                EnrollmentsList = Repository.ReadAll();
            }
            catch (VuelingDomainException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingDomainException(
                    ex.Message, ex.InnerException);
            }

            return EnrollmentsList;
        }

        public Enrollment ReadById(int id)
        {
            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Enrollment EnrollmentRead;

            try
            {
                EnrollmentRead = Repository.ReadById(id);
            }
            catch (VuelingDomainException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingDomainException(
                    ex.Message, ex.InnerException);
            }

            log.Debug(EnrollmentRead +
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            return EnrollmentRead;
        }

        public Enrollment Update(int id, Enrollment model)
        {
            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Enrollment EnrollmentUpdated = null;

            try
            {
                EnrollmentUpdated = Repository.Update(id, model);
            }
            catch (VuelingDomainException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingDomainException(
                    ex.Message, ex.InnerException);
            }

            log.Debug(EnrollmentUpdated +
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            return EnrollmentUpdated;
        }

        public int Delete(int id)
        {
            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            int rowsAffected = 0;

            try
            {
                rowsAffected = Repository.Delete(id);
            }
            catch (VuelingDomainException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingDomainException(
                    ex.Message, ex.InnerException);
            }

            log.Debug(rowsAffected +
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            return rowsAffected;
        }
    }
}
