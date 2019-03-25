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
    public class SubjectRepository : IRepository<Subject>
    {
        private readonly static string connectionString = "server=localhost;database=School;Integrated Security=SSPI;";
        private readonly ILogger log;

        public SubjectRepository(ILogger logger)
        {
            this.log = logger;
        }

        public Subject Create(Subject model)
        {
            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string queryString = "INSERT INTO Subject(Id,Title,Description) " +
                                            "VALUES(@Id,@Title,@Description)";

                    using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = model.Id;
                        sqlCommand.Parameters.Add("@Title", SqlDbType.VarChar, 100).Value = model.Title;
                        sqlCommand.Parameters.Add("@Description", SqlDbType.VarChar, 250).Value = model.Description;
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

            Subject SubjectRead = ReadById(model.Id);

            log.Debug(SubjectRead +
                        System.Reflection.MethodBase.GetCurrentMethod().Name);
            return SubjectRead;
        }

        public List<Subject> ReadAll()
        {
            List<Subject> SubjectsList = new List<Subject>();

            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM dbo.Subject";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        sqlConnection.Open();
                        using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlReader.Read())
                            {
                                var Subject = new Subject
                                {
                                    Id = Convert.ToInt32(sqlReader["Id"].ToString()),
                                    Title = sqlReader["Title"].ToString(),
                                    Description = sqlReader["Description"].ToString()
                                };

                                SubjectsList.Add(Subject);
                                log.Debug(Subject +
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

            return SubjectsList;
        }

        public Subject ReadById(int id)
        {
            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Subject Subject = null;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string queryString = "SELECT * FROM Subject " +
                                                    "WHERE Id=@Id ";

                    using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                        using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                        {
                            if (sqlReader.Read())
                            {
                                Subject = new Subject
                                {
                                    Id = Convert.ToInt32(sqlReader["Id"].ToString()),
                                    Title = sqlReader["Title"].ToString(),
                                    Description = sqlReader["Description"].ToString()
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

            log.Debug(Subject +
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Subject;
        }

        public Subject Update(int id, Subject model)
        {
            Subject modelRead = null;

            string queryString = "UPDATE Subject (Id,Title,Description) " +
                                    "SET " +
                                        "Id=@Id, " +
                                        "Title=@Title, " +
                                        "Description=@Description " +
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
                        sqlCommand.Parameters.Add("@Title", SqlDbType.Int).Value = model.Title;
                        sqlCommand.Parameters.Add("@Description", SqlDbType.Int).Value = model.Description;
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

            string queryString = "DELETE FROM Subject " +
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
