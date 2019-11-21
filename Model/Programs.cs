using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Jkaur18BAIS3150CodeSample.Model
{
    public class Programs
    {
        public Program GetProgram(string programCode)
        {
            SqlConnection ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @"Data Source= (LocalDB)\MSSQLLocalDB; Initial Catalog = ClubBaist;
                                                     Integrated Security = True";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = ClubBaistConnection;
            command.CommandText = "GetProgram";

            SqlParameter ProgramCode = new SqlParameter();
            ProgramCode.ParameterName = "@programcode";

            ProgramCode.SqlDbType = SqlDbType.VarChar;
            ProgramCode.Value = programCode;
            ProgramCode.Direction = ParameterDirection.Input;

            command.Parameters.Add(ProgramCode);

            ClubBaistConnection.Open();

            SqlDataReader theDataReader;
            theDataReader = command.ExecuteReader();


            Program activeProgram = new Program(programCode);

            //Console.WriteLine(theDataReader);
            if (theDataReader.HasRows)
            {
                while (theDataReader.Read())
                {
                    activeProgram.programCode = theDataReader["programCode"].ToString();
                    activeProgram.Description = theDataReader["Description"].ToString();
                }
            }

            ClubBaistConnection.Close();

            return activeProgram;
        }
        public bool AddProgram(string programCode, string Description)
        {
            bool confirmation;

            SqlConnection ClubBaistConnection = new SqlConnection();
            ClubBaistConnection.ConnectionString = @"Data Source= (LocalDB)\MSSQLLocalDB; Initial Catalog = ClubBaist;
                                                     Integrated Security = True";

            SqlCommand thecommand = new SqlCommand();
            thecommand.CommandType = CommandType.StoredProcedure;
            thecommand.Connection = ClubBaistConnection;
            thecommand.CommandText = "AddProgram";

            SqlParameter pCode = new SqlParameter();
            pCode.ParameterName = "@ProgramCode";

            pCode.SqlDbType = SqlDbType.VarChar;
            pCode.Value = programCode;
            pCode.Direction = ParameterDirection.Input;

            thecommand.Parameters.Add(pCode);

            //Description
            SqlParameter desc = new SqlParameter();
            desc.ParameterName = "@Description";

            desc.SqlDbType = SqlDbType.VarChar;
            desc.Value = Description;
            desc.Direction = ParameterDirection.Input;

            thecommand.Parameters.Add(desc);

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
    }
}
