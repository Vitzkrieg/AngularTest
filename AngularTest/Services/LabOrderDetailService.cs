﻿using System;
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
    public class LabOrderDetailService
    {
        public async Task<LabOrderDetailViewModel> GetLabOrderDetail(int id)
        {
            LabOrderDetailViewModel result = new LabOrderDetailViewModel();

            string con = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            
            string queryString = "SELECT LO.Id, LO.OrderDate, LO.AmountCollected, LT.LabTestName, P.FirstName, P.LastName, F.FacilityName FROM LabOrder as LO " +
                "LEFT JOIN LabTest as LT ON LO.LabTestId = LT.Id " +
                "LEFT JOIN Patient as P ON LO.PatientId = P.Id " +
                "LEFT JOIN Facility as F ON LO.FacilityId = F.Id " +
                "WHERE LO.Id = " + id;
            //System.Diagnostics.Debug.WriteLine("GetLabOrderDetail() queryString: " + queryString);

            DataSet data;

            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(queryString, connection);

                int x = await command.ExecuteNonQueryAsync();

                data = new DataSet();
                adapter.SelectCommand = command;
                adapter.Fill(data);
                
                connection.Close();
            }
            //System.Diagnostics.Debug.WriteLine("GetLabOrderDetail() Count: " + data.Tables[0].Rows.Count);
            if (data.Tables[0].Rows.Count > 0)
            {
                result = getLabOrderDetailFromDataRow(data.Tables[0].Rows[0]);
            }

            return result;
        }


        private static LabOrderDetailViewModel getLabOrderDetailFromDataRow(DataRow row)
        {
            //foreach (System.ComponentModel.PropertyDescriptor descriptor in System.ComponentModel.TypeDescriptor.GetProperties(row))
            //{
            //    string name = descriptor.Name;
            //    object value = descriptor.GetValue(row);
            //    Console.WriteLine("{0} = {1}", name, value);
            //}
            LabOrderDetailViewModel laborder = new LabOrderDetailViewModel
            {
                Id = row.Field<int>("Id"),
                OrderDate = row.Field<DateTime>("OrderDate"),
                OrderDateDisplay = row.Field<DateTime>("OrderDate").ToShortDateString(),
                LabTestName = row.Field<string>("LabTestName"),
                AmountCollected = row.Field<decimal>("AmountCollected"),
                PatientFirstName = row.Field<string>("Firstname"),
                PatientLastName = row.Field<string>("LastName"),
                FacilityName = row.Field<string>("FacilityName")
            };
            return laborder;
        }


        public async Task<Boolean> SaveLabOrderDetail(int id, decimal amountCollected)
        {
            Boolean result = false;

            string con = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            string queryString = "UPDATE LabOrder SET AmountCollected = " + amountCollected + " WHERE Id = " + id;
            System.Diagnostics.Debug.WriteLine("GetLabOrderDetail() queryString: " + queryString);
            
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(queryString, connection);

                int x = await command.ExecuteNonQueryAsync();
                System.Diagnostics.Debug.WriteLine("GetLabOrderDetail() x: " + x);
                result = x > 0;

                connection.Close();
            }
            System.Diagnostics.Debug.WriteLine("GetLabOrderDetail() result: " + result);

            return result;
        }
    }
}