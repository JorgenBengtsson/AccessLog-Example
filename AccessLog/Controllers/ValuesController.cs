using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccessLog.Controllers
{
    public class user
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }

    public class ValuesController : ApiController
    {
        // GET api/values
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

            return ret;
        }
        
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
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

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
