using Microsoft.Data.SqlClient;
using MvcCoreAdoNet.Models;

namespace MvcCoreAdoNet.Repositories
{
    public class RepositoryHospital
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public RepositoryHospital()
        {
            string connectionstring = @"Data Source=""LOCALHOST \DEVELOPER"";Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionstring);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }
        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            string sql = "select * from HOSPITAL";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            await this.com.ExecuteReaderAsync();
            List<Hospital> hospitales = new List<Hospital>();
            while (await this.reader.ReadAsync())
            {
                Hospital h = new Hospital();
                h.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                h.Nombre = this.reader["NOMBRE"].ToString();
                h.Direccion = this.reader["DIRECCION"].ToString();
                h.Telefono = this.reader["TELEFONO"].ToString();
                h.Camas = int.Parse(this.reader["NUM_CAMAS"].ToString());
                hospitales.Add(h);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return hospitales;
        }
    }
}
