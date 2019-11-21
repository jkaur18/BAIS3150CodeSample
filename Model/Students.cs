using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Jkaur18BAIS3150CodeSample.Model
{
    public class Students
    {
        public Student GetStudent(string StudentID)
        {
            SqlConnection ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @"Data Source= (LocalDB)\MSSQLLocalDB; 
                                                        Initial Catalog = ClubBaist;
                                                     Integrated Security = True";

            SqlCommand thecommand = new SqlCommand();
            thecommand.CommandType = CommandType.StoredProcedure;
            thecommand.Connection = ClubBaistConnection;
            thecommand.CommandText = "GetStudent";

            SqlParameter studentid = new SqlParameter();
            studentid.ParameterName = "@studentid";

            studentid.SqlDbType = SqlDbType.VarChar;
            studentid.Value = StudentID;
            studentid.Direction = ParameterDirection.Input;

            thecommand.Parameters.Add(studentid);

            ClubBaistConnection.Open();

            SqlDataReader theDataReader;
            theDataReader = thecommand.ExecuteReader();

            Student enrolledStudent = new Student();

            if (theDataReader.HasRows)
            {
                while (theDataReader.Read())
                {
                    enrolledStudent.Studentid = theDataReader["StudentID"].ToString();
                    enrolledStudent.Firstname = theDataReader["FirstName"].ToString();
                    enrolledStudent.Lastname = theDataReader["LastName"].ToString();
                    enrolledStudent.Email = theDataReader["Email"].ToString();
                    enrolledStudent.Programcode = theDataReader["Programcode"].ToString();
                }
            }

            ClubBaistConnection.Close();

            return enrolledStudent;
        }

        public bool AddStudent(Student acceptedStudent, string programCode)
        {
            bool confirmation;

            SqlConnection ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @"Data Source= (LocalDB)\MSSQLLocalDB; Initial Catalog = ClubBaist;
                                                     Integrated Security = True";

            SqlCommand thecommand = new SqlCommand();
            thecommand.CommandType = CommandType.StoredProcedure;
            thecommand.Connection = ClubBaistConnection;
            thecommand.CommandText = "AddStudent";

            SqlParameter studentid = new SqlParameter();
            studentid.ParameterName = "@studentid";

            studentid.SqlDbType = SqlDbType.VarChar;
            studentid.Value = acceptedStudent.Studentid;
            studentid.Direction = ParameterDirection.Input;

            thecommand.Parameters.Add(studentid);

            //First Name
            SqlParameter fName = new SqlParameter();
            fName.ParameterName = "@firstname";

            fName.SqlDbType = SqlDbType.VarChar;
            fName.Value = acceptedStudent.Firstname;
            fName.Direction = ParameterDirection.Input;

            thecommand.Parameters.Add(fName);

            //Last Name
            SqlParameter lName = new SqlParameter();
            lName.ParameterName = "@lastname";

            lName.SqlDbType = SqlDbType.VarChar;
            lName.Value = acceptedStudent.Lastname;
            lName.Direction = ParameterDirection.Input;

            thecommand.Parameters.Add(lName);

            //Email
            SqlParameter email = new SqlParameter();
            email.ParameterName = "@email";

            email.SqlDbType = SqlDbType.VarChar;
            email.Value = acceptedStudent.Email;
            email.Direction = ParameterDirection.Input;

            thecommand.Parameters.Add(email);

            //Program Code
            SqlParameter program = new SqlParameter();
            program.ParameterName = "@programid";

            program.SqlDbType = SqlDbType.VarChar;
            program.Value = programCode;
            program.Direction = ParameterDirection.Input;

            thecommand.Parameters.Add(program);

            ClubBaistConnection.Open();

            int rowsaffected = thecommand.ExecuteNonQuery();
            if (rowsaffected >= 1)
            {
                confirmation = true;
            }
            else
            {
                confirmation = false;
            }

            ClubBaistConnection.Close();

            return confirmation;
        }

        public bool UpdateStudent(Student enrolledStudent)
        {
            bool confirmation;

            SqlConnection ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @"Data Source= (LocalDB)\MSSQLLocalDB; Initial Catalog = ClubBaist;
                                                     Integrated Security = True";

            SqlCommand thecommand = new SqlCommand();
            thecommand.CommandType = CommandType.StoredProcedure;
            thecommand.Connection = ClubBaistConnection;
            thecommand.CommandText = "UpdateStudent";

            SqlParameter studentid = new SqlParameter();
            studentid.ParameterName = "@studentid";

            studentid.SqlDbType = SqlDbType.VarChar;
            studentid.Value = enrolledStudent.Studentid;
            studentid.Direction = ParameterDirection.Input;

            thecommand.Parameters.Add(studentid);

            //First Name
            SqlParameter fName = new SqlParameter();
            fName.ParameterName = "@firstname";

            fName.SqlDbType = SqlDbType.VarChar;
            fName.Value = enrolledStudent.Firstname;
            fName.Direction = ParameterDirection.Input;

            thecommand.Parameters.Add(fName);

            //Last Name
            SqlParameter lName = new SqlParameter();
            lName.ParameterName = "@lastname";

            lName.SqlDbType = SqlDbType.VarChar;
            lName.Value = enrolledStudent.Lastname;
            lName.Direction = ParameterDirection.Input;

            thecommand.Parameters.Add(lName);

            //Email
            SqlParameter email = new SqlParameter();
            email.ParameterName = "@email";

            email.SqlDbType = SqlDbType.VarChar;
            email.Value = enrolledStudent.Email;
            email.Direction = ParameterDirection.Input;

            thecommand.Parameters.Add(email);
            ClubBaistConnection.Open();

            int rowsaffected = thecommand.ExecuteNonQuery();
            if (rowsaffected >= 1)
            {
                confirmation = true;
            }
            else
            {
                confirmation = false;
            }

            ClubBaistConnection.Close();

            return confirmation;

        }

        public bool DeleteStudent(string Studentid)
        {
            bool confirmation;

            SqlConnection ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @"Data Source= (LocalDB)\MSSQLLocalDB; Initial Catalog = ClubBaist;
                                                     Integrated Security = True";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = ClubBaistConnection;
            command.CommandText = "DeleteStudent";

            SqlParameter StudentID = new SqlParameter();
            StudentID.ParameterName = "@StudentID";

            StudentID.SqlDbType = SqlDbType.VarChar;
            StudentID.Value = Studentid;
            StudentID.Direction = ParameterDirection.Input;

            command.Parameters.Add(StudentID);

            ClubBaistConnection.Open();

            int rowsaffected = command.ExecuteNonQuery();

            if (rowsaffected >= 1)
            {
                confirmation = true;
            }
            else
            {
                confirmation = false;
            }

            ClubBaistConnection.Close();

            return confirmation;
        }

        public List<Student> GetStudents(string programCode)
        {
            SqlConnection ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @"Data Source= (LocalDB)\MSSQLLocalDB; 
                                                        Initial Catalog = ClubBaist;
                                                     Integrated Security = True";
            SqlCommand thecommand = new SqlCommand();
            thecommand.CommandType = CommandType.StoredProcedure;
            thecommand.Connection = ClubBaistConnection;
            thecommand.CommandText = "GetStudents";

            SqlParameter programcode = new SqlParameter();
            programcode.ParameterName = "@ProgramCode";

            programcode.SqlDbType = SqlDbType.VarChar;
            programcode.Value = programCode;
            programcode.Direction = ParameterDirection.Input;

            thecommand.Parameters.Add(programcode);

            ClubBaistConnection.Open();

            SqlDataReader theDataReader;
            theDataReader = thecommand.ExecuteReader();

            List<Student> enrolledStudents = new List<Student>();

            if (theDataReader.HasRows)
            {
                while (theDataReader.Read())
                {
                    Student student = new Student();
                    student.Studentid = theDataReader["StudentID"].ToString();
                    student.Firstname = theDataReader["FirstName"].ToString();
                    student.Lastname = theDataReader["LastName"].ToString();
                    student.Email = theDataReader["Email"].ToString();

                    enrolledStudents.Add(student);
                }
            }

            ClubBaistConnection.Close();

            return enrolledStudents;
        }
    }
}
