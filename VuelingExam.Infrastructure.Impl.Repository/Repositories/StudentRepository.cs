using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExam.Common.Automapper;
using VuelingExam.Common.Logic.Logging.Interfaces;
using VuelingExam.Domain.BusinessEntities;
using VuelingExam.Infrastructure.Contracts.Repository.Interfaces;
using VuelingExam.Infrastructure.DataModel;
using VuelingExam.Infrastructure.Impl.Repository.Exceptions;

namespace VuelingExam.Infrastructure.Impl.Repository.Repositories
{
    public class StudentRepository : IStudentRepository<StudentEntity, Student>
    {
        //private readonly static string connectionString = "server=localhost;database=School;Integrated Security=SSPI;";
        private readonly ILogger log;

        public StudentRepository(ILogger logger)
        {
            this.log = logger;
        }

        public Student Create(StudentEntity model)
        {
            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                   StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            try
            {
                AutomapperClass map = new AutomapperClass();
                Student student = map.Map<StudentEntity, Student>(model);

                using (var db = new SchoolEntities())
                using (var transaction = db.Database.BeginTransaction())
                {
                    db.Student.Add(student);
                    foreach (Enrollment enrollment in student.Enrollment)
                    {
                        db.Enrollment.Add(enrollment);
                    }
                    db.SaveChanges();
                }
            }
            #region Exceptions
            catch (ObjectDisposedException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            catch (DbEntityValidationException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            catch (DbUpdateException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            catch (NotSupportedException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            #endregion
            /*try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string queryString = "INSERT INTO Student(Id,FirstName,LastName) " +
                                            "VALUES(@Id,@FirstName,@LastName)";

                    using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = model.Id;
                        sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = model.FirstName;
                        sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar, 100).Value = model.LastName;
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
            #endregion*/

            Student StudentRead = ReadById(model.Id);

            log.Debug(StudentRead +
                        System.Reflection.MethodBase.GetCurrentMethod().Name);
            return StudentRead;
        }
        
        public List<Student> ReadAll()
        {
            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                   StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            List<Student> StudentsList;

            try
            {
                using (var db = new SchoolEntities())
                {
                    StudentsList = db.Student.ToList();
                }
            }
            #region Exceptions
            catch (ArgumentNullException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            #endregion

            return StudentsList;

            /*List<Student> StudentsList = new List<Student>();

            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM dbo.Student";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        sqlConnection.Open();
                        using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlReader.Read())
                            {
                                var Student = new Student
                                {
                                    Id = Convert.ToInt32(sqlReader["Id"].ToString()),
                                    FirstName = sqlReader["FirstName"].ToString(),
                                    LastName = sqlReader["LastName"].ToString()
                                };

                                StudentsList.Add(Student);
                                log.Debug(Student +
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

            return StudentsList;*/
        }

        public Student ReadById(int id)
        {
            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                   StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Student StudentRead = null;

            try
            {
                using (var db = new SchoolEntities())
                {
                    StudentRead = db.Student.Where(s => s.Id == id).FirstOrDefault();
                }
            }
            #region Exceptions
            catch (ArgumentNullException ex)
            {
                log.Error(ex.Message);
                log.Info(ex.StackTrace);
                throw new VuelingInfrastructureException(
                    ex.Message, ex.InnerException);
            }
            #endregion

            return StudentRead;
            /*log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                StringResources.DebugClass + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Student Student = null;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string queryString = "SELECT * FROM Student " +
                                                    "WHERE Id=@Id ";

                    using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                        using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                        {
                            if (sqlReader.Read())
                            {
                                Student = new Student
                                {
                                    Id = Convert.ToInt32(sqlReader["Id"].ToString()),
                                    FirstName = sqlReader["FirstName"].ToString(),
                                    LastName = sqlReader["LastName"].ToString()
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

            log.Debug(Student +
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Student;*/
        }

        /*
        public Student Update(int id, StudentEntity model)
        {
            Student modelRead = null;

            string queryString = "UPDATE Student (Id,FirstName,LastName) " +
                                    "SET " +
                                        "Id=@Id, " +
                                        "FirstName=@FirstName, " +
                                        "LastName=@LastName " +
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
                        sqlCommand.Parameters.Add("@FirstName", SqlDbType.Int).Value = model.FirstName;
                        sqlCommand.Parameters.Add("@LastName", SqlDbType.Int).Value = model.LastName;
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

            string queryString = "DELETE FROM Student " +
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
        }*/

    }
}
