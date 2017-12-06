/*******************************************************************************
* ������ʶ: 
* ��������: 
* 
* ��������: 
* 
* �޸ı�ʶ: 
* �޸�����: 
*******************************************************************************/

using System;
using System.Configuration;
using System.Web;
using DBUtility;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections;


namespace EmsDAL
{
    public class DALHelper
    {
        protected static DBHelper dbHelper = GetHelper("DB");

        /// <summary>
        /// ��Web.config�Ӷ�ȡ���ݿ�������Լ����ݿ�����
        /// </summary>
        private static DBHelper GetHelper(string connectionStringName)
        {
            DBHelper dbHelper = new DBHelper();

            // ��Web.config�ж�ȡ���ݿ�����
            string providerName = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ProviderName;
            switch (providerName)
            {
                case "System.Data.OracleClient":
                    dbHelper.DatabaseType = DBHelper.DatabaseTypes.Oracle;
                    break;
                case "MySql.Data.MySqlClient":
                    dbHelper.DatabaseType = DBHelper.DatabaseTypes.MySql;
                    break;
                case "System.Data.OleDb":
                    dbHelper.DatabaseType = DBHelper.DatabaseTypes.OleDb;
                    break;
                case "System.Data.SQLite":
                    dbHelper.DatabaseType = DBHelper.DatabaseTypes.SQLite;
                    break;
                case "System.Data.SqlClient":
                default:
                    dbHelper.DatabaseType = DBHelper.DatabaseTypes.Sql;
                    break;
            }

            // ��Web.config�ж�ȡ���ݿ�����
            dbHelper.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;

            return dbHelper;
        } 


