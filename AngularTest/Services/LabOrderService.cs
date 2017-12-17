using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AngularTest.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AngularTest.Services
{
    public class LabOrderService
    {
        public async Task<List<LabOrderListViewModel>> GetLabOrderList()
        {
            var result = new List<LabOrderListViewModel>();
            //Load List from Context
            string con = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            
            string queryString = "SELECT LO.Id, LO.OrderDate, LO.AmountBilled, LO.AmountCollected, LT.LabTestName FROM LabOrder as LO " +
                "LEFT JOIN LabTest as LT ON LO.LabTestId = LT.Id";

            DataSet data;

            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(queryString, connection);

                var x = await command.ExecuteNonQueryAsync();
                System.Diagnostics.Debug.WriteLine("x: " + x);
                data = new DataSet();
                adapter.SelectCommand = command;
                adapter.Fill(data);
                
                connection.Close();
            }
            System.Diagnostics.Debug.WriteLine("Rows: " + data.Tables[0].Rows);
            foreach (DataRow row in data.Tables[0].Rows)
            {
                LabOrderListViewModel laborder = getLabOrderFromDataRow(row);
                result.Add(laborder);
            }

            return result;
        }


        private static LabOrderListViewModel getLabOrderFromDataRow(DataRow row)
        {
            LabOrderListViewModel laborder = new LabOrderListViewModel
            {
                Id = row.Field<int>("Id"),
                OrderDate = row.Field<DateTime>("OrderDate"),
                OrderDateDisplay = row.Field<DateTime>("OrderDate").ToShortDateString(),
                LabTestName = row.Field<string>("LabTestName"),
                AmountBilled = row.Field<decimal>("AmountBilled"),
                AmountCollected = row.Field<decimal>("AmountCollected")
            };
            System.Diagnostics.Debug.WriteLine("Id: " + laborder.Id);
            return laborder;
        }
    }
}