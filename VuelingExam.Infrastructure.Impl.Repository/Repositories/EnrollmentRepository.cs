using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExam.Common.Logic.Logging.Interfaces;
using VuelingExam.Infrastructure.Contracts.Repository.Interfaces;
using VuelingExam.Infrastructure.DataModel;
using VuelingExam.Infrastructure.Impl.Repository.Exceptions;

namespace VuelingExam.Infrastructure.Impl.Repository.Repositories
{
    public class EnrollmentRepository : IRepository<Enrollment>
    {
        private readonly static string connectionString = "server=localhost;database=School;Integrated Security=SSPI;";
        private readonly ILogger log;

        public EnrollmentRepository(ILogger logger)
        {
            this.log = logger;
        }

        public Enrollment Create(Enrollment model)
        {
            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string queryString = "INSERT INTO Enrollment(Id,StudentId,SubjectId) " +
                                            "VALUES(@Id,@StudentId,@SubjectId)";

                    using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = model.Id;
                        sqlCommand.Parameters.Add("@StudentId", SqlDbType.Int).Value = model.StudentId;
                        sqlCommand.Parameters.Add("@SubjectId", SqlDbType.Int).Value = model.SubjectId;
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            #region Exceptions
            catch (InvalidOperationException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            catch (SqlException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            catch (InvalidCastException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            #endregion

            Enrollment EnrollmentRead = ReadById(model.Id);

            log.Debug(EnrollmentRead +
                        System.Reflection.MethodBase.GetCurrentMethod().Name);
            return EnrollmentRead;
        }

        public List<Enrollment> ReadAll()
        {
            List<Enrollment> EnrollmentsList = new List<Enrollment>();

            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM dbo.Enrollment";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        sqlConnection.Open();
                        using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlReader.Read())
                            {
                                var Enrollment = new Enrollment
                                {
                                    Id = Convert.ToInt32(sqlReader["Id"].ToString()),
                                    StudentId = Convert.ToInt32(sqlReader["StudentId"].ToString()),
                                    SubjectId = Convert.ToInt32(sqlReader["SubjectId"].ToString())
                                };

                                EnrollmentsList.Add(Enrollment);
                                log.Debug(Enrollment +
                                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                            }
                        }
                    }
                }
            }
            #region Exceptions
            catch (InvalidOperationException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            catch (FormatException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            catch (SqlException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            catch (InvalidCastException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            catch (OverflowException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            #endregion

            return EnrollmentsList;
        }

        public Enrollment ReadById(int id)
        {
            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Enrollment Enrollment = null;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string queryString = "SELECT * FROM Enrollment " +
                                                    "WHERE Id=@Id ";

                    using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                        using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                        {
                            if (sqlReader.Read())
                            {
                                Enrollment = new Enrollment
                                {
                                    Id = Convert.ToInt32(sqlReader["Id"].ToString()),
                                    StudentId = Convert.ToInt32(sqlReader["StudentId"].ToString()),
                                    SubjectId = Convert.ToInt32(sqlReader["SubjectId"].ToString())
                                };
                            }
                        }
                    }

                }
            }
            #region Exceptions
            catch (InvalidOperationException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            catch (FormatException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            catch (SqlException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            catch (InvalidCastException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            catch (OverflowException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            #endregion

            log.Debug(Enrollment +
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Enrollment;
        }

        public Enrollment Update(int id, Enrollment model)
        {
            Enrollment modelRead = null;

            string queryString = "UPDATE Enrollment (Id,StudentId,SubjectId) " +
                                    "SET " +
                                        "Id=@Id, " +
                                        "StudentId=@StudentId, " +
                                        "SubjectId=@SubjectId " +
                                    "WHERE Id=@Id";

            log.Debug(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        sqlCommand.Parameters.Add("@StudentId", SqlDbType.Int).Value = model.StudentId;
                        sqlCommand.Parameters.Add("@SubjectId", SqlDbType.Int).Value = model.SubjectId;
                        sqlCommand.ExecuteNonQuery();

                        modelRead = ReadById(model.Id);

                        log.Debug(modelRead +
                                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
            }
            #region Exceptions
            catch (InvalidOperationException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw;
            }
            catch (SqlException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw;
            }
            catch (InvalidCastException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw;
            }
            #endregion

            return modelRead;
        }

        public int Delete(int id)
        {
            int rowsAffected;

            string queryString = "DELETE FROM Enrollment " +
                                    "WHERE Id=@Id";

            log.Debug(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                        rowsAffected = sqlCommand.ExecuteNonQuery();

                        log.Debug(rowsAffected +
                                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
            }
            #region Exceptions
            catch (InvalidOperationException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw;
            }
            catch (SqlException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw;
            }
            catch (InvalidCastException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw;
            }
            #endregion

            return rowsAffected;
        }

    }
}