        #region ��Objectȡֵ
        /// <summary>
        /// ȡ��Int16ֵ
        /// </summary>
        public static Int16? GetInt16(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                short result;
                if (Int16.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ȡ��UInt16ֵ
        /// </summary>
        public static UInt16? GetUInt16(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                ushort result;
                if (UInt16.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ȡ��Intֵ
        /// </summary>
        public static int? GetInt(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                int result;
                if (int.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ȡ��UIntֵ
        /// </summary>
        public static uint? GetUInt(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                uint result;
                if (uint.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ȡ��UInt64ֵ
        /// </summary>
        public static ulong? GetULong(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                ulong result;
                if (ulong.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ȡ��byteֵ
        /// </summary>
        public static byte? GetByte(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                byte result;
                if (byte.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ȡ��sbyteֵ
        /// </summary>
        public static sbyte? GetSByte(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                sbyte result;
                if (sbyte.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ���Longֵ
        /// </summary>
        public static long? GetLong(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                long result;
                if (long.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ȡ��Decimalֵ
        /// </summary>
        public static decimal? GetDecimal(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                decimal result;
                if (decimal.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ȡ��floatֵ
        /// </summary>
        public static float? GetFloat(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                float result;
                if (float.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null; ;
            }
        }

        /// <summary>
        /// ȡ��doubleֵ
        /// </summary>
        public static double? GetDouble(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                double result;
                if (double.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ȡ��Guidֵ
        /// </summary>
        public static Guid? GetGuid(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                try
                {
                    Guid result = new Guid(obj.ToString());
                    return result;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ȡ��DateTimeֵ
        /// </summary>
        public static DateTime? GetDateTime(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                DateTime result;
                if (DateTime.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ȡ��boolֵ
        /// </summary>
        public static bool? GetBool(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                bool result;
                if (bool.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ȡ��byte[]
        /// </summary>
        public static byte[] GetBinary(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                return (byte[])obj;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ȡ��stringֵ
        /// </summary>
        public static string GetString(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                return obj.ToString();
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region ��ҳ
        		/// <summary>
				/// ��ȡ��¼����
				/// </summary>
				/// <param name="strWhere">����</param>
				/// <returns>��¼����</returns>
				public int GetRecordCount(string TableName,string strWhere,DbParameter[] parms4org)
				{
                    StringBuilder sbSql = new StringBuilder();
                    sbSql.Append("select count(1) FROM "+TableName);
					if (strWhere.Trim() != "")
					{
                        sbSql.Append(" where 1=1" + strWhere);
					}

                    object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms4org);
                    
					if (obj == null)
					{
						return 0;
					}
					else
					{
						return Convert.ToInt32(obj);
					}
				}

				/// <summary>
				/// ��ҳ��ȡ�����б�
				/// </summary>
				/// <param name="strWhere">����</param>
				/// <param name="orderby">����</param>
				/// <param name="startIndex">��ʼ����</param>
				/// <param name="endIndex">��������</param>
				/// <returns>DataSet</returns>
                public DataSet GetListByPage(string TableName,string strWhere, string orderby, int startIndex, int endIndex, DbParameter[] parms4org,bool ispage=true)
				{
                    StringBuilder sbSql = new StringBuilder();
                    sbSql.Append("SELECT * FROM ( ");
                    sbSql.Append(" SELECT ROW_NUMBER() OVER (");
					if (!string.IsNullOrEmpty(orderby.Trim()))
					{
                        sbSql.Append("order by T." + orderby);
					}
					else
					{
                        sbSql.Append("order by T.ID desc");
					}
                    sbSql.Append(")AS rowNum, T.*  from " + TableName + " T ");
					if (!string.IsNullOrEmpty(strWhere.Trim()))
					{
                        sbSql.Append(" WHERE 1=1 " + strWhere);
					}
                    sbSql.Append(" ) TT");
                    if (ispage)
                    {
                        sbSql.AppendFormat(" WHERE TT.rowNum between {0} and {1}", startIndex, endIndex);
                    }
                    return dbHelper.ExecuteQuery(CommandType.Text, sbSql.ToString(), parms4org);
				}                
        #endregion

        #region ��ҳ ���������Ӳ�ѯ
                /// <summary>
                /// ��ȡ��¼����
                /// </summary>
                /// <param name="strWhere">����</param>
                /// <returns>��¼����</returns>
                public int GetRecordCount(string sql, DbParameter[] parms4org)
                {
                    StringBuilder sbSql = new StringBuilder();
                    sbSql.Append("select count(1) FROM (" + sql + ") T");                   
                    object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms4org);

                    if (obj == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToInt32(obj);
                    }
                }

                /// <summary>
                /// ��ҳ��ȡ�����б�
                /// </summary>
                /// <param name="strWhere">����</param>
                /// <param name="orderby">����</param>
                /// <param name="startIndex">��ʼ����</param>
                /// <param name="endIndex">��������</param>
                /// <returns>DataSet</returns>
                public DataSet GetListByPage(string sql, string orderby, int startIndex, int endIndex, DbParameter[] parms4org)
                {
                    StringBuilder sbSql = new StringBuilder();
                    sbSql.Append("SELECT * FROM ( ");
                    sbSql.Append(" SELECT ROW_NUMBER() OVER (");
                    if (!string.IsNullOrEmpty(orderby.Trim()))
                    {
                        sbSql.Append("order by T." + orderby);
                    }
                    else
                    {
                        sbSql.Append("order by T.ID desc");
                    }
                    sbSql.Append(")AS rowNum, T.*  from (" + sql + ") T ");
                    sbSql.Append(" ) TT");
                    sbSql.AppendFormat(" WHERE TT.rowNum between {0} and {1}", startIndex, endIndex);
                    return dbHelper.ExecuteQuery(CommandType.Text, sbSql.ToString(), parms4org);
                }
                #endregion

        #region �޸�IsDelete����״̬
                /// <summary>
        /// �޸�IsDelete����״̬
        /// </summary>
        /// <param name="ht">����Key:Id(Ψһ��ʶ),IsDelete(0 ����;1 ɾ��;2�鵵),Editor(�޸���),UpdateTime(�޸�ʱ��),TableName(����)</param>
        /// <returns></returns>
        public int UpdateIsDelete(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;

                sbSql = new StringBuilder();
                sbSql.Append("update " + ht["TableName"].ToString() + " set ");
                sbSql.Append("Editor=@Editor,");
                sbSql.Append("UpdateTime=@UpdateTime,");
                sbSql.Append("IsDelete=@in_IsDelete");
                sbSql.Append("  where Id=@in_Id ");

                parms = new DbParameter[]{
				dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Convert.ToInt32(ht["Id"].ToString())),
                dbHelper.CreateInDbParameter("@UpdateTime", DbType.DateTime2,Convert.ToDateTime(ht["UpdateTime"].ToString())),
                dbHelper.CreateInDbParameter("@Editor", DbType.String,ht["Editor"].ToString()),
				dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte,Convert.ToByte(ht["IsDelete"].ToString()))
			    };

                return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
            }
            catch (Exception)
            {
                //д����־
                //throw;
                return 0;
            }
        }
        #endregion
    }
}