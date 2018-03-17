using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace ChartLibrary
{
    public class FundDAL
    {
        #region objDB Variable
        /// <summary>     
        /// Specify the Database variable     
        /// </summary>     
        Database objDB;
        /// <summary>     
        /// Specify the static variable     
        /// </summary>     
        string ConnectionString;
        #endregion

        #region Database Method  
        public List<T> ConvertTo<T>(DataTable datatable) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => getObject<T>(row, columnsNames));
                return Temp;
            }
            catch
            {
                return Temp;
            }
        }
        public T getObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties;
                Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString();
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                return obj;
            }
        }
        #endregion

        #region Constructor  
        /// <summary>     
        /// This constructor is used to get the connectionstring from the config file     
        /// </summary>     
        public FundDAL()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["FundConnectionString"].ToString();
            //ConnectionString = ConnectionString()
        }
        #  endregion

        #region Fund Details  
        /// <summary>     
        /// This method is used to get all players     
        /// </summary>     
        /// <returns></returns>     
        public List<FundInstance> GetFundDetails()
        {
            List<FundInstance> objFundInstance = null;
            objDB = new SqlDatabase(ConnectionString);
            using (DbCommand objcmd = objDB.GetStoredProcCommand("SC_GetFundInstance"))
            {
                try
                {
                    using (DataTable dataTable = objDB.ExecuteDataSet(objcmd).Tables[0])
                    {
                        objFundInstance = ConvertTo<FundInstance>(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                    return null;
                }
            }
            return objFundInstance;
        }
        /// <summary>    
        /// This method is used to get player records on the basis of player id    
        /// </summary>    
        // <param name="fundId"></param>    
        /// <returns></returns>    
        public List<FundRecord> GetFundRecordByFundId(Int16? fundId)
        {
            List<FundRecord> objFundRecords = null;
            objDB = new SqlDatabase(ConnectionString);
            using (DbCommand objcmd = objDB.GetStoredProcCommand("SC_GetFundRecordByFundId"))
            {
                objDB.AddInParameter(objcmd, "@FundId", DbType.Int16, fundId);
                try
                {
                    using (DataTable dataTable = objDB.ExecuteDataSet(objcmd).Tables[0])
                    {
                        objFundRecords = ConvertTo<FundRecord>(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                    return null;
                }
            }
            return objFundRecords;
        }
        #  endregion
    }
}
