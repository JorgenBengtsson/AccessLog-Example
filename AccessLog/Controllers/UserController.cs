using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;

namespace AccessLog.Controllers
{
    public class user
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }

    public class UsersController : ApiController
    {
        // GET api/users
        public List<user> Get()
        {
            var connectionString = "Data Source=(local);Initial Catalog=AccessLog;User Id=accessloguser;Password=sql2019;";
            var query = "SELECT * FROM [user]";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand(query, con);

            con.Open();
            SqlDataReader red = com.ExecuteReader();

            var ret = new List<user>();

            while(red.Read())
            {
                ret.Add(new user { id = int.Parse(red[0].ToString()), password = red[2].ToString(), username = red[1].ToString() });
            }

            red.Close();

            return ret;
        }

        // GET api/users/5
        public user Get(int id)
        {
            var connectionString = "Data Source=(local);Initial Catalog=AccessLog;Integrated Security=true;";
            var query = "SELECT * FROM [user] WHERE id = @id";
            var returnValue = new user();

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                returnValue.id = int.Parse(reader[0].ToString());
                returnValue.password = reader[2].ToString();
                returnValue.username = reader[1].ToString();
            }

            reader.Close();

            return returnValue;
        }

        // POST api/users
        public void Post([FromBody]user value)
        {
            var connectionString = "Data Source=(local);Initial Catalog=AccessLog;User Id=accessloguser;Password=sql2019;";
            var query = "INSERT INTO [user] (username, password) VALUES (@username, @password)";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand(query, con);
            
            com.Parameters.AddWithValue("@username", value.username);
            com.Parameters.AddWithValue("@password", value.password);

            con.Open();
            com.ExecuteNonQuery();
        }

        // PUT api/users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/users/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("api/users/username/{id:int}")]
        // GET api/users/username/1
        public string UserName(int id)
        {
            var connectionString = "Data Source=(local);Initial Catalog=AccessLog;Integrated Security=true;";
            var query = "SELECT username FROM [user] WHERE id = @id";
            var returnValue = string.Empty;

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                returnValue = reader[0].ToString();
            }

            reader.Close();

            return returnValue;
        }
    }
}
