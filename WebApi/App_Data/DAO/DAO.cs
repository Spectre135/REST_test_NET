using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using si.nkbm.porfu.DTO;
using System.Text;

namespace si.nkbm.porfu.DAO
{
    public class DataDAO
    {
        //----------------------------------------------------------------------------------------------------------------------------
        public IEnumerable<FatcaXmlBean> GetData(string query, int pageIndex, int pageSize, string sortKey, string asceding)
        {

            SqlConnection connection = new SqlConnection();

            try
            {

                List<FatcaXmlBean> result = new List<FatcaXmlBean>();

                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hekata_conn"].ConnectionString);

                using (connection)
                {
                    connection.Open();
                    SqlCommand cmd;
                    using (cmd = new SqlCommand(this.GetSQL(sortKey,asceding), connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@searchParam", "%" + query + "%");
                        cmd.Parameters.AddWithValue("@pageSize", pageSize);
                        cmd.Parameters.AddWithValue("@pageIndex", pageIndex);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                result.Add(ReflectPropertyInfo.ReflectType<FatcaXmlBean>(reader));
                            }
                        }
                    }
                    
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                //connection.Close(); //tega ne rabimo če uporabimo using
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public int GetRowsCount(string query)
        {
            SqlConnection connection = new SqlConnection();
            int pageCount= 0;

            try
            {

                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hekata_conn"].ConnectionString);

                using (connection)
                {
                    connection.Open();
                    SqlCommand cmd;
                    using (cmd = new SqlCommand(this.GetSQLRowsCount(), connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@searchParam", "%" + query + "%");

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                pageCount = (int)reader[0];
                            }
                        }
                    }

                }

                return pageCount;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
                throw;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        private string GetSQL(string sortKey, string asceding)
        {
            StringBuilder sbSql = new StringBuilder();
            FatcaXmlBean dto = new FatcaXmlBean();

            sbSql.Append("Select  * from HARM.dbo.FATCA_CRS ");
            sbSql.Append(" where ").Append(ReflectPropertyInfo.GetSearchFields(dto)).Append(" like @searchParam ");
            sbSql.Append(" ORDER BY ");
            sbSql.Append(sortKey.Equals("null") ? " Datum " : sortKey + (asceding.Equals("true") ? " ASC " : " DESC "));
            sbSql.Append(" OFFSET @pageSize*(@pageIndex-1) ROWS FETCH NEXT @pageSize ROWS ONLY;");

            return sbSql.ToString();

        }
        //----------------------------------------------------------------------------------------------------------------------------
        private string GetSQLRowsCount()
        {
            StringBuilder sbSql = new StringBuilder();
            FatcaXmlBean dto = new FatcaXmlBean();

            sbSql.Append("Select count(*) from HARM.dbo.FATCA_CRS ");
            sbSql.Append(" where ").Append(ReflectPropertyInfo.GetSearchFields(dto)).Append(" like @searchParam ");

            return sbSql.ToString();

        }
        //----------------------------------------------------------------------------------------------------------------------------
    }
}
