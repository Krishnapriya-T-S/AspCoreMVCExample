using System.Data;
using System.Data.SqlClient;
namespace AspCoreMVCExample.Models
{
    public class EmployeeDB
    {
        SqlConnection con;
        public EmployeeDB()
        {
            con = new SqlConnection("Data Source=.\\MSSQLSERVER01;Initial Catalog=ASP_Core;Integrated Security=True;Encrypt=False");
        }


        public string InsertDB(Employee objcls)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_EmpInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empna", objcls.ename);//get
                cmd.Parameters.AddWithValue("@empaddr", objcls.eaddr);
                cmd.Parameters.AddWithValue("@empsal", objcls.esal);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Inserted successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }

        public string LoginDB(Employee objcls)
        {
            try
            {
                string cid = "", msg = "";
                SqlCommand cmd = new SqlCommand("sp_login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", objcls.eid);
                cmd.Parameters.AddWithValue("@ena", objcls.ename);
                con.Open();
                cid = cmd.ExecuteScalar().ToString();
                con.Close();
                if (cid == "1")
                {
                    msg = "Success";
                }
                else
                {
                    msg = "Invalid login";
                }
                return msg;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }
        public Employee SelectProfileDB(int id)
        {
            var getdata = new Employee();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_selectProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    getdata = new Employee
                    {
                        eid = Convert.ToInt32(sdr["Emp_Id"]), //set
                        ename = sdr["Emp_Name"].ToString(),
                        eaddr = sdr["Emp_Address"].ToString(),
                        esal = sdr["Emp_Salary"].ToString(),
                    };
                }
                con.Close();
                return getdata;

            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }

        public string UpdateDB(Employee emp)
        {
            string reVal = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_updateProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", emp.eid);
                cmd.Parameters.AddWithValue("@esal", emp.esal);
                cmd.Parameters.AddWithValue("@eaddr", emp.eaddr);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                reVal = "OK....updated";
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
            return (reVal);
        }

        public List<Employee> SelectDB()
        {
            var list = new List<Employee>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_selectProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                   var  o = new Employee
                    {
                        eid = Convert.ToInt32(sdr["Emp_Id"]), //set
                        ename = sdr["Emp_Name"].ToString(),
                        eaddr = sdr["Emp_Address"].ToString(),
                        esal = sdr["Emp_Salary"].ToString(),
                    };
                    list.Add(o);
                }
                con.Close();
                return list;
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }

    }
}