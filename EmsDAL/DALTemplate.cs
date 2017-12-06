
 
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EmsDAL
{

	/// </summary>
	///	教学计划表实体类1
	/// </summary>
    public partial class View_orderCount: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.View_orderCount EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO View_orderCount(");
						sbSql.Append("Id,RelationID,EquipKindId,EQNAME,EQNUM,EQUNIT,Count,countL,countE)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Id,@in_RelationID,@in_EquipKindId,@in_EQNAME,@in_EQNUM,@in_EQUNIT,@in_Count,@in_countL,@in_countE)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_RelationID", DbType.Int32, EmsModel.RelationID),dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_EQNAME", DbType.String, EmsModel.EQNAME),dbHelper.CreateInDbParameter("@in_EQNUM", DbType.String, EmsModel.EQNUM),dbHelper.CreateInDbParameter("@in_EQUNIT", DbType.String, EmsModel.EQUNIT),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_countL", DbType.Int32, EmsModel.countL),dbHelper.CreateInDbParameter("@in_countE", DbType.Int32, EmsModel.countE)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.View_orderCount EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO View_orderCount(");
						sbSql.Append("Id,RelationID,EquipKindId,EQNAME,EQNUM,EQUNIT,Count,countL,countE)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Id,@in_RelationID,@in_EquipKindId,@in_EQNAME,@in_EQNUM,@in_EQUNIT,@in_Count,@in_countL,@in_countE)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_RelationID", DbType.Int32, EmsModel.RelationID),dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_EQNAME", DbType.String, EmsModel.EQNAME),dbHelper.CreateInDbParameter("@in_EQNUM", DbType.String, EmsModel.EQNUM),dbHelper.CreateInDbParameter("@in_EQUNIT", DbType.String, EmsModel.EQUNIT),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_countL", DbType.Int32, EmsModel.countL),dbHelper.CreateInDbParameter("@in_countE", DbType.Int32, EmsModel.countE)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.View_orderCount EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update View_orderCount set ");
					sbSql.Append("Id=@in_Id,RelationID=@in_RelationID,EquipKindId=@in_EquipKindId,EQNAME=@in_EQNAME,EQNUM=@in_EQNUM,EQUNIT=@in_EQUNIT,Count=@in_Count,countL=@in_countL,countE=@in_countE");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_RelationID", DbType.Int32, EmsModel.RelationID),dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_EQNAME", DbType.String, EmsModel.EQNAME),dbHelper.CreateInDbParameter("@in_EQNUM", DbType.String, EmsModel.EQNUM),dbHelper.CreateInDbParameter("@in_EQUNIT", DbType.String, EmsModel.EQUNIT),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_countL", DbType.Int32, EmsModel.countL),dbHelper.CreateInDbParameter("@in_countE", DbType.Int32, EmsModel.countE)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.View_orderCount EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update View_orderCount set ");
					sbSql.Append("Id=@in_Id,RelationID=@in_RelationID,EquipKindId=@in_EquipKindId,EQNAME=@in_EQNAME,EQNUM=@in_EQNUM,EQUNIT=@in_EQUNIT,Count=@in_Count,countL=@in_countL,countE=@in_countE");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_RelationID", DbType.Int32, EmsModel.RelationID),dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_EQNAME", DbType.String, EmsModel.EQNAME),dbHelper.CreateInDbParameter("@in_EQNUM", DbType.String, EmsModel.EQNUM),dbHelper.CreateInDbParameter("@in_EQUNIT", DbType.String, EmsModel.EQUNIT),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_countL", DbType.Int32, EmsModel.countL),dbHelper.CreateInDbParameter("@in_countE", DbType.Int32, EmsModel.countE)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM View_orderCount");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM View_orderCount");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists( )
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM View_orderCount");
					sbSql.Append("");

					parms = new DbParameter[]{
						
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.View_orderCount> GetListByPage(EmsModel.View_orderCount EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "View_orderCount";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Id != null){strWhere += " and Id=@in_Id ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Id", DbType.String, EmsMod.Id)); }if (EmsMod.RelationID != null){strWhere += " and RelationID=@in_RelationID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RelationID", DbType.String, EmsMod.RelationID)); }if (EmsMod.EquipKindId != null){strWhere += " and EquipKindId=@in_EquipKindId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.String, EmsMod.EquipKindId)); }if (EmsMod.EQNAME != null){strWhere += " and EQNAME=@in_EQNAME ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EQNAME", DbType.String, EmsMod.EQNAME)); }if (EmsMod.EQNUM != null){strWhere += " and EQNUM=@in_EQNUM ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EQNUM", DbType.String, EmsMod.EQNUM)); }if (EmsMod.EQUNIT != null){strWhere += " and EQUNIT=@in_EQUNIT ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EQUNIT", DbType.String, EmsMod.EQUNIT)); }if (EmsMod.Count != null){strWhere += " and Count=@in_Count ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Count", DbType.String, EmsMod.Count)); }if (EmsMod.countL != null){strWhere += " and countL=@in_countL ";parmsList.Add(dbHelper.CreateInDbParameter("@in_countL", DbType.String, EmsMod.countL)); }if (EmsMod.countE != null){strWhere += " and countE=@in_countE ";parmsList.Add(dbHelper.CreateInDbParameter("@in_countE", DbType.String, EmsMod.countE)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.View_orderCount> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.View_orderCount EmsMod)
        {
            string TableName = "View_orderCount";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Id != null){strWhere += " and Id=@in_Id ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Id", DbType.String, EmsMod.Id)); }if (EmsMod.RelationID != null){strWhere += " and RelationID=@in_RelationID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RelationID", DbType.String, EmsMod.RelationID)); }if (EmsMod.EquipKindId != null){strWhere += " and EquipKindId=@in_EquipKindId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.String, EmsMod.EquipKindId)); }if (EmsMod.EQNAME != null){strWhere += " and EQNAME=@in_EQNAME ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EQNAME", DbType.String, EmsMod.EQNAME)); }if (EmsMod.EQNUM != null){strWhere += " and EQNUM=@in_EQNUM ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EQNUM", DbType.String, EmsMod.EQNUM)); }if (EmsMod.EQUNIT != null){strWhere += " and EQUNIT=@in_EQUNIT ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EQUNIT", DbType.String, EmsMod.EQUNIT)); }if (EmsMod.Count != null){strWhere += " and Count=@in_Count ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Count", DbType.String, EmsMod.Count)); }if (EmsMod.countL != null){strWhere += " and countL=@in_countL ";parmsList.Add(dbHelper.CreateInDbParameter("@in_countL", DbType.String, EmsMod.countL)); }if (EmsMod.countE != null){strWhere += " and countE=@in_countE ";parmsList.Add(dbHelper.CreateInDbParameter("@in_countE", DbType.String, EmsMod.countE)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.View_orderCount EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.RelationID = dr["RelationID"] as int?;EmsModel.EquipKindId = dr["EquipKindId"] as int?;EmsModel.EQNAME = dr["EQNAME"] as string;EmsModel.EQNUM = dr["EQNUM"] as string;EmsModel.EQUNIT = dr["EQUNIT"] as string;EmsModel.Count = dr["Count"] as int?;EmsModel.countL = dr["countL"] as int?;EmsModel.countE = dr["countE"] as int?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.View_orderCount> GetList(DataTable dt)
        {
            List<EmsModel.View_orderCount> lst = new List<EmsModel.View_orderCount>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.View_orderCount mod = new EmsModel.View_orderCount();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.View_orderCount EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.RelationID = dr["RelationID"] as int?;EmsModel.EquipKindId = dr["EquipKindId"] as int?;EmsModel.EQNAME = dr["EQNAME"] as string;EmsModel.EQNUM = dr["EQNUM"] as string;EmsModel.EQUNIT = dr["EQUNIT"] as string;EmsModel.Count = dr["Count"] as int?;EmsModel.countL = dr["countL"] as int?;EmsModel.countE = dr["countE"] as int?;
        }		

    }

	/// </summary>
	///	教学计划表实体类2
	/// </summary>
    public partial class View_LoanDate: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.View_LoanDate EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO View_LoanDate(");
						sbSql.Append("Id,Name,CName,Creator,stuLoanIDCard,StartDate,isStatus,orderID,OrderNo,LoanName,stuLoanName)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Id,@in_Name,@in_CName,@in_Creator,@in_stuLoanIDCard,@in_StartDate,@in_isStatus,@in_orderID,@in_OrderNo,@in_LoanName,@in_stuLoanName)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_CName", DbType.String, EmsModel.CName),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_stuLoanIDCard", DbType.String, EmsModel.stuLoanIDCard),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_isStatus", DbType.Int32, EmsModel.isStatus),dbHelper.CreateInDbParameter("@in_orderID", DbType.Int32, EmsModel.orderID),dbHelper.CreateInDbParameter("@in_OrderNo", DbType.String, EmsModel.OrderNo),dbHelper.CreateInDbParameter("@in_LoanName", DbType.String, EmsModel.LoanName),dbHelper.CreateInDbParameter("@in_stuLoanName", DbType.String, EmsModel.stuLoanName)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.View_LoanDate EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO View_LoanDate(");
						sbSql.Append("Id,Name,CName,Creator,stuLoanIDCard,StartDate,isStatus,orderID,OrderNo,LoanName,stuLoanName)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Id,@in_Name,@in_CName,@in_Creator,@in_stuLoanIDCard,@in_StartDate,@in_isStatus,@in_orderID,@in_OrderNo,@in_LoanName,@in_stuLoanName)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_CName", DbType.String, EmsModel.CName),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_stuLoanIDCard", DbType.String, EmsModel.stuLoanIDCard),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_isStatus", DbType.Int32, EmsModel.isStatus),dbHelper.CreateInDbParameter("@in_orderID", DbType.Int32, EmsModel.orderID),dbHelper.CreateInDbParameter("@in_OrderNo", DbType.String, EmsModel.OrderNo),dbHelper.CreateInDbParameter("@in_LoanName", DbType.String, EmsModel.LoanName),dbHelper.CreateInDbParameter("@in_stuLoanName", DbType.String, EmsModel.stuLoanName)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.View_LoanDate EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update View_LoanDate set ");
					sbSql.Append("Id=@in_Id,Name=@in_Name,CName=@in_CName,Creator=@in_Creator,stuLoanIDCard=@in_stuLoanIDCard,StartDate=@in_StartDate,isStatus=@in_isStatus,orderID=@in_orderID,OrderNo=@in_OrderNo,LoanName=@in_LoanName,stuLoanName=@in_stuLoanName");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_CName", DbType.String, EmsModel.CName),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_stuLoanIDCard", DbType.String, EmsModel.stuLoanIDCard),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_isStatus", DbType.Int32, EmsModel.isStatus),dbHelper.CreateInDbParameter("@in_orderID", DbType.Int32, EmsModel.orderID),dbHelper.CreateInDbParameter("@in_OrderNo", DbType.String, EmsModel.OrderNo),dbHelper.CreateInDbParameter("@in_LoanName", DbType.String, EmsModel.LoanName),dbHelper.CreateInDbParameter("@in_stuLoanName", DbType.String, EmsModel.stuLoanName)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.View_LoanDate EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update View_LoanDate set ");
					sbSql.Append("Id=@in_Id,Name=@in_Name,CName=@in_CName,Creator=@in_Creator,stuLoanIDCard=@in_stuLoanIDCard,StartDate=@in_StartDate,isStatus=@in_isStatus,orderID=@in_orderID,OrderNo=@in_OrderNo,LoanName=@in_LoanName,stuLoanName=@in_stuLoanName");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_CName", DbType.String, EmsModel.CName),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_stuLoanIDCard", DbType.String, EmsModel.stuLoanIDCard),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_isStatus", DbType.Int32, EmsModel.isStatus),dbHelper.CreateInDbParameter("@in_orderID", DbType.Int32, EmsModel.orderID),dbHelper.CreateInDbParameter("@in_OrderNo", DbType.String, EmsModel.OrderNo),dbHelper.CreateInDbParameter("@in_LoanName", DbType.String, EmsModel.LoanName),dbHelper.CreateInDbParameter("@in_stuLoanName", DbType.String, EmsModel.stuLoanName)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM View_LoanDate");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM View_LoanDate");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists( )
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM View_LoanDate");
					sbSql.Append("");

					parms = new DbParameter[]{
						
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.View_LoanDate> GetListByPage(EmsModel.View_LoanDate EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "View_LoanDate";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Id != null){strWhere += " and Id=@in_Id ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Id", DbType.String, EmsMod.Id)); }if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.CName != null){strWhere += " and CName=@in_CName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CName", DbType.String, EmsMod.CName)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.stuLoanIDCard != null){strWhere += " and stuLoanIDCard=@in_stuLoanIDCard ";parmsList.Add(dbHelper.CreateInDbParameter("@in_stuLoanIDCard", DbType.String, EmsMod.stuLoanIDCard)); }if (EmsMod.StartDate != null){strWhere += " and StartDate=@in_StartDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StartDate", DbType.String, EmsMod.StartDate)); }if (EmsMod.isStatus != null){strWhere += " and isStatus=@in_isStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_isStatus", DbType.String, EmsMod.isStatus)); }if (EmsMod.orderID != null){strWhere += " and orderID=@in_orderID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_orderID", DbType.String, EmsMod.orderID)); }if (EmsMod.OrderNo != null){strWhere += " and OrderNo=@in_OrderNo ";parmsList.Add(dbHelper.CreateInDbParameter("@in_OrderNo", DbType.String, EmsMod.OrderNo)); }if (EmsMod.LoanName != null){strWhere += " and LoanName=@in_LoanName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LoanName", DbType.String, EmsMod.LoanName)); }if (EmsMod.stuLoanName != null){strWhere += " and stuLoanName=@in_stuLoanName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_stuLoanName", DbType.String, EmsMod.stuLoanName)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.View_LoanDate> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.View_LoanDate EmsMod)
        {
            string TableName = "View_LoanDate";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Id != null){strWhere += " and Id=@in_Id ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Id", DbType.String, EmsMod.Id)); }if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.CName != null){strWhere += " and CName=@in_CName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CName", DbType.String, EmsMod.CName)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.stuLoanIDCard != null){strWhere += " and stuLoanIDCard=@in_stuLoanIDCard ";parmsList.Add(dbHelper.CreateInDbParameter("@in_stuLoanIDCard", DbType.String, EmsMod.stuLoanIDCard)); }if (EmsMod.StartDate != null){strWhere += " and StartDate=@in_StartDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StartDate", DbType.String, EmsMod.StartDate)); }if (EmsMod.isStatus != null){strWhere += " and isStatus=@in_isStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_isStatus", DbType.String, EmsMod.isStatus)); }if (EmsMod.orderID != null){strWhere += " and orderID=@in_orderID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_orderID", DbType.String, EmsMod.orderID)); }if (EmsMod.OrderNo != null){strWhere += " and OrderNo=@in_OrderNo ";parmsList.Add(dbHelper.CreateInDbParameter("@in_OrderNo", DbType.String, EmsMod.OrderNo)); }if (EmsMod.LoanName != null){strWhere += " and LoanName=@in_LoanName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LoanName", DbType.String, EmsMod.LoanName)); }if (EmsMod.stuLoanName != null){strWhere += " and stuLoanName=@in_stuLoanName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_stuLoanName", DbType.String, EmsMod.stuLoanName)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.View_LoanDate EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.CName = dr["CName"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.stuLoanIDCard = dr["stuLoanIDCard"] as string;EmsModel.StartDate = dr["StartDate"] as DateTime?;EmsModel.isStatus = dr["isStatus"] as int?;EmsModel.orderID = dr["orderID"] as int?;EmsModel.OrderNo = dr["OrderNo"] as string;EmsModel.LoanName = dr["LoanName"] as string;EmsModel.stuLoanName = dr["stuLoanName"] as string;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.View_LoanDate> GetList(DataTable dt)
        {
            List<EmsModel.View_LoanDate> lst = new List<EmsModel.View_LoanDate>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.View_LoanDate mod = new EmsModel.View_LoanDate();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.View_LoanDate EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.CName = dr["CName"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.stuLoanIDCard = dr["stuLoanIDCard"] as string;EmsModel.StartDate = dr["StartDate"] as DateTime?;EmsModel.isStatus = dr["isStatus"] as int?;EmsModel.orderID = dr["orderID"] as int?;EmsModel.OrderNo = dr["OrderNo"] as string;EmsModel.LoanName = dr["LoanName"] as string;EmsModel.stuLoanName = dr["stuLoanName"] as string;
        }		

    }

	/// </summary>
	///	教学计划表实体类3
	/// </summary>
    public partial class View_InvenRoomEquip: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.View_InvenRoomEquip EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO View_InvenRoomEquip(");
						sbSql.Append("Id,InventoryListId,EquipId,AssetNumber,AssetName,RoomId,SourceRoomId,Status,IsLoss,Remarks,Barcode,ImageName)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Id,@in_InventoryListId,@in_EquipId,@in_AssetNumber,@in_AssetName,@in_RoomId,@in_SourceRoomId,@in_Status,@in_IsLoss,@in_Remarks,@in_Barcode,@in_ImageName)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_InventoryListId", DbType.Int32, EmsModel.InventoryListId),dbHelper.CreateInDbParameter("@in_EquipId", DbType.Int32, EmsModel.EquipId),dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsModel.AssetNumber),dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsModel.AssetName),dbHelper.CreateInDbParameter("@in_RoomId", DbType.Int32, EmsModel.RoomId),dbHelper.CreateInDbParameter("@in_SourceRoomId", DbType.Int32, EmsModel.SourceRoomId),dbHelper.CreateInDbParameter("@in_Status", DbType.Int32, EmsModel.Status),dbHelper.CreateInDbParameter("@in_IsLoss", DbType.Boolean, EmsModel.IsLoss),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsModel.Barcode),dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsModel.ImageName)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.View_InvenRoomEquip EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO View_InvenRoomEquip(");
						sbSql.Append("Id,InventoryListId,EquipId,AssetNumber,AssetName,RoomId,SourceRoomId,Status,IsLoss,Remarks,Barcode,ImageName)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Id,@in_InventoryListId,@in_EquipId,@in_AssetNumber,@in_AssetName,@in_RoomId,@in_SourceRoomId,@in_Status,@in_IsLoss,@in_Remarks,@in_Barcode,@in_ImageName)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_InventoryListId", DbType.Int32, EmsModel.InventoryListId),dbHelper.CreateInDbParameter("@in_EquipId", DbType.Int32, EmsModel.EquipId),dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsModel.AssetNumber),dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsModel.AssetName),dbHelper.CreateInDbParameter("@in_RoomId", DbType.Int32, EmsModel.RoomId),dbHelper.CreateInDbParameter("@in_SourceRoomId", DbType.Int32, EmsModel.SourceRoomId),dbHelper.CreateInDbParameter("@in_Status", DbType.Int32, EmsModel.Status),dbHelper.CreateInDbParameter("@in_IsLoss", DbType.Boolean, EmsModel.IsLoss),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsModel.Barcode),dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsModel.ImageName)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.View_InvenRoomEquip EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update View_InvenRoomEquip set ");
					sbSql.Append("Id=@in_Id,InventoryListId=@in_InventoryListId,EquipId=@in_EquipId,AssetNumber=@in_AssetNumber,AssetName=@in_AssetName,RoomId=@in_RoomId,SourceRoomId=@in_SourceRoomId,Status=@in_Status,IsLoss=@in_IsLoss,Remarks=@in_Remarks,Barcode=@in_Barcode,ImageName=@in_ImageName");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_InventoryListId", DbType.Int32, EmsModel.InventoryListId),dbHelper.CreateInDbParameter("@in_EquipId", DbType.Int32, EmsModel.EquipId),dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsModel.AssetNumber),dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsModel.AssetName),dbHelper.CreateInDbParameter("@in_RoomId", DbType.Int32, EmsModel.RoomId),dbHelper.CreateInDbParameter("@in_SourceRoomId", DbType.Int32, EmsModel.SourceRoomId),dbHelper.CreateInDbParameter("@in_Status", DbType.Int32, EmsModel.Status),dbHelper.CreateInDbParameter("@in_IsLoss", DbType.Boolean, EmsModel.IsLoss),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsModel.Barcode),dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsModel.ImageName)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.View_InvenRoomEquip EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update View_InvenRoomEquip set ");
					sbSql.Append("Id=@in_Id,InventoryListId=@in_InventoryListId,EquipId=@in_EquipId,AssetNumber=@in_AssetNumber,AssetName=@in_AssetName,RoomId=@in_RoomId,SourceRoomId=@in_SourceRoomId,Status=@in_Status,IsLoss=@in_IsLoss,Remarks=@in_Remarks,Barcode=@in_Barcode,ImageName=@in_ImageName");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_InventoryListId", DbType.Int32, EmsModel.InventoryListId),dbHelper.CreateInDbParameter("@in_EquipId", DbType.Int32, EmsModel.EquipId),dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsModel.AssetNumber),dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsModel.AssetName),dbHelper.CreateInDbParameter("@in_RoomId", DbType.Int32, EmsModel.RoomId),dbHelper.CreateInDbParameter("@in_SourceRoomId", DbType.Int32, EmsModel.SourceRoomId),dbHelper.CreateInDbParameter("@in_Status", DbType.Int32, EmsModel.Status),dbHelper.CreateInDbParameter("@in_IsLoss", DbType.Boolean, EmsModel.IsLoss),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsModel.Barcode),dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsModel.ImageName)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM View_InvenRoomEquip");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM View_InvenRoomEquip");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists( )
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM View_InvenRoomEquip");
					sbSql.Append("");

					parms = new DbParameter[]{
						
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.View_InvenRoomEquip> GetListByPage(EmsModel.View_InvenRoomEquip EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "View_InvenRoomEquip";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Id != null){strWhere += " and Id=@in_Id ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Id", DbType.String, EmsMod.Id)); }if (EmsMod.InventoryListId != null){strWhere += " and InventoryListId=@in_InventoryListId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InventoryListId", DbType.String, EmsMod.InventoryListId)); }if (EmsMod.EquipId != null){strWhere += " and EquipId=@in_EquipId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipId", DbType.String, EmsMod.EquipId)); }if (EmsMod.AssetNumber != null){strWhere += " and AssetNumber=@in_AssetNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsMod.AssetNumber)); }if (EmsMod.AssetName != null){strWhere += " and AssetName=@in_AssetName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsMod.AssetName)); }if (EmsMod.RoomId != null){strWhere += " and RoomId=@in_RoomId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RoomId", DbType.String, EmsMod.RoomId)); }if (EmsMod.SourceRoomId != null){strWhere += " and SourceRoomId=@in_SourceRoomId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_SourceRoomId", DbType.String, EmsMod.SourceRoomId)); }if (EmsMod.Status != null){strWhere += " and Status=@in_Status ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Status", DbType.String, EmsMod.Status)); }if (EmsMod.IsLoss != null){strWhere += " and IsLoss=@in_IsLoss ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsLoss", DbType.String, EmsMod.IsLoss)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.Barcode != null){strWhere += " and Barcode=@in_Barcode ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsMod.Barcode)); }if (EmsMod.ImageName != null){strWhere += " and ImageName=@in_ImageName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsMod.ImageName)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.View_InvenRoomEquip> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.View_InvenRoomEquip EmsMod)
        {
            string TableName = "View_InvenRoomEquip";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Id != null){strWhere += " and Id=@in_Id ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Id", DbType.String, EmsMod.Id)); }if (EmsMod.InventoryListId != null){strWhere += " and InventoryListId=@in_InventoryListId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InventoryListId", DbType.String, EmsMod.InventoryListId)); }if (EmsMod.EquipId != null){strWhere += " and EquipId=@in_EquipId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipId", DbType.String, EmsMod.EquipId)); }if (EmsMod.AssetNumber != null){strWhere += " and AssetNumber=@in_AssetNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsMod.AssetNumber)); }if (EmsMod.AssetName != null){strWhere += " and AssetName=@in_AssetName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsMod.AssetName)); }if (EmsMod.RoomId != null){strWhere += " and RoomId=@in_RoomId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RoomId", DbType.String, EmsMod.RoomId)); }if (EmsMod.SourceRoomId != null){strWhere += " and SourceRoomId=@in_SourceRoomId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_SourceRoomId", DbType.String, EmsMod.SourceRoomId)); }if (EmsMod.Status != null){strWhere += " and Status=@in_Status ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Status", DbType.String, EmsMod.Status)); }if (EmsMod.IsLoss != null){strWhere += " and IsLoss=@in_IsLoss ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsLoss", DbType.String, EmsMod.IsLoss)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.Barcode != null){strWhere += " and Barcode=@in_Barcode ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsMod.Barcode)); }if (EmsMod.ImageName != null){strWhere += " and ImageName=@in_ImageName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsMod.ImageName)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.View_InvenRoomEquip EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.InventoryListId = dr["InventoryListId"] as int?;EmsModel.EquipId = dr["EquipId"] as int?;EmsModel.AssetNumber = dr["AssetNumber"] as string;EmsModel.AssetName = dr["AssetName"] as string;EmsModel.RoomId = dr["RoomId"] as int?;EmsModel.SourceRoomId = dr["SourceRoomId"] as int?;EmsModel.Status = dr["Status"] as int?;EmsModel.IsLoss = dr["IsLoss"] as bool?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.Barcode = dr["Barcode"] as string;EmsModel.ImageName = dr["ImageName"] as string;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.View_InvenRoomEquip> GetList(DataTable dt)
        {
            List<EmsModel.View_InvenRoomEquip> lst = new List<EmsModel.View_InvenRoomEquip>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.View_InvenRoomEquip mod = new EmsModel.View_InvenRoomEquip();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.View_InvenRoomEquip EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.InventoryListId = dr["InventoryListId"] as int?;EmsModel.EquipId = dr["EquipId"] as int?;EmsModel.AssetNumber = dr["AssetNumber"] as string;EmsModel.AssetName = dr["AssetName"] as string;EmsModel.RoomId = dr["RoomId"] as int?;EmsModel.SourceRoomId = dr["SourceRoomId"] as int?;EmsModel.Status = dr["Status"] as int?;EmsModel.IsLoss = dr["IsLoss"] as bool?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.Barcode = dr["Barcode"] as string;EmsModel.ImageName = dr["ImageName"] as string;
        }		

    }

	/// </summary>
	///	教学计划表实体类4
	/// </summary>
    public partial class View_LoanANDEscheat: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.View_LoanANDEscheat EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO View_LoanANDEscheat(");
						sbSql.Append("OrderId,InventoryKindId,InstrumentEquip,countL,countE)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_OrderId,@in_InventoryKindId,@in_InstrumentEquip,@in_countL,@in_countE)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_OrderId", DbType.Int32, EmsModel.OrderId),dbHelper.CreateInDbParameter("@in_InventoryKindId", DbType.Int32, EmsModel.InventoryKindId),dbHelper.CreateInDbParameter("@in_InstrumentEquip", DbType.String, EmsModel.InstrumentEquip),dbHelper.CreateInDbParameter("@in_countL", DbType.Int32, EmsModel.countL),dbHelper.CreateInDbParameter("@in_countE", DbType.Int32, EmsModel.countE)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.View_LoanANDEscheat EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO View_LoanANDEscheat(");
						sbSql.Append("OrderId,InventoryKindId,InstrumentEquip,countL,countE)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_OrderId,@in_InventoryKindId,@in_InstrumentEquip,@in_countL,@in_countE)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_OrderId", DbType.Int32, EmsModel.OrderId),dbHelper.CreateInDbParameter("@in_InventoryKindId", DbType.Int32, EmsModel.InventoryKindId),dbHelper.CreateInDbParameter("@in_InstrumentEquip", DbType.String, EmsModel.InstrumentEquip),dbHelper.CreateInDbParameter("@in_countL", DbType.Int32, EmsModel.countL),dbHelper.CreateInDbParameter("@in_countE", DbType.Int32, EmsModel.countE)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.View_LoanANDEscheat EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update View_LoanANDEscheat set ");
					sbSql.Append("OrderId=@in_OrderId,InventoryKindId=@in_InventoryKindId,InstrumentEquip=@in_InstrumentEquip,countL=@in_countL,countE=@in_countE");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_OrderId", DbType.Int32, EmsModel.OrderId),dbHelper.CreateInDbParameter("@in_InventoryKindId", DbType.Int32, EmsModel.InventoryKindId),dbHelper.CreateInDbParameter("@in_InstrumentEquip", DbType.String, EmsModel.InstrumentEquip),dbHelper.CreateInDbParameter("@in_countL", DbType.Int32, EmsModel.countL),dbHelper.CreateInDbParameter("@in_countE", DbType.Int32, EmsModel.countE)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.View_LoanANDEscheat EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update View_LoanANDEscheat set ");
					sbSql.Append("OrderId=@in_OrderId,InventoryKindId=@in_InventoryKindId,InstrumentEquip=@in_InstrumentEquip,countL=@in_countL,countE=@in_countE");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_OrderId", DbType.Int32, EmsModel.OrderId),dbHelper.CreateInDbParameter("@in_InventoryKindId", DbType.Int32, EmsModel.InventoryKindId),dbHelper.CreateInDbParameter("@in_InstrumentEquip", DbType.String, EmsModel.InstrumentEquip),dbHelper.CreateInDbParameter("@in_countL", DbType.Int32, EmsModel.countL),dbHelper.CreateInDbParameter("@in_countE", DbType.Int32, EmsModel.countE)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM View_LoanANDEscheat");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM View_LoanANDEscheat");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists( )
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM View_LoanANDEscheat");
					sbSql.Append("");

					parms = new DbParameter[]{
						
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.View_LoanANDEscheat> GetListByPage(EmsModel.View_LoanANDEscheat EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "View_LoanANDEscheat";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.OrderId != null){strWhere += " and OrderId=@in_OrderId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_OrderId", DbType.String, EmsMod.OrderId)); }if (EmsMod.InventoryKindId != null){strWhere += " and InventoryKindId=@in_InventoryKindId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InventoryKindId", DbType.String, EmsMod.InventoryKindId)); }if (EmsMod.InstrumentEquip != null){strWhere += " and InstrumentEquip=@in_InstrumentEquip ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InstrumentEquip", DbType.String, EmsMod.InstrumentEquip)); }if (EmsMod.countL != null){strWhere += " and countL=@in_countL ";parmsList.Add(dbHelper.CreateInDbParameter("@in_countL", DbType.String, EmsMod.countL)); }if (EmsMod.countE != null){strWhere += " and countE=@in_countE ";parmsList.Add(dbHelper.CreateInDbParameter("@in_countE", DbType.String, EmsMod.countE)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.View_LoanANDEscheat> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.View_LoanANDEscheat EmsMod)
        {
            string TableName = "View_LoanANDEscheat";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.OrderId != null){strWhere += " and OrderId=@in_OrderId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_OrderId", DbType.String, EmsMod.OrderId)); }if (EmsMod.InventoryKindId != null){strWhere += " and InventoryKindId=@in_InventoryKindId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InventoryKindId", DbType.String, EmsMod.InventoryKindId)); }if (EmsMod.InstrumentEquip != null){strWhere += " and InstrumentEquip=@in_InstrumentEquip ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InstrumentEquip", DbType.String, EmsMod.InstrumentEquip)); }if (EmsMod.countL != null){strWhere += " and countL=@in_countL ";parmsList.Add(dbHelper.CreateInDbParameter("@in_countL", DbType.String, EmsMod.countL)); }if (EmsMod.countE != null){strWhere += " and countE=@in_countE ";parmsList.Add(dbHelper.CreateInDbParameter("@in_countE", DbType.String, EmsMod.countE)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.View_LoanANDEscheat EmsModel, DbDataReader dr)
        {
            EmsModel.OrderId = dr["OrderId"] as int?;EmsModel.InventoryKindId = dr["InventoryKindId"] as int?;EmsModel.InstrumentEquip = dr["InstrumentEquip"] as string;EmsModel.countL = dr["countL"] as int?;EmsModel.countE = dr["countE"] as int?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.View_LoanANDEscheat> GetList(DataTable dt)
        {
            List<EmsModel.View_LoanANDEscheat> lst = new List<EmsModel.View_LoanANDEscheat>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.View_LoanANDEscheat mod = new EmsModel.View_LoanANDEscheat();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.View_LoanANDEscheat EmsModel, DataRow dr)
        {
            EmsModel.OrderId = dr["OrderId"] as int?;EmsModel.InventoryKindId = dr["InventoryKindId"] as int?;EmsModel.InstrumentEquip = dr["InstrumentEquip"] as string;EmsModel.countL = dr["countL"] as int?;EmsModel.countE = dr["countE"] as int?;
        }		

    }

	/// </summary>
	///	教学计划表实体类5
	/// </summary>
    public partial class View_Calendar: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.View_Calendar EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO View_Calendar(");
						sbSql.Append("Id,title,start,StartDate,planName,isStatus,orderid,num)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Id,@in_title,@in_start,@in_StartDate,@in_planName,@in_isStatus,@in_orderid,@in_num)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_title", DbType.String, EmsModel.title),dbHelper.CreateInDbParameter("@in_start", DbType.String, EmsModel.start),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_planName", DbType.String, EmsModel.planName),dbHelper.CreateInDbParameter("@in_isStatus", DbType.Int32, EmsModel.isStatus),dbHelper.CreateInDbParameter("@in_orderid", DbType.Int32, EmsModel.orderid),dbHelper.CreateInDbParameter("@in_num", DbType.Int32, EmsModel.num)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.View_Calendar EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO View_Calendar(");
						sbSql.Append("Id,title,start,StartDate,planName,isStatus,orderid,num)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Id,@in_title,@in_start,@in_StartDate,@in_planName,@in_isStatus,@in_orderid,@in_num)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_title", DbType.String, EmsModel.title),dbHelper.CreateInDbParameter("@in_start", DbType.String, EmsModel.start),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_planName", DbType.String, EmsModel.planName),dbHelper.CreateInDbParameter("@in_isStatus", DbType.Int32, EmsModel.isStatus),dbHelper.CreateInDbParameter("@in_orderid", DbType.Int32, EmsModel.orderid),dbHelper.CreateInDbParameter("@in_num", DbType.Int32, EmsModel.num)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.View_Calendar EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update View_Calendar set ");
					sbSql.Append("Id=@in_Id,title=@in_title,start=@in_start,StartDate=@in_StartDate,planName=@in_planName,isStatus=@in_isStatus,orderid=@in_orderid,num=@in_num");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_title", DbType.String, EmsModel.title),dbHelper.CreateInDbParameter("@in_start", DbType.String, EmsModel.start),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_planName", DbType.String, EmsModel.planName),dbHelper.CreateInDbParameter("@in_isStatus", DbType.Int32, EmsModel.isStatus),dbHelper.CreateInDbParameter("@in_orderid", DbType.Int32, EmsModel.orderid),dbHelper.CreateInDbParameter("@in_num", DbType.Int32, EmsModel.num)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.View_Calendar EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update View_Calendar set ");
					sbSql.Append("Id=@in_Id,title=@in_title,start=@in_start,StartDate=@in_StartDate,planName=@in_planName,isStatus=@in_isStatus,orderid=@in_orderid,num=@in_num");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_title", DbType.String, EmsModel.title),dbHelper.CreateInDbParameter("@in_start", DbType.String, EmsModel.start),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_planName", DbType.String, EmsModel.planName),dbHelper.CreateInDbParameter("@in_isStatus", DbType.Int32, EmsModel.isStatus),dbHelper.CreateInDbParameter("@in_orderid", DbType.Int32, EmsModel.orderid),dbHelper.CreateInDbParameter("@in_num", DbType.Int32, EmsModel.num)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM View_Calendar");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM View_Calendar");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists( )
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM View_Calendar");
					sbSql.Append("");

					parms = new DbParameter[]{
						
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.View_Calendar> GetListByPage(EmsModel.View_Calendar EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "View_Calendar";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Id != null){strWhere += " and Id=@in_Id ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Id", DbType.String, EmsMod.Id)); }if (EmsMod.title != null){strWhere += " and title=@in_title ";parmsList.Add(dbHelper.CreateInDbParameter("@in_title", DbType.String, EmsMod.title)); }if (EmsMod.start != null){strWhere += " and start=@in_start ";parmsList.Add(dbHelper.CreateInDbParameter("@in_start", DbType.String, EmsMod.start)); }if (EmsMod.StartDate != null){strWhere += " and StartDate=@in_StartDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StartDate", DbType.String, EmsMod.StartDate)); }if (EmsMod.planName != null){strWhere += " and planName=@in_planName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_planName", DbType.String, EmsMod.planName)); }if (EmsMod.isStatus != null){strWhere += " and isStatus=@in_isStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_isStatus", DbType.String, EmsMod.isStatus)); }if (EmsMod.orderid != null){strWhere += " and orderid=@in_orderid ";parmsList.Add(dbHelper.CreateInDbParameter("@in_orderid", DbType.String, EmsMod.orderid)); }if (EmsMod.num != null){strWhere += " and num=@in_num ";parmsList.Add(dbHelper.CreateInDbParameter("@in_num", DbType.String, EmsMod.num)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.View_Calendar> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.View_Calendar EmsMod)
        {
            string TableName = "View_Calendar";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Id != null){strWhere += " and Id=@in_Id ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Id", DbType.String, EmsMod.Id)); }if (EmsMod.title != null){strWhere += " and title=@in_title ";parmsList.Add(dbHelper.CreateInDbParameter("@in_title", DbType.String, EmsMod.title)); }if (EmsMod.start != null){strWhere += " and start=@in_start ";parmsList.Add(dbHelper.CreateInDbParameter("@in_start", DbType.String, EmsMod.start)); }if (EmsMod.StartDate != null){strWhere += " and StartDate=@in_StartDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StartDate", DbType.String, EmsMod.StartDate)); }if (EmsMod.planName != null){strWhere += " and planName=@in_planName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_planName", DbType.String, EmsMod.planName)); }if (EmsMod.isStatus != null){strWhere += " and isStatus=@in_isStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_isStatus", DbType.String, EmsMod.isStatus)); }if (EmsMod.orderid != null){strWhere += " and orderid=@in_orderid ";parmsList.Add(dbHelper.CreateInDbParameter("@in_orderid", DbType.String, EmsMod.orderid)); }if (EmsMod.num != null){strWhere += " and num=@in_num ";parmsList.Add(dbHelper.CreateInDbParameter("@in_num", DbType.String, EmsMod.num)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.View_Calendar EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.title = dr["title"] as string;EmsModel.start = dr["start"] as string;EmsModel.StartDate = dr["StartDate"] as DateTime?;EmsModel.planName = dr["planName"] as string;EmsModel.isStatus = dr["isStatus"] as int?;EmsModel.orderid = dr["orderid"] as int?;EmsModel.num = dr["num"] as long?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.View_Calendar> GetList(DataTable dt)
        {
            List<EmsModel.View_Calendar> lst = new List<EmsModel.View_Calendar>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.View_Calendar mod = new EmsModel.View_Calendar();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.View_Calendar EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.title = dr["title"] as string;EmsModel.start = dr["start"] as string;EmsModel.StartDate = dr["StartDate"] as DateTime?;EmsModel.planName = dr["planName"] as string;EmsModel.isStatus = dr["isStatus"] as int?;EmsModel.orderid = dr["orderid"] as int?;EmsModel.num = dr["num"] as long?;
        }		

    }

	/// </summary>
	///	教学计划表实体类6
	/// </summary>
    public partial class View_RepairList: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.View_RepairList EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO View_RepairList(");
						sbSql.Append("ID,RepairMan,EquipID,RepairTime,DamageCauses,Damagetime,RepairLocation,CostOfRepairs,CompleteTime,Remark,RepairStatus,IsDelete,EQtype,name,userName)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_ID,@in_RepairMan,@in_EquipID,@in_RepairTime,@in_DamageCauses,@in_Damagetime,@in_RepairLocation,@in_CostOfRepairs,@in_CompleteTime,@in_Remark,@in_RepairStatus,@in_IsDelete,@in_EQtype,@in_name,@in_userName)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_ID", DbType.Int32, EmsModel.ID),dbHelper.CreateInDbParameter("@in_RepairMan", DbType.String, EmsModel.RepairMan),dbHelper.CreateInDbParameter("@in_EquipID", DbType.Int32, EmsModel.EquipID),dbHelper.CreateInDbParameter("@in_RepairTime", DbType.DateTime, EmsModel.RepairTime),dbHelper.CreateInDbParameter("@in_DamageCauses", DbType.String, EmsModel.DamageCauses),dbHelper.CreateInDbParameter("@in_Damagetime", DbType.DateTime, EmsModel.Damagetime),dbHelper.CreateInDbParameter("@in_RepairLocation", DbType.String, EmsModel.RepairLocation),dbHelper.CreateInDbParameter("@in_CostOfRepairs", DbType.String, EmsModel.CostOfRepairs),dbHelper.CreateInDbParameter("@in_CompleteTime", DbType.String, EmsModel.CompleteTime),dbHelper.CreateInDbParameter("@in_Remark", DbType.String, EmsModel.Remark),dbHelper.CreateInDbParameter("@in_RepairStatus", DbType.Int32, EmsModel.RepairStatus),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Int32, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_EQtype", DbType.Byte, EmsModel.EQtype),dbHelper.CreateInDbParameter("@in_name", DbType.String, EmsModel.name),dbHelper.CreateInDbParameter("@in_userName", DbType.String, EmsModel.userName)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.View_RepairList EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO View_RepairList(");
						sbSql.Append("ID,RepairMan,EquipID,RepairTime,DamageCauses,Damagetime,RepairLocation,CostOfRepairs,CompleteTime,Remark,RepairStatus,IsDelete,EQtype,name,userName)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_ID,@in_RepairMan,@in_EquipID,@in_RepairTime,@in_DamageCauses,@in_Damagetime,@in_RepairLocation,@in_CostOfRepairs,@in_CompleteTime,@in_Remark,@in_RepairStatus,@in_IsDelete,@in_EQtype,@in_name,@in_userName)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_ID", DbType.Int32, EmsModel.ID),dbHelper.CreateInDbParameter("@in_RepairMan", DbType.String, EmsModel.RepairMan),dbHelper.CreateInDbParameter("@in_EquipID", DbType.Int32, EmsModel.EquipID),dbHelper.CreateInDbParameter("@in_RepairTime", DbType.DateTime, EmsModel.RepairTime),dbHelper.CreateInDbParameter("@in_DamageCauses", DbType.String, EmsModel.DamageCauses),dbHelper.CreateInDbParameter("@in_Damagetime", DbType.DateTime, EmsModel.Damagetime),dbHelper.CreateInDbParameter("@in_RepairLocation", DbType.String, EmsModel.RepairLocation),dbHelper.CreateInDbParameter("@in_CostOfRepairs", DbType.String, EmsModel.CostOfRepairs),dbHelper.CreateInDbParameter("@in_CompleteTime", DbType.String, EmsModel.CompleteTime),dbHelper.CreateInDbParameter("@in_Remark", DbType.String, EmsModel.Remark),dbHelper.CreateInDbParameter("@in_RepairStatus", DbType.Int32, EmsModel.RepairStatus),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Int32, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_EQtype", DbType.Byte, EmsModel.EQtype),dbHelper.CreateInDbParameter("@in_name", DbType.String, EmsModel.name),dbHelper.CreateInDbParameter("@in_userName", DbType.String, EmsModel.userName)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.View_RepairList EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update View_RepairList set ");
					sbSql.Append("ID=@in_ID,RepairMan=@in_RepairMan,EquipID=@in_EquipID,RepairTime=@in_RepairTime,DamageCauses=@in_DamageCauses,Damagetime=@in_Damagetime,RepairLocation=@in_RepairLocation,CostOfRepairs=@in_CostOfRepairs,CompleteTime=@in_CompleteTime,Remark=@in_Remark,RepairStatus=@in_RepairStatus,IsDelete=@in_IsDelete,EQtype=@in_EQtype,name=@in_name,userName=@in_userName");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_ID", DbType.Int32, EmsModel.ID),dbHelper.CreateInDbParameter("@in_RepairMan", DbType.String, EmsModel.RepairMan),dbHelper.CreateInDbParameter("@in_EquipID", DbType.Int32, EmsModel.EquipID),dbHelper.CreateInDbParameter("@in_RepairTime", DbType.DateTime, EmsModel.RepairTime),dbHelper.CreateInDbParameter("@in_DamageCauses", DbType.String, EmsModel.DamageCauses),dbHelper.CreateInDbParameter("@in_Damagetime", DbType.DateTime, EmsModel.Damagetime),dbHelper.CreateInDbParameter("@in_RepairLocation", DbType.String, EmsModel.RepairLocation),dbHelper.CreateInDbParameter("@in_CostOfRepairs", DbType.String, EmsModel.CostOfRepairs),dbHelper.CreateInDbParameter("@in_CompleteTime", DbType.String, EmsModel.CompleteTime),dbHelper.CreateInDbParameter("@in_Remark", DbType.String, EmsModel.Remark),dbHelper.CreateInDbParameter("@in_RepairStatus", DbType.Int32, EmsModel.RepairStatus),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Int32, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_EQtype", DbType.Byte, EmsModel.EQtype),dbHelper.CreateInDbParameter("@in_name", DbType.String, EmsModel.name),dbHelper.CreateInDbParameter("@in_userName", DbType.String, EmsModel.userName)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.View_RepairList EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update View_RepairList set ");
					sbSql.Append("ID=@in_ID,RepairMan=@in_RepairMan,EquipID=@in_EquipID,RepairTime=@in_RepairTime,DamageCauses=@in_DamageCauses,Damagetime=@in_Damagetime,RepairLocation=@in_RepairLocation,CostOfRepairs=@in_CostOfRepairs,CompleteTime=@in_CompleteTime,Remark=@in_Remark,RepairStatus=@in_RepairStatus,IsDelete=@in_IsDelete,EQtype=@in_EQtype,name=@in_name,userName=@in_userName");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_ID", DbType.Int32, EmsModel.ID),dbHelper.CreateInDbParameter("@in_RepairMan", DbType.String, EmsModel.RepairMan),dbHelper.CreateInDbParameter("@in_EquipID", DbType.Int32, EmsModel.EquipID),dbHelper.CreateInDbParameter("@in_RepairTime", DbType.DateTime, EmsModel.RepairTime),dbHelper.CreateInDbParameter("@in_DamageCauses", DbType.String, EmsModel.DamageCauses),dbHelper.CreateInDbParameter("@in_Damagetime", DbType.DateTime, EmsModel.Damagetime),dbHelper.CreateInDbParameter("@in_RepairLocation", DbType.String, EmsModel.RepairLocation),dbHelper.CreateInDbParameter("@in_CostOfRepairs", DbType.String, EmsModel.CostOfRepairs),dbHelper.CreateInDbParameter("@in_CompleteTime", DbType.String, EmsModel.CompleteTime),dbHelper.CreateInDbParameter("@in_Remark", DbType.String, EmsModel.Remark),dbHelper.CreateInDbParameter("@in_RepairStatus", DbType.Int32, EmsModel.RepairStatus),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Int32, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_EQtype", DbType.Byte, EmsModel.EQtype),dbHelper.CreateInDbParameter("@in_name", DbType.String, EmsModel.name),dbHelper.CreateInDbParameter("@in_userName", DbType.String, EmsModel.userName)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM View_RepairList");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM View_RepairList");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists( )
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM View_RepairList");
					sbSql.Append("");

					parms = new DbParameter[]{
						
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.View_RepairList> GetListByPage(EmsModel.View_RepairList EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "View_RepairList";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.ID != null){strWhere += " and ID=@in_ID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ID", DbType.String, EmsMod.ID)); }if (EmsMod.RepairMan != null){strWhere += " and RepairMan=@in_RepairMan ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairMan", DbType.String, EmsMod.RepairMan)); }if (EmsMod.EquipID != null){strWhere += " and EquipID=@in_EquipID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipID", DbType.String, EmsMod.EquipID)); }if (EmsMod.RepairTime != null){strWhere += " and RepairTime=@in_RepairTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairTime", DbType.String, EmsMod.RepairTime)); }if (EmsMod.DamageCauses != null){strWhere += " and DamageCauses=@in_DamageCauses ";parmsList.Add(dbHelper.CreateInDbParameter("@in_DamageCauses", DbType.String, EmsMod.DamageCauses)); }if (EmsMod.Damagetime != null){strWhere += " and Damagetime=@in_Damagetime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Damagetime", DbType.String, EmsMod.Damagetime)); }if (EmsMod.RepairLocation != null){strWhere += " and RepairLocation=@in_RepairLocation ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairLocation", DbType.String, EmsMod.RepairLocation)); }if (EmsMod.CostOfRepairs != null){strWhere += " and CostOfRepairs=@in_CostOfRepairs ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CostOfRepairs", DbType.String, EmsMod.CostOfRepairs)); }if (EmsMod.CompleteTime != null){strWhere += " and CompleteTime=@in_CompleteTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CompleteTime", DbType.String, EmsMod.CompleteTime)); }if (EmsMod.Remark != null){strWhere += " and Remark=@in_Remark ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remark", DbType.String, EmsMod.Remark)); }if (EmsMod.RepairStatus != null){strWhere += " and RepairStatus=@in_RepairStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairStatus", DbType.String, EmsMod.RepairStatus)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.EQtype != null){strWhere += " and EQtype=@in_EQtype ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EQtype", DbType.String, EmsMod.EQtype)); }if (EmsMod.name != null){strWhere += " and name=@in_name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_name", DbType.String, EmsMod.name)); }if (EmsMod.userName != null){strWhere += " and userName=@in_userName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_userName", DbType.String, EmsMod.userName)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.View_RepairList> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.View_RepairList EmsMod)
        {
            string TableName = "View_RepairList";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.ID != null){strWhere += " and ID=@in_ID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ID", DbType.String, EmsMod.ID)); }if (EmsMod.RepairMan != null){strWhere += " and RepairMan=@in_RepairMan ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairMan", DbType.String, EmsMod.RepairMan)); }if (EmsMod.EquipID != null){strWhere += " and EquipID=@in_EquipID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipID", DbType.String, EmsMod.EquipID)); }if (EmsMod.RepairTime != null){strWhere += " and RepairTime=@in_RepairTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairTime", DbType.String, EmsMod.RepairTime)); }if (EmsMod.DamageCauses != null){strWhere += " and DamageCauses=@in_DamageCauses ";parmsList.Add(dbHelper.CreateInDbParameter("@in_DamageCauses", DbType.String, EmsMod.DamageCauses)); }if (EmsMod.Damagetime != null){strWhere += " and Damagetime=@in_Damagetime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Damagetime", DbType.String, EmsMod.Damagetime)); }if (EmsMod.RepairLocation != null){strWhere += " and RepairLocation=@in_RepairLocation ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairLocation", DbType.String, EmsMod.RepairLocation)); }if (EmsMod.CostOfRepairs != null){strWhere += " and CostOfRepairs=@in_CostOfRepairs ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CostOfRepairs", DbType.String, EmsMod.CostOfRepairs)); }if (EmsMod.CompleteTime != null){strWhere += " and CompleteTime=@in_CompleteTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CompleteTime", DbType.String, EmsMod.CompleteTime)); }if (EmsMod.Remark != null){strWhere += " and Remark=@in_Remark ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remark", DbType.String, EmsMod.Remark)); }if (EmsMod.RepairStatus != null){strWhere += " and RepairStatus=@in_RepairStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairStatus", DbType.String, EmsMod.RepairStatus)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.EQtype != null){strWhere += " and EQtype=@in_EQtype ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EQtype", DbType.String, EmsMod.EQtype)); }if (EmsMod.name != null){strWhere += " and name=@in_name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_name", DbType.String, EmsMod.name)); }if (EmsMod.userName != null){strWhere += " and userName=@in_userName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_userName", DbType.String, EmsMod.userName)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.View_RepairList EmsModel, DbDataReader dr)
        {
            EmsModel.ID = dr["ID"] as int?;EmsModel.RepairMan = dr["RepairMan"] as string;EmsModel.EquipID = dr["EquipID"] as int?;EmsModel.RepairTime = dr["RepairTime"] as DateTime?;EmsModel.DamageCauses = dr["DamageCauses"] as string;EmsModel.Damagetime = dr["Damagetime"] as DateTime?;EmsModel.RepairLocation = dr["RepairLocation"] as string;EmsModel.CostOfRepairs = dr["CostOfRepairs"] as string;EmsModel.CompleteTime = dr["CompleteTime"] as string;EmsModel.Remark = dr["Remark"] as string;EmsModel.RepairStatus = dr["RepairStatus"] as int?;EmsModel.IsDelete = dr["IsDelete"] as int?;EmsModel.EQtype = dr["EQtype"] as Byte?;EmsModel.name = dr["name"] as string;EmsModel.userName = dr["userName"] as string;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.View_RepairList> GetList(DataTable dt)
        {
            List<EmsModel.View_RepairList> lst = new List<EmsModel.View_RepairList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.View_RepairList mod = new EmsModel.View_RepairList();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.View_RepairList EmsModel, DataRow dr)
        {
            EmsModel.ID = dr["ID"] as int?;EmsModel.RepairMan = dr["RepairMan"] as string;EmsModel.EquipID = dr["EquipID"] as int?;EmsModel.RepairTime = dr["RepairTime"] as DateTime?;EmsModel.DamageCauses = dr["DamageCauses"] as string;EmsModel.Damagetime = dr["Damagetime"] as DateTime?;EmsModel.RepairLocation = dr["RepairLocation"] as string;EmsModel.CostOfRepairs = dr["CostOfRepairs"] as string;EmsModel.CompleteTime = dr["CompleteTime"] as string;EmsModel.Remark = dr["Remark"] as string;EmsModel.RepairStatus = dr["RepairStatus"] as int?;EmsModel.IsDelete = dr["IsDelete"] as int?;EmsModel.EQtype = dr["EQtype"] as Byte?;EmsModel.name = dr["name"] as string;EmsModel.userName = dr["userName"] as string;
        }		

    }

	/// </summary>
	///	教学计划表实体类7
	/// </summary>
    public partial class View_EquipDatail: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.View_EquipDatail EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO View_EquipDatail(");
						sbSql.Append("Id,EquipKindId,AssetNumber,EquipIntoID,EquipStatus,Type,Barcode,ImageName,Count,ClassNumber,AssetsClassName,IntlClassCode,IntlClassName,AssetName,Unit,UsageStatus,UsageDirection,JYBBBSYFX,AcquisitionMethod,AcquisitionDate,BrandStandardModel,EquipmentUse,UseDepartment,UsePeople,Factory,StorageLocation,WorthType,UseNature,Worth,FinanceRecordType,FiscalFunds,NonFiscalFunds,FinanceRecordDate,VoucherNumber,UseTime,ExpectedScrapDate,DepreciationState,NetWorth,OutFactoryNumber,Supplier,FundsSubject,PurchaseModality,CountryCode,Operator,GuaranteeEndDate,EquipmentNumber,InvoiceNumber,CompactNumber,BasicFunds,ItemFunds1,ItemFunds2,ItemFunds3,ItemFunds4,ItemFundsMoney1,ItemFundsMoney2,ItemFundsMoney3,ItemFundsMoney4,Remarks,Creator,CreateTime,Editor,UpdateTime,IsDelete,UseStatus,StorageLocation1,IsConsume,EquipSource,EquipOwner,ManualModify,ImageUrl,BorrowYN,WarehouseName)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Id,@in_EquipKindId,@in_AssetNumber,@in_EquipIntoID,@in_EquipStatus,@in_Type,@in_Barcode,@in_ImageName,@in_Count,@in_ClassNumber,@in_AssetsClassName,@in_IntlClassCode,@in_IntlClassName,@in_AssetName,@in_Unit,@in_UsageStatus,@in_UsageDirection,@in_JYBBBSYFX,@in_AcquisitionMethod,@in_AcquisitionDate,@in_BrandStandardModel,@in_EquipmentUse,@in_UseDepartment,@in_UsePeople,@in_Factory,@in_StorageLocation,@in_WorthType,@in_UseNature,@in_Worth,@in_FinanceRecordType,@in_FiscalFunds,@in_NonFiscalFunds,@in_FinanceRecordDate,@in_VoucherNumber,@in_UseTime,@in_ExpectedScrapDate,@in_DepreciationState,@in_NetWorth,@in_OutFactoryNumber,@in_Supplier,@in_FundsSubject,@in_PurchaseModality,@in_CountryCode,@in_Operator,@in_GuaranteeEndDate,@in_EquipmentNumber,@in_InvoiceNumber,@in_CompactNumber,@in_BasicFunds,@in_ItemFunds1,@in_ItemFunds2,@in_ItemFunds3,@in_ItemFunds4,@in_ItemFundsMoney1,@in_ItemFundsMoney2,@in_ItemFundsMoney3,@in_ItemFundsMoney4,@in_Remarks,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_UseStatus,@in_StorageLocation1,@in_IsConsume,@in_EquipSource,@in_EquipOwner,@in_ManualModify,@in_ImageUrl,@in_BorrowYN,@in_WarehouseName)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsModel.AssetNumber),dbHelper.CreateInDbParameter("@in_EquipIntoID", DbType.Int32, EmsModel.EquipIntoID),dbHelper.CreateInDbParameter("@in_EquipStatus", DbType.Int32, EmsModel.EquipStatus),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsModel.Barcode),dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsModel.ImageName),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_ClassNumber", DbType.String, EmsModel.ClassNumber),dbHelper.CreateInDbParameter("@in_AssetsClassName", DbType.String, EmsModel.AssetsClassName),dbHelper.CreateInDbParameter("@in_IntlClassCode", DbType.String, EmsModel.IntlClassCode),dbHelper.CreateInDbParameter("@in_IntlClassName", DbType.String, EmsModel.IntlClassName),dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsModel.AssetName),dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsModel.Unit),dbHelper.CreateInDbParameter("@in_UsageStatus", DbType.String, EmsModel.UsageStatus),dbHelper.CreateInDbParameter("@in_UsageDirection", DbType.String, EmsModel.UsageDirection),dbHelper.CreateInDbParameter("@in_JYBBBSYFX", DbType.String, EmsModel.JYBBBSYFX),dbHelper.CreateInDbParameter("@in_AcquisitionMethod", DbType.String, EmsModel.AcquisitionMethod),dbHelper.CreateInDbParameter("@in_AcquisitionDate", DbType.DateTime, EmsModel.AcquisitionDate),dbHelper.CreateInDbParameter("@in_BrandStandardModel", DbType.String, EmsModel.BrandStandardModel),dbHelper.CreateInDbParameter("@in_EquipmentUse", DbType.String, EmsModel.EquipmentUse),dbHelper.CreateInDbParameter("@in_UseDepartment", DbType.String, EmsModel.UseDepartment),dbHelper.CreateInDbParameter("@in_UsePeople", DbType.String, EmsModel.UsePeople),dbHelper.CreateInDbParameter("@in_Factory", DbType.String, EmsModel.Factory),dbHelper.CreateInDbParameter("@in_StorageLocation", DbType.String, EmsModel.StorageLocation),dbHelper.CreateInDbParameter("@in_WorthType", DbType.String, EmsModel.WorthType),dbHelper.CreateInDbParameter("@in_UseNature", DbType.String, EmsModel.UseNature),dbHelper.CreateInDbParameter("@in_Worth", DbType.Decimal, EmsModel.Worth),dbHelper.CreateInDbParameter("@in_FinanceRecordType", DbType.String, EmsModel.FinanceRecordType),dbHelper.CreateInDbParameter("@in_FiscalFunds", DbType.Decimal, EmsModel.FiscalFunds),dbHelper.CreateInDbParameter("@in_NonFiscalFunds", DbType.Decimal, EmsModel.NonFiscalFunds),dbHelper.CreateInDbParameter("@in_FinanceRecordDate", DbType.DateTime, EmsModel.FinanceRecordDate),dbHelper.CreateInDbParameter("@in_VoucherNumber", DbType.String, EmsModel.VoucherNumber),dbHelper.CreateInDbParameter("@in_UseTime", DbType.Int32, EmsModel.UseTime),dbHelper.CreateInDbParameter("@in_ExpectedScrapDate", DbType.DateTime, EmsModel.ExpectedScrapDate),dbHelper.CreateInDbParameter("@in_DepreciationState", DbType.String, EmsModel.DepreciationState),dbHelper.CreateInDbParameter("@in_NetWorth", DbType.Decimal, EmsModel.NetWorth),dbHelper.CreateInDbParameter("@in_OutFactoryNumber", DbType.String, EmsModel.OutFactoryNumber),dbHelper.CreateInDbParameter("@in_Supplier", DbType.String, EmsModel.Supplier),dbHelper.CreateInDbParameter("@in_FundsSubject", DbType.String, EmsModel.FundsSubject),dbHelper.CreateInDbParameter("@in_PurchaseModality", DbType.String, EmsModel.PurchaseModality),dbHelper.CreateInDbParameter("@in_CountryCode", DbType.String, EmsModel.CountryCode),dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsModel.Operator),dbHelper.CreateInDbParameter("@in_GuaranteeEndDate", DbType.DateTime, EmsModel.GuaranteeEndDate),dbHelper.CreateInDbParameter("@in_EquipmentNumber", DbType.String, EmsModel.EquipmentNumber),dbHelper.CreateInDbParameter("@in_InvoiceNumber", DbType.String, EmsModel.InvoiceNumber),dbHelper.CreateInDbParameter("@in_CompactNumber", DbType.String, EmsModel.CompactNumber),dbHelper.CreateInDbParameter("@in_BasicFunds", DbType.String, EmsModel.BasicFunds),dbHelper.CreateInDbParameter("@in_ItemFunds1", DbType.String, EmsModel.ItemFunds1),dbHelper.CreateInDbParameter("@in_ItemFunds2", DbType.String, EmsModel.ItemFunds2),dbHelper.CreateInDbParameter("@in_ItemFunds3", DbType.String, EmsModel.ItemFunds3),dbHelper.CreateInDbParameter("@in_ItemFunds4", DbType.String, EmsModel.ItemFunds4),dbHelper.CreateInDbParameter("@in_ItemFundsMoney1", DbType.Decimal, EmsModel.ItemFundsMoney1),dbHelper.CreateInDbParameter("@in_ItemFundsMoney2", DbType.Decimal, EmsModel.ItemFundsMoney2),dbHelper.CreateInDbParameter("@in_ItemFundsMoney3", DbType.Decimal, EmsModel.ItemFundsMoney3),dbHelper.CreateInDbParameter("@in_ItemFundsMoney4", DbType.Decimal, EmsModel.ItemFundsMoney4),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus),dbHelper.CreateInDbParameter("@in_StorageLocation1", DbType.String, EmsModel.StorageLocation1),dbHelper.CreateInDbParameter("@in_IsConsume", DbType.Byte, EmsModel.IsConsume),dbHelper.CreateInDbParameter("@in_EquipSource", DbType.Byte, EmsModel.EquipSource),dbHelper.CreateInDbParameter("@in_EquipOwner", DbType.String, EmsModel.EquipOwner),dbHelper.CreateInDbParameter("@in_ManualModify", DbType.Byte, EmsModel.ManualModify),dbHelper.CreateInDbParameter("@in_ImageUrl", DbType.String, EmsModel.ImageUrl),dbHelper.CreateInDbParameter("@in_BorrowYN", DbType.Byte, EmsModel.BorrowYN),dbHelper.CreateInDbParameter("@in_WarehouseName", DbType.String, EmsModel.WarehouseName)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.View_EquipDatail EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO View_EquipDatail(");
						sbSql.Append("Id,EquipKindId,AssetNumber,EquipIntoID,EquipStatus,Type,Barcode,ImageName,Count,ClassNumber,AssetsClassName,IntlClassCode,IntlClassName,AssetName,Unit,UsageStatus,UsageDirection,JYBBBSYFX,AcquisitionMethod,AcquisitionDate,BrandStandardModel,EquipmentUse,UseDepartment,UsePeople,Factory,StorageLocation,WorthType,UseNature,Worth,FinanceRecordType,FiscalFunds,NonFiscalFunds,FinanceRecordDate,VoucherNumber,UseTime,ExpectedScrapDate,DepreciationState,NetWorth,OutFactoryNumber,Supplier,FundsSubject,PurchaseModality,CountryCode,Operator,GuaranteeEndDate,EquipmentNumber,InvoiceNumber,CompactNumber,BasicFunds,ItemFunds1,ItemFunds2,ItemFunds3,ItemFunds4,ItemFundsMoney1,ItemFundsMoney2,ItemFundsMoney3,ItemFundsMoney4,Remarks,Creator,CreateTime,Editor,UpdateTime,IsDelete,UseStatus,StorageLocation1,IsConsume,EquipSource,EquipOwner,ManualModify,ImageUrl,BorrowYN,WarehouseName)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Id,@in_EquipKindId,@in_AssetNumber,@in_EquipIntoID,@in_EquipStatus,@in_Type,@in_Barcode,@in_ImageName,@in_Count,@in_ClassNumber,@in_AssetsClassName,@in_IntlClassCode,@in_IntlClassName,@in_AssetName,@in_Unit,@in_UsageStatus,@in_UsageDirection,@in_JYBBBSYFX,@in_AcquisitionMethod,@in_AcquisitionDate,@in_BrandStandardModel,@in_EquipmentUse,@in_UseDepartment,@in_UsePeople,@in_Factory,@in_StorageLocation,@in_WorthType,@in_UseNature,@in_Worth,@in_FinanceRecordType,@in_FiscalFunds,@in_NonFiscalFunds,@in_FinanceRecordDate,@in_VoucherNumber,@in_UseTime,@in_ExpectedScrapDate,@in_DepreciationState,@in_NetWorth,@in_OutFactoryNumber,@in_Supplier,@in_FundsSubject,@in_PurchaseModality,@in_CountryCode,@in_Operator,@in_GuaranteeEndDate,@in_EquipmentNumber,@in_InvoiceNumber,@in_CompactNumber,@in_BasicFunds,@in_ItemFunds1,@in_ItemFunds2,@in_ItemFunds3,@in_ItemFunds4,@in_ItemFundsMoney1,@in_ItemFundsMoney2,@in_ItemFundsMoney3,@in_ItemFundsMoney4,@in_Remarks,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_UseStatus,@in_StorageLocation1,@in_IsConsume,@in_EquipSource,@in_EquipOwner,@in_ManualModify,@in_ImageUrl,@in_BorrowYN,@in_WarehouseName)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsModel.AssetNumber),dbHelper.CreateInDbParameter("@in_EquipIntoID", DbType.Int32, EmsModel.EquipIntoID),dbHelper.CreateInDbParameter("@in_EquipStatus", DbType.Int32, EmsModel.EquipStatus),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsModel.Barcode),dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsModel.ImageName),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_ClassNumber", DbType.String, EmsModel.ClassNumber),dbHelper.CreateInDbParameter("@in_AssetsClassName", DbType.String, EmsModel.AssetsClassName),dbHelper.CreateInDbParameter("@in_IntlClassCode", DbType.String, EmsModel.IntlClassCode),dbHelper.CreateInDbParameter("@in_IntlClassName", DbType.String, EmsModel.IntlClassName),dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsModel.AssetName),dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsModel.Unit),dbHelper.CreateInDbParameter("@in_UsageStatus", DbType.String, EmsModel.UsageStatus),dbHelper.CreateInDbParameter("@in_UsageDirection", DbType.String, EmsModel.UsageDirection),dbHelper.CreateInDbParameter("@in_JYBBBSYFX", DbType.String, EmsModel.JYBBBSYFX),dbHelper.CreateInDbParameter("@in_AcquisitionMethod", DbType.String, EmsModel.AcquisitionMethod),dbHelper.CreateInDbParameter("@in_AcquisitionDate", DbType.DateTime, EmsModel.AcquisitionDate),dbHelper.CreateInDbParameter("@in_BrandStandardModel", DbType.String, EmsModel.BrandStandardModel),dbHelper.CreateInDbParameter("@in_EquipmentUse", DbType.String, EmsModel.EquipmentUse),dbHelper.CreateInDbParameter("@in_UseDepartment", DbType.String, EmsModel.UseDepartment),dbHelper.CreateInDbParameter("@in_UsePeople", DbType.String, EmsModel.UsePeople),dbHelper.CreateInDbParameter("@in_Factory", DbType.String, EmsModel.Factory),dbHelper.CreateInDbParameter("@in_StorageLocation", DbType.String, EmsModel.StorageLocation),dbHelper.CreateInDbParameter("@in_WorthType", DbType.String, EmsModel.WorthType),dbHelper.CreateInDbParameter("@in_UseNature", DbType.String, EmsModel.UseNature),dbHelper.CreateInDbParameter("@in_Worth", DbType.Decimal, EmsModel.Worth),dbHelper.CreateInDbParameter("@in_FinanceRecordType", DbType.String, EmsModel.FinanceRecordType),dbHelper.CreateInDbParameter("@in_FiscalFunds", DbType.Decimal, EmsModel.FiscalFunds),dbHelper.CreateInDbParameter("@in_NonFiscalFunds", DbType.Decimal, EmsModel.NonFiscalFunds),dbHelper.CreateInDbParameter("@in_FinanceRecordDate", DbType.DateTime, EmsModel.FinanceRecordDate),dbHelper.CreateInDbParameter("@in_VoucherNumber", DbType.String, EmsModel.VoucherNumber),dbHelper.CreateInDbParameter("@in_UseTime", DbType.Int32, EmsModel.UseTime),dbHelper.CreateInDbParameter("@in_ExpectedScrapDate", DbType.DateTime, EmsModel.ExpectedScrapDate),dbHelper.CreateInDbParameter("@in_DepreciationState", DbType.String, EmsModel.DepreciationState),dbHelper.CreateInDbParameter("@in_NetWorth", DbType.Decimal, EmsModel.NetWorth),dbHelper.CreateInDbParameter("@in_OutFactoryNumber", DbType.String, EmsModel.OutFactoryNumber),dbHelper.CreateInDbParameter("@in_Supplier", DbType.String, EmsModel.Supplier),dbHelper.CreateInDbParameter("@in_FundsSubject", DbType.String, EmsModel.FundsSubject),dbHelper.CreateInDbParameter("@in_PurchaseModality", DbType.String, EmsModel.PurchaseModality),dbHelper.CreateInDbParameter("@in_CountryCode", DbType.String, EmsModel.CountryCode),dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsModel.Operator),dbHelper.CreateInDbParameter("@in_GuaranteeEndDate", DbType.DateTime, EmsModel.GuaranteeEndDate),dbHelper.CreateInDbParameter("@in_EquipmentNumber", DbType.String, EmsModel.EquipmentNumber),dbHelper.CreateInDbParameter("@in_InvoiceNumber", DbType.String, EmsModel.InvoiceNumber),dbHelper.CreateInDbParameter("@in_CompactNumber", DbType.String, EmsModel.CompactNumber),dbHelper.CreateInDbParameter("@in_BasicFunds", DbType.String, EmsModel.BasicFunds),dbHelper.CreateInDbParameter("@in_ItemFunds1", DbType.String, EmsModel.ItemFunds1),dbHelper.CreateInDbParameter("@in_ItemFunds2", DbType.String, EmsModel.ItemFunds2),dbHelper.CreateInDbParameter("@in_ItemFunds3", DbType.String, EmsModel.ItemFunds3),dbHelper.CreateInDbParameter("@in_ItemFunds4", DbType.String, EmsModel.ItemFunds4),dbHelper.CreateInDbParameter("@in_ItemFundsMoney1", DbType.Decimal, EmsModel.ItemFundsMoney1),dbHelper.CreateInDbParameter("@in_ItemFundsMoney2", DbType.Decimal, EmsModel.ItemFundsMoney2),dbHelper.CreateInDbParameter("@in_ItemFundsMoney3", DbType.Decimal, EmsModel.ItemFundsMoney3),dbHelper.CreateInDbParameter("@in_ItemFundsMoney4", DbType.Decimal, EmsModel.ItemFundsMoney4),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus),dbHelper.CreateInDbParameter("@in_StorageLocation1", DbType.String, EmsModel.StorageLocation1),dbHelper.CreateInDbParameter("@in_IsConsume", DbType.Byte, EmsModel.IsConsume),dbHelper.CreateInDbParameter("@in_EquipSource", DbType.Byte, EmsModel.EquipSource),dbHelper.CreateInDbParameter("@in_EquipOwner", DbType.String, EmsModel.EquipOwner),dbHelper.CreateInDbParameter("@in_ManualModify", DbType.Byte, EmsModel.ManualModify),dbHelper.CreateInDbParameter("@in_ImageUrl", DbType.String, EmsModel.ImageUrl),dbHelper.CreateInDbParameter("@in_BorrowYN", DbType.Byte, EmsModel.BorrowYN),dbHelper.CreateInDbParameter("@in_WarehouseName", DbType.String, EmsModel.WarehouseName)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.View_EquipDatail EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update View_EquipDatail set ");
					sbSql.Append("Id=@in_Id,EquipKindId=@in_EquipKindId,AssetNumber=@in_AssetNumber,EquipIntoID=@in_EquipIntoID,EquipStatus=@in_EquipStatus,Type=@in_Type,Barcode=@in_Barcode,ImageName=@in_ImageName,Count=@in_Count,ClassNumber=@in_ClassNumber,AssetsClassName=@in_AssetsClassName,IntlClassCode=@in_IntlClassCode,IntlClassName=@in_IntlClassName,AssetName=@in_AssetName,Unit=@in_Unit,UsageStatus=@in_UsageStatus,UsageDirection=@in_UsageDirection,JYBBBSYFX=@in_JYBBBSYFX,AcquisitionMethod=@in_AcquisitionMethod,AcquisitionDate=@in_AcquisitionDate,BrandStandardModel=@in_BrandStandardModel,EquipmentUse=@in_EquipmentUse,UseDepartment=@in_UseDepartment,UsePeople=@in_UsePeople,Factory=@in_Factory,StorageLocation=@in_StorageLocation,WorthType=@in_WorthType,UseNature=@in_UseNature,Worth=@in_Worth,FinanceRecordType=@in_FinanceRecordType,FiscalFunds=@in_FiscalFunds,NonFiscalFunds=@in_NonFiscalFunds,FinanceRecordDate=@in_FinanceRecordDate,VoucherNumber=@in_VoucherNumber,UseTime=@in_UseTime,ExpectedScrapDate=@in_ExpectedScrapDate,DepreciationState=@in_DepreciationState,NetWorth=@in_NetWorth,OutFactoryNumber=@in_OutFactoryNumber,Supplier=@in_Supplier,FundsSubject=@in_FundsSubject,PurchaseModality=@in_PurchaseModality,CountryCode=@in_CountryCode,Operator=@in_Operator,GuaranteeEndDate=@in_GuaranteeEndDate,EquipmentNumber=@in_EquipmentNumber,InvoiceNumber=@in_InvoiceNumber,CompactNumber=@in_CompactNumber,BasicFunds=@in_BasicFunds,ItemFunds1=@in_ItemFunds1,ItemFunds2=@in_ItemFunds2,ItemFunds3=@in_ItemFunds3,ItemFunds4=@in_ItemFunds4,ItemFundsMoney1=@in_ItemFundsMoney1,ItemFundsMoney2=@in_ItemFundsMoney2,ItemFundsMoney3=@in_ItemFundsMoney3,ItemFundsMoney4=@in_ItemFundsMoney4,Remarks=@in_Remarks,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,UseStatus=@in_UseStatus,StorageLocation1=@in_StorageLocation1,IsConsume=@in_IsConsume,EquipSource=@in_EquipSource,EquipOwner=@in_EquipOwner,ManualModify=@in_ManualModify,ImageUrl=@in_ImageUrl,BorrowYN=@in_BorrowYN,WarehouseName=@in_WarehouseName");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsModel.AssetNumber),dbHelper.CreateInDbParameter("@in_EquipIntoID", DbType.Int32, EmsModel.EquipIntoID),dbHelper.CreateInDbParameter("@in_EquipStatus", DbType.Int32, EmsModel.EquipStatus),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsModel.Barcode),dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsModel.ImageName),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_ClassNumber", DbType.String, EmsModel.ClassNumber),dbHelper.CreateInDbParameter("@in_AssetsClassName", DbType.String, EmsModel.AssetsClassName),dbHelper.CreateInDbParameter("@in_IntlClassCode", DbType.String, EmsModel.IntlClassCode),dbHelper.CreateInDbParameter("@in_IntlClassName", DbType.String, EmsModel.IntlClassName),dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsModel.AssetName),dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsModel.Unit),dbHelper.CreateInDbParameter("@in_UsageStatus", DbType.String, EmsModel.UsageStatus),dbHelper.CreateInDbParameter("@in_UsageDirection", DbType.String, EmsModel.UsageDirection),dbHelper.CreateInDbParameter("@in_JYBBBSYFX", DbType.String, EmsModel.JYBBBSYFX),dbHelper.CreateInDbParameter("@in_AcquisitionMethod", DbType.String, EmsModel.AcquisitionMethod),dbHelper.CreateInDbParameter("@in_AcquisitionDate", DbType.DateTime, EmsModel.AcquisitionDate),dbHelper.CreateInDbParameter("@in_BrandStandardModel", DbType.String, EmsModel.BrandStandardModel),dbHelper.CreateInDbParameter("@in_EquipmentUse", DbType.String, EmsModel.EquipmentUse),dbHelper.CreateInDbParameter("@in_UseDepartment", DbType.String, EmsModel.UseDepartment),dbHelper.CreateInDbParameter("@in_UsePeople", DbType.String, EmsModel.UsePeople),dbHelper.CreateInDbParameter("@in_Factory", DbType.String, EmsModel.Factory),dbHelper.CreateInDbParameter("@in_StorageLocation", DbType.String, EmsModel.StorageLocation),dbHelper.CreateInDbParameter("@in_WorthType", DbType.String, EmsModel.WorthType),dbHelper.CreateInDbParameter("@in_UseNature", DbType.String, EmsModel.UseNature),dbHelper.CreateInDbParameter("@in_Worth", DbType.Decimal, EmsModel.Worth),dbHelper.CreateInDbParameter("@in_FinanceRecordType", DbType.String, EmsModel.FinanceRecordType),dbHelper.CreateInDbParameter("@in_FiscalFunds", DbType.Decimal, EmsModel.FiscalFunds),dbHelper.CreateInDbParameter("@in_NonFiscalFunds", DbType.Decimal, EmsModel.NonFiscalFunds),dbHelper.CreateInDbParameter("@in_FinanceRecordDate", DbType.DateTime, EmsModel.FinanceRecordDate),dbHelper.CreateInDbParameter("@in_VoucherNumber", DbType.String, EmsModel.VoucherNumber),dbHelper.CreateInDbParameter("@in_UseTime", DbType.Int32, EmsModel.UseTime),dbHelper.CreateInDbParameter("@in_ExpectedScrapDate", DbType.DateTime, EmsModel.ExpectedScrapDate),dbHelper.CreateInDbParameter("@in_DepreciationState", DbType.String, EmsModel.DepreciationState),dbHelper.CreateInDbParameter("@in_NetWorth", DbType.Decimal, EmsModel.NetWorth),dbHelper.CreateInDbParameter("@in_OutFactoryNumber", DbType.String, EmsModel.OutFactoryNumber),dbHelper.CreateInDbParameter("@in_Supplier", DbType.String, EmsModel.Supplier),dbHelper.CreateInDbParameter("@in_FundsSubject", DbType.String, EmsModel.FundsSubject),dbHelper.CreateInDbParameter("@in_PurchaseModality", DbType.String, EmsModel.PurchaseModality),dbHelper.CreateInDbParameter("@in_CountryCode", DbType.String, EmsModel.CountryCode),dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsModel.Operator),dbHelper.CreateInDbParameter("@in_GuaranteeEndDate", DbType.DateTime, EmsModel.GuaranteeEndDate),dbHelper.CreateInDbParameter("@in_EquipmentNumber", DbType.String, EmsModel.EquipmentNumber),dbHelper.CreateInDbParameter("@in_InvoiceNumber", DbType.String, EmsModel.InvoiceNumber),dbHelper.CreateInDbParameter("@in_CompactNumber", DbType.String, EmsModel.CompactNumber),dbHelper.CreateInDbParameter("@in_BasicFunds", DbType.String, EmsModel.BasicFunds),dbHelper.CreateInDbParameter("@in_ItemFunds1", DbType.String, EmsModel.ItemFunds1),dbHelper.CreateInDbParameter("@in_ItemFunds2", DbType.String, EmsModel.ItemFunds2),dbHelper.CreateInDbParameter("@in_ItemFunds3", DbType.String, EmsModel.ItemFunds3),dbHelper.CreateInDbParameter("@in_ItemFunds4", DbType.String, EmsModel.ItemFunds4),dbHelper.CreateInDbParameter("@in_ItemFundsMoney1", DbType.Decimal, EmsModel.ItemFundsMoney1),dbHelper.CreateInDbParameter("@in_ItemFundsMoney2", DbType.Decimal, EmsModel.ItemFundsMoney2),dbHelper.CreateInDbParameter("@in_ItemFundsMoney3", DbType.Decimal, EmsModel.ItemFundsMoney3),dbHelper.CreateInDbParameter("@in_ItemFundsMoney4", DbType.Decimal, EmsModel.ItemFundsMoney4),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus),dbHelper.CreateInDbParameter("@in_StorageLocation1", DbType.String, EmsModel.StorageLocation1),dbHelper.CreateInDbParameter("@in_IsConsume", DbType.Byte, EmsModel.IsConsume),dbHelper.CreateInDbParameter("@in_EquipSource", DbType.Byte, EmsModel.EquipSource),dbHelper.CreateInDbParameter("@in_EquipOwner", DbType.String, EmsModel.EquipOwner),dbHelper.CreateInDbParameter("@in_ManualModify", DbType.Byte, EmsModel.ManualModify),dbHelper.CreateInDbParameter("@in_ImageUrl", DbType.String, EmsModel.ImageUrl),dbHelper.CreateInDbParameter("@in_BorrowYN", DbType.Byte, EmsModel.BorrowYN),dbHelper.CreateInDbParameter("@in_WarehouseName", DbType.String, EmsModel.WarehouseName)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.View_EquipDatail EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update View_EquipDatail set ");
					sbSql.Append("Id=@in_Id,EquipKindId=@in_EquipKindId,AssetNumber=@in_AssetNumber,EquipIntoID=@in_EquipIntoID,EquipStatus=@in_EquipStatus,Type=@in_Type,Barcode=@in_Barcode,ImageName=@in_ImageName,Count=@in_Count,ClassNumber=@in_ClassNumber,AssetsClassName=@in_AssetsClassName,IntlClassCode=@in_IntlClassCode,IntlClassName=@in_IntlClassName,AssetName=@in_AssetName,Unit=@in_Unit,UsageStatus=@in_UsageStatus,UsageDirection=@in_UsageDirection,JYBBBSYFX=@in_JYBBBSYFX,AcquisitionMethod=@in_AcquisitionMethod,AcquisitionDate=@in_AcquisitionDate,BrandStandardModel=@in_BrandStandardModel,EquipmentUse=@in_EquipmentUse,UseDepartment=@in_UseDepartment,UsePeople=@in_UsePeople,Factory=@in_Factory,StorageLocation=@in_StorageLocation,WorthType=@in_WorthType,UseNature=@in_UseNature,Worth=@in_Worth,FinanceRecordType=@in_FinanceRecordType,FiscalFunds=@in_FiscalFunds,NonFiscalFunds=@in_NonFiscalFunds,FinanceRecordDate=@in_FinanceRecordDate,VoucherNumber=@in_VoucherNumber,UseTime=@in_UseTime,ExpectedScrapDate=@in_ExpectedScrapDate,DepreciationState=@in_DepreciationState,NetWorth=@in_NetWorth,OutFactoryNumber=@in_OutFactoryNumber,Supplier=@in_Supplier,FundsSubject=@in_FundsSubject,PurchaseModality=@in_PurchaseModality,CountryCode=@in_CountryCode,Operator=@in_Operator,GuaranteeEndDate=@in_GuaranteeEndDate,EquipmentNumber=@in_EquipmentNumber,InvoiceNumber=@in_InvoiceNumber,CompactNumber=@in_CompactNumber,BasicFunds=@in_BasicFunds,ItemFunds1=@in_ItemFunds1,ItemFunds2=@in_ItemFunds2,ItemFunds3=@in_ItemFunds3,ItemFunds4=@in_ItemFunds4,ItemFundsMoney1=@in_ItemFundsMoney1,ItemFundsMoney2=@in_ItemFundsMoney2,ItemFundsMoney3=@in_ItemFundsMoney3,ItemFundsMoney4=@in_ItemFundsMoney4,Remarks=@in_Remarks,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,UseStatus=@in_UseStatus,StorageLocation1=@in_StorageLocation1,IsConsume=@in_IsConsume,EquipSource=@in_EquipSource,EquipOwner=@in_EquipOwner,ManualModify=@in_ManualModify,ImageUrl=@in_ImageUrl,BorrowYN=@in_BorrowYN,WarehouseName=@in_WarehouseName");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsModel.AssetNumber),dbHelper.CreateInDbParameter("@in_EquipIntoID", DbType.Int32, EmsModel.EquipIntoID),dbHelper.CreateInDbParameter("@in_EquipStatus", DbType.Int32, EmsModel.EquipStatus),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsModel.Barcode),dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsModel.ImageName),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_ClassNumber", DbType.String, EmsModel.ClassNumber),dbHelper.CreateInDbParameter("@in_AssetsClassName", DbType.String, EmsModel.AssetsClassName),dbHelper.CreateInDbParameter("@in_IntlClassCode", DbType.String, EmsModel.IntlClassCode),dbHelper.CreateInDbParameter("@in_IntlClassName", DbType.String, EmsModel.IntlClassName),dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsModel.AssetName),dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsModel.Unit),dbHelper.CreateInDbParameter("@in_UsageStatus", DbType.String, EmsModel.UsageStatus),dbHelper.CreateInDbParameter("@in_UsageDirection", DbType.String, EmsModel.UsageDirection),dbHelper.CreateInDbParameter("@in_JYBBBSYFX", DbType.String, EmsModel.JYBBBSYFX),dbHelper.CreateInDbParameter("@in_AcquisitionMethod", DbType.String, EmsModel.AcquisitionMethod),dbHelper.CreateInDbParameter("@in_AcquisitionDate", DbType.DateTime, EmsModel.AcquisitionDate),dbHelper.CreateInDbParameter("@in_BrandStandardModel", DbType.String, EmsModel.BrandStandardModel),dbHelper.CreateInDbParameter("@in_EquipmentUse", DbType.String, EmsModel.EquipmentUse),dbHelper.CreateInDbParameter("@in_UseDepartment", DbType.String, EmsModel.UseDepartment),dbHelper.CreateInDbParameter("@in_UsePeople", DbType.String, EmsModel.UsePeople),dbHelper.CreateInDbParameter("@in_Factory", DbType.String, EmsModel.Factory),dbHelper.CreateInDbParameter("@in_StorageLocation", DbType.String, EmsModel.StorageLocation),dbHelper.CreateInDbParameter("@in_WorthType", DbType.String, EmsModel.WorthType),dbHelper.CreateInDbParameter("@in_UseNature", DbType.String, EmsModel.UseNature),dbHelper.CreateInDbParameter("@in_Worth", DbType.Decimal, EmsModel.Worth),dbHelper.CreateInDbParameter("@in_FinanceRecordType", DbType.String, EmsModel.FinanceRecordType),dbHelper.CreateInDbParameter("@in_FiscalFunds", DbType.Decimal, EmsModel.FiscalFunds),dbHelper.CreateInDbParameter("@in_NonFiscalFunds", DbType.Decimal, EmsModel.NonFiscalFunds),dbHelper.CreateInDbParameter("@in_FinanceRecordDate", DbType.DateTime, EmsModel.FinanceRecordDate),dbHelper.CreateInDbParameter("@in_VoucherNumber", DbType.String, EmsModel.VoucherNumber),dbHelper.CreateInDbParameter("@in_UseTime", DbType.Int32, EmsModel.UseTime),dbHelper.CreateInDbParameter("@in_ExpectedScrapDate", DbType.DateTime, EmsModel.ExpectedScrapDate),dbHelper.CreateInDbParameter("@in_DepreciationState", DbType.String, EmsModel.DepreciationState),dbHelper.CreateInDbParameter("@in_NetWorth", DbType.Decimal, EmsModel.NetWorth),dbHelper.CreateInDbParameter("@in_OutFactoryNumber", DbType.String, EmsModel.OutFactoryNumber),dbHelper.CreateInDbParameter("@in_Supplier", DbType.String, EmsModel.Supplier),dbHelper.CreateInDbParameter("@in_FundsSubject", DbType.String, EmsModel.FundsSubject),dbHelper.CreateInDbParameter("@in_PurchaseModality", DbType.String, EmsModel.PurchaseModality),dbHelper.CreateInDbParameter("@in_CountryCode", DbType.String, EmsModel.CountryCode),dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsModel.Operator),dbHelper.CreateInDbParameter("@in_GuaranteeEndDate", DbType.DateTime, EmsModel.GuaranteeEndDate),dbHelper.CreateInDbParameter("@in_EquipmentNumber", DbType.String, EmsModel.EquipmentNumber),dbHelper.CreateInDbParameter("@in_InvoiceNumber", DbType.String, EmsModel.InvoiceNumber),dbHelper.CreateInDbParameter("@in_CompactNumber", DbType.String, EmsModel.CompactNumber),dbHelper.CreateInDbParameter("@in_BasicFunds", DbType.String, EmsModel.BasicFunds),dbHelper.CreateInDbParameter("@in_ItemFunds1", DbType.String, EmsModel.ItemFunds1),dbHelper.CreateInDbParameter("@in_ItemFunds2", DbType.String, EmsModel.ItemFunds2),dbHelper.CreateInDbParameter("@in_ItemFunds3", DbType.String, EmsModel.ItemFunds3),dbHelper.CreateInDbParameter("@in_ItemFunds4", DbType.String, EmsModel.ItemFunds4),dbHelper.CreateInDbParameter("@in_ItemFundsMoney1", DbType.Decimal, EmsModel.ItemFundsMoney1),dbHelper.CreateInDbParameter("@in_ItemFundsMoney2", DbType.Decimal, EmsModel.ItemFundsMoney2),dbHelper.CreateInDbParameter("@in_ItemFundsMoney3", DbType.Decimal, EmsModel.ItemFundsMoney3),dbHelper.CreateInDbParameter("@in_ItemFundsMoney4", DbType.Decimal, EmsModel.ItemFundsMoney4),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus),dbHelper.CreateInDbParameter("@in_StorageLocation1", DbType.String, EmsModel.StorageLocation1),dbHelper.CreateInDbParameter("@in_IsConsume", DbType.Byte, EmsModel.IsConsume),dbHelper.CreateInDbParameter("@in_EquipSource", DbType.Byte, EmsModel.EquipSource),dbHelper.CreateInDbParameter("@in_EquipOwner", DbType.String, EmsModel.EquipOwner),dbHelper.CreateInDbParameter("@in_ManualModify", DbType.Byte, EmsModel.ManualModify),dbHelper.CreateInDbParameter("@in_ImageUrl", DbType.String, EmsModel.ImageUrl),dbHelper.CreateInDbParameter("@in_BorrowYN", DbType.Byte, EmsModel.BorrowYN),dbHelper.CreateInDbParameter("@in_WarehouseName", DbType.String, EmsModel.WarehouseName)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM View_EquipDatail");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM View_EquipDatail");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists( )
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM View_EquipDatail");
					sbSql.Append("");

					parms = new DbParameter[]{
						
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.View_EquipDatail> GetListByPage(EmsModel.View_EquipDatail EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "View_EquipDatail";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Id != null){strWhere += " and Id=@in_Id ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Id", DbType.String, EmsMod.Id)); }if (EmsMod.EquipKindId != null){strWhere += " and EquipKindId=@in_EquipKindId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.String, EmsMod.EquipKindId)); }if (EmsMod.AssetNumber != null){strWhere += " and AssetNumber=@in_AssetNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsMod.AssetNumber)); }if (EmsMod.EquipIntoID != null){strWhere += " and EquipIntoID=@in_EquipIntoID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipIntoID", DbType.String, EmsMod.EquipIntoID)); }if (EmsMod.EquipStatus != null){strWhere += " and EquipStatus=@in_EquipStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipStatus", DbType.String, EmsMod.EquipStatus)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.Barcode != null){strWhere += " and Barcode=@in_Barcode ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsMod.Barcode)); }if (EmsMod.ImageName != null){strWhere += " and ImageName=@in_ImageName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsMod.ImageName)); }if (EmsMod.Count != null){strWhere += " and Count=@in_Count ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Count", DbType.String, EmsMod.Count)); }if (EmsMod.ClassNumber != null){strWhere += " and ClassNumber=@in_ClassNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ClassNumber", DbType.String, EmsMod.ClassNumber)); }if (EmsMod.AssetsClassName != null){strWhere += " and AssetsClassName=@in_AssetsClassName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetsClassName", DbType.String, EmsMod.AssetsClassName)); }if (EmsMod.IntlClassCode != null){strWhere += " and IntlClassCode=@in_IntlClassCode ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IntlClassCode", DbType.String, EmsMod.IntlClassCode)); }if (EmsMod.IntlClassName != null){strWhere += " and IntlClassName=@in_IntlClassName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IntlClassName", DbType.String, EmsMod.IntlClassName)); }if (EmsMod.AssetName != null){strWhere += " and AssetName=@in_AssetName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsMod.AssetName)); }if (EmsMod.Unit != null){strWhere += " and Unit=@in_Unit ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsMod.Unit)); }if (EmsMod.UsageStatus != null){strWhere += " and UsageStatus=@in_UsageStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UsageStatus", DbType.String, EmsMod.UsageStatus)); }if (EmsMod.UsageDirection != null){strWhere += " and UsageDirection=@in_UsageDirection ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UsageDirection", DbType.String, EmsMod.UsageDirection)); }if (EmsMod.JYBBBSYFX != null){strWhere += " and JYBBBSYFX=@in_JYBBBSYFX ";parmsList.Add(dbHelper.CreateInDbParameter("@in_JYBBBSYFX", DbType.String, EmsMod.JYBBBSYFX)); }if (EmsMod.AcquisitionMethod != null){strWhere += " and AcquisitionMethod=@in_AcquisitionMethod ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AcquisitionMethod", DbType.String, EmsMod.AcquisitionMethod)); }if (EmsMod.AcquisitionDate != null){strWhere += " and AcquisitionDate=@in_AcquisitionDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AcquisitionDate", DbType.String, EmsMod.AcquisitionDate)); }if (EmsMod.BrandStandardModel != null){strWhere += " and BrandStandardModel=@in_BrandStandardModel ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BrandStandardModel", DbType.String, EmsMod.BrandStandardModel)); }if (EmsMod.EquipmentUse != null){strWhere += " and EquipmentUse=@in_EquipmentUse ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipmentUse", DbType.String, EmsMod.EquipmentUse)); }if (EmsMod.UseDepartment != null){strWhere += " and UseDepartment=@in_UseDepartment ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseDepartment", DbType.String, EmsMod.UseDepartment)); }if (EmsMod.UsePeople != null){strWhere += " and UsePeople=@in_UsePeople ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UsePeople", DbType.String, EmsMod.UsePeople)); }if (EmsMod.Factory != null){strWhere += " and Factory=@in_Factory ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Factory", DbType.String, EmsMod.Factory)); }if (EmsMod.StorageLocation != null){strWhere += " and StorageLocation=@in_StorageLocation ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StorageLocation", DbType.String, EmsMod.StorageLocation)); }if (EmsMod.WorthType != null){strWhere += " and WorthType=@in_WorthType ";parmsList.Add(dbHelper.CreateInDbParameter("@in_WorthType", DbType.String, EmsMod.WorthType)); }if (EmsMod.UseNature != null){strWhere += " and UseNature=@in_UseNature ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseNature", DbType.String, EmsMod.UseNature)); }if (EmsMod.Worth != null){strWhere += " and Worth=@in_Worth ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Worth", DbType.String, EmsMod.Worth)); }if (EmsMod.FinanceRecordType != null){strWhere += " and FinanceRecordType=@in_FinanceRecordType ";parmsList.Add(dbHelper.CreateInDbParameter("@in_FinanceRecordType", DbType.String, EmsMod.FinanceRecordType)); }if (EmsMod.FiscalFunds != null){strWhere += " and FiscalFunds=@in_FiscalFunds ";parmsList.Add(dbHelper.CreateInDbParameter("@in_FiscalFunds", DbType.String, EmsMod.FiscalFunds)); }if (EmsMod.NonFiscalFunds != null){strWhere += " and NonFiscalFunds=@in_NonFiscalFunds ";parmsList.Add(dbHelper.CreateInDbParameter("@in_NonFiscalFunds", DbType.String, EmsMod.NonFiscalFunds)); }if (EmsMod.FinanceRecordDate != null){strWhere += " and FinanceRecordDate=@in_FinanceRecordDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_FinanceRecordDate", DbType.String, EmsMod.FinanceRecordDate)); }if (EmsMod.VoucherNumber != null){strWhere += " and VoucherNumber=@in_VoucherNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_VoucherNumber", DbType.String, EmsMod.VoucherNumber)); }if (EmsMod.UseTime != null){strWhere += " and UseTime=@in_UseTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseTime", DbType.String, EmsMod.UseTime)); }if (EmsMod.ExpectedScrapDate != null){strWhere += " and ExpectedScrapDate=@in_ExpectedScrapDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ExpectedScrapDate", DbType.String, EmsMod.ExpectedScrapDate)); }if (EmsMod.DepreciationState != null){strWhere += " and DepreciationState=@in_DepreciationState ";parmsList.Add(dbHelper.CreateInDbParameter("@in_DepreciationState", DbType.String, EmsMod.DepreciationState)); }if (EmsMod.NetWorth != null){strWhere += " and NetWorth=@in_NetWorth ";parmsList.Add(dbHelper.CreateInDbParameter("@in_NetWorth", DbType.String, EmsMod.NetWorth)); }if (EmsMod.OutFactoryNumber != null){strWhere += " and OutFactoryNumber=@in_OutFactoryNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_OutFactoryNumber", DbType.String, EmsMod.OutFactoryNumber)); }if (EmsMod.Supplier != null){strWhere += " and Supplier=@in_Supplier ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Supplier", DbType.String, EmsMod.Supplier)); }if (EmsMod.FundsSubject != null){strWhere += " and FundsSubject=@in_FundsSubject ";parmsList.Add(dbHelper.CreateInDbParameter("@in_FundsSubject", DbType.String, EmsMod.FundsSubject)); }if (EmsMod.PurchaseModality != null){strWhere += " and PurchaseModality=@in_PurchaseModality ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PurchaseModality", DbType.String, EmsMod.PurchaseModality)); }if (EmsMod.CountryCode != null){strWhere += " and CountryCode=@in_CountryCode ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CountryCode", DbType.String, EmsMod.CountryCode)); }if (EmsMod.Operator != null){strWhere += " and Operator=@in_Operator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsMod.Operator)); }if (EmsMod.GuaranteeEndDate != null){strWhere += " and GuaranteeEndDate=@in_GuaranteeEndDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_GuaranteeEndDate", DbType.String, EmsMod.GuaranteeEndDate)); }if (EmsMod.EquipmentNumber != null){strWhere += " and EquipmentNumber=@in_EquipmentNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipmentNumber", DbType.String, EmsMod.EquipmentNumber)); }if (EmsMod.InvoiceNumber != null){strWhere += " and InvoiceNumber=@in_InvoiceNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InvoiceNumber", DbType.String, EmsMod.InvoiceNumber)); }if (EmsMod.CompactNumber != null){strWhere += " and CompactNumber=@in_CompactNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CompactNumber", DbType.String, EmsMod.CompactNumber)); }if (EmsMod.BasicFunds != null){strWhere += " and BasicFunds=@in_BasicFunds ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BasicFunds", DbType.String, EmsMod.BasicFunds)); }if (EmsMod.ItemFunds1 != null){strWhere += " and ItemFunds1=@in_ItemFunds1 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFunds1", DbType.String, EmsMod.ItemFunds1)); }if (EmsMod.ItemFunds2 != null){strWhere += " and ItemFunds2=@in_ItemFunds2 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFunds2", DbType.String, EmsMod.ItemFunds2)); }if (EmsMod.ItemFunds3 != null){strWhere += " and ItemFunds3=@in_ItemFunds3 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFunds3", DbType.String, EmsMod.ItemFunds3)); }if (EmsMod.ItemFunds4 != null){strWhere += " and ItemFunds4=@in_ItemFunds4 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFunds4", DbType.String, EmsMod.ItemFunds4)); }if (EmsMod.ItemFundsMoney1 != null){strWhere += " and ItemFundsMoney1=@in_ItemFundsMoney1 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFundsMoney1", DbType.String, EmsMod.ItemFundsMoney1)); }if (EmsMod.ItemFundsMoney2 != null){strWhere += " and ItemFundsMoney2=@in_ItemFundsMoney2 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFundsMoney2", DbType.String, EmsMod.ItemFundsMoney2)); }if (EmsMod.ItemFundsMoney3 != null){strWhere += " and ItemFundsMoney3=@in_ItemFundsMoney3 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFundsMoney3", DbType.String, EmsMod.ItemFundsMoney3)); }if (EmsMod.ItemFundsMoney4 != null){strWhere += " and ItemFundsMoney4=@in_ItemFundsMoney4 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFundsMoney4", DbType.String, EmsMod.ItemFundsMoney4)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }if (EmsMod.StorageLocation1 != null){strWhere += " and StorageLocation1=@in_StorageLocation1 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StorageLocation1", DbType.String, EmsMod.StorageLocation1)); }if (EmsMod.IsConsume != null){strWhere += " and IsConsume=@in_IsConsume ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsConsume", DbType.String, EmsMod.IsConsume)); }if (EmsMod.EquipSource != null){strWhere += " and EquipSource=@in_EquipSource ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipSource", DbType.String, EmsMod.EquipSource)); }if (EmsMod.EquipOwner != null){strWhere += " and EquipOwner=@in_EquipOwner ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipOwner", DbType.String, EmsMod.EquipOwner)); }if (EmsMod.ManualModify != null){strWhere += " and ManualModify=@in_ManualModify ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ManualModify", DbType.String, EmsMod.ManualModify)); }if (EmsMod.ImageUrl != null){strWhere += " and ImageUrl=@in_ImageUrl ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ImageUrl", DbType.String, EmsMod.ImageUrl)); }if (EmsMod.BorrowYN != null){strWhere += " and BorrowYN=@in_BorrowYN ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BorrowYN", DbType.String, EmsMod.BorrowYN)); }if (EmsMod.WarehouseName != null){strWhere += " and WarehouseName=@in_WarehouseName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_WarehouseName", DbType.String, EmsMod.WarehouseName)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.View_EquipDatail> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.View_EquipDatail EmsMod)
        {
            string TableName = "View_EquipDatail";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Id != null){strWhere += " and Id=@in_Id ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Id", DbType.String, EmsMod.Id)); }if (EmsMod.EquipKindId != null){strWhere += " and EquipKindId=@in_EquipKindId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.String, EmsMod.EquipKindId)); }if (EmsMod.AssetNumber != null){strWhere += " and AssetNumber=@in_AssetNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsMod.AssetNumber)); }if (EmsMod.EquipIntoID != null){strWhere += " and EquipIntoID=@in_EquipIntoID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipIntoID", DbType.String, EmsMod.EquipIntoID)); }if (EmsMod.EquipStatus != null){strWhere += " and EquipStatus=@in_EquipStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipStatus", DbType.String, EmsMod.EquipStatus)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.Barcode != null){strWhere += " and Barcode=@in_Barcode ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsMod.Barcode)); }if (EmsMod.ImageName != null){strWhere += " and ImageName=@in_ImageName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsMod.ImageName)); }if (EmsMod.Count != null){strWhere += " and Count=@in_Count ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Count", DbType.String, EmsMod.Count)); }if (EmsMod.ClassNumber != null){strWhere += " and ClassNumber=@in_ClassNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ClassNumber", DbType.String, EmsMod.ClassNumber)); }if (EmsMod.AssetsClassName != null){strWhere += " and AssetsClassName=@in_AssetsClassName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetsClassName", DbType.String, EmsMod.AssetsClassName)); }if (EmsMod.IntlClassCode != null){strWhere += " and IntlClassCode=@in_IntlClassCode ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IntlClassCode", DbType.String, EmsMod.IntlClassCode)); }if (EmsMod.IntlClassName != null){strWhere += " and IntlClassName=@in_IntlClassName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IntlClassName", DbType.String, EmsMod.IntlClassName)); }if (EmsMod.AssetName != null){strWhere += " and AssetName=@in_AssetName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsMod.AssetName)); }if (EmsMod.Unit != null){strWhere += " and Unit=@in_Unit ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsMod.Unit)); }if (EmsMod.UsageStatus != null){strWhere += " and UsageStatus=@in_UsageStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UsageStatus", DbType.String, EmsMod.UsageStatus)); }if (EmsMod.UsageDirection != null){strWhere += " and UsageDirection=@in_UsageDirection ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UsageDirection", DbType.String, EmsMod.UsageDirection)); }if (EmsMod.JYBBBSYFX != null){strWhere += " and JYBBBSYFX=@in_JYBBBSYFX ";parmsList.Add(dbHelper.CreateInDbParameter("@in_JYBBBSYFX", DbType.String, EmsMod.JYBBBSYFX)); }if (EmsMod.AcquisitionMethod != null){strWhere += " and AcquisitionMethod=@in_AcquisitionMethod ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AcquisitionMethod", DbType.String, EmsMod.AcquisitionMethod)); }if (EmsMod.AcquisitionDate != null){strWhere += " and AcquisitionDate=@in_AcquisitionDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AcquisitionDate", DbType.String, EmsMod.AcquisitionDate)); }if (EmsMod.BrandStandardModel != null){strWhere += " and BrandStandardModel=@in_BrandStandardModel ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BrandStandardModel", DbType.String, EmsMod.BrandStandardModel)); }if (EmsMod.EquipmentUse != null){strWhere += " and EquipmentUse=@in_EquipmentUse ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipmentUse", DbType.String, EmsMod.EquipmentUse)); }if (EmsMod.UseDepartment != null){strWhere += " and UseDepartment=@in_UseDepartment ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseDepartment", DbType.String, EmsMod.UseDepartment)); }if (EmsMod.UsePeople != null){strWhere += " and UsePeople=@in_UsePeople ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UsePeople", DbType.String, EmsMod.UsePeople)); }if (EmsMod.Factory != null){strWhere += " and Factory=@in_Factory ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Factory", DbType.String, EmsMod.Factory)); }if (EmsMod.StorageLocation != null){strWhere += " and StorageLocation=@in_StorageLocation ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StorageLocation", DbType.String, EmsMod.StorageLocation)); }if (EmsMod.WorthType != null){strWhere += " and WorthType=@in_WorthType ";parmsList.Add(dbHelper.CreateInDbParameter("@in_WorthType", DbType.String, EmsMod.WorthType)); }if (EmsMod.UseNature != null){strWhere += " and UseNature=@in_UseNature ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseNature", DbType.String, EmsMod.UseNature)); }if (EmsMod.Worth != null){strWhere += " and Worth=@in_Worth ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Worth", DbType.String, EmsMod.Worth)); }if (EmsMod.FinanceRecordType != null){strWhere += " and FinanceRecordType=@in_FinanceRecordType ";parmsList.Add(dbHelper.CreateInDbParameter("@in_FinanceRecordType", DbType.String, EmsMod.FinanceRecordType)); }if (EmsMod.FiscalFunds != null){strWhere += " and FiscalFunds=@in_FiscalFunds ";parmsList.Add(dbHelper.CreateInDbParameter("@in_FiscalFunds", DbType.String, EmsMod.FiscalFunds)); }if (EmsMod.NonFiscalFunds != null){strWhere += " and NonFiscalFunds=@in_NonFiscalFunds ";parmsList.Add(dbHelper.CreateInDbParameter("@in_NonFiscalFunds", DbType.String, EmsMod.NonFiscalFunds)); }if (EmsMod.FinanceRecordDate != null){strWhere += " and FinanceRecordDate=@in_FinanceRecordDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_FinanceRecordDate", DbType.String, EmsMod.FinanceRecordDate)); }if (EmsMod.VoucherNumber != null){strWhere += " and VoucherNumber=@in_VoucherNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_VoucherNumber", DbType.String, EmsMod.VoucherNumber)); }if (EmsMod.UseTime != null){strWhere += " and UseTime=@in_UseTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseTime", DbType.String, EmsMod.UseTime)); }if (EmsMod.ExpectedScrapDate != null){strWhere += " and ExpectedScrapDate=@in_ExpectedScrapDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ExpectedScrapDate", DbType.String, EmsMod.ExpectedScrapDate)); }if (EmsMod.DepreciationState != null){strWhere += " and DepreciationState=@in_DepreciationState ";parmsList.Add(dbHelper.CreateInDbParameter("@in_DepreciationState", DbType.String, EmsMod.DepreciationState)); }if (EmsMod.NetWorth != null){strWhere += " and NetWorth=@in_NetWorth ";parmsList.Add(dbHelper.CreateInDbParameter("@in_NetWorth", DbType.String, EmsMod.NetWorth)); }if (EmsMod.OutFactoryNumber != null){strWhere += " and OutFactoryNumber=@in_OutFactoryNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_OutFactoryNumber", DbType.String, EmsMod.OutFactoryNumber)); }if (EmsMod.Supplier != null){strWhere += " and Supplier=@in_Supplier ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Supplier", DbType.String, EmsMod.Supplier)); }if (EmsMod.FundsSubject != null){strWhere += " and FundsSubject=@in_FundsSubject ";parmsList.Add(dbHelper.CreateInDbParameter("@in_FundsSubject", DbType.String, EmsMod.FundsSubject)); }if (EmsMod.PurchaseModality != null){strWhere += " and PurchaseModality=@in_PurchaseModality ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PurchaseModality", DbType.String, EmsMod.PurchaseModality)); }if (EmsMod.CountryCode != null){strWhere += " and CountryCode=@in_CountryCode ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CountryCode", DbType.String, EmsMod.CountryCode)); }if (EmsMod.Operator != null){strWhere += " and Operator=@in_Operator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsMod.Operator)); }if (EmsMod.GuaranteeEndDate != null){strWhere += " and GuaranteeEndDate=@in_GuaranteeEndDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_GuaranteeEndDate", DbType.String, EmsMod.GuaranteeEndDate)); }if (EmsMod.EquipmentNumber != null){strWhere += " and EquipmentNumber=@in_EquipmentNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipmentNumber", DbType.String, EmsMod.EquipmentNumber)); }if (EmsMod.InvoiceNumber != null){strWhere += " and InvoiceNumber=@in_InvoiceNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InvoiceNumber", DbType.String, EmsMod.InvoiceNumber)); }if (EmsMod.CompactNumber != null){strWhere += " and CompactNumber=@in_CompactNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CompactNumber", DbType.String, EmsMod.CompactNumber)); }if (EmsMod.BasicFunds != null){strWhere += " and BasicFunds=@in_BasicFunds ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BasicFunds", DbType.String, EmsMod.BasicFunds)); }if (EmsMod.ItemFunds1 != null){strWhere += " and ItemFunds1=@in_ItemFunds1 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFunds1", DbType.String, EmsMod.ItemFunds1)); }if (EmsMod.ItemFunds2 != null){strWhere += " and ItemFunds2=@in_ItemFunds2 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFunds2", DbType.String, EmsMod.ItemFunds2)); }if (EmsMod.ItemFunds3 != null){strWhere += " and ItemFunds3=@in_ItemFunds3 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFunds3", DbType.String, EmsMod.ItemFunds3)); }if (EmsMod.ItemFunds4 != null){strWhere += " and ItemFunds4=@in_ItemFunds4 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFunds4", DbType.String, EmsMod.ItemFunds4)); }if (EmsMod.ItemFundsMoney1 != null){strWhere += " and ItemFundsMoney1=@in_ItemFundsMoney1 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFundsMoney1", DbType.String, EmsMod.ItemFundsMoney1)); }if (EmsMod.ItemFundsMoney2 != null){strWhere += " and ItemFundsMoney2=@in_ItemFundsMoney2 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFundsMoney2", DbType.String, EmsMod.ItemFundsMoney2)); }if (EmsMod.ItemFundsMoney3 != null){strWhere += " and ItemFundsMoney3=@in_ItemFundsMoney3 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFundsMoney3", DbType.String, EmsMod.ItemFundsMoney3)); }if (EmsMod.ItemFundsMoney4 != null){strWhere += " and ItemFundsMoney4=@in_ItemFundsMoney4 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFundsMoney4", DbType.String, EmsMod.ItemFundsMoney4)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }if (EmsMod.StorageLocation1 != null){strWhere += " and StorageLocation1=@in_StorageLocation1 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StorageLocation1", DbType.String, EmsMod.StorageLocation1)); }if (EmsMod.IsConsume != null){strWhere += " and IsConsume=@in_IsConsume ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsConsume", DbType.String, EmsMod.IsConsume)); }if (EmsMod.EquipSource != null){strWhere += " and EquipSource=@in_EquipSource ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipSource", DbType.String, EmsMod.EquipSource)); }if (EmsMod.EquipOwner != null){strWhere += " and EquipOwner=@in_EquipOwner ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipOwner", DbType.String, EmsMod.EquipOwner)); }if (EmsMod.ManualModify != null){strWhere += " and ManualModify=@in_ManualModify ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ManualModify", DbType.String, EmsMod.ManualModify)); }if (EmsMod.ImageUrl != null){strWhere += " and ImageUrl=@in_ImageUrl ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ImageUrl", DbType.String, EmsMod.ImageUrl)); }if (EmsMod.BorrowYN != null){strWhere += " and BorrowYN=@in_BorrowYN ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BorrowYN", DbType.String, EmsMod.BorrowYN)); }if (EmsMod.WarehouseName != null){strWhere += " and WarehouseName=@in_WarehouseName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_WarehouseName", DbType.String, EmsMod.WarehouseName)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.View_EquipDatail EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.EquipKindId = dr["EquipKindId"] as int?;EmsModel.AssetNumber = dr["AssetNumber"] as string;EmsModel.EquipIntoID = dr["EquipIntoID"] as int?;EmsModel.EquipStatus = dr["EquipStatus"] as int?;EmsModel.Type = dr["Type"] as Byte?;EmsModel.Barcode = dr["Barcode"] as string;EmsModel.ImageName = dr["ImageName"] as string;EmsModel.Count = dr["Count"] as int?;EmsModel.ClassNumber = dr["ClassNumber"] as string;EmsModel.AssetsClassName = dr["AssetsClassName"] as string;EmsModel.IntlClassCode = dr["IntlClassCode"] as string;EmsModel.IntlClassName = dr["IntlClassName"] as string;EmsModel.AssetName = dr["AssetName"] as string;EmsModel.Unit = dr["Unit"] as string;EmsModel.UsageStatus = dr["UsageStatus"] as string;EmsModel.UsageDirection = dr["UsageDirection"] as string;EmsModel.JYBBBSYFX = dr["JYBBBSYFX"] as string;EmsModel.AcquisitionMethod = dr["AcquisitionMethod"] as string;EmsModel.AcquisitionDate = dr["AcquisitionDate"] as DateTime?;EmsModel.BrandStandardModel = dr["BrandStandardModel"] as string;EmsModel.EquipmentUse = dr["EquipmentUse"] as string;EmsModel.UseDepartment = dr["UseDepartment"] as string;EmsModel.UsePeople = dr["UsePeople"] as string;EmsModel.Factory = dr["Factory"] as string;EmsModel.StorageLocation = dr["StorageLocation"] as string;EmsModel.WorthType = dr["WorthType"] as string;EmsModel.UseNature = dr["UseNature"] as string;EmsModel.Worth = dr["Worth"] as decimal?;EmsModel.FinanceRecordType = dr["FinanceRecordType"] as string;EmsModel.FiscalFunds = dr["FiscalFunds"] as decimal?;EmsModel.NonFiscalFunds = dr["NonFiscalFunds"] as decimal?;EmsModel.FinanceRecordDate = dr["FinanceRecordDate"] as DateTime?;EmsModel.VoucherNumber = dr["VoucherNumber"] as string;EmsModel.UseTime = dr["UseTime"] as int?;EmsModel.ExpectedScrapDate = dr["ExpectedScrapDate"] as DateTime?;EmsModel.DepreciationState = dr["DepreciationState"] as string;EmsModel.NetWorth = dr["NetWorth"] as decimal?;EmsModel.OutFactoryNumber = dr["OutFactoryNumber"] as string;EmsModel.Supplier = dr["Supplier"] as string;EmsModel.FundsSubject = dr["FundsSubject"] as string;EmsModel.PurchaseModality = dr["PurchaseModality"] as string;EmsModel.CountryCode = dr["CountryCode"] as string;EmsModel.Operator = dr["Operator"] as string;EmsModel.GuaranteeEndDate = dr["GuaranteeEndDate"] as DateTime?;EmsModel.EquipmentNumber = dr["EquipmentNumber"] as string;EmsModel.InvoiceNumber = dr["InvoiceNumber"] as string;EmsModel.CompactNumber = dr["CompactNumber"] as string;EmsModel.BasicFunds = dr["BasicFunds"] as string;EmsModel.ItemFunds1 = dr["ItemFunds1"] as string;EmsModel.ItemFunds2 = dr["ItemFunds2"] as string;EmsModel.ItemFunds3 = dr["ItemFunds3"] as string;EmsModel.ItemFunds4 = dr["ItemFunds4"] as string;EmsModel.ItemFundsMoney1 = dr["ItemFundsMoney1"] as decimal?;EmsModel.ItemFundsMoney2 = dr["ItemFundsMoney2"] as decimal?;EmsModel.ItemFundsMoney3 = dr["ItemFundsMoney3"] as decimal?;EmsModel.ItemFundsMoney4 = dr["ItemFundsMoney4"] as decimal?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.UseStatus = dr["UseStatus"] as Byte?;EmsModel.StorageLocation1 = dr["StorageLocation1"] as string;EmsModel.IsConsume = dr["IsConsume"] as Byte?;EmsModel.EquipSource = dr["EquipSource"] as Byte?;EmsModel.EquipOwner = dr["EquipOwner"] as string;EmsModel.ManualModify = dr["ManualModify"] as Byte?;EmsModel.ImageUrl = dr["ImageUrl"] as string;EmsModel.BorrowYN = dr["BorrowYN"] as Byte?;EmsModel.WarehouseName = dr["WarehouseName"] as string;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.View_EquipDatail> GetList(DataTable dt)
        {
            List<EmsModel.View_EquipDatail> lst = new List<EmsModel.View_EquipDatail>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.View_EquipDatail mod = new EmsModel.View_EquipDatail();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.View_EquipDatail EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.EquipKindId = dr["EquipKindId"] as int?;EmsModel.AssetNumber = dr["AssetNumber"] as string;EmsModel.EquipIntoID = dr["EquipIntoID"] as int?;EmsModel.EquipStatus = dr["EquipStatus"] as int?;EmsModel.Type = dr["Type"] as Byte?;EmsModel.Barcode = dr["Barcode"] as string;EmsModel.ImageName = dr["ImageName"] as string;EmsModel.Count = dr["Count"] as int?;EmsModel.ClassNumber = dr["ClassNumber"] as string;EmsModel.AssetsClassName = dr["AssetsClassName"] as string;EmsModel.IntlClassCode = dr["IntlClassCode"] as string;EmsModel.IntlClassName = dr["IntlClassName"] as string;EmsModel.AssetName = dr["AssetName"] as string;EmsModel.Unit = dr["Unit"] as string;EmsModel.UsageStatus = dr["UsageStatus"] as string;EmsModel.UsageDirection = dr["UsageDirection"] as string;EmsModel.JYBBBSYFX = dr["JYBBBSYFX"] as string;EmsModel.AcquisitionMethod = dr["AcquisitionMethod"] as string;EmsModel.AcquisitionDate = dr["AcquisitionDate"] as DateTime?;EmsModel.BrandStandardModel = dr["BrandStandardModel"] as string;EmsModel.EquipmentUse = dr["EquipmentUse"] as string;EmsModel.UseDepartment = dr["UseDepartment"] as string;EmsModel.UsePeople = dr["UsePeople"] as string;EmsModel.Factory = dr["Factory"] as string;EmsModel.StorageLocation = dr["StorageLocation"] as string;EmsModel.WorthType = dr["WorthType"] as string;EmsModel.UseNature = dr["UseNature"] as string;EmsModel.Worth = dr["Worth"] as decimal?;EmsModel.FinanceRecordType = dr["FinanceRecordType"] as string;EmsModel.FiscalFunds = dr["FiscalFunds"] as decimal?;EmsModel.NonFiscalFunds = dr["NonFiscalFunds"] as decimal?;EmsModel.FinanceRecordDate = dr["FinanceRecordDate"] as DateTime?;EmsModel.VoucherNumber = dr["VoucherNumber"] as string;EmsModel.UseTime = dr["UseTime"] as int?;EmsModel.ExpectedScrapDate = dr["ExpectedScrapDate"] as DateTime?;EmsModel.DepreciationState = dr["DepreciationState"] as string;EmsModel.NetWorth = dr["NetWorth"] as decimal?;EmsModel.OutFactoryNumber = dr["OutFactoryNumber"] as string;EmsModel.Supplier = dr["Supplier"] as string;EmsModel.FundsSubject = dr["FundsSubject"] as string;EmsModel.PurchaseModality = dr["PurchaseModality"] as string;EmsModel.CountryCode = dr["CountryCode"] as string;EmsModel.Operator = dr["Operator"] as string;EmsModel.GuaranteeEndDate = dr["GuaranteeEndDate"] as DateTime?;EmsModel.EquipmentNumber = dr["EquipmentNumber"] as string;EmsModel.InvoiceNumber = dr["InvoiceNumber"] as string;EmsModel.CompactNumber = dr["CompactNumber"] as string;EmsModel.BasicFunds = dr["BasicFunds"] as string;EmsModel.ItemFunds1 = dr["ItemFunds1"] as string;EmsModel.ItemFunds2 = dr["ItemFunds2"] as string;EmsModel.ItemFunds3 = dr["ItemFunds3"] as string;EmsModel.ItemFunds4 = dr["ItemFunds4"] as string;EmsModel.ItemFundsMoney1 = dr["ItemFundsMoney1"] as decimal?;EmsModel.ItemFundsMoney2 = dr["ItemFundsMoney2"] as decimal?;EmsModel.ItemFundsMoney3 = dr["ItemFundsMoney3"] as decimal?;EmsModel.ItemFundsMoney4 = dr["ItemFundsMoney4"] as decimal?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.UseStatus = dr["UseStatus"] as Byte?;EmsModel.StorageLocation1 = dr["StorageLocation1"] as string;EmsModel.IsConsume = dr["IsConsume"] as Byte?;EmsModel.EquipSource = dr["EquipSource"] as Byte?;EmsModel.EquipOwner = dr["EquipOwner"] as string;EmsModel.ManualModify = dr["ManualModify"] as Byte?;EmsModel.ImageUrl = dr["ImageUrl"] as string;EmsModel.BorrowYN = dr["BorrowYN"] as Byte?;EmsModel.WarehouseName = dr["WarehouseName"] as string;
        }		

    }

	/// </summary>
	///	教学计划表实体类8
	/// </summary>
    public partial class View_Calendar_Land: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.View_Calendar_Land EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO View_Calendar_Land(");
						sbSql.Append("Id,title,start,StartDate,planName,planId,tpDate,isStatus,orderid,num)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Id,@in_title,@in_start,@in_StartDate,@in_planName,@in_planId,@in_tpDate,@in_isStatus,@in_orderid,@in_num)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_title", DbType.String, EmsModel.title),dbHelper.CreateInDbParameter("@in_start", DbType.String, EmsModel.start),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_planName", DbType.String, EmsModel.planName),dbHelper.CreateInDbParameter("@in_planId", DbType.Int32, EmsModel.planId),dbHelper.CreateInDbParameter("@in_tpDate", DbType.DateTime, EmsModel.tpDate),dbHelper.CreateInDbParameter("@in_isStatus", DbType.Int32, EmsModel.isStatus),dbHelper.CreateInDbParameter("@in_orderid", DbType.Int32, EmsModel.orderid),dbHelper.CreateInDbParameter("@in_num", DbType.Int32, EmsModel.num)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.View_Calendar_Land EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO View_Calendar_Land(");
						sbSql.Append("Id,title,start,StartDate,planName,planId,tpDate,isStatus,orderid,num)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Id,@in_title,@in_start,@in_StartDate,@in_planName,@in_planId,@in_tpDate,@in_isStatus,@in_orderid,@in_num)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_title", DbType.String, EmsModel.title),dbHelper.CreateInDbParameter("@in_start", DbType.String, EmsModel.start),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_planName", DbType.String, EmsModel.planName),dbHelper.CreateInDbParameter("@in_planId", DbType.Int32, EmsModel.planId),dbHelper.CreateInDbParameter("@in_tpDate", DbType.DateTime, EmsModel.tpDate),dbHelper.CreateInDbParameter("@in_isStatus", DbType.Int32, EmsModel.isStatus),dbHelper.CreateInDbParameter("@in_orderid", DbType.Int32, EmsModel.orderid),dbHelper.CreateInDbParameter("@in_num", DbType.Int32, EmsModel.num)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.View_Calendar_Land EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update View_Calendar_Land set ");
					sbSql.Append("Id=@in_Id,title=@in_title,start=@in_start,StartDate=@in_StartDate,planName=@in_planName,planId=@in_planId,tpDate=@in_tpDate,isStatus=@in_isStatus,orderid=@in_orderid,num=@in_num");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_title", DbType.String, EmsModel.title),dbHelper.CreateInDbParameter("@in_start", DbType.String, EmsModel.start),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_planName", DbType.String, EmsModel.planName),dbHelper.CreateInDbParameter("@in_planId", DbType.Int32, EmsModel.planId),dbHelper.CreateInDbParameter("@in_tpDate", DbType.DateTime, EmsModel.tpDate),dbHelper.CreateInDbParameter("@in_isStatus", DbType.Int32, EmsModel.isStatus),dbHelper.CreateInDbParameter("@in_orderid", DbType.Int32, EmsModel.orderid),dbHelper.CreateInDbParameter("@in_num", DbType.Int32, EmsModel.num)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.View_Calendar_Land EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update View_Calendar_Land set ");
					sbSql.Append("Id=@in_Id,title=@in_title,start=@in_start,StartDate=@in_StartDate,planName=@in_planName,planId=@in_planId,tpDate=@in_tpDate,isStatus=@in_isStatus,orderid=@in_orderid,num=@in_num");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_title", DbType.String, EmsModel.title),dbHelper.CreateInDbParameter("@in_start", DbType.String, EmsModel.start),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_planName", DbType.String, EmsModel.planName),dbHelper.CreateInDbParameter("@in_planId", DbType.Int32, EmsModel.planId),dbHelper.CreateInDbParameter("@in_tpDate", DbType.DateTime, EmsModel.tpDate),dbHelper.CreateInDbParameter("@in_isStatus", DbType.Int32, EmsModel.isStatus),dbHelper.CreateInDbParameter("@in_orderid", DbType.Int32, EmsModel.orderid),dbHelper.CreateInDbParameter("@in_num", DbType.Int32, EmsModel.num)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM View_Calendar_Land");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM View_Calendar_Land");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists( )
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM View_Calendar_Land");
					sbSql.Append("");

					parms = new DbParameter[]{
						
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.View_Calendar_Land> GetListByPage(EmsModel.View_Calendar_Land EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "View_Calendar_Land";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Id != null){strWhere += " and Id=@in_Id ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Id", DbType.String, EmsMod.Id)); }if (EmsMod.title != null){strWhere += " and title=@in_title ";parmsList.Add(dbHelper.CreateInDbParameter("@in_title", DbType.String, EmsMod.title)); }if (EmsMod.start != null){strWhere += " and start=@in_start ";parmsList.Add(dbHelper.CreateInDbParameter("@in_start", DbType.String, EmsMod.start)); }if (EmsMod.StartDate != null){strWhere += " and StartDate=@in_StartDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StartDate", DbType.String, EmsMod.StartDate)); }if (EmsMod.planName != null){strWhere += " and planName=@in_planName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_planName", DbType.String, EmsMod.planName)); }if (EmsMod.planId != null){strWhere += " and planId=@in_planId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_planId", DbType.String, EmsMod.planId)); }if (EmsMod.tpDate != null){strWhere += " and tpDate=@in_tpDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_tpDate", DbType.String, EmsMod.tpDate)); }if (EmsMod.isStatus != null){strWhere += " and isStatus=@in_isStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_isStatus", DbType.String, EmsMod.isStatus)); }if (EmsMod.orderid != null){strWhere += " and orderid=@in_orderid ";parmsList.Add(dbHelper.CreateInDbParameter("@in_orderid", DbType.String, EmsMod.orderid)); }if (EmsMod.num != null){strWhere += " and num=@in_num ";parmsList.Add(dbHelper.CreateInDbParameter("@in_num", DbType.String, EmsMod.num)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.View_Calendar_Land> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.View_Calendar_Land EmsMod)
        {
            string TableName = "View_Calendar_Land";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Id != null){strWhere += " and Id=@in_Id ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Id", DbType.String, EmsMod.Id)); }if (EmsMod.title != null){strWhere += " and title=@in_title ";parmsList.Add(dbHelper.CreateInDbParameter("@in_title", DbType.String, EmsMod.title)); }if (EmsMod.start != null){strWhere += " and start=@in_start ";parmsList.Add(dbHelper.CreateInDbParameter("@in_start", DbType.String, EmsMod.start)); }if (EmsMod.StartDate != null){strWhere += " and StartDate=@in_StartDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StartDate", DbType.String, EmsMod.StartDate)); }if (EmsMod.planName != null){strWhere += " and planName=@in_planName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_planName", DbType.String, EmsMod.planName)); }if (EmsMod.planId != null){strWhere += " and planId=@in_planId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_planId", DbType.String, EmsMod.planId)); }if (EmsMod.tpDate != null){strWhere += " and tpDate=@in_tpDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_tpDate", DbType.String, EmsMod.tpDate)); }if (EmsMod.isStatus != null){strWhere += " and isStatus=@in_isStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_isStatus", DbType.String, EmsMod.isStatus)); }if (EmsMod.orderid != null){strWhere += " and orderid=@in_orderid ";parmsList.Add(dbHelper.CreateInDbParameter("@in_orderid", DbType.String, EmsMod.orderid)); }if (EmsMod.num != null){strWhere += " and num=@in_num ";parmsList.Add(dbHelper.CreateInDbParameter("@in_num", DbType.String, EmsMod.num)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.View_Calendar_Land EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.title = dr["title"] as string;EmsModel.start = dr["start"] as string;EmsModel.StartDate = dr["StartDate"] as DateTime?;EmsModel.planName = dr["planName"] as string;EmsModel.planId = dr["planId"] as int?;EmsModel.tpDate = dr["tpDate"] as DateTime?;EmsModel.isStatus = dr["isStatus"] as int?;EmsModel.orderid = dr["orderid"] as int?;EmsModel.num = dr["num"] as long?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.View_Calendar_Land> GetList(DataTable dt)
        {
            List<EmsModel.View_Calendar_Land> lst = new List<EmsModel.View_Calendar_Land>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.View_Calendar_Land mod = new EmsModel.View_Calendar_Land();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.View_Calendar_Land EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.title = dr["title"] as string;EmsModel.start = dr["start"] as string;EmsModel.StartDate = dr["StartDate"] as DateTime?;EmsModel.planName = dr["planName"] as string;EmsModel.planId = dr["planId"] as int?;EmsModel.tpDate = dr["tpDate"] as DateTime?;EmsModel.isStatus = dr["isStatus"] as int?;EmsModel.orderid = dr["orderid"] as int?;EmsModel.num = dr["num"] as long?;
        }		

    }

	/// </summary>
	///	教学计划表实体类9
	/// </summary>
    public partial class Student: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.Student EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO Student(");
						sbSql.Append("Name,IDCard,ClassId,Sex,Phone,KaNo,Creator,CreateTime,Editor,UpdateTime,IsDelete,UseStatus,Remarks)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_IDCard,@in_ClassId,@in_Sex,@in_Phone,@in_KaNo,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_UseStatus,@in_Remarks)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsModel.IDCard),dbHelper.CreateInDbParameter("@in_ClassId", DbType.Int32, EmsModel.ClassId),dbHelper.CreateInDbParameter("@in_Sex", DbType.String, EmsModel.Sex),dbHelper.CreateInDbParameter("@in_Phone", DbType.String, EmsModel.Phone),dbHelper.CreateInDbParameter("@in_KaNo", DbType.String, EmsModel.KaNo),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.Student EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO Student(");
						sbSql.Append("Name,IDCard,ClassId,Sex,Phone,KaNo,Creator,CreateTime,Editor,UpdateTime,IsDelete,UseStatus,Remarks)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_IDCard,@in_ClassId,@in_Sex,@in_Phone,@in_KaNo,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_UseStatus,@in_Remarks)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsModel.IDCard),dbHelper.CreateInDbParameter("@in_ClassId", DbType.Int32, EmsModel.ClassId),dbHelper.CreateInDbParameter("@in_Sex", DbType.String, EmsModel.Sex),dbHelper.CreateInDbParameter("@in_Phone", DbType.String, EmsModel.Phone),dbHelper.CreateInDbParameter("@in_KaNo", DbType.String, EmsModel.KaNo),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.Student EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update Student set ");
					sbSql.Append("Name=@in_Name,IDCard=@in_IDCard,ClassId=@in_ClassId,Sex=@in_Sex,Phone=@in_Phone,KaNo=@in_KaNo,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,UseStatus=@in_UseStatus,Remarks=@in_Remarks");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsModel.IDCard),dbHelper.CreateInDbParameter("@in_ClassId", DbType.Int32, EmsModel.ClassId),dbHelper.CreateInDbParameter("@in_Sex", DbType.String, EmsModel.Sex),dbHelper.CreateInDbParameter("@in_Phone", DbType.String, EmsModel.Phone),dbHelper.CreateInDbParameter("@in_KaNo", DbType.String, EmsModel.KaNo),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.Student EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update Student set ");
					sbSql.Append("Name=@in_Name,IDCard=@in_IDCard,ClassId=@in_ClassId,Sex=@in_Sex,Phone=@in_Phone,KaNo=@in_KaNo,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,UseStatus=@in_UseStatus,Remarks=@in_Remarks");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsModel.IDCard),dbHelper.CreateInDbParameter("@in_ClassId", DbType.Int32, EmsModel.ClassId),dbHelper.CreateInDbParameter("@in_Sex", DbType.String, EmsModel.Sex),dbHelper.CreateInDbParameter("@in_Phone", DbType.String, EmsModel.Phone),dbHelper.CreateInDbParameter("@in_KaNo", DbType.String, EmsModel.KaNo),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM Student");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM Student");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM Student");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.Student> GetListByPage(EmsModel.Student EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "Student";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.IDCard != null){strWhere += " and IDCard=@in_IDCard ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsMod.IDCard)); }if (EmsMod.ClassId != null){strWhere += " and ClassId=@in_ClassId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ClassId", DbType.String, EmsMod.ClassId)); }if (EmsMod.Sex != null){strWhere += " and Sex=@in_Sex ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Sex", DbType.String, EmsMod.Sex)); }if (EmsMod.Phone != null){strWhere += " and Phone=@in_Phone ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Phone", DbType.String, EmsMod.Phone)); }if (EmsMod.KaNo != null){strWhere += " and KaNo=@in_KaNo ";parmsList.Add(dbHelper.CreateInDbParameter("@in_KaNo", DbType.String, EmsMod.KaNo)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.Student> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.Student EmsMod)
        {
            string TableName = "Student";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.IDCard != null){strWhere += " and IDCard=@in_IDCard ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsMod.IDCard)); }if (EmsMod.ClassId != null){strWhere += " and ClassId=@in_ClassId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ClassId", DbType.String, EmsMod.ClassId)); }if (EmsMod.Sex != null){strWhere += " and Sex=@in_Sex ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Sex", DbType.String, EmsMod.Sex)); }if (EmsMod.Phone != null){strWhere += " and Phone=@in_Phone ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Phone", DbType.String, EmsMod.Phone)); }if (EmsMod.KaNo != null){strWhere += " and KaNo=@in_KaNo ";parmsList.Add(dbHelper.CreateInDbParameter("@in_KaNo", DbType.String, EmsMod.KaNo)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.Student EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.IDCard = dr["IDCard"] as string;EmsModel.ClassId = dr["ClassId"] as int?;EmsModel.Sex = dr["Sex"] as string;EmsModel.Phone = dr["Phone"] as string;EmsModel.KaNo = dr["KaNo"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.UseStatus = dr["UseStatus"] as Byte?;EmsModel.Remarks = dr["Remarks"] as string;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.Student> GetList(DataTable dt)
        {
            List<EmsModel.Student> lst = new List<EmsModel.Student>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.Student mod = new EmsModel.Student();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.Student EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.IDCard = dr["IDCard"] as string;EmsModel.ClassId = dr["ClassId"] as int?;EmsModel.Sex = dr["Sex"] as string;EmsModel.Phone = dr["Phone"] as string;EmsModel.KaNo = dr["KaNo"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.UseStatus = dr["UseStatus"] as Byte?;EmsModel.Remarks = dr["Remarks"] as string;
        }		

    }

	/// </summary>
	///	教学计划表实体类10
	/// </summary>
    public partial class TeachingPlan: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.TeachingPlan EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO TeachingPlan(");
						sbSql.Append("Name,MainTeacher,GuideTeacher1,GuideTeacher2,Contents,LearnYear,Creator,CreateTime,Editor,UpdateTime,IsDelete)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_MainTeacher,@in_GuideTeacher1,@in_GuideTeacher2,@in_Contents,@in_LearnYear,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_MainTeacher", DbType.String, EmsModel.MainTeacher),dbHelper.CreateInDbParameter("@in_GuideTeacher1", DbType.String, EmsModel.GuideTeacher1),dbHelper.CreateInDbParameter("@in_GuideTeacher2", DbType.String, EmsModel.GuideTeacher2),dbHelper.CreateInDbParameter("@in_Contents", DbType.String, EmsModel.Contents),dbHelper.CreateInDbParameter("@in_LearnYear", DbType.Int32, EmsModel.LearnYear),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.TeachingPlan EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO TeachingPlan(");
						sbSql.Append("Name,MainTeacher,GuideTeacher1,GuideTeacher2,Contents,LearnYear,Creator,CreateTime,Editor,UpdateTime,IsDelete)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_MainTeacher,@in_GuideTeacher1,@in_GuideTeacher2,@in_Contents,@in_LearnYear,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_MainTeacher", DbType.String, EmsModel.MainTeacher),dbHelper.CreateInDbParameter("@in_GuideTeacher1", DbType.String, EmsModel.GuideTeacher1),dbHelper.CreateInDbParameter("@in_GuideTeacher2", DbType.String, EmsModel.GuideTeacher2),dbHelper.CreateInDbParameter("@in_Contents", DbType.String, EmsModel.Contents),dbHelper.CreateInDbParameter("@in_LearnYear", DbType.Int32, EmsModel.LearnYear),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.TeachingPlan EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update TeachingPlan set ");
					sbSql.Append("Name=@in_Name,MainTeacher=@in_MainTeacher,GuideTeacher1=@in_GuideTeacher1,GuideTeacher2=@in_GuideTeacher2,Contents=@in_Contents,LearnYear=@in_LearnYear,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_MainTeacher", DbType.String, EmsModel.MainTeacher),dbHelper.CreateInDbParameter("@in_GuideTeacher1", DbType.String, EmsModel.GuideTeacher1),dbHelper.CreateInDbParameter("@in_GuideTeacher2", DbType.String, EmsModel.GuideTeacher2),dbHelper.CreateInDbParameter("@in_Contents", DbType.String, EmsModel.Contents),dbHelper.CreateInDbParameter("@in_LearnYear", DbType.Int32, EmsModel.LearnYear),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.TeachingPlan EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update TeachingPlan set ");
					sbSql.Append("Name=@in_Name,MainTeacher=@in_MainTeacher,GuideTeacher1=@in_GuideTeacher1,GuideTeacher2=@in_GuideTeacher2,Contents=@in_Contents,LearnYear=@in_LearnYear,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_MainTeacher", DbType.String, EmsModel.MainTeacher),dbHelper.CreateInDbParameter("@in_GuideTeacher1", DbType.String, EmsModel.GuideTeacher1),dbHelper.CreateInDbParameter("@in_GuideTeacher2", DbType.String, EmsModel.GuideTeacher2),dbHelper.CreateInDbParameter("@in_Contents", DbType.String, EmsModel.Contents),dbHelper.CreateInDbParameter("@in_LearnYear", DbType.Int32, EmsModel.LearnYear),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM TeachingPlan");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM TeachingPlan");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM TeachingPlan");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.TeachingPlan> GetListByPage(EmsModel.TeachingPlan EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "TeachingPlan";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.MainTeacher != null){strWhere += " and MainTeacher=@in_MainTeacher ";parmsList.Add(dbHelper.CreateInDbParameter("@in_MainTeacher", DbType.String, EmsMod.MainTeacher)); }if (EmsMod.GuideTeacher1 != null){strWhere += " and GuideTeacher1=@in_GuideTeacher1 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_GuideTeacher1", DbType.String, EmsMod.GuideTeacher1)); }if (EmsMod.GuideTeacher2 != null){strWhere += " and GuideTeacher2=@in_GuideTeacher2 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_GuideTeacher2", DbType.String, EmsMod.GuideTeacher2)); }if (EmsMod.Contents != null){strWhere += " and Contents=@in_Contents ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Contents", DbType.String, EmsMod.Contents)); }if (EmsMod.LearnYear != null){strWhere += " and LearnYear=@in_LearnYear ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LearnYear", DbType.String, EmsMod.LearnYear)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.TeachingPlan> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.TeachingPlan EmsMod)
        {
            string TableName = "TeachingPlan";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.MainTeacher != null){strWhere += " and MainTeacher=@in_MainTeacher ";parmsList.Add(dbHelper.CreateInDbParameter("@in_MainTeacher", DbType.String, EmsMod.MainTeacher)); }if (EmsMod.GuideTeacher1 != null){strWhere += " and GuideTeacher1=@in_GuideTeacher1 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_GuideTeacher1", DbType.String, EmsMod.GuideTeacher1)); }if (EmsMod.GuideTeacher2 != null){strWhere += " and GuideTeacher2=@in_GuideTeacher2 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_GuideTeacher2", DbType.String, EmsMod.GuideTeacher2)); }if (EmsMod.Contents != null){strWhere += " and Contents=@in_Contents ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Contents", DbType.String, EmsMod.Contents)); }if (EmsMod.LearnYear != null){strWhere += " and LearnYear=@in_LearnYear ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LearnYear", DbType.String, EmsMod.LearnYear)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.TeachingPlan EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.MainTeacher = dr["MainTeacher"] as string;EmsModel.GuideTeacher1 = dr["GuideTeacher1"] as string;EmsModel.GuideTeacher2 = dr["GuideTeacher2"] as string;EmsModel.Contents = dr["Contents"] as string;EmsModel.LearnYear = dr["LearnYear"] as int?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.TeachingPlan> GetList(DataTable dt)
        {
            List<EmsModel.TeachingPlan> lst = new List<EmsModel.TeachingPlan>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.TeachingPlan mod = new EmsModel.TeachingPlan();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.TeachingPlan EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.MainTeacher = dr["MainTeacher"] as string;EmsModel.GuideTeacher1 = dr["GuideTeacher1"] as string;EmsModel.GuideTeacher2 = dr["GuideTeacher2"] as string;EmsModel.Contents = dr["Contents"] as string;EmsModel.LearnYear = dr["LearnYear"] as int?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;
        }		

    }

	/// </summary>
	///	教学计划表实体类11
	/// </summary>
    public partial class UserInfo: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.UserInfo EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO UserInfo(");
						sbSql.Append("LoginName,Name,PassWord,Creator,CreateTime,Editor,UpdateTime,IsDelete,Sex,KaNo,KaLv,UseStatus,IDCard)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_LoginName,@in_Name,@in_PassWord,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_Sex,@in_KaNo,@in_KaLv,@in_UseStatus,@in_IDCard)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsModel.LoginName),dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_PassWord", DbType.String, EmsModel.PassWord),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_Sex", DbType.String, EmsModel.Sex),dbHelper.CreateInDbParameter("@in_KaNo", DbType.String, EmsModel.KaNo),dbHelper.CreateInDbParameter("@in_KaLv", DbType.String, EmsModel.KaLv),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus),dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsModel.IDCard)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.UserInfo EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO UserInfo(");
						sbSql.Append("LoginName,Name,PassWord,Creator,CreateTime,Editor,UpdateTime,IsDelete,Sex,KaNo,KaLv,UseStatus,IDCard)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_LoginName,@in_Name,@in_PassWord,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_Sex,@in_KaNo,@in_KaLv,@in_UseStatus,@in_IDCard)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsModel.LoginName),dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_PassWord", DbType.String, EmsModel.PassWord),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_Sex", DbType.String, EmsModel.Sex),dbHelper.CreateInDbParameter("@in_KaNo", DbType.String, EmsModel.KaNo),dbHelper.CreateInDbParameter("@in_KaLv", DbType.String, EmsModel.KaLv),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus),dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsModel.IDCard)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.UserInfo EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update UserInfo set ");
					sbSql.Append("LoginName=@in_LoginName,Name=@in_Name,PassWord=@in_PassWord,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,Sex=@in_Sex,KaNo=@in_KaNo,KaLv=@in_KaLv,UseStatus=@in_UseStatus,IDCard=@in_IDCard");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsModel.LoginName),dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_PassWord", DbType.String, EmsModel.PassWord),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_Sex", DbType.String, EmsModel.Sex),dbHelper.CreateInDbParameter("@in_KaNo", DbType.String, EmsModel.KaNo),dbHelper.CreateInDbParameter("@in_KaLv", DbType.String, EmsModel.KaLv),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus),dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsModel.IDCard)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.UserInfo EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update UserInfo set ");
					sbSql.Append("LoginName=@in_LoginName,Name=@in_Name,PassWord=@in_PassWord,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,Sex=@in_Sex,KaNo=@in_KaNo,KaLv=@in_KaLv,UseStatus=@in_UseStatus,IDCard=@in_IDCard");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsModel.LoginName),dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_PassWord", DbType.String, EmsModel.PassWord),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_Sex", DbType.String, EmsModel.Sex),dbHelper.CreateInDbParameter("@in_KaNo", DbType.String, EmsModel.KaNo),dbHelper.CreateInDbParameter("@in_KaLv", DbType.String, EmsModel.KaLv),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus),dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsModel.IDCard)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM UserInfo");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM UserInfo");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM UserInfo");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.UserInfo> GetListByPage(EmsModel.UserInfo EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "UserInfo";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.LoginName != null){strWhere += " and LoginName=@in_LoginName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsMod.LoginName)); }if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.PassWord != null){strWhere += " and PassWord=@in_PassWord ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PassWord", DbType.String, EmsMod.PassWord)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.Sex != null){strWhere += " and Sex=@in_Sex ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Sex", DbType.String, EmsMod.Sex)); }if (EmsMod.KaNo != null){strWhere += " and KaNo=@in_KaNo ";parmsList.Add(dbHelper.CreateInDbParameter("@in_KaNo", DbType.String, EmsMod.KaNo)); }if (EmsMod.KaLv != null){strWhere += " and KaLv=@in_KaLv ";parmsList.Add(dbHelper.CreateInDbParameter("@in_KaLv", DbType.String, EmsMod.KaLv)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }if (EmsMod.IDCard != null){strWhere += " and IDCard=@in_IDCard ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsMod.IDCard)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.UserInfo> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.UserInfo EmsMod)
        {
            string TableName = "UserInfo";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.LoginName != null){strWhere += " and LoginName=@in_LoginName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsMod.LoginName)); }if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.PassWord != null){strWhere += " and PassWord=@in_PassWord ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PassWord", DbType.String, EmsMod.PassWord)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.Sex != null){strWhere += " and Sex=@in_Sex ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Sex", DbType.String, EmsMod.Sex)); }if (EmsMod.KaNo != null){strWhere += " and KaNo=@in_KaNo ";parmsList.Add(dbHelper.CreateInDbParameter("@in_KaNo", DbType.String, EmsMod.KaNo)); }if (EmsMod.KaLv != null){strWhere += " and KaLv=@in_KaLv ";parmsList.Add(dbHelper.CreateInDbParameter("@in_KaLv", DbType.String, EmsMod.KaLv)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }if (EmsMod.IDCard != null){strWhere += " and IDCard=@in_IDCard ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsMod.IDCard)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.UserInfo EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.LoginName = dr["LoginName"] as string;EmsModel.Name = dr["Name"] as string;EmsModel.PassWord = dr["PassWord"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.Sex = dr["Sex"] as string;EmsModel.KaNo = dr["KaNo"] as string;EmsModel.KaLv = dr["KaLv"] as string;EmsModel.UseStatus = dr["UseStatus"] as Byte?;EmsModel.IDCard = dr["IDCard"] as string;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.UserInfo> GetList(DataTable dt)
        {
            List<EmsModel.UserInfo> lst = new List<EmsModel.UserInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.UserInfo mod = new EmsModel.UserInfo();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.UserInfo EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.LoginName = dr["LoginName"] as string;EmsModel.Name = dr["Name"] as string;EmsModel.PassWord = dr["PassWord"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.Sex = dr["Sex"] as string;EmsModel.KaNo = dr["KaNo"] as string;EmsModel.KaLv = dr["KaLv"] as string;EmsModel.UseStatus = dr["UseStatus"] as Byte?;EmsModel.IDCard = dr["IDCard"] as string;
        }		

    }

	/// </summary>
	///	教学计划表实体类12
	/// </summary>
    public partial class AttachmentInfo: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.AttachmentInfo EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO AttachmentInfo(");
						sbSql.Append("AttachmentName,AttachmentPath,Creator,CreateTime,IsDelete,ContractID)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_AttachmentName,@in_AttachmentPath,@in_Creator,@in_CreateTime,@in_IsDelete,@in_ContractID)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_AttachmentName", DbType.String, EmsModel.AttachmentName),dbHelper.CreateInDbParameter("@in_AttachmentPath", DbType.String, EmsModel.AttachmentPath),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_ContractID", DbType.Int32, EmsModel.ContractID)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.AttachmentInfo EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO AttachmentInfo(");
						sbSql.Append("AttachmentName,AttachmentPath,Creator,CreateTime,IsDelete,ContractID)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_AttachmentName,@in_AttachmentPath,@in_Creator,@in_CreateTime,@in_IsDelete,@in_ContractID)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_AttachmentName", DbType.String, EmsModel.AttachmentName),dbHelper.CreateInDbParameter("@in_AttachmentPath", DbType.String, EmsModel.AttachmentPath),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_ContractID", DbType.Int32, EmsModel.ContractID)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.AttachmentInfo EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update AttachmentInfo set ");
					sbSql.Append("AttachmentName=@in_AttachmentName,AttachmentPath=@in_AttachmentPath,Creator=@in_Creator,CreateTime=@in_CreateTime,IsDelete=@in_IsDelete,ContractID=@in_ContractID");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_AttachmentName", DbType.String, EmsModel.AttachmentName),dbHelper.CreateInDbParameter("@in_AttachmentPath", DbType.String, EmsModel.AttachmentPath),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_ContractID", DbType.Int32, EmsModel.ContractID)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.AttachmentInfo EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update AttachmentInfo set ");
					sbSql.Append("AttachmentName=@in_AttachmentName,AttachmentPath=@in_AttachmentPath,Creator=@in_Creator,CreateTime=@in_CreateTime,IsDelete=@in_IsDelete,ContractID=@in_ContractID");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_AttachmentName", DbType.String, EmsModel.AttachmentName),dbHelper.CreateInDbParameter("@in_AttachmentPath", DbType.String, EmsModel.AttachmentPath),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_ContractID", DbType.Int32, EmsModel.ContractID)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM AttachmentInfo");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM AttachmentInfo");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM AttachmentInfo");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.AttachmentInfo> GetListByPage(EmsModel.AttachmentInfo EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "AttachmentInfo";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.AttachmentName != null){strWhere += " and AttachmentName=@in_AttachmentName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AttachmentName", DbType.String, EmsMod.AttachmentName)); }if (EmsMod.AttachmentPath != null){strWhere += " and AttachmentPath=@in_AttachmentPath ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AttachmentPath", DbType.String, EmsMod.AttachmentPath)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.ContractID != null){strWhere += " and ContractID=@in_ContractID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ContractID", DbType.String, EmsMod.ContractID)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.AttachmentInfo> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.AttachmentInfo EmsMod)
        {
            string TableName = "AttachmentInfo";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.AttachmentName != null){strWhere += " and AttachmentName=@in_AttachmentName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AttachmentName", DbType.String, EmsMod.AttachmentName)); }if (EmsMod.AttachmentPath != null){strWhere += " and AttachmentPath=@in_AttachmentPath ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AttachmentPath", DbType.String, EmsMod.AttachmentPath)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.ContractID != null){strWhere += " and ContractID=@in_ContractID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ContractID", DbType.String, EmsMod.ContractID)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.AttachmentInfo EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.AttachmentName = dr["AttachmentName"] as string;EmsModel.AttachmentPath = dr["AttachmentPath"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.ContractID = dr["ContractID"] as int?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.AttachmentInfo> GetList(DataTable dt)
        {
            List<EmsModel.AttachmentInfo> lst = new List<EmsModel.AttachmentInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.AttachmentInfo mod = new EmsModel.AttachmentInfo();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.AttachmentInfo EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.AttachmentName = dr["AttachmentName"] as string;EmsModel.AttachmentPath = dr["AttachmentPath"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.ContractID = dr["ContractID"] as int?;
        }		

    }

	/// </summary>
	///	教学计划表实体类13
	/// </summary>
    public partial class Warehouse: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.Warehouse EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO Warehouse(");
						sbSql.Append("Name,Type,Remarks,PlaneGraph,Creator,CreateTime,Editor,UpdateTime,IsDelete,UseStatus)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_Type,@in_Remarks,@in_PlaneGraph,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_UseStatus)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_PlaneGraph", DbType.String, EmsModel.PlaneGraph),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.Warehouse EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO Warehouse(");
						sbSql.Append("Name,Type,Remarks,PlaneGraph,Creator,CreateTime,Editor,UpdateTime,IsDelete,UseStatus)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_Type,@in_Remarks,@in_PlaneGraph,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_UseStatus)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_PlaneGraph", DbType.String, EmsModel.PlaneGraph),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.Warehouse EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update Warehouse set ");
					sbSql.Append("Name=@in_Name,Type=@in_Type,Remarks=@in_Remarks,PlaneGraph=@in_PlaneGraph,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,UseStatus=@in_UseStatus");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_PlaneGraph", DbType.String, EmsModel.PlaneGraph),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.Warehouse EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update Warehouse set ");
					sbSql.Append("Name=@in_Name,Type=@in_Type,Remarks=@in_Remarks,PlaneGraph=@in_PlaneGraph,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,UseStatus=@in_UseStatus");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_PlaneGraph", DbType.String, EmsModel.PlaneGraph),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM Warehouse");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM Warehouse");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM Warehouse");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.Warehouse> GetListByPage(EmsModel.Warehouse EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "Warehouse";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.PlaneGraph != null){strWhere += " and PlaneGraph=@in_PlaneGraph ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PlaneGraph", DbType.String, EmsMod.PlaneGraph)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.Warehouse> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.Warehouse EmsMod)
        {
            string TableName = "Warehouse";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.PlaneGraph != null){strWhere += " and PlaneGraph=@in_PlaneGraph ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PlaneGraph", DbType.String, EmsMod.PlaneGraph)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.Warehouse EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.Type = dr["Type"] as Byte?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.PlaneGraph = dr["PlaneGraph"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.UseStatus = dr["UseStatus"] as Byte?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.Warehouse> GetList(DataTable dt)
        {
            List<EmsModel.Warehouse> lst = new List<EmsModel.Warehouse>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.Warehouse mod = new EmsModel.Warehouse();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.Warehouse EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.Type = dr["Type"] as Byte?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.PlaneGraph = dr["PlaneGraph"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.UseStatus = dr["UseStatus"] as Byte?;
        }		

    }

	/// </summary>
	///	教学计划表实体类14
	/// </summary>
    public partial class BorrowRecord: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.BorrowRecord EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO BorrowRecord(");
						sbSql.Append("BeginDate,EndDate,BorrowReason,Notes,BorrowStatus,IDCard)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_BeginDate,@in_EndDate,@in_BorrowReason,@in_Notes,@in_BorrowStatus,@in_IDCard)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_BeginDate", DbType.DateTime, EmsModel.BeginDate),dbHelper.CreateInDbParameter("@in_EndDate", DbType.DateTime, EmsModel.EndDate),dbHelper.CreateInDbParameter("@in_BorrowReason", DbType.String, EmsModel.BorrowReason),dbHelper.CreateInDbParameter("@in_Notes", DbType.String, EmsModel.Notes),dbHelper.CreateInDbParameter("@in_BorrowStatus", DbType.Int32, EmsModel.BorrowStatus),dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsModel.IDCard)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.BorrowRecord EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO BorrowRecord(");
						sbSql.Append("BeginDate,EndDate,BorrowReason,Notes,BorrowStatus,IDCard)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_BeginDate,@in_EndDate,@in_BorrowReason,@in_Notes,@in_BorrowStatus,@in_IDCard)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_BeginDate", DbType.DateTime, EmsModel.BeginDate),dbHelper.CreateInDbParameter("@in_EndDate", DbType.DateTime, EmsModel.EndDate),dbHelper.CreateInDbParameter("@in_BorrowReason", DbType.String, EmsModel.BorrowReason),dbHelper.CreateInDbParameter("@in_Notes", DbType.String, EmsModel.Notes),dbHelper.CreateInDbParameter("@in_BorrowStatus", DbType.Int32, EmsModel.BorrowStatus),dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsModel.IDCard)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.BorrowRecord EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update BorrowRecord set ");
					sbSql.Append("BeginDate=@in_BeginDate,EndDate=@in_EndDate,BorrowReason=@in_BorrowReason,Notes=@in_Notes,BorrowStatus=@in_BorrowStatus,IDCard=@in_IDCard");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_BeginDate", DbType.DateTime, EmsModel.BeginDate),dbHelper.CreateInDbParameter("@in_EndDate", DbType.DateTime, EmsModel.EndDate),dbHelper.CreateInDbParameter("@in_BorrowReason", DbType.String, EmsModel.BorrowReason),dbHelper.CreateInDbParameter("@in_Notes", DbType.String, EmsModel.Notes),dbHelper.CreateInDbParameter("@in_BorrowStatus", DbType.Int32, EmsModel.BorrowStatus),dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsModel.IDCard)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.BorrowRecord EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update BorrowRecord set ");
					sbSql.Append("BeginDate=@in_BeginDate,EndDate=@in_EndDate,BorrowReason=@in_BorrowReason,Notes=@in_Notes,BorrowStatus=@in_BorrowStatus,IDCard=@in_IDCard");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_BeginDate", DbType.DateTime, EmsModel.BeginDate),dbHelper.CreateInDbParameter("@in_EndDate", DbType.DateTime, EmsModel.EndDate),dbHelper.CreateInDbParameter("@in_BorrowReason", DbType.String, EmsModel.BorrowReason),dbHelper.CreateInDbParameter("@in_Notes", DbType.String, EmsModel.Notes),dbHelper.CreateInDbParameter("@in_BorrowStatus", DbType.Int32, EmsModel.BorrowStatus),dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsModel.IDCard)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM BorrowRecord");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM BorrowRecord");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM BorrowRecord");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.BorrowRecord> GetListByPage(EmsModel.BorrowRecord EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "BorrowRecord";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.BeginDate != null){strWhere += " and BeginDate=@in_BeginDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BeginDate", DbType.String, EmsMod.BeginDate)); }if (EmsMod.EndDate != null){strWhere += " and EndDate=@in_EndDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EndDate", DbType.String, EmsMod.EndDate)); }if (EmsMod.BorrowReason != null){strWhere += " and BorrowReason=@in_BorrowReason ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BorrowReason", DbType.String, EmsMod.BorrowReason)); }if (EmsMod.Notes != null){strWhere += " and Notes=@in_Notes ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Notes", DbType.String, EmsMod.Notes)); }if (EmsMod.BorrowStatus != null){strWhere += " and BorrowStatus=@in_BorrowStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BorrowStatus", DbType.String, EmsMod.BorrowStatus)); }if (EmsMod.IDCard != null){strWhere += " and IDCard=@in_IDCard ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsMod.IDCard)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.BorrowRecord> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.BorrowRecord EmsMod)
        {
            string TableName = "BorrowRecord";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.BeginDate != null){strWhere += " and BeginDate=@in_BeginDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BeginDate", DbType.String, EmsMod.BeginDate)); }if (EmsMod.EndDate != null){strWhere += " and EndDate=@in_EndDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EndDate", DbType.String, EmsMod.EndDate)); }if (EmsMod.BorrowReason != null){strWhere += " and BorrowReason=@in_BorrowReason ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BorrowReason", DbType.String, EmsMod.BorrowReason)); }if (EmsMod.Notes != null){strWhere += " and Notes=@in_Notes ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Notes", DbType.String, EmsMod.Notes)); }if (EmsMod.BorrowStatus != null){strWhere += " and BorrowStatus=@in_BorrowStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BorrowStatus", DbType.String, EmsMod.BorrowStatus)); }if (EmsMod.IDCard != null){strWhere += " and IDCard=@in_IDCard ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsMod.IDCard)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.BorrowRecord EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.BeginDate = dr["BeginDate"] as DateTime?;EmsModel.EndDate = dr["EndDate"] as DateTime?;EmsModel.BorrowReason = dr["BorrowReason"] as string;EmsModel.Notes = dr["Notes"] as string;EmsModel.BorrowStatus = dr["BorrowStatus"] as int?;EmsModel.IDCard = dr["IDCard"] as string;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.BorrowRecord> GetList(DataTable dt)
        {
            List<EmsModel.BorrowRecord> lst = new List<EmsModel.BorrowRecord>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.BorrowRecord mod = new EmsModel.BorrowRecord();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.BorrowRecord EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.BeginDate = dr["BeginDate"] as DateTime?;EmsModel.EndDate = dr["EndDate"] as DateTime?;EmsModel.BorrowReason = dr["BorrowReason"] as string;EmsModel.Notes = dr["Notes"] as string;EmsModel.BorrowStatus = dr["BorrowStatus"] as int?;EmsModel.IDCard = dr["IDCard"] as string;
        }		

    }

	/// </summary>
	///	教学计划表实体类15
	/// </summary>
    public partial class BorrowRecordDetail: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.BorrowRecordDetail EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO BorrowRecordDetail(");
						sbSql.Append("BorrowRecord,EquipDatailID)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_BorrowRecord,@in_EquipDatailID)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_BorrowRecord", DbType.Int32, EmsModel.BorrowRecord),dbHelper.CreateInDbParameter("@in_EquipDatailID", DbType.Int32, EmsModel.EquipDatailID)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.BorrowRecordDetail EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO BorrowRecordDetail(");
						sbSql.Append("BorrowRecord,EquipDatailID)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_BorrowRecord,@in_EquipDatailID)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_BorrowRecord", DbType.Int32, EmsModel.BorrowRecord),dbHelper.CreateInDbParameter("@in_EquipDatailID", DbType.Int32, EmsModel.EquipDatailID)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.BorrowRecordDetail EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update BorrowRecordDetail set ");
					sbSql.Append("BorrowRecord=@in_BorrowRecord,EquipDatailID=@in_EquipDatailID");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_BorrowRecord", DbType.Int32, EmsModel.BorrowRecord),dbHelper.CreateInDbParameter("@in_EquipDatailID", DbType.Int32, EmsModel.EquipDatailID)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.BorrowRecordDetail EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update BorrowRecordDetail set ");
					sbSql.Append("BorrowRecord=@in_BorrowRecord,EquipDatailID=@in_EquipDatailID");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_BorrowRecord", DbType.Int32, EmsModel.BorrowRecord),dbHelper.CreateInDbParameter("@in_EquipDatailID", DbType.Int32, EmsModel.EquipDatailID)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM BorrowRecordDetail");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM BorrowRecordDetail");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM BorrowRecordDetail");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.BorrowRecordDetail> GetListByPage(EmsModel.BorrowRecordDetail EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "BorrowRecordDetail";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.BorrowRecord != null){strWhere += " and BorrowRecord=@in_BorrowRecord ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BorrowRecord", DbType.String, EmsMod.BorrowRecord)); }if (EmsMod.EquipDatailID != null){strWhere += " and EquipDatailID=@in_EquipDatailID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipDatailID", DbType.String, EmsMod.EquipDatailID)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.BorrowRecordDetail> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.BorrowRecordDetail EmsMod)
        {
            string TableName = "BorrowRecordDetail";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.BorrowRecord != null){strWhere += " and BorrowRecord=@in_BorrowRecord ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BorrowRecord", DbType.String, EmsMod.BorrowRecord)); }if (EmsMod.EquipDatailID != null){strWhere += " and EquipDatailID=@in_EquipDatailID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipDatailID", DbType.String, EmsMod.EquipDatailID)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.BorrowRecordDetail EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.BorrowRecord = dr["BorrowRecord"] as int?;EmsModel.EquipDatailID = dr["EquipDatailID"] as int?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.BorrowRecordDetail> GetList(DataTable dt)
        {
            List<EmsModel.BorrowRecordDetail> lst = new List<EmsModel.BorrowRecordDetail>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.BorrowRecordDetail mod = new EmsModel.BorrowRecordDetail();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.BorrowRecordDetail EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.BorrowRecord = dr["BorrowRecord"] as int?;EmsModel.EquipDatailID = dr["EquipDatailID"] as int?;
        }		

    }

	/// </summary>
	///	教学计划表实体类16
	/// </summary>
    public partial class Building: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.Building EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO Building(");
						sbSql.Append("Name,PID,Creator,CreateTime,Editor,UpdateTime,IsDelete,Remarks,RoomNo,Type,SectionPlaceId)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_PID,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_Remarks,@in_RoomNo,@in_Type,@in_SectionPlaceId)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_PID", DbType.Int32, EmsModel.PID),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_RoomNo", DbType.String, EmsModel.RoomNo),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_SectionPlaceId", DbType.Int32, EmsModel.SectionPlaceId)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.Building EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO Building(");
						sbSql.Append("Name,PID,Creator,CreateTime,Editor,UpdateTime,IsDelete,Remarks,RoomNo,Type,SectionPlaceId)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_PID,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_Remarks,@in_RoomNo,@in_Type,@in_SectionPlaceId)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_PID", DbType.Int32, EmsModel.PID),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_RoomNo", DbType.String, EmsModel.RoomNo),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_SectionPlaceId", DbType.Int32, EmsModel.SectionPlaceId)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.Building EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update Building set ");
					sbSql.Append("Name=@in_Name,PID=@in_PID,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,Remarks=@in_Remarks,RoomNo=@in_RoomNo,Type=@in_Type,SectionPlaceId=@in_SectionPlaceId");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_PID", DbType.Int32, EmsModel.PID),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_RoomNo", DbType.String, EmsModel.RoomNo),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_SectionPlaceId", DbType.Int32, EmsModel.SectionPlaceId)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.Building EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update Building set ");
					sbSql.Append("Name=@in_Name,PID=@in_PID,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,Remarks=@in_Remarks,RoomNo=@in_RoomNo,Type=@in_Type,SectionPlaceId=@in_SectionPlaceId");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_PID", DbType.Int32, EmsModel.PID),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_RoomNo", DbType.String, EmsModel.RoomNo),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_SectionPlaceId", DbType.Int32, EmsModel.SectionPlaceId)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM Building");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM Building");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM Building");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.Building> GetListByPage(EmsModel.Building EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "Building";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.PID != null){strWhere += " and PID=@in_PID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PID", DbType.String, EmsMod.PID)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.RoomNo != null){strWhere += " and RoomNo=@in_RoomNo ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RoomNo", DbType.String, EmsMod.RoomNo)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.SectionPlaceId != null){strWhere += " and SectionPlaceId=@in_SectionPlaceId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_SectionPlaceId", DbType.String, EmsMod.SectionPlaceId)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.Building> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.Building EmsMod)
        {
            string TableName = "Building";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.PID != null){strWhere += " and PID=@in_PID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PID", DbType.String, EmsMod.PID)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.RoomNo != null){strWhere += " and RoomNo=@in_RoomNo ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RoomNo", DbType.String, EmsMod.RoomNo)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.SectionPlaceId != null){strWhere += " and SectionPlaceId=@in_SectionPlaceId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_SectionPlaceId", DbType.String, EmsMod.SectionPlaceId)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.Building EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.PID = dr["PID"] as int?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.RoomNo = dr["RoomNo"] as string;EmsModel.Type = dr["Type"] as Byte?;EmsModel.SectionPlaceId = dr["SectionPlaceId"] as int?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.Building> GetList(DataTable dt)
        {
            List<EmsModel.Building> lst = new List<EmsModel.Building>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.Building mod = new EmsModel.Building();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.Building EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.PID = dr["PID"] as int?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.RoomNo = dr["RoomNo"] as string;EmsModel.Type = dr["Type"] as Byte?;EmsModel.SectionPlaceId = dr["SectionPlaceId"] as int?;
        }		

    }

	/// </summary>
	///	教学计划表实体类17
	/// </summary>
    public partial class ClassInfo: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.ClassInfo EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO ClassInfo(");
						sbSql.Append("Name,Creator,CreateTime,Editor,UpdateTime,Remarks,UseStatus)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_Remarks,@in_UseStatus)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.ClassInfo EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO ClassInfo(");
						sbSql.Append("Name,Creator,CreateTime,Editor,UpdateTime,Remarks,UseStatus)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_Remarks,@in_UseStatus)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.ClassInfo EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update ClassInfo set ");
					sbSql.Append("Name=@in_Name,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,Remarks=@in_Remarks,UseStatus=@in_UseStatus");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.ClassInfo EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update ClassInfo set ");
					sbSql.Append("Name=@in_Name,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,Remarks=@in_Remarks,UseStatus=@in_UseStatus");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM ClassInfo");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM ClassInfo");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM ClassInfo");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.ClassInfo> GetListByPage(EmsModel.ClassInfo EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "ClassInfo";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.ClassInfo> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.ClassInfo EmsMod)
        {
            string TableName = "ClassInfo";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.ClassInfo EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.UseStatus = dr["UseStatus"] as Byte?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.ClassInfo> GetList(DataTable dt)
        {
            List<EmsModel.ClassInfo> lst = new List<EmsModel.ClassInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.ClassInfo mod = new EmsModel.ClassInfo();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.ClassInfo EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.UseStatus = dr["UseStatus"] as Byte?;
        }		

    }

	/// </summary>
	///	教学计划表实体类18
	/// </summary>
    public partial class ContractEquip: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.ContractEquip EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO ContractEquip(");
						sbSql.Append("ContractID,EquipDetailID,Creator,CreateTime,IsDelete)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_ContractID,@in_EquipDetailID,@in_Creator,@in_CreateTime,@in_IsDelete)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_ContractID", DbType.Int32, EmsModel.ContractID),dbHelper.CreateInDbParameter("@in_EquipDetailID", DbType.Int32, EmsModel.EquipDetailID),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.ContractEquip EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO ContractEquip(");
						sbSql.Append("ContractID,EquipDetailID,Creator,CreateTime,IsDelete)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_ContractID,@in_EquipDetailID,@in_Creator,@in_CreateTime,@in_IsDelete)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_ContractID", DbType.Int32, EmsModel.ContractID),dbHelper.CreateInDbParameter("@in_EquipDetailID", DbType.Int32, EmsModel.EquipDetailID),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.ContractEquip EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update ContractEquip set ");
					sbSql.Append("ContractID=@in_ContractID,EquipDetailID=@in_EquipDetailID,Creator=@in_Creator,CreateTime=@in_CreateTime,IsDelete=@in_IsDelete");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_ContractID", DbType.Int32, EmsModel.ContractID),dbHelper.CreateInDbParameter("@in_EquipDetailID", DbType.Int32, EmsModel.EquipDetailID),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.ContractEquip EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update ContractEquip set ");
					sbSql.Append("ContractID=@in_ContractID,EquipDetailID=@in_EquipDetailID,Creator=@in_Creator,CreateTime=@in_CreateTime,IsDelete=@in_IsDelete");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_ContractID", DbType.Int32, EmsModel.ContractID),dbHelper.CreateInDbParameter("@in_EquipDetailID", DbType.Int32, EmsModel.EquipDetailID),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM ContractEquip");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM ContractEquip");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM ContractEquip");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.ContractEquip> GetListByPage(EmsModel.ContractEquip EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "ContractEquip";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.ContractID != null){strWhere += " and ContractID=@in_ContractID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ContractID", DbType.String, EmsMod.ContractID)); }if (EmsMod.EquipDetailID != null){strWhere += " and EquipDetailID=@in_EquipDetailID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipDetailID", DbType.String, EmsMod.EquipDetailID)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.ContractEquip> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.ContractEquip EmsMod)
        {
            string TableName = "ContractEquip";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.ContractID != null){strWhere += " and ContractID=@in_ContractID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ContractID", DbType.String, EmsMod.ContractID)); }if (EmsMod.EquipDetailID != null){strWhere += " and EquipDetailID=@in_EquipDetailID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipDetailID", DbType.String, EmsMod.EquipDetailID)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.ContractEquip EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.ContractID = dr["ContractID"] as int?;EmsModel.EquipDetailID = dr["EquipDetailID"] as int?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.ContractEquip> GetList(DataTable dt)
        {
            List<EmsModel.ContractEquip> lst = new List<EmsModel.ContractEquip>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.ContractEquip mod = new EmsModel.ContractEquip();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.ContractEquip EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.ContractID = dr["ContractID"] as int?;EmsModel.EquipDetailID = dr["EquipDetailID"] as int?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;
        }		

    }

	/// </summary>
	///	教学计划表实体类19
	/// </summary>
    public partial class ContractInfo: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.ContractInfo EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO ContractInfo(");
						sbSql.Append("ContractName,ContractNumber,Description,Creator,CreateTime,IsDelete,PartyB,Money)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_ContractName,@in_ContractNumber,@in_Description,@in_Creator,@in_CreateTime,@in_IsDelete,@in_PartyB,@in_Money)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_ContractName", DbType.String, EmsModel.ContractName),dbHelper.CreateInDbParameter("@in_ContractNumber", DbType.String, EmsModel.ContractNumber),dbHelper.CreateInDbParameter("@in_Description", DbType.String, EmsModel.Description),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_PartyB", DbType.String, EmsModel.PartyB),dbHelper.CreateInDbParameter("@in_Money", DbType.Decimal, EmsModel.Money)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.ContractInfo EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO ContractInfo(");
						sbSql.Append("ContractName,ContractNumber,Description,Creator,CreateTime,IsDelete,PartyB,Money)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_ContractName,@in_ContractNumber,@in_Description,@in_Creator,@in_CreateTime,@in_IsDelete,@in_PartyB,@in_Money)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_ContractName", DbType.String, EmsModel.ContractName),dbHelper.CreateInDbParameter("@in_ContractNumber", DbType.String, EmsModel.ContractNumber),dbHelper.CreateInDbParameter("@in_Description", DbType.String, EmsModel.Description),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_PartyB", DbType.String, EmsModel.PartyB),dbHelper.CreateInDbParameter("@in_Money", DbType.Decimal, EmsModel.Money)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.ContractInfo EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update ContractInfo set ");
					sbSql.Append("ContractName=@in_ContractName,ContractNumber=@in_ContractNumber,Description=@in_Description,Creator=@in_Creator,CreateTime=@in_CreateTime,IsDelete=@in_IsDelete,PartyB=@in_PartyB,Money=@in_Money");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_ContractName", DbType.String, EmsModel.ContractName),dbHelper.CreateInDbParameter("@in_ContractNumber", DbType.String, EmsModel.ContractNumber),dbHelper.CreateInDbParameter("@in_Description", DbType.String, EmsModel.Description),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_PartyB", DbType.String, EmsModel.PartyB),dbHelper.CreateInDbParameter("@in_Money", DbType.Decimal, EmsModel.Money)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.ContractInfo EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update ContractInfo set ");
					sbSql.Append("ContractName=@in_ContractName,ContractNumber=@in_ContractNumber,Description=@in_Description,Creator=@in_Creator,CreateTime=@in_CreateTime,IsDelete=@in_IsDelete,PartyB=@in_PartyB,Money=@in_Money");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_ContractName", DbType.String, EmsModel.ContractName),dbHelper.CreateInDbParameter("@in_ContractNumber", DbType.String, EmsModel.ContractNumber),dbHelper.CreateInDbParameter("@in_Description", DbType.String, EmsModel.Description),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_PartyB", DbType.String, EmsModel.PartyB),dbHelper.CreateInDbParameter("@in_Money", DbType.Decimal, EmsModel.Money)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM ContractInfo");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM ContractInfo");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM ContractInfo");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.ContractInfo> GetListByPage(EmsModel.ContractInfo EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "ContractInfo";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.ContractName != null){strWhere += " and ContractName=@in_ContractName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ContractName", DbType.String, EmsMod.ContractName)); }if (EmsMod.ContractNumber != null){strWhere += " and ContractNumber=@in_ContractNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ContractNumber", DbType.String, EmsMod.ContractNumber)); }if (EmsMod.Description != null){strWhere += " and Description=@in_Description ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Description", DbType.String, EmsMod.Description)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.PartyB != null){strWhere += " and PartyB=@in_PartyB ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PartyB", DbType.String, EmsMod.PartyB)); }if (EmsMod.Money != null){strWhere += " and Money=@in_Money ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Money", DbType.String, EmsMod.Money)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.ContractInfo> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.ContractInfo EmsMod)
        {
            string TableName = "ContractInfo";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.ContractName != null){strWhere += " and ContractName=@in_ContractName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ContractName", DbType.String, EmsMod.ContractName)); }if (EmsMod.ContractNumber != null){strWhere += " and ContractNumber=@in_ContractNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ContractNumber", DbType.String, EmsMod.ContractNumber)); }if (EmsMod.Description != null){strWhere += " and Description=@in_Description ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Description", DbType.String, EmsMod.Description)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.PartyB != null){strWhere += " and PartyB=@in_PartyB ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PartyB", DbType.String, EmsMod.PartyB)); }if (EmsMod.Money != null){strWhere += " and Money=@in_Money ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Money", DbType.String, EmsMod.Money)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.ContractInfo EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.ContractName = dr["ContractName"] as string;EmsModel.ContractNumber = dr["ContractNumber"] as string;EmsModel.Description = dr["Description"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.PartyB = dr["PartyB"] as string;EmsModel.Money = dr["Money"] as decimal?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.ContractInfo> GetList(DataTable dt)
        {
            List<EmsModel.ContractInfo> lst = new List<EmsModel.ContractInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.ContractInfo mod = new EmsModel.ContractInfo();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.ContractInfo EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.ContractName = dr["ContractName"] as string;EmsModel.ContractNumber = dr["ContractNumber"] as string;EmsModel.Description = dr["Description"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.PartyB = dr["PartyB"] as string;EmsModel.Money = dr["Money"] as decimal?;
        }		

    }

	/// </summary>
	///	教学计划表实体类20
	/// </summary>
    public partial class Dictionary: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.Dictionary EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO Dictionary(");
						sbSql.Append("Name,PID,Path,Creator,CreateTime,Editor,UpdateTime,Remarks)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_PID,@in_Path,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_Remarks)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_PID", DbType.Int32, EmsModel.PID),dbHelper.CreateInDbParameter("@in_Path", DbType.String, EmsModel.Path),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.Dictionary EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO Dictionary(");
						sbSql.Append("Name,PID,Path,Creator,CreateTime,Editor,UpdateTime,Remarks)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_PID,@in_Path,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_Remarks)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_PID", DbType.Int32, EmsModel.PID),dbHelper.CreateInDbParameter("@in_Path", DbType.String, EmsModel.Path),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.Dictionary EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update Dictionary set ");
					sbSql.Append("Name=@in_Name,PID=@in_PID,Path=@in_Path,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,Remarks=@in_Remarks");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_PID", DbType.Int32, EmsModel.PID),dbHelper.CreateInDbParameter("@in_Path", DbType.String, EmsModel.Path),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.Dictionary EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update Dictionary set ");
					sbSql.Append("Name=@in_Name,PID=@in_PID,Path=@in_Path,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,Remarks=@in_Remarks");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_PID", DbType.Int32, EmsModel.PID),dbHelper.CreateInDbParameter("@in_Path", DbType.String, EmsModel.Path),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM Dictionary");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM Dictionary");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM Dictionary");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.Dictionary> GetListByPage(EmsModel.Dictionary EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "Dictionary";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.PID != null){strWhere += " and PID=@in_PID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PID", DbType.String, EmsMod.PID)); }if (EmsMod.Path != null){strWhere += " and Path=@in_Path ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Path", DbType.String, EmsMod.Path)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.Dictionary> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.Dictionary EmsMod)
        {
            string TableName = "Dictionary";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.PID != null){strWhere += " and PID=@in_PID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PID", DbType.String, EmsMod.PID)); }if (EmsMod.Path != null){strWhere += " and Path=@in_Path ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Path", DbType.String, EmsMod.Path)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.Dictionary EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.PID = dr["PID"] as int?;EmsModel.Path = dr["Path"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.Remarks = dr["Remarks"] as string;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.Dictionary> GetList(DataTable dt)
        {
            List<EmsModel.Dictionary> lst = new List<EmsModel.Dictionary>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.Dictionary mod = new EmsModel.Dictionary();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.Dictionary EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.PID = dr["PID"] as int?;EmsModel.Path = dr["Path"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.Remarks = dr["Remarks"] as string;
        }		

    }

	/// </summary>
	///	教学计划表实体类21
	/// </summary>
    public partial class EquipDetail: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.EquipDetail EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO EquipDetail(");
						sbSql.Append("EquipKindId,AssetNumber,EquipIntoID,EquipStatus,Type,Barcode,ImageName,Count,ClassNumber,AssetsClassName,IntlClassCode,IntlClassName,AssetName,Unit,UsageStatus,UsageDirection,JYBBBSYFX,AcquisitionMethod,AcquisitionDate,BrandStandardModel,EquipmentUse,UseDepartment,UsePeople,Factory,StorageLocation,WorthType,UseNature,Worth,FinanceRecordType,FiscalFunds,NonFiscalFunds,FinanceRecordDate,VoucherNumber,UseTime,ExpectedScrapDate,DepreciationState,NetWorth,OutFactoryNumber,Supplier,FundsSubject,PurchaseModality,CountryCode,Operator,GuaranteeEndDate,EquipmentNumber,InvoiceNumber,CompactNumber,BasicFunds,ItemFunds1,ItemFunds2,ItemFunds3,ItemFunds4,ItemFundsMoney1,ItemFundsMoney2,ItemFundsMoney3,ItemFundsMoney4,Remarks,Creator,CreateTime,Editor,UpdateTime,IsDelete,UseStatus,StorageLocation1,IsConsume,EquipSource,EquipOwner,ManualModify,ImageUrl,BorrowYN)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_EquipKindId,@in_AssetNumber,@in_EquipIntoID,@in_EquipStatus,@in_Type,@in_Barcode,@in_ImageName,@in_Count,@in_ClassNumber,@in_AssetsClassName,@in_IntlClassCode,@in_IntlClassName,@in_AssetName,@in_Unit,@in_UsageStatus,@in_UsageDirection,@in_JYBBBSYFX,@in_AcquisitionMethod,@in_AcquisitionDate,@in_BrandStandardModel,@in_EquipmentUse,@in_UseDepartment,@in_UsePeople,@in_Factory,@in_StorageLocation,@in_WorthType,@in_UseNature,@in_Worth,@in_FinanceRecordType,@in_FiscalFunds,@in_NonFiscalFunds,@in_FinanceRecordDate,@in_VoucherNumber,@in_UseTime,@in_ExpectedScrapDate,@in_DepreciationState,@in_NetWorth,@in_OutFactoryNumber,@in_Supplier,@in_FundsSubject,@in_PurchaseModality,@in_CountryCode,@in_Operator,@in_GuaranteeEndDate,@in_EquipmentNumber,@in_InvoiceNumber,@in_CompactNumber,@in_BasicFunds,@in_ItemFunds1,@in_ItemFunds2,@in_ItemFunds3,@in_ItemFunds4,@in_ItemFundsMoney1,@in_ItemFundsMoney2,@in_ItemFundsMoney3,@in_ItemFundsMoney4,@in_Remarks,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_UseStatus,@in_StorageLocation1,@in_IsConsume,@in_EquipSource,@in_EquipOwner,@in_ManualModify,@in_ImageUrl,@in_BorrowYN)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsModel.AssetNumber),dbHelper.CreateInDbParameter("@in_EquipIntoID", DbType.Int32, EmsModel.EquipIntoID),dbHelper.CreateInDbParameter("@in_EquipStatus", DbType.Int32, EmsModel.EquipStatus),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsModel.Barcode),dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsModel.ImageName),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_ClassNumber", DbType.String, EmsModel.ClassNumber),dbHelper.CreateInDbParameter("@in_AssetsClassName", DbType.String, EmsModel.AssetsClassName),dbHelper.CreateInDbParameter("@in_IntlClassCode", DbType.String, EmsModel.IntlClassCode),dbHelper.CreateInDbParameter("@in_IntlClassName", DbType.String, EmsModel.IntlClassName),dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsModel.AssetName),dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsModel.Unit),dbHelper.CreateInDbParameter("@in_UsageStatus", DbType.String, EmsModel.UsageStatus),dbHelper.CreateInDbParameter("@in_UsageDirection", DbType.String, EmsModel.UsageDirection),dbHelper.CreateInDbParameter("@in_JYBBBSYFX", DbType.String, EmsModel.JYBBBSYFX),dbHelper.CreateInDbParameter("@in_AcquisitionMethod", DbType.String, EmsModel.AcquisitionMethod),dbHelper.CreateInDbParameter("@in_AcquisitionDate", DbType.DateTime, EmsModel.AcquisitionDate),dbHelper.CreateInDbParameter("@in_BrandStandardModel", DbType.String, EmsModel.BrandStandardModel),dbHelper.CreateInDbParameter("@in_EquipmentUse", DbType.String, EmsModel.EquipmentUse),dbHelper.CreateInDbParameter("@in_UseDepartment", DbType.String, EmsModel.UseDepartment),dbHelper.CreateInDbParameter("@in_UsePeople", DbType.String, EmsModel.UsePeople),dbHelper.CreateInDbParameter("@in_Factory", DbType.String, EmsModel.Factory),dbHelper.CreateInDbParameter("@in_StorageLocation", DbType.String, EmsModel.StorageLocation),dbHelper.CreateInDbParameter("@in_WorthType", DbType.String, EmsModel.WorthType),dbHelper.CreateInDbParameter("@in_UseNature", DbType.String, EmsModel.UseNature),dbHelper.CreateInDbParameter("@in_Worth", DbType.Decimal, EmsModel.Worth),dbHelper.CreateInDbParameter("@in_FinanceRecordType", DbType.String, EmsModel.FinanceRecordType),dbHelper.CreateInDbParameter("@in_FiscalFunds", DbType.Decimal, EmsModel.FiscalFunds),dbHelper.CreateInDbParameter("@in_NonFiscalFunds", DbType.Decimal, EmsModel.NonFiscalFunds),dbHelper.CreateInDbParameter("@in_FinanceRecordDate", DbType.DateTime, EmsModel.FinanceRecordDate),dbHelper.CreateInDbParameter("@in_VoucherNumber", DbType.String, EmsModel.VoucherNumber),dbHelper.CreateInDbParameter("@in_UseTime", DbType.Int32, EmsModel.UseTime),dbHelper.CreateInDbParameter("@in_ExpectedScrapDate", DbType.DateTime, EmsModel.ExpectedScrapDate),dbHelper.CreateInDbParameter("@in_DepreciationState", DbType.String, EmsModel.DepreciationState),dbHelper.CreateInDbParameter("@in_NetWorth", DbType.Decimal, EmsModel.NetWorth),dbHelper.CreateInDbParameter("@in_OutFactoryNumber", DbType.String, EmsModel.OutFactoryNumber),dbHelper.CreateInDbParameter("@in_Supplier", DbType.String, EmsModel.Supplier),dbHelper.CreateInDbParameter("@in_FundsSubject", DbType.String, EmsModel.FundsSubject),dbHelper.CreateInDbParameter("@in_PurchaseModality", DbType.String, EmsModel.PurchaseModality),dbHelper.CreateInDbParameter("@in_CountryCode", DbType.String, EmsModel.CountryCode),dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsModel.Operator),dbHelper.CreateInDbParameter("@in_GuaranteeEndDate", DbType.DateTime, EmsModel.GuaranteeEndDate),dbHelper.CreateInDbParameter("@in_EquipmentNumber", DbType.String, EmsModel.EquipmentNumber),dbHelper.CreateInDbParameter("@in_InvoiceNumber", DbType.String, EmsModel.InvoiceNumber),dbHelper.CreateInDbParameter("@in_CompactNumber", DbType.String, EmsModel.CompactNumber),dbHelper.CreateInDbParameter("@in_BasicFunds", DbType.String, EmsModel.BasicFunds),dbHelper.CreateInDbParameter("@in_ItemFunds1", DbType.String, EmsModel.ItemFunds1),dbHelper.CreateInDbParameter("@in_ItemFunds2", DbType.String, EmsModel.ItemFunds2),dbHelper.CreateInDbParameter("@in_ItemFunds3", DbType.String, EmsModel.ItemFunds3),dbHelper.CreateInDbParameter("@in_ItemFunds4", DbType.String, EmsModel.ItemFunds4),dbHelper.CreateInDbParameter("@in_ItemFundsMoney1", DbType.Decimal, EmsModel.ItemFundsMoney1),dbHelper.CreateInDbParameter("@in_ItemFundsMoney2", DbType.Decimal, EmsModel.ItemFundsMoney2),dbHelper.CreateInDbParameter("@in_ItemFundsMoney3", DbType.Decimal, EmsModel.ItemFundsMoney3),dbHelper.CreateInDbParameter("@in_ItemFundsMoney4", DbType.Decimal, EmsModel.ItemFundsMoney4),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus),dbHelper.CreateInDbParameter("@in_StorageLocation1", DbType.String, EmsModel.StorageLocation1),dbHelper.CreateInDbParameter("@in_IsConsume", DbType.Byte, EmsModel.IsConsume),dbHelper.CreateInDbParameter("@in_EquipSource", DbType.Byte, EmsModel.EquipSource),dbHelper.CreateInDbParameter("@in_EquipOwner", DbType.String, EmsModel.EquipOwner),dbHelper.CreateInDbParameter("@in_ManualModify", DbType.Byte, EmsModel.ManualModify),dbHelper.CreateInDbParameter("@in_ImageUrl", DbType.String, EmsModel.ImageUrl),dbHelper.CreateInDbParameter("@in_BorrowYN", DbType.Byte, EmsModel.BorrowYN)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.EquipDetail EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO EquipDetail(");
						sbSql.Append("EquipKindId,AssetNumber,EquipIntoID,EquipStatus,Type,Barcode,ImageName,Count,ClassNumber,AssetsClassName,IntlClassCode,IntlClassName,AssetName,Unit,UsageStatus,UsageDirection,JYBBBSYFX,AcquisitionMethod,AcquisitionDate,BrandStandardModel,EquipmentUse,UseDepartment,UsePeople,Factory,StorageLocation,WorthType,UseNature,Worth,FinanceRecordType,FiscalFunds,NonFiscalFunds,FinanceRecordDate,VoucherNumber,UseTime,ExpectedScrapDate,DepreciationState,NetWorth,OutFactoryNumber,Supplier,FundsSubject,PurchaseModality,CountryCode,Operator,GuaranteeEndDate,EquipmentNumber,InvoiceNumber,CompactNumber,BasicFunds,ItemFunds1,ItemFunds2,ItemFunds3,ItemFunds4,ItemFundsMoney1,ItemFundsMoney2,ItemFundsMoney3,ItemFundsMoney4,Remarks,Creator,CreateTime,Editor,UpdateTime,IsDelete,UseStatus,StorageLocation1,IsConsume,EquipSource,EquipOwner,ManualModify,ImageUrl,BorrowYN)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_EquipKindId,@in_AssetNumber,@in_EquipIntoID,@in_EquipStatus,@in_Type,@in_Barcode,@in_ImageName,@in_Count,@in_ClassNumber,@in_AssetsClassName,@in_IntlClassCode,@in_IntlClassName,@in_AssetName,@in_Unit,@in_UsageStatus,@in_UsageDirection,@in_JYBBBSYFX,@in_AcquisitionMethod,@in_AcquisitionDate,@in_BrandStandardModel,@in_EquipmentUse,@in_UseDepartment,@in_UsePeople,@in_Factory,@in_StorageLocation,@in_WorthType,@in_UseNature,@in_Worth,@in_FinanceRecordType,@in_FiscalFunds,@in_NonFiscalFunds,@in_FinanceRecordDate,@in_VoucherNumber,@in_UseTime,@in_ExpectedScrapDate,@in_DepreciationState,@in_NetWorth,@in_OutFactoryNumber,@in_Supplier,@in_FundsSubject,@in_PurchaseModality,@in_CountryCode,@in_Operator,@in_GuaranteeEndDate,@in_EquipmentNumber,@in_InvoiceNumber,@in_CompactNumber,@in_BasicFunds,@in_ItemFunds1,@in_ItemFunds2,@in_ItemFunds3,@in_ItemFunds4,@in_ItemFundsMoney1,@in_ItemFundsMoney2,@in_ItemFundsMoney3,@in_ItemFundsMoney4,@in_Remarks,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_UseStatus,@in_StorageLocation1,@in_IsConsume,@in_EquipSource,@in_EquipOwner,@in_ManualModify,@in_ImageUrl,@in_BorrowYN)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsModel.AssetNumber),dbHelper.CreateInDbParameter("@in_EquipIntoID", DbType.Int32, EmsModel.EquipIntoID),dbHelper.CreateInDbParameter("@in_EquipStatus", DbType.Int32, EmsModel.EquipStatus),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsModel.Barcode),dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsModel.ImageName),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_ClassNumber", DbType.String, EmsModel.ClassNumber),dbHelper.CreateInDbParameter("@in_AssetsClassName", DbType.String, EmsModel.AssetsClassName),dbHelper.CreateInDbParameter("@in_IntlClassCode", DbType.String, EmsModel.IntlClassCode),dbHelper.CreateInDbParameter("@in_IntlClassName", DbType.String, EmsModel.IntlClassName),dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsModel.AssetName),dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsModel.Unit),dbHelper.CreateInDbParameter("@in_UsageStatus", DbType.String, EmsModel.UsageStatus),dbHelper.CreateInDbParameter("@in_UsageDirection", DbType.String, EmsModel.UsageDirection),dbHelper.CreateInDbParameter("@in_JYBBBSYFX", DbType.String, EmsModel.JYBBBSYFX),dbHelper.CreateInDbParameter("@in_AcquisitionMethod", DbType.String, EmsModel.AcquisitionMethod),dbHelper.CreateInDbParameter("@in_AcquisitionDate", DbType.DateTime, EmsModel.AcquisitionDate),dbHelper.CreateInDbParameter("@in_BrandStandardModel", DbType.String, EmsModel.BrandStandardModel),dbHelper.CreateInDbParameter("@in_EquipmentUse", DbType.String, EmsModel.EquipmentUse),dbHelper.CreateInDbParameter("@in_UseDepartment", DbType.String, EmsModel.UseDepartment),dbHelper.CreateInDbParameter("@in_UsePeople", DbType.String, EmsModel.UsePeople),dbHelper.CreateInDbParameter("@in_Factory", DbType.String, EmsModel.Factory),dbHelper.CreateInDbParameter("@in_StorageLocation", DbType.String, EmsModel.StorageLocation),dbHelper.CreateInDbParameter("@in_WorthType", DbType.String, EmsModel.WorthType),dbHelper.CreateInDbParameter("@in_UseNature", DbType.String, EmsModel.UseNature),dbHelper.CreateInDbParameter("@in_Worth", DbType.Decimal, EmsModel.Worth),dbHelper.CreateInDbParameter("@in_FinanceRecordType", DbType.String, EmsModel.FinanceRecordType),dbHelper.CreateInDbParameter("@in_FiscalFunds", DbType.Decimal, EmsModel.FiscalFunds),dbHelper.CreateInDbParameter("@in_NonFiscalFunds", DbType.Decimal, EmsModel.NonFiscalFunds),dbHelper.CreateInDbParameter("@in_FinanceRecordDate", DbType.DateTime, EmsModel.FinanceRecordDate),dbHelper.CreateInDbParameter("@in_VoucherNumber", DbType.String, EmsModel.VoucherNumber),dbHelper.CreateInDbParameter("@in_UseTime", DbType.Int32, EmsModel.UseTime),dbHelper.CreateInDbParameter("@in_ExpectedScrapDate", DbType.DateTime, EmsModel.ExpectedScrapDate),dbHelper.CreateInDbParameter("@in_DepreciationState", DbType.String, EmsModel.DepreciationState),dbHelper.CreateInDbParameter("@in_NetWorth", DbType.Decimal, EmsModel.NetWorth),dbHelper.CreateInDbParameter("@in_OutFactoryNumber", DbType.String, EmsModel.OutFactoryNumber),dbHelper.CreateInDbParameter("@in_Supplier", DbType.String, EmsModel.Supplier),dbHelper.CreateInDbParameter("@in_FundsSubject", DbType.String, EmsModel.FundsSubject),dbHelper.CreateInDbParameter("@in_PurchaseModality", DbType.String, EmsModel.PurchaseModality),dbHelper.CreateInDbParameter("@in_CountryCode", DbType.String, EmsModel.CountryCode),dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsModel.Operator),dbHelper.CreateInDbParameter("@in_GuaranteeEndDate", DbType.DateTime, EmsModel.GuaranteeEndDate),dbHelper.CreateInDbParameter("@in_EquipmentNumber", DbType.String, EmsModel.EquipmentNumber),dbHelper.CreateInDbParameter("@in_InvoiceNumber", DbType.String, EmsModel.InvoiceNumber),dbHelper.CreateInDbParameter("@in_CompactNumber", DbType.String, EmsModel.CompactNumber),dbHelper.CreateInDbParameter("@in_BasicFunds", DbType.String, EmsModel.BasicFunds),dbHelper.CreateInDbParameter("@in_ItemFunds1", DbType.String, EmsModel.ItemFunds1),dbHelper.CreateInDbParameter("@in_ItemFunds2", DbType.String, EmsModel.ItemFunds2),dbHelper.CreateInDbParameter("@in_ItemFunds3", DbType.String, EmsModel.ItemFunds3),dbHelper.CreateInDbParameter("@in_ItemFunds4", DbType.String, EmsModel.ItemFunds4),dbHelper.CreateInDbParameter("@in_ItemFundsMoney1", DbType.Decimal, EmsModel.ItemFundsMoney1),dbHelper.CreateInDbParameter("@in_ItemFundsMoney2", DbType.Decimal, EmsModel.ItemFundsMoney2),dbHelper.CreateInDbParameter("@in_ItemFundsMoney3", DbType.Decimal, EmsModel.ItemFundsMoney3),dbHelper.CreateInDbParameter("@in_ItemFundsMoney4", DbType.Decimal, EmsModel.ItemFundsMoney4),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus),dbHelper.CreateInDbParameter("@in_StorageLocation1", DbType.String, EmsModel.StorageLocation1),dbHelper.CreateInDbParameter("@in_IsConsume", DbType.Byte, EmsModel.IsConsume),dbHelper.CreateInDbParameter("@in_EquipSource", DbType.Byte, EmsModel.EquipSource),dbHelper.CreateInDbParameter("@in_EquipOwner", DbType.String, EmsModel.EquipOwner),dbHelper.CreateInDbParameter("@in_ManualModify", DbType.Byte, EmsModel.ManualModify),dbHelper.CreateInDbParameter("@in_ImageUrl", DbType.String, EmsModel.ImageUrl),dbHelper.CreateInDbParameter("@in_BorrowYN", DbType.Byte, EmsModel.BorrowYN)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.EquipDetail EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update EquipDetail set ");
					sbSql.Append("EquipKindId=@in_EquipKindId,AssetNumber=@in_AssetNumber,EquipIntoID=@in_EquipIntoID,EquipStatus=@in_EquipStatus,Type=@in_Type,Barcode=@in_Barcode,ImageName=@in_ImageName,Count=@in_Count,ClassNumber=@in_ClassNumber,AssetsClassName=@in_AssetsClassName,IntlClassCode=@in_IntlClassCode,IntlClassName=@in_IntlClassName,AssetName=@in_AssetName,Unit=@in_Unit,UsageStatus=@in_UsageStatus,UsageDirection=@in_UsageDirection,JYBBBSYFX=@in_JYBBBSYFX,AcquisitionMethod=@in_AcquisitionMethod,AcquisitionDate=@in_AcquisitionDate,BrandStandardModel=@in_BrandStandardModel,EquipmentUse=@in_EquipmentUse,UseDepartment=@in_UseDepartment,UsePeople=@in_UsePeople,Factory=@in_Factory,StorageLocation=@in_StorageLocation,WorthType=@in_WorthType,UseNature=@in_UseNature,Worth=@in_Worth,FinanceRecordType=@in_FinanceRecordType,FiscalFunds=@in_FiscalFunds,NonFiscalFunds=@in_NonFiscalFunds,FinanceRecordDate=@in_FinanceRecordDate,VoucherNumber=@in_VoucherNumber,UseTime=@in_UseTime,ExpectedScrapDate=@in_ExpectedScrapDate,DepreciationState=@in_DepreciationState,NetWorth=@in_NetWorth,OutFactoryNumber=@in_OutFactoryNumber,Supplier=@in_Supplier,FundsSubject=@in_FundsSubject,PurchaseModality=@in_PurchaseModality,CountryCode=@in_CountryCode,Operator=@in_Operator,GuaranteeEndDate=@in_GuaranteeEndDate,EquipmentNumber=@in_EquipmentNumber,InvoiceNumber=@in_InvoiceNumber,CompactNumber=@in_CompactNumber,BasicFunds=@in_BasicFunds,ItemFunds1=@in_ItemFunds1,ItemFunds2=@in_ItemFunds2,ItemFunds3=@in_ItemFunds3,ItemFunds4=@in_ItemFunds4,ItemFundsMoney1=@in_ItemFundsMoney1,ItemFundsMoney2=@in_ItemFundsMoney2,ItemFundsMoney3=@in_ItemFundsMoney3,ItemFundsMoney4=@in_ItemFundsMoney4,Remarks=@in_Remarks,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,UseStatus=@in_UseStatus,StorageLocation1=@in_StorageLocation1,IsConsume=@in_IsConsume,EquipSource=@in_EquipSource,EquipOwner=@in_EquipOwner,ManualModify=@in_ManualModify,ImageUrl=@in_ImageUrl,BorrowYN=@in_BorrowYN");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsModel.AssetNumber),dbHelper.CreateInDbParameter("@in_EquipIntoID", DbType.Int32, EmsModel.EquipIntoID),dbHelper.CreateInDbParameter("@in_EquipStatus", DbType.Int32, EmsModel.EquipStatus),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsModel.Barcode),dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsModel.ImageName),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_ClassNumber", DbType.String, EmsModel.ClassNumber),dbHelper.CreateInDbParameter("@in_AssetsClassName", DbType.String, EmsModel.AssetsClassName),dbHelper.CreateInDbParameter("@in_IntlClassCode", DbType.String, EmsModel.IntlClassCode),dbHelper.CreateInDbParameter("@in_IntlClassName", DbType.String, EmsModel.IntlClassName),dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsModel.AssetName),dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsModel.Unit),dbHelper.CreateInDbParameter("@in_UsageStatus", DbType.String, EmsModel.UsageStatus),dbHelper.CreateInDbParameter("@in_UsageDirection", DbType.String, EmsModel.UsageDirection),dbHelper.CreateInDbParameter("@in_JYBBBSYFX", DbType.String, EmsModel.JYBBBSYFX),dbHelper.CreateInDbParameter("@in_AcquisitionMethod", DbType.String, EmsModel.AcquisitionMethod),dbHelper.CreateInDbParameter("@in_AcquisitionDate", DbType.DateTime, EmsModel.AcquisitionDate),dbHelper.CreateInDbParameter("@in_BrandStandardModel", DbType.String, EmsModel.BrandStandardModel),dbHelper.CreateInDbParameter("@in_EquipmentUse", DbType.String, EmsModel.EquipmentUse),dbHelper.CreateInDbParameter("@in_UseDepartment", DbType.String, EmsModel.UseDepartment),dbHelper.CreateInDbParameter("@in_UsePeople", DbType.String, EmsModel.UsePeople),dbHelper.CreateInDbParameter("@in_Factory", DbType.String, EmsModel.Factory),dbHelper.CreateInDbParameter("@in_StorageLocation", DbType.String, EmsModel.StorageLocation),dbHelper.CreateInDbParameter("@in_WorthType", DbType.String, EmsModel.WorthType),dbHelper.CreateInDbParameter("@in_UseNature", DbType.String, EmsModel.UseNature),dbHelper.CreateInDbParameter("@in_Worth", DbType.Decimal, EmsModel.Worth),dbHelper.CreateInDbParameter("@in_FinanceRecordType", DbType.String, EmsModel.FinanceRecordType),dbHelper.CreateInDbParameter("@in_FiscalFunds", DbType.Decimal, EmsModel.FiscalFunds),dbHelper.CreateInDbParameter("@in_NonFiscalFunds", DbType.Decimal, EmsModel.NonFiscalFunds),dbHelper.CreateInDbParameter("@in_FinanceRecordDate", DbType.DateTime, EmsModel.FinanceRecordDate),dbHelper.CreateInDbParameter("@in_VoucherNumber", DbType.String, EmsModel.VoucherNumber),dbHelper.CreateInDbParameter("@in_UseTime", DbType.Int32, EmsModel.UseTime),dbHelper.CreateInDbParameter("@in_ExpectedScrapDate", DbType.DateTime, EmsModel.ExpectedScrapDate),dbHelper.CreateInDbParameter("@in_DepreciationState", DbType.String, EmsModel.DepreciationState),dbHelper.CreateInDbParameter("@in_NetWorth", DbType.Decimal, EmsModel.NetWorth),dbHelper.CreateInDbParameter("@in_OutFactoryNumber", DbType.String, EmsModel.OutFactoryNumber),dbHelper.CreateInDbParameter("@in_Supplier", DbType.String, EmsModel.Supplier),dbHelper.CreateInDbParameter("@in_FundsSubject", DbType.String, EmsModel.FundsSubject),dbHelper.CreateInDbParameter("@in_PurchaseModality", DbType.String, EmsModel.PurchaseModality),dbHelper.CreateInDbParameter("@in_CountryCode", DbType.String, EmsModel.CountryCode),dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsModel.Operator),dbHelper.CreateInDbParameter("@in_GuaranteeEndDate", DbType.DateTime, EmsModel.GuaranteeEndDate),dbHelper.CreateInDbParameter("@in_EquipmentNumber", DbType.String, EmsModel.EquipmentNumber),dbHelper.CreateInDbParameter("@in_InvoiceNumber", DbType.String, EmsModel.InvoiceNumber),dbHelper.CreateInDbParameter("@in_CompactNumber", DbType.String, EmsModel.CompactNumber),dbHelper.CreateInDbParameter("@in_BasicFunds", DbType.String, EmsModel.BasicFunds),dbHelper.CreateInDbParameter("@in_ItemFunds1", DbType.String, EmsModel.ItemFunds1),dbHelper.CreateInDbParameter("@in_ItemFunds2", DbType.String, EmsModel.ItemFunds2),dbHelper.CreateInDbParameter("@in_ItemFunds3", DbType.String, EmsModel.ItemFunds3),dbHelper.CreateInDbParameter("@in_ItemFunds4", DbType.String, EmsModel.ItemFunds4),dbHelper.CreateInDbParameter("@in_ItemFundsMoney1", DbType.Decimal, EmsModel.ItemFundsMoney1),dbHelper.CreateInDbParameter("@in_ItemFundsMoney2", DbType.Decimal, EmsModel.ItemFundsMoney2),dbHelper.CreateInDbParameter("@in_ItemFundsMoney3", DbType.Decimal, EmsModel.ItemFundsMoney3),dbHelper.CreateInDbParameter("@in_ItemFundsMoney4", DbType.Decimal, EmsModel.ItemFundsMoney4),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus),dbHelper.CreateInDbParameter("@in_StorageLocation1", DbType.String, EmsModel.StorageLocation1),dbHelper.CreateInDbParameter("@in_IsConsume", DbType.Byte, EmsModel.IsConsume),dbHelper.CreateInDbParameter("@in_EquipSource", DbType.Byte, EmsModel.EquipSource),dbHelper.CreateInDbParameter("@in_EquipOwner", DbType.String, EmsModel.EquipOwner),dbHelper.CreateInDbParameter("@in_ManualModify", DbType.Byte, EmsModel.ManualModify),dbHelper.CreateInDbParameter("@in_ImageUrl", DbType.String, EmsModel.ImageUrl),dbHelper.CreateInDbParameter("@in_BorrowYN", DbType.Byte, EmsModel.BorrowYN)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.EquipDetail EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update EquipDetail set ");
					sbSql.Append("EquipKindId=@in_EquipKindId,AssetNumber=@in_AssetNumber,EquipIntoID=@in_EquipIntoID,EquipStatus=@in_EquipStatus,Type=@in_Type,Barcode=@in_Barcode,ImageName=@in_ImageName,Count=@in_Count,ClassNumber=@in_ClassNumber,AssetsClassName=@in_AssetsClassName,IntlClassCode=@in_IntlClassCode,IntlClassName=@in_IntlClassName,AssetName=@in_AssetName,Unit=@in_Unit,UsageStatus=@in_UsageStatus,UsageDirection=@in_UsageDirection,JYBBBSYFX=@in_JYBBBSYFX,AcquisitionMethod=@in_AcquisitionMethod,AcquisitionDate=@in_AcquisitionDate,BrandStandardModel=@in_BrandStandardModel,EquipmentUse=@in_EquipmentUse,UseDepartment=@in_UseDepartment,UsePeople=@in_UsePeople,Factory=@in_Factory,StorageLocation=@in_StorageLocation,WorthType=@in_WorthType,UseNature=@in_UseNature,Worth=@in_Worth,FinanceRecordType=@in_FinanceRecordType,FiscalFunds=@in_FiscalFunds,NonFiscalFunds=@in_NonFiscalFunds,FinanceRecordDate=@in_FinanceRecordDate,VoucherNumber=@in_VoucherNumber,UseTime=@in_UseTime,ExpectedScrapDate=@in_ExpectedScrapDate,DepreciationState=@in_DepreciationState,NetWorth=@in_NetWorth,OutFactoryNumber=@in_OutFactoryNumber,Supplier=@in_Supplier,FundsSubject=@in_FundsSubject,PurchaseModality=@in_PurchaseModality,CountryCode=@in_CountryCode,Operator=@in_Operator,GuaranteeEndDate=@in_GuaranteeEndDate,EquipmentNumber=@in_EquipmentNumber,InvoiceNumber=@in_InvoiceNumber,CompactNumber=@in_CompactNumber,BasicFunds=@in_BasicFunds,ItemFunds1=@in_ItemFunds1,ItemFunds2=@in_ItemFunds2,ItemFunds3=@in_ItemFunds3,ItemFunds4=@in_ItemFunds4,ItemFundsMoney1=@in_ItemFundsMoney1,ItemFundsMoney2=@in_ItemFundsMoney2,ItemFundsMoney3=@in_ItemFundsMoney3,ItemFundsMoney4=@in_ItemFundsMoney4,Remarks=@in_Remarks,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,UseStatus=@in_UseStatus,StorageLocation1=@in_StorageLocation1,IsConsume=@in_IsConsume,EquipSource=@in_EquipSource,EquipOwner=@in_EquipOwner,ManualModify=@in_ManualModify,ImageUrl=@in_ImageUrl,BorrowYN=@in_BorrowYN");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsModel.AssetNumber),dbHelper.CreateInDbParameter("@in_EquipIntoID", DbType.Int32, EmsModel.EquipIntoID),dbHelper.CreateInDbParameter("@in_EquipStatus", DbType.Int32, EmsModel.EquipStatus),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsModel.Barcode),dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsModel.ImageName),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_ClassNumber", DbType.String, EmsModel.ClassNumber),dbHelper.CreateInDbParameter("@in_AssetsClassName", DbType.String, EmsModel.AssetsClassName),dbHelper.CreateInDbParameter("@in_IntlClassCode", DbType.String, EmsModel.IntlClassCode),dbHelper.CreateInDbParameter("@in_IntlClassName", DbType.String, EmsModel.IntlClassName),dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsModel.AssetName),dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsModel.Unit),dbHelper.CreateInDbParameter("@in_UsageStatus", DbType.String, EmsModel.UsageStatus),dbHelper.CreateInDbParameter("@in_UsageDirection", DbType.String, EmsModel.UsageDirection),dbHelper.CreateInDbParameter("@in_JYBBBSYFX", DbType.String, EmsModel.JYBBBSYFX),dbHelper.CreateInDbParameter("@in_AcquisitionMethod", DbType.String, EmsModel.AcquisitionMethod),dbHelper.CreateInDbParameter("@in_AcquisitionDate", DbType.DateTime, EmsModel.AcquisitionDate),dbHelper.CreateInDbParameter("@in_BrandStandardModel", DbType.String, EmsModel.BrandStandardModel),dbHelper.CreateInDbParameter("@in_EquipmentUse", DbType.String, EmsModel.EquipmentUse),dbHelper.CreateInDbParameter("@in_UseDepartment", DbType.String, EmsModel.UseDepartment),dbHelper.CreateInDbParameter("@in_UsePeople", DbType.String, EmsModel.UsePeople),dbHelper.CreateInDbParameter("@in_Factory", DbType.String, EmsModel.Factory),dbHelper.CreateInDbParameter("@in_StorageLocation", DbType.String, EmsModel.StorageLocation),dbHelper.CreateInDbParameter("@in_WorthType", DbType.String, EmsModel.WorthType),dbHelper.CreateInDbParameter("@in_UseNature", DbType.String, EmsModel.UseNature),dbHelper.CreateInDbParameter("@in_Worth", DbType.Decimal, EmsModel.Worth),dbHelper.CreateInDbParameter("@in_FinanceRecordType", DbType.String, EmsModel.FinanceRecordType),dbHelper.CreateInDbParameter("@in_FiscalFunds", DbType.Decimal, EmsModel.FiscalFunds),dbHelper.CreateInDbParameter("@in_NonFiscalFunds", DbType.Decimal, EmsModel.NonFiscalFunds),dbHelper.CreateInDbParameter("@in_FinanceRecordDate", DbType.DateTime, EmsModel.FinanceRecordDate),dbHelper.CreateInDbParameter("@in_VoucherNumber", DbType.String, EmsModel.VoucherNumber),dbHelper.CreateInDbParameter("@in_UseTime", DbType.Int32, EmsModel.UseTime),dbHelper.CreateInDbParameter("@in_ExpectedScrapDate", DbType.DateTime, EmsModel.ExpectedScrapDate),dbHelper.CreateInDbParameter("@in_DepreciationState", DbType.String, EmsModel.DepreciationState),dbHelper.CreateInDbParameter("@in_NetWorth", DbType.Decimal, EmsModel.NetWorth),dbHelper.CreateInDbParameter("@in_OutFactoryNumber", DbType.String, EmsModel.OutFactoryNumber),dbHelper.CreateInDbParameter("@in_Supplier", DbType.String, EmsModel.Supplier),dbHelper.CreateInDbParameter("@in_FundsSubject", DbType.String, EmsModel.FundsSubject),dbHelper.CreateInDbParameter("@in_PurchaseModality", DbType.String, EmsModel.PurchaseModality),dbHelper.CreateInDbParameter("@in_CountryCode", DbType.String, EmsModel.CountryCode),dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsModel.Operator),dbHelper.CreateInDbParameter("@in_GuaranteeEndDate", DbType.DateTime, EmsModel.GuaranteeEndDate),dbHelper.CreateInDbParameter("@in_EquipmentNumber", DbType.String, EmsModel.EquipmentNumber),dbHelper.CreateInDbParameter("@in_InvoiceNumber", DbType.String, EmsModel.InvoiceNumber),dbHelper.CreateInDbParameter("@in_CompactNumber", DbType.String, EmsModel.CompactNumber),dbHelper.CreateInDbParameter("@in_BasicFunds", DbType.String, EmsModel.BasicFunds),dbHelper.CreateInDbParameter("@in_ItemFunds1", DbType.String, EmsModel.ItemFunds1),dbHelper.CreateInDbParameter("@in_ItemFunds2", DbType.String, EmsModel.ItemFunds2),dbHelper.CreateInDbParameter("@in_ItemFunds3", DbType.String, EmsModel.ItemFunds3),dbHelper.CreateInDbParameter("@in_ItemFunds4", DbType.String, EmsModel.ItemFunds4),dbHelper.CreateInDbParameter("@in_ItemFundsMoney1", DbType.Decimal, EmsModel.ItemFundsMoney1),dbHelper.CreateInDbParameter("@in_ItemFundsMoney2", DbType.Decimal, EmsModel.ItemFundsMoney2),dbHelper.CreateInDbParameter("@in_ItemFundsMoney3", DbType.Decimal, EmsModel.ItemFundsMoney3),dbHelper.CreateInDbParameter("@in_ItemFundsMoney4", DbType.Decimal, EmsModel.ItemFundsMoney4),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus),dbHelper.CreateInDbParameter("@in_StorageLocation1", DbType.String, EmsModel.StorageLocation1),dbHelper.CreateInDbParameter("@in_IsConsume", DbType.Byte, EmsModel.IsConsume),dbHelper.CreateInDbParameter("@in_EquipSource", DbType.Byte, EmsModel.EquipSource),dbHelper.CreateInDbParameter("@in_EquipOwner", DbType.String, EmsModel.EquipOwner),dbHelper.CreateInDbParameter("@in_ManualModify", DbType.Byte, EmsModel.ManualModify),dbHelper.CreateInDbParameter("@in_ImageUrl", DbType.String, EmsModel.ImageUrl),dbHelper.CreateInDbParameter("@in_BorrowYN", DbType.Byte, EmsModel.BorrowYN)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM EquipDetail");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM EquipDetail");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM EquipDetail");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.EquipDetail> GetListByPage(EmsModel.EquipDetail EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "EquipDetail";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.EquipKindId != null){strWhere += " and EquipKindId=@in_EquipKindId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.String, EmsMod.EquipKindId)); }if (EmsMod.AssetNumber != null){strWhere += " and AssetNumber=@in_AssetNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsMod.AssetNumber)); }if (EmsMod.EquipIntoID != null){strWhere += " and EquipIntoID=@in_EquipIntoID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipIntoID", DbType.String, EmsMod.EquipIntoID)); }if (EmsMod.EquipStatus != null){strWhere += " and EquipStatus=@in_EquipStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipStatus", DbType.String, EmsMod.EquipStatus)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.Barcode != null){strWhere += " and Barcode=@in_Barcode ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsMod.Barcode)); }if (EmsMod.ImageName != null){strWhere += " and ImageName=@in_ImageName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsMod.ImageName)); }if (EmsMod.Count != null){strWhere += " and Count=@in_Count ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Count", DbType.String, EmsMod.Count)); }if (EmsMod.ClassNumber != null){strWhere += " and ClassNumber=@in_ClassNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ClassNumber", DbType.String, EmsMod.ClassNumber)); }if (EmsMod.AssetsClassName != null){strWhere += " and AssetsClassName=@in_AssetsClassName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetsClassName", DbType.String, EmsMod.AssetsClassName)); }if (EmsMod.IntlClassCode != null){strWhere += " and IntlClassCode=@in_IntlClassCode ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IntlClassCode", DbType.String, EmsMod.IntlClassCode)); }if (EmsMod.IntlClassName != null){strWhere += " and IntlClassName=@in_IntlClassName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IntlClassName", DbType.String, EmsMod.IntlClassName)); }if (EmsMod.AssetName != null){strWhere += " and AssetName=@in_AssetName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsMod.AssetName)); }if (EmsMod.Unit != null){strWhere += " and Unit=@in_Unit ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsMod.Unit)); }if (EmsMod.UsageStatus != null){strWhere += " and UsageStatus=@in_UsageStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UsageStatus", DbType.String, EmsMod.UsageStatus)); }if (EmsMod.UsageDirection != null){strWhere += " and UsageDirection=@in_UsageDirection ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UsageDirection", DbType.String, EmsMod.UsageDirection)); }if (EmsMod.JYBBBSYFX != null){strWhere += " and JYBBBSYFX=@in_JYBBBSYFX ";parmsList.Add(dbHelper.CreateInDbParameter("@in_JYBBBSYFX", DbType.String, EmsMod.JYBBBSYFX)); }if (EmsMod.AcquisitionMethod != null){strWhere += " and AcquisitionMethod=@in_AcquisitionMethod ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AcquisitionMethod", DbType.String, EmsMod.AcquisitionMethod)); }if (EmsMod.AcquisitionDate != null){strWhere += " and AcquisitionDate=@in_AcquisitionDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AcquisitionDate", DbType.String, EmsMod.AcquisitionDate)); }if (EmsMod.BrandStandardModel != null){strWhere += " and BrandStandardModel=@in_BrandStandardModel ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BrandStandardModel", DbType.String, EmsMod.BrandStandardModel)); }if (EmsMod.EquipmentUse != null){strWhere += " and EquipmentUse=@in_EquipmentUse ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipmentUse", DbType.String, EmsMod.EquipmentUse)); }if (EmsMod.UseDepartment != null){strWhere += " and UseDepartment=@in_UseDepartment ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseDepartment", DbType.String, EmsMod.UseDepartment)); }if (EmsMod.UsePeople != null){strWhere += " and UsePeople=@in_UsePeople ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UsePeople", DbType.String, EmsMod.UsePeople)); }if (EmsMod.Factory != null){strWhere += " and Factory=@in_Factory ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Factory", DbType.String, EmsMod.Factory)); }if (EmsMod.StorageLocation != null){strWhere += " and StorageLocation=@in_StorageLocation ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StorageLocation", DbType.String, EmsMod.StorageLocation)); }if (EmsMod.WorthType != null){strWhere += " and WorthType=@in_WorthType ";parmsList.Add(dbHelper.CreateInDbParameter("@in_WorthType", DbType.String, EmsMod.WorthType)); }if (EmsMod.UseNature != null){strWhere += " and UseNature=@in_UseNature ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseNature", DbType.String, EmsMod.UseNature)); }if (EmsMod.Worth != null){strWhere += " and Worth=@in_Worth ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Worth", DbType.String, EmsMod.Worth)); }if (EmsMod.FinanceRecordType != null){strWhere += " and FinanceRecordType=@in_FinanceRecordType ";parmsList.Add(dbHelper.CreateInDbParameter("@in_FinanceRecordType", DbType.String, EmsMod.FinanceRecordType)); }if (EmsMod.FiscalFunds != null){strWhere += " and FiscalFunds=@in_FiscalFunds ";parmsList.Add(dbHelper.CreateInDbParameter("@in_FiscalFunds", DbType.String, EmsMod.FiscalFunds)); }if (EmsMod.NonFiscalFunds != null){strWhere += " and NonFiscalFunds=@in_NonFiscalFunds ";parmsList.Add(dbHelper.CreateInDbParameter("@in_NonFiscalFunds", DbType.String, EmsMod.NonFiscalFunds)); }if (EmsMod.FinanceRecordDate != null){strWhere += " and FinanceRecordDate=@in_FinanceRecordDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_FinanceRecordDate", DbType.String, EmsMod.FinanceRecordDate)); }if (EmsMod.VoucherNumber != null){strWhere += " and VoucherNumber=@in_VoucherNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_VoucherNumber", DbType.String, EmsMod.VoucherNumber)); }if (EmsMod.UseTime != null){strWhere += " and UseTime=@in_UseTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseTime", DbType.String, EmsMod.UseTime)); }if (EmsMod.ExpectedScrapDate != null){strWhere += " and ExpectedScrapDate=@in_ExpectedScrapDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ExpectedScrapDate", DbType.String, EmsMod.ExpectedScrapDate)); }if (EmsMod.DepreciationState != null){strWhere += " and DepreciationState=@in_DepreciationState ";parmsList.Add(dbHelper.CreateInDbParameter("@in_DepreciationState", DbType.String, EmsMod.DepreciationState)); }if (EmsMod.NetWorth != null){strWhere += " and NetWorth=@in_NetWorth ";parmsList.Add(dbHelper.CreateInDbParameter("@in_NetWorth", DbType.String, EmsMod.NetWorth)); }if (EmsMod.OutFactoryNumber != null){strWhere += " and OutFactoryNumber=@in_OutFactoryNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_OutFactoryNumber", DbType.String, EmsMod.OutFactoryNumber)); }if (EmsMod.Supplier != null){strWhere += " and Supplier=@in_Supplier ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Supplier", DbType.String, EmsMod.Supplier)); }if (EmsMod.FundsSubject != null){strWhere += " and FundsSubject=@in_FundsSubject ";parmsList.Add(dbHelper.CreateInDbParameter("@in_FundsSubject", DbType.String, EmsMod.FundsSubject)); }if (EmsMod.PurchaseModality != null){strWhere += " and PurchaseModality=@in_PurchaseModality ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PurchaseModality", DbType.String, EmsMod.PurchaseModality)); }if (EmsMod.CountryCode != null){strWhere += " and CountryCode=@in_CountryCode ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CountryCode", DbType.String, EmsMod.CountryCode)); }if (EmsMod.Operator != null){strWhere += " and Operator=@in_Operator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsMod.Operator)); }if (EmsMod.GuaranteeEndDate != null){strWhere += " and GuaranteeEndDate=@in_GuaranteeEndDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_GuaranteeEndDate", DbType.String, EmsMod.GuaranteeEndDate)); }if (EmsMod.EquipmentNumber != null){strWhere += " and EquipmentNumber=@in_EquipmentNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipmentNumber", DbType.String, EmsMod.EquipmentNumber)); }if (EmsMod.InvoiceNumber != null){strWhere += " and InvoiceNumber=@in_InvoiceNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InvoiceNumber", DbType.String, EmsMod.InvoiceNumber)); }if (EmsMod.CompactNumber != null){strWhere += " and CompactNumber=@in_CompactNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CompactNumber", DbType.String, EmsMod.CompactNumber)); }if (EmsMod.BasicFunds != null){strWhere += " and BasicFunds=@in_BasicFunds ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BasicFunds", DbType.String, EmsMod.BasicFunds)); }if (EmsMod.ItemFunds1 != null){strWhere += " and ItemFunds1=@in_ItemFunds1 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFunds1", DbType.String, EmsMod.ItemFunds1)); }if (EmsMod.ItemFunds2 != null){strWhere += " and ItemFunds2=@in_ItemFunds2 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFunds2", DbType.String, EmsMod.ItemFunds2)); }if (EmsMod.ItemFunds3 != null){strWhere += " and ItemFunds3=@in_ItemFunds3 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFunds3", DbType.String, EmsMod.ItemFunds3)); }if (EmsMod.ItemFunds4 != null){strWhere += " and ItemFunds4=@in_ItemFunds4 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFunds4", DbType.String, EmsMod.ItemFunds4)); }if (EmsMod.ItemFundsMoney1 != null){strWhere += " and ItemFundsMoney1=@in_ItemFundsMoney1 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFundsMoney1", DbType.String, EmsMod.ItemFundsMoney1)); }if (EmsMod.ItemFundsMoney2 != null){strWhere += " and ItemFundsMoney2=@in_ItemFundsMoney2 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFundsMoney2", DbType.String, EmsMod.ItemFundsMoney2)); }if (EmsMod.ItemFundsMoney3 != null){strWhere += " and ItemFundsMoney3=@in_ItemFundsMoney3 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFundsMoney3", DbType.String, EmsMod.ItemFundsMoney3)); }if (EmsMod.ItemFundsMoney4 != null){strWhere += " and ItemFundsMoney4=@in_ItemFundsMoney4 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFundsMoney4", DbType.String, EmsMod.ItemFundsMoney4)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }if (EmsMod.StorageLocation1 != null){strWhere += " and StorageLocation1=@in_StorageLocation1 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StorageLocation1", DbType.String, EmsMod.StorageLocation1)); }if (EmsMod.IsConsume != null){strWhere += " and IsConsume=@in_IsConsume ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsConsume", DbType.String, EmsMod.IsConsume)); }if (EmsMod.EquipSource != null){strWhere += " and EquipSource=@in_EquipSource ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipSource", DbType.String, EmsMod.EquipSource)); }if (EmsMod.EquipOwner != null){strWhere += " and EquipOwner=@in_EquipOwner ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipOwner", DbType.String, EmsMod.EquipOwner)); }if (EmsMod.ManualModify != null){strWhere += " and ManualModify=@in_ManualModify ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ManualModify", DbType.String, EmsMod.ManualModify)); }if (EmsMod.ImageUrl != null){strWhere += " and ImageUrl=@in_ImageUrl ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ImageUrl", DbType.String, EmsMod.ImageUrl)); }if (EmsMod.BorrowYN != null){strWhere += " and BorrowYN=@in_BorrowYN ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BorrowYN", DbType.String, EmsMod.BorrowYN)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.EquipDetail> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.EquipDetail EmsMod)
        {
            string TableName = "EquipDetail";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.EquipKindId != null){strWhere += " and EquipKindId=@in_EquipKindId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.String, EmsMod.EquipKindId)); }if (EmsMod.AssetNumber != null){strWhere += " and AssetNumber=@in_AssetNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsMod.AssetNumber)); }if (EmsMod.EquipIntoID != null){strWhere += " and EquipIntoID=@in_EquipIntoID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipIntoID", DbType.String, EmsMod.EquipIntoID)); }if (EmsMod.EquipStatus != null){strWhere += " and EquipStatus=@in_EquipStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipStatus", DbType.String, EmsMod.EquipStatus)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.Barcode != null){strWhere += " and Barcode=@in_Barcode ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Barcode", DbType.String, EmsMod.Barcode)); }if (EmsMod.ImageName != null){strWhere += " and ImageName=@in_ImageName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ImageName", DbType.String, EmsMod.ImageName)); }if (EmsMod.Count != null){strWhere += " and Count=@in_Count ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Count", DbType.String, EmsMod.Count)); }if (EmsMod.ClassNumber != null){strWhere += " and ClassNumber=@in_ClassNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ClassNumber", DbType.String, EmsMod.ClassNumber)); }if (EmsMod.AssetsClassName != null){strWhere += " and AssetsClassName=@in_AssetsClassName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetsClassName", DbType.String, EmsMod.AssetsClassName)); }if (EmsMod.IntlClassCode != null){strWhere += " and IntlClassCode=@in_IntlClassCode ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IntlClassCode", DbType.String, EmsMod.IntlClassCode)); }if (EmsMod.IntlClassName != null){strWhere += " and IntlClassName=@in_IntlClassName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IntlClassName", DbType.String, EmsMod.IntlClassName)); }if (EmsMod.AssetName != null){strWhere += " and AssetName=@in_AssetName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsMod.AssetName)); }if (EmsMod.Unit != null){strWhere += " and Unit=@in_Unit ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsMod.Unit)); }if (EmsMod.UsageStatus != null){strWhere += " and UsageStatus=@in_UsageStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UsageStatus", DbType.String, EmsMod.UsageStatus)); }if (EmsMod.UsageDirection != null){strWhere += " and UsageDirection=@in_UsageDirection ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UsageDirection", DbType.String, EmsMod.UsageDirection)); }if (EmsMod.JYBBBSYFX != null){strWhere += " and JYBBBSYFX=@in_JYBBBSYFX ";parmsList.Add(dbHelper.CreateInDbParameter("@in_JYBBBSYFX", DbType.String, EmsMod.JYBBBSYFX)); }if (EmsMod.AcquisitionMethod != null){strWhere += " and AcquisitionMethod=@in_AcquisitionMethod ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AcquisitionMethod", DbType.String, EmsMod.AcquisitionMethod)); }if (EmsMod.AcquisitionDate != null){strWhere += " and AcquisitionDate=@in_AcquisitionDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AcquisitionDate", DbType.String, EmsMod.AcquisitionDate)); }if (EmsMod.BrandStandardModel != null){strWhere += " and BrandStandardModel=@in_BrandStandardModel ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BrandStandardModel", DbType.String, EmsMod.BrandStandardModel)); }if (EmsMod.EquipmentUse != null){strWhere += " and EquipmentUse=@in_EquipmentUse ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipmentUse", DbType.String, EmsMod.EquipmentUse)); }if (EmsMod.UseDepartment != null){strWhere += " and UseDepartment=@in_UseDepartment ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseDepartment", DbType.String, EmsMod.UseDepartment)); }if (EmsMod.UsePeople != null){strWhere += " and UsePeople=@in_UsePeople ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UsePeople", DbType.String, EmsMod.UsePeople)); }if (EmsMod.Factory != null){strWhere += " and Factory=@in_Factory ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Factory", DbType.String, EmsMod.Factory)); }if (EmsMod.StorageLocation != null){strWhere += " and StorageLocation=@in_StorageLocation ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StorageLocation", DbType.String, EmsMod.StorageLocation)); }if (EmsMod.WorthType != null){strWhere += " and WorthType=@in_WorthType ";parmsList.Add(dbHelper.CreateInDbParameter("@in_WorthType", DbType.String, EmsMod.WorthType)); }if (EmsMod.UseNature != null){strWhere += " and UseNature=@in_UseNature ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseNature", DbType.String, EmsMod.UseNature)); }if (EmsMod.Worth != null){strWhere += " and Worth=@in_Worth ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Worth", DbType.String, EmsMod.Worth)); }if (EmsMod.FinanceRecordType != null){strWhere += " and FinanceRecordType=@in_FinanceRecordType ";parmsList.Add(dbHelper.CreateInDbParameter("@in_FinanceRecordType", DbType.String, EmsMod.FinanceRecordType)); }if (EmsMod.FiscalFunds != null){strWhere += " and FiscalFunds=@in_FiscalFunds ";parmsList.Add(dbHelper.CreateInDbParameter("@in_FiscalFunds", DbType.String, EmsMod.FiscalFunds)); }if (EmsMod.NonFiscalFunds != null){strWhere += " and NonFiscalFunds=@in_NonFiscalFunds ";parmsList.Add(dbHelper.CreateInDbParameter("@in_NonFiscalFunds", DbType.String, EmsMod.NonFiscalFunds)); }if (EmsMod.FinanceRecordDate != null){strWhere += " and FinanceRecordDate=@in_FinanceRecordDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_FinanceRecordDate", DbType.String, EmsMod.FinanceRecordDate)); }if (EmsMod.VoucherNumber != null){strWhere += " and VoucherNumber=@in_VoucherNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_VoucherNumber", DbType.String, EmsMod.VoucherNumber)); }if (EmsMod.UseTime != null){strWhere += " and UseTime=@in_UseTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseTime", DbType.String, EmsMod.UseTime)); }if (EmsMod.ExpectedScrapDate != null){strWhere += " and ExpectedScrapDate=@in_ExpectedScrapDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ExpectedScrapDate", DbType.String, EmsMod.ExpectedScrapDate)); }if (EmsMod.DepreciationState != null){strWhere += " and DepreciationState=@in_DepreciationState ";parmsList.Add(dbHelper.CreateInDbParameter("@in_DepreciationState", DbType.String, EmsMod.DepreciationState)); }if (EmsMod.NetWorth != null){strWhere += " and NetWorth=@in_NetWorth ";parmsList.Add(dbHelper.CreateInDbParameter("@in_NetWorth", DbType.String, EmsMod.NetWorth)); }if (EmsMod.OutFactoryNumber != null){strWhere += " and OutFactoryNumber=@in_OutFactoryNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_OutFactoryNumber", DbType.String, EmsMod.OutFactoryNumber)); }if (EmsMod.Supplier != null){strWhere += " and Supplier=@in_Supplier ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Supplier", DbType.String, EmsMod.Supplier)); }if (EmsMod.FundsSubject != null){strWhere += " and FundsSubject=@in_FundsSubject ";parmsList.Add(dbHelper.CreateInDbParameter("@in_FundsSubject", DbType.String, EmsMod.FundsSubject)); }if (EmsMod.PurchaseModality != null){strWhere += " and PurchaseModality=@in_PurchaseModality ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PurchaseModality", DbType.String, EmsMod.PurchaseModality)); }if (EmsMod.CountryCode != null){strWhere += " and CountryCode=@in_CountryCode ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CountryCode", DbType.String, EmsMod.CountryCode)); }if (EmsMod.Operator != null){strWhere += " and Operator=@in_Operator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsMod.Operator)); }if (EmsMod.GuaranteeEndDate != null){strWhere += " and GuaranteeEndDate=@in_GuaranteeEndDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_GuaranteeEndDate", DbType.String, EmsMod.GuaranteeEndDate)); }if (EmsMod.EquipmentNumber != null){strWhere += " and EquipmentNumber=@in_EquipmentNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipmentNumber", DbType.String, EmsMod.EquipmentNumber)); }if (EmsMod.InvoiceNumber != null){strWhere += " and InvoiceNumber=@in_InvoiceNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InvoiceNumber", DbType.String, EmsMod.InvoiceNumber)); }if (EmsMod.CompactNumber != null){strWhere += " and CompactNumber=@in_CompactNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CompactNumber", DbType.String, EmsMod.CompactNumber)); }if (EmsMod.BasicFunds != null){strWhere += " and BasicFunds=@in_BasicFunds ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BasicFunds", DbType.String, EmsMod.BasicFunds)); }if (EmsMod.ItemFunds1 != null){strWhere += " and ItemFunds1=@in_ItemFunds1 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFunds1", DbType.String, EmsMod.ItemFunds1)); }if (EmsMod.ItemFunds2 != null){strWhere += " and ItemFunds2=@in_ItemFunds2 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFunds2", DbType.String, EmsMod.ItemFunds2)); }if (EmsMod.ItemFunds3 != null){strWhere += " and ItemFunds3=@in_ItemFunds3 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFunds3", DbType.String, EmsMod.ItemFunds3)); }if (EmsMod.ItemFunds4 != null){strWhere += " and ItemFunds4=@in_ItemFunds4 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFunds4", DbType.String, EmsMod.ItemFunds4)); }if (EmsMod.ItemFundsMoney1 != null){strWhere += " and ItemFundsMoney1=@in_ItemFundsMoney1 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFundsMoney1", DbType.String, EmsMod.ItemFundsMoney1)); }if (EmsMod.ItemFundsMoney2 != null){strWhere += " and ItemFundsMoney2=@in_ItemFundsMoney2 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFundsMoney2", DbType.String, EmsMod.ItemFundsMoney2)); }if (EmsMod.ItemFundsMoney3 != null){strWhere += " and ItemFundsMoney3=@in_ItemFundsMoney3 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFundsMoney3", DbType.String, EmsMod.ItemFundsMoney3)); }if (EmsMod.ItemFundsMoney4 != null){strWhere += " and ItemFundsMoney4=@in_ItemFundsMoney4 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ItemFundsMoney4", DbType.String, EmsMod.ItemFundsMoney4)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }if (EmsMod.StorageLocation1 != null){strWhere += " and StorageLocation1=@in_StorageLocation1 ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StorageLocation1", DbType.String, EmsMod.StorageLocation1)); }if (EmsMod.IsConsume != null){strWhere += " and IsConsume=@in_IsConsume ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsConsume", DbType.String, EmsMod.IsConsume)); }if (EmsMod.EquipSource != null){strWhere += " and EquipSource=@in_EquipSource ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipSource", DbType.String, EmsMod.EquipSource)); }if (EmsMod.EquipOwner != null){strWhere += " and EquipOwner=@in_EquipOwner ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipOwner", DbType.String, EmsMod.EquipOwner)); }if (EmsMod.ManualModify != null){strWhere += " and ManualModify=@in_ManualModify ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ManualModify", DbType.String, EmsMod.ManualModify)); }if (EmsMod.ImageUrl != null){strWhere += " and ImageUrl=@in_ImageUrl ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ImageUrl", DbType.String, EmsMod.ImageUrl)); }if (EmsMod.BorrowYN != null){strWhere += " and BorrowYN=@in_BorrowYN ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BorrowYN", DbType.String, EmsMod.BorrowYN)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.EquipDetail EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.EquipKindId = dr["EquipKindId"] as int?;EmsModel.AssetNumber = dr["AssetNumber"] as string;EmsModel.EquipIntoID = dr["EquipIntoID"] as int?;EmsModel.EquipStatus = dr["EquipStatus"] as int?;EmsModel.Type = dr["Type"] as Byte?;EmsModel.Barcode = dr["Barcode"] as string;EmsModel.ImageName = dr["ImageName"] as string;EmsModel.Count = dr["Count"] as int?;EmsModel.ClassNumber = dr["ClassNumber"] as string;EmsModel.AssetsClassName = dr["AssetsClassName"] as string;EmsModel.IntlClassCode = dr["IntlClassCode"] as string;EmsModel.IntlClassName = dr["IntlClassName"] as string;EmsModel.AssetName = dr["AssetName"] as string;EmsModel.Unit = dr["Unit"] as string;EmsModel.UsageStatus = dr["UsageStatus"] as string;EmsModel.UsageDirection = dr["UsageDirection"] as string;EmsModel.JYBBBSYFX = dr["JYBBBSYFX"] as string;EmsModel.AcquisitionMethod = dr["AcquisitionMethod"] as string;EmsModel.AcquisitionDate = dr["AcquisitionDate"] as DateTime?;EmsModel.BrandStandardModel = dr["BrandStandardModel"] as string;EmsModel.EquipmentUse = dr["EquipmentUse"] as string;EmsModel.UseDepartment = dr["UseDepartment"] as string;EmsModel.UsePeople = dr["UsePeople"] as string;EmsModel.Factory = dr["Factory"] as string;EmsModel.StorageLocation = dr["StorageLocation"] as string;EmsModel.WorthType = dr["WorthType"] as string;EmsModel.UseNature = dr["UseNature"] as string;EmsModel.Worth = dr["Worth"] as decimal?;EmsModel.FinanceRecordType = dr["FinanceRecordType"] as string;EmsModel.FiscalFunds = dr["FiscalFunds"] as decimal?;EmsModel.NonFiscalFunds = dr["NonFiscalFunds"] as decimal?;EmsModel.FinanceRecordDate = dr["FinanceRecordDate"] as DateTime?;EmsModel.VoucherNumber = dr["VoucherNumber"] as string;EmsModel.UseTime = dr["UseTime"] as int?;EmsModel.ExpectedScrapDate = dr["ExpectedScrapDate"] as DateTime?;EmsModel.DepreciationState = dr["DepreciationState"] as string;EmsModel.NetWorth = dr["NetWorth"] as decimal?;EmsModel.OutFactoryNumber = dr["OutFactoryNumber"] as string;EmsModel.Supplier = dr["Supplier"] as string;EmsModel.FundsSubject = dr["FundsSubject"] as string;EmsModel.PurchaseModality = dr["PurchaseModality"] as string;EmsModel.CountryCode = dr["CountryCode"] as string;EmsModel.Operator = dr["Operator"] as string;EmsModel.GuaranteeEndDate = dr["GuaranteeEndDate"] as DateTime?;EmsModel.EquipmentNumber = dr["EquipmentNumber"] as string;EmsModel.InvoiceNumber = dr["InvoiceNumber"] as string;EmsModel.CompactNumber = dr["CompactNumber"] as string;EmsModel.BasicFunds = dr["BasicFunds"] as string;EmsModel.ItemFunds1 = dr["ItemFunds1"] as string;EmsModel.ItemFunds2 = dr["ItemFunds2"] as string;EmsModel.ItemFunds3 = dr["ItemFunds3"] as string;EmsModel.ItemFunds4 = dr["ItemFunds4"] as string;EmsModel.ItemFundsMoney1 = dr["ItemFundsMoney1"] as decimal?;EmsModel.ItemFundsMoney2 = dr["ItemFundsMoney2"] as decimal?;EmsModel.ItemFundsMoney3 = dr["ItemFundsMoney3"] as decimal?;EmsModel.ItemFundsMoney4 = dr["ItemFundsMoney4"] as decimal?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.UseStatus = dr["UseStatus"] as Byte?;EmsModel.StorageLocation1 = dr["StorageLocation1"] as string;EmsModel.IsConsume = dr["IsConsume"] as Byte?;EmsModel.EquipSource = dr["EquipSource"] as Byte?;EmsModel.EquipOwner = dr["EquipOwner"] as string;EmsModel.ManualModify = dr["ManualModify"] as Byte?;EmsModel.ImageUrl = dr["ImageUrl"] as string;EmsModel.BorrowYN = dr["BorrowYN"] as Byte?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.EquipDetail> GetList(DataTable dt)
        {
            List<EmsModel.EquipDetail> lst = new List<EmsModel.EquipDetail>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.EquipDetail mod = new EmsModel.EquipDetail();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.EquipDetail EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.EquipKindId = dr["EquipKindId"] as int?;EmsModel.AssetNumber = dr["AssetNumber"] as string;EmsModel.EquipIntoID = dr["EquipIntoID"] as int?;EmsModel.EquipStatus = dr["EquipStatus"] as int?;EmsModel.Type = dr["Type"] as Byte?;EmsModel.Barcode = dr["Barcode"] as string;EmsModel.ImageName = dr["ImageName"] as string;EmsModel.Count = dr["Count"] as int?;EmsModel.ClassNumber = dr["ClassNumber"] as string;EmsModel.AssetsClassName = dr["AssetsClassName"] as string;EmsModel.IntlClassCode = dr["IntlClassCode"] as string;EmsModel.IntlClassName = dr["IntlClassName"] as string;EmsModel.AssetName = dr["AssetName"] as string;EmsModel.Unit = dr["Unit"] as string;EmsModel.UsageStatus = dr["UsageStatus"] as string;EmsModel.UsageDirection = dr["UsageDirection"] as string;EmsModel.JYBBBSYFX = dr["JYBBBSYFX"] as string;EmsModel.AcquisitionMethod = dr["AcquisitionMethod"] as string;EmsModel.AcquisitionDate = dr["AcquisitionDate"] as DateTime?;EmsModel.BrandStandardModel = dr["BrandStandardModel"] as string;EmsModel.EquipmentUse = dr["EquipmentUse"] as string;EmsModel.UseDepartment = dr["UseDepartment"] as string;EmsModel.UsePeople = dr["UsePeople"] as string;EmsModel.Factory = dr["Factory"] as string;EmsModel.StorageLocation = dr["StorageLocation"] as string;EmsModel.WorthType = dr["WorthType"] as string;EmsModel.UseNature = dr["UseNature"] as string;EmsModel.Worth = dr["Worth"] as decimal?;EmsModel.FinanceRecordType = dr["FinanceRecordType"] as string;EmsModel.FiscalFunds = dr["FiscalFunds"] as decimal?;EmsModel.NonFiscalFunds = dr["NonFiscalFunds"] as decimal?;EmsModel.FinanceRecordDate = dr["FinanceRecordDate"] as DateTime?;EmsModel.VoucherNumber = dr["VoucherNumber"] as string;EmsModel.UseTime = dr["UseTime"] as int?;EmsModel.ExpectedScrapDate = dr["ExpectedScrapDate"] as DateTime?;EmsModel.DepreciationState = dr["DepreciationState"] as string;EmsModel.NetWorth = dr["NetWorth"] as decimal?;EmsModel.OutFactoryNumber = dr["OutFactoryNumber"] as string;EmsModel.Supplier = dr["Supplier"] as string;EmsModel.FundsSubject = dr["FundsSubject"] as string;EmsModel.PurchaseModality = dr["PurchaseModality"] as string;EmsModel.CountryCode = dr["CountryCode"] as string;EmsModel.Operator = dr["Operator"] as string;EmsModel.GuaranteeEndDate = dr["GuaranteeEndDate"] as DateTime?;EmsModel.EquipmentNumber = dr["EquipmentNumber"] as string;EmsModel.InvoiceNumber = dr["InvoiceNumber"] as string;EmsModel.CompactNumber = dr["CompactNumber"] as string;EmsModel.BasicFunds = dr["BasicFunds"] as string;EmsModel.ItemFunds1 = dr["ItemFunds1"] as string;EmsModel.ItemFunds2 = dr["ItemFunds2"] as string;EmsModel.ItemFunds3 = dr["ItemFunds3"] as string;EmsModel.ItemFunds4 = dr["ItemFunds4"] as string;EmsModel.ItemFundsMoney1 = dr["ItemFundsMoney1"] as decimal?;EmsModel.ItemFundsMoney2 = dr["ItemFundsMoney2"] as decimal?;EmsModel.ItemFundsMoney3 = dr["ItemFundsMoney3"] as decimal?;EmsModel.ItemFundsMoney4 = dr["ItemFundsMoney4"] as decimal?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.UseStatus = dr["UseStatus"] as Byte?;EmsModel.StorageLocation1 = dr["StorageLocation1"] as string;EmsModel.IsConsume = dr["IsConsume"] as Byte?;EmsModel.EquipSource = dr["EquipSource"] as Byte?;EmsModel.EquipOwner = dr["EquipOwner"] as string;EmsModel.ManualModify = dr["ManualModify"] as Byte?;EmsModel.ImageUrl = dr["ImageUrl"] as string;EmsModel.BorrowYN = dr["BorrowYN"] as Byte?;
        }		

    }

	/// </summary>
	///	教学计划表实体类22
	/// </summary>
    public partial class EquipInto: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.EquipInto EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO EquipInto(");
						sbSql.Append("WarehouseId,EquipKindId,Count,Creator,CreateTime,IsDelete)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_WarehouseId,@in_EquipKindId,@in_Count,@in_Creator,@in_CreateTime,@in_IsDelete)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_WarehouseId", DbType.Int32, EmsModel.WarehouseId),dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.EquipInto EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO EquipInto(");
						sbSql.Append("WarehouseId,EquipKindId,Count,Creator,CreateTime,IsDelete)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_WarehouseId,@in_EquipKindId,@in_Count,@in_Creator,@in_CreateTime,@in_IsDelete)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_WarehouseId", DbType.Int32, EmsModel.WarehouseId),dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.EquipInto EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update EquipInto set ");
					sbSql.Append("WarehouseId=@in_WarehouseId,EquipKindId=@in_EquipKindId,Count=@in_Count,Creator=@in_Creator,CreateTime=@in_CreateTime,IsDelete=@in_IsDelete");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_WarehouseId", DbType.Int32, EmsModel.WarehouseId),dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.EquipInto EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update EquipInto set ");
					sbSql.Append("WarehouseId=@in_WarehouseId,EquipKindId=@in_EquipKindId,Count=@in_Count,Creator=@in_Creator,CreateTime=@in_CreateTime,IsDelete=@in_IsDelete");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_WarehouseId", DbType.Int32, EmsModel.WarehouseId),dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM EquipInto");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM EquipInto");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM EquipInto");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.EquipInto> GetListByPage(EmsModel.EquipInto EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "EquipInto";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.WarehouseId != null){strWhere += " and WarehouseId=@in_WarehouseId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_WarehouseId", DbType.String, EmsMod.WarehouseId)); }if (EmsMod.EquipKindId != null){strWhere += " and EquipKindId=@in_EquipKindId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.String, EmsMod.EquipKindId)); }if (EmsMod.Count != null){strWhere += " and Count=@in_Count ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Count", DbType.String, EmsMod.Count)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.EquipInto> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.EquipInto EmsMod)
        {
            string TableName = "EquipInto";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.WarehouseId != null){strWhere += " and WarehouseId=@in_WarehouseId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_WarehouseId", DbType.String, EmsMod.WarehouseId)); }if (EmsMod.EquipKindId != null){strWhere += " and EquipKindId=@in_EquipKindId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.String, EmsMod.EquipKindId)); }if (EmsMod.Count != null){strWhere += " and Count=@in_Count ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Count", DbType.String, EmsMod.Count)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.EquipInto EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.WarehouseId = dr["WarehouseId"] as int?;EmsModel.EquipKindId = dr["EquipKindId"] as int?;EmsModel.Count = dr["Count"] as int?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.EquipInto> GetList(DataTable dt)
        {
            List<EmsModel.EquipInto> lst = new List<EmsModel.EquipInto>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.EquipInto mod = new EmsModel.EquipInto();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.EquipInto EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.WarehouseId = dr["WarehouseId"] as int?;EmsModel.EquipKindId = dr["EquipKindId"] as int?;EmsModel.Count = dr["Count"] as int?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;
        }		

    }

	/// </summary>
	///	教学计划表实体类23
	/// </summary>
    public partial class EquipList: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.EquipList EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO EquipList(");
						sbSql.Append("RelationID,EquipKindId,EquipName,Parts,Count,Remarks)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_RelationID,@in_EquipKindId,@in_EquipName,@in_Parts,@in_Count,@in_Remarks)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_RelationID", DbType.Int32, EmsModel.RelationID),dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_EquipName", DbType.String, EmsModel.EquipName),dbHelper.CreateInDbParameter("@in_Parts", DbType.String, EmsModel.Parts),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.EquipList EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO EquipList(");
						sbSql.Append("RelationID,EquipKindId,EquipName,Parts,Count,Remarks)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_RelationID,@in_EquipKindId,@in_EquipName,@in_Parts,@in_Count,@in_Remarks)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_RelationID", DbType.Int32, EmsModel.RelationID),dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_EquipName", DbType.String, EmsModel.EquipName),dbHelper.CreateInDbParameter("@in_Parts", DbType.String, EmsModel.Parts),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.EquipList EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update EquipList set ");
					sbSql.Append("RelationID=@in_RelationID,EquipKindId=@in_EquipKindId,EquipName=@in_EquipName,Parts=@in_Parts,Count=@in_Count,Remarks=@in_Remarks");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_RelationID", DbType.Int32, EmsModel.RelationID),dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_EquipName", DbType.String, EmsModel.EquipName),dbHelper.CreateInDbParameter("@in_Parts", DbType.String, EmsModel.Parts),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.EquipList EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update EquipList set ");
					sbSql.Append("RelationID=@in_RelationID,EquipKindId=@in_EquipKindId,EquipName=@in_EquipName,Parts=@in_Parts,Count=@in_Count,Remarks=@in_Remarks");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_RelationID", DbType.Int32, EmsModel.RelationID),dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.Int32, EmsModel.EquipKindId),dbHelper.CreateInDbParameter("@in_EquipName", DbType.String, EmsModel.EquipName),dbHelper.CreateInDbParameter("@in_Parts", DbType.String, EmsModel.Parts),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM EquipList");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM EquipList");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM EquipList");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.EquipList> GetListByPage(EmsModel.EquipList EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "EquipList";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.RelationID != null){strWhere += " and RelationID=@in_RelationID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RelationID", DbType.String, EmsMod.RelationID)); }if (EmsMod.EquipKindId != null){strWhere += " and EquipKindId=@in_EquipKindId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.String, EmsMod.EquipKindId)); }if (EmsMod.EquipName != null){strWhere += " and EquipName=@in_EquipName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipName", DbType.String, EmsMod.EquipName)); }if (EmsMod.Parts != null){strWhere += " and Parts=@in_Parts ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Parts", DbType.String, EmsMod.Parts)); }if (EmsMod.Count != null){strWhere += " and Count=@in_Count ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Count", DbType.String, EmsMod.Count)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.EquipList> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.EquipList EmsMod)
        {
            string TableName = "EquipList";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.RelationID != null){strWhere += " and RelationID=@in_RelationID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RelationID", DbType.String, EmsMod.RelationID)); }if (EmsMod.EquipKindId != null){strWhere += " and EquipKindId=@in_EquipKindId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipKindId", DbType.String, EmsMod.EquipKindId)); }if (EmsMod.EquipName != null){strWhere += " and EquipName=@in_EquipName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipName", DbType.String, EmsMod.EquipName)); }if (EmsMod.Parts != null){strWhere += " and Parts=@in_Parts ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Parts", DbType.String, EmsMod.Parts)); }if (EmsMod.Count != null){strWhere += " and Count=@in_Count ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Count", DbType.String, EmsMod.Count)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.EquipList EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.RelationID = dr["RelationID"] as int?;EmsModel.EquipKindId = dr["EquipKindId"] as int?;EmsModel.EquipName = dr["EquipName"] as string;EmsModel.Parts = dr["Parts"] as string;EmsModel.Count = dr["Count"] as int?;EmsModel.Remarks = dr["Remarks"] as string;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.EquipList> GetList(DataTable dt)
        {
            List<EmsModel.EquipList> lst = new List<EmsModel.EquipList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.EquipList mod = new EmsModel.EquipList();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.EquipList EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.RelationID = dr["RelationID"] as int?;EmsModel.EquipKindId = dr["EquipKindId"] as int?;EmsModel.EquipName = dr["EquipName"] as string;EmsModel.Parts = dr["Parts"] as string;EmsModel.Count = dr["Count"] as int?;EmsModel.Remarks = dr["Remarks"] as string;
        }		

    }

	/// </summary>
	///	教学计划表实体类24
	/// </summary>
    public partial class EqWorth: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.EqWorth EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO EqWorth(");
						sbSql.Append("Worth)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Worth)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Worth", DbType.Decimal, EmsModel.Worth)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.EqWorth EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO EqWorth(");
						sbSql.Append("Worth)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Worth)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Worth", DbType.Decimal, EmsModel.Worth)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.EqWorth EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update EqWorth set ");
					sbSql.Append("Worth=@in_Worth");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Worth", DbType.Decimal, EmsModel.Worth)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.EqWorth EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update EqWorth set ");
					sbSql.Append("Worth=@in_Worth");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Worth", DbType.Decimal, EmsModel.Worth)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM EqWorth");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM EqWorth");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM EqWorth");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.EqWorth> GetListByPage(EmsModel.EqWorth EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "EqWorth";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Worth != null){strWhere += " and Worth=@in_Worth ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Worth", DbType.String, EmsMod.Worth)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.EqWorth> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.EqWorth EmsMod)
        {
            string TableName = "EqWorth";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Worth != null){strWhere += " and Worth=@in_Worth ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Worth", DbType.String, EmsMod.Worth)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.EqWorth EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Worth = dr["Worth"] as decimal?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.EqWorth> GetList(DataTable dt)
        {
            List<EmsModel.EqWorth> lst = new List<EmsModel.EqWorth>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.EqWorth mod = new EmsModel.EqWorth();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.EqWorth EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Worth = dr["Worth"] as decimal?;
        }		

    }

	/// </summary>
	///	教学计划表实体类25
	/// </summary>
    public partial class ExperimentClassInfo: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.ExperimentClassInfo EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO ExperimentClassInfo(");
						sbSql.Append("ExperimentId,ClassId)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_ExperimentId,@in_ClassId)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.Int32, EmsModel.ExperimentId),dbHelper.CreateInDbParameter("@in_ClassId", DbType.Int32, EmsModel.ClassId)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.ExperimentClassInfo EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO ExperimentClassInfo(");
						sbSql.Append("ExperimentId,ClassId)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_ExperimentId,@in_ClassId)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.Int32, EmsModel.ExperimentId),dbHelper.CreateInDbParameter("@in_ClassId", DbType.Int32, EmsModel.ClassId)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.ExperimentClassInfo EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update ExperimentClassInfo set ");
					sbSql.Append("ExperimentId=@in_ExperimentId,ClassId=@in_ClassId");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.Int32, EmsModel.ExperimentId),dbHelper.CreateInDbParameter("@in_ClassId", DbType.Int32, EmsModel.ClassId)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.ExperimentClassInfo EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update ExperimentClassInfo set ");
					sbSql.Append("ExperimentId=@in_ExperimentId,ClassId=@in_ClassId");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.Int32, EmsModel.ExperimentId),dbHelper.CreateInDbParameter("@in_ClassId", DbType.Int32, EmsModel.ClassId)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM ExperimentClassInfo");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM ExperimentClassInfo");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM ExperimentClassInfo");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.ExperimentClassInfo> GetListByPage(EmsModel.ExperimentClassInfo EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "ExperimentClassInfo";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.ExperimentId != null){strWhere += " and ExperimentId=@in_ExperimentId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.String, EmsMod.ExperimentId)); }if (EmsMod.ClassId != null){strWhere += " and ClassId=@in_ClassId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ClassId", DbType.String, EmsMod.ClassId)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.ExperimentClassInfo> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.ExperimentClassInfo EmsMod)
        {
            string TableName = "ExperimentClassInfo";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.ExperimentId != null){strWhere += " and ExperimentId=@in_ExperimentId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.String, EmsMod.ExperimentId)); }if (EmsMod.ClassId != null){strWhere += " and ClassId=@in_ClassId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ClassId", DbType.String, EmsMod.ClassId)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.ExperimentClassInfo EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.ExperimentId = dr["ExperimentId"] as int?;EmsModel.ClassId = dr["ClassId"] as int?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.ExperimentClassInfo> GetList(DataTable dt)
        {
            List<EmsModel.ExperimentClassInfo> lst = new List<EmsModel.ExperimentClassInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.ExperimentClassInfo mod = new EmsModel.ExperimentClassInfo();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.ExperimentClassInfo EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.ExperimentId = dr["ExperimentId"] as int?;EmsModel.ClassId = dr["ClassId"] as int?;
        }		

    }

	/// </summary>
	///	教学计划表实体类26
	/// </summary>
    public partial class Honor: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.Honor EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO Honor(");
						sbSql.Append("Name,HonorLevel,ExperimentId,Creator,CreateTime,Editor,UpdateTime,IsDelete)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_HonorLevel,@in_ExperimentId,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_HonorLevel", DbType.Int32, EmsModel.HonorLevel),dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.Int32, EmsModel.ExperimentId),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.Honor EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO Honor(");
						sbSql.Append("Name,HonorLevel,ExperimentId,Creator,CreateTime,Editor,UpdateTime,IsDelete)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_HonorLevel,@in_ExperimentId,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_HonorLevel", DbType.Int32, EmsModel.HonorLevel),dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.Int32, EmsModel.ExperimentId),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.Honor EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update Honor set ");
					sbSql.Append("Name=@in_Name,HonorLevel=@in_HonorLevel,ExperimentId=@in_ExperimentId,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_HonorLevel", DbType.Int32, EmsModel.HonorLevel),dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.Int32, EmsModel.ExperimentId),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.Honor EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update Honor set ");
					sbSql.Append("Name=@in_Name,HonorLevel=@in_HonorLevel,ExperimentId=@in_ExperimentId,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_HonorLevel", DbType.Int32, EmsModel.HonorLevel),dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.Int32, EmsModel.ExperimentId),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM Honor");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM Honor");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM Honor");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.Honor> GetListByPage(EmsModel.Honor EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "Honor";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.HonorLevel != null){strWhere += " and HonorLevel=@in_HonorLevel ";parmsList.Add(dbHelper.CreateInDbParameter("@in_HonorLevel", DbType.String, EmsMod.HonorLevel)); }if (EmsMod.ExperimentId != null){strWhere += " and ExperimentId=@in_ExperimentId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.String, EmsMod.ExperimentId)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.Honor> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.Honor EmsMod)
        {
            string TableName = "Honor";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.HonorLevel != null){strWhere += " and HonorLevel=@in_HonorLevel ";parmsList.Add(dbHelper.CreateInDbParameter("@in_HonorLevel", DbType.String, EmsMod.HonorLevel)); }if (EmsMod.ExperimentId != null){strWhere += " and ExperimentId=@in_ExperimentId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.String, EmsMod.ExperimentId)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.Honor EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.HonorLevel = dr["HonorLevel"] as int?;EmsModel.ExperimentId = dr["ExperimentId"] as int?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.Honor> GetList(DataTable dt)
        {
            List<EmsModel.Honor> lst = new List<EmsModel.Honor>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.Honor mod = new EmsModel.Honor();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.Honor EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.HonorLevel = dr["HonorLevel"] as int?;EmsModel.ExperimentId = dr["ExperimentId"] as int?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;
        }		

    }

	/// </summary>
	///	教学计划表实体类27
	/// </summary>
    public partial class InstrumentEquip: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.InstrumentEquip EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO InstrumentEquip(");
						sbSql.Append("Number,Name,Model,Count,Unit,Type,WarehouseId,Company,Remarks,Creator,CreateTime,Editor,UpdateTime,IsDelete,UseStatus)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Number,@in_Name,@in_Model,@in_Count,@in_Unit,@in_Type,@in_WarehouseId,@in_Company,@in_Remarks,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_UseStatus)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Number", DbType.String, EmsModel.Number),dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Model", DbType.String, EmsModel.Model),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsModel.Unit),dbHelper.CreateInDbParameter("@in_Type", DbType.Int32, EmsModel.Type),dbHelper.CreateInDbParameter("@in_WarehouseId", DbType.Int32, EmsModel.WarehouseId),dbHelper.CreateInDbParameter("@in_Company", DbType.String, EmsModel.Company),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.InstrumentEquip EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO InstrumentEquip(");
						sbSql.Append("Number,Name,Model,Count,Unit,Type,WarehouseId,Company,Remarks,Creator,CreateTime,Editor,UpdateTime,IsDelete,UseStatus)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Number,@in_Name,@in_Model,@in_Count,@in_Unit,@in_Type,@in_WarehouseId,@in_Company,@in_Remarks,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_UseStatus)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Number", DbType.String, EmsModel.Number),dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Model", DbType.String, EmsModel.Model),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsModel.Unit),dbHelper.CreateInDbParameter("@in_Type", DbType.Int32, EmsModel.Type),dbHelper.CreateInDbParameter("@in_WarehouseId", DbType.Int32, EmsModel.WarehouseId),dbHelper.CreateInDbParameter("@in_Company", DbType.String, EmsModel.Company),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.InstrumentEquip EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update InstrumentEquip set ");
					sbSql.Append("Number=@in_Number,Name=@in_Name,Model=@in_Model,Count=@in_Count,Unit=@in_Unit,Type=@in_Type,WarehouseId=@in_WarehouseId,Company=@in_Company,Remarks=@in_Remarks,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,UseStatus=@in_UseStatus");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Number", DbType.String, EmsModel.Number),dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Model", DbType.String, EmsModel.Model),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsModel.Unit),dbHelper.CreateInDbParameter("@in_Type", DbType.Int32, EmsModel.Type),dbHelper.CreateInDbParameter("@in_WarehouseId", DbType.Int32, EmsModel.WarehouseId),dbHelper.CreateInDbParameter("@in_Company", DbType.String, EmsModel.Company),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.InstrumentEquip EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update InstrumentEquip set ");
					sbSql.Append("Number=@in_Number,Name=@in_Name,Model=@in_Model,Count=@in_Count,Unit=@in_Unit,Type=@in_Type,WarehouseId=@in_WarehouseId,Company=@in_Company,Remarks=@in_Remarks,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,UseStatus=@in_UseStatus");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Number", DbType.String, EmsModel.Number),dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Model", DbType.String, EmsModel.Model),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsModel.Unit),dbHelper.CreateInDbParameter("@in_Type", DbType.Int32, EmsModel.Type),dbHelper.CreateInDbParameter("@in_WarehouseId", DbType.Int32, EmsModel.WarehouseId),dbHelper.CreateInDbParameter("@in_Company", DbType.String, EmsModel.Company),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM InstrumentEquip");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM InstrumentEquip");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM InstrumentEquip");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.InstrumentEquip> GetListByPage(EmsModel.InstrumentEquip EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "InstrumentEquip";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Number != null){strWhere += " and Number=@in_Number ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Number", DbType.String, EmsMod.Number)); }if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.Model != null){strWhere += " and Model=@in_Model ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Model", DbType.String, EmsMod.Model)); }if (EmsMod.Count != null){strWhere += " and Count=@in_Count ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Count", DbType.String, EmsMod.Count)); }if (EmsMod.Unit != null){strWhere += " and Unit=@in_Unit ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsMod.Unit)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.WarehouseId != null){strWhere += " and WarehouseId=@in_WarehouseId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_WarehouseId", DbType.String, EmsMod.WarehouseId)); }if (EmsMod.Company != null){strWhere += " and Company=@in_Company ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Company", DbType.String, EmsMod.Company)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.InstrumentEquip> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.InstrumentEquip EmsMod)
        {
            string TableName = "InstrumentEquip";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Number != null){strWhere += " and Number=@in_Number ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Number", DbType.String, EmsMod.Number)); }if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.Model != null){strWhere += " and Model=@in_Model ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Model", DbType.String, EmsMod.Model)); }if (EmsMod.Count != null){strWhere += " and Count=@in_Count ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Count", DbType.String, EmsMod.Count)); }if (EmsMod.Unit != null){strWhere += " and Unit=@in_Unit ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsMod.Unit)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.WarehouseId != null){strWhere += " and WarehouseId=@in_WarehouseId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_WarehouseId", DbType.String, EmsMod.WarehouseId)); }if (EmsMod.Company != null){strWhere += " and Company=@in_Company ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Company", DbType.String, EmsMod.Company)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.InstrumentEquip EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Number = dr["Number"] as string;EmsModel.Name = dr["Name"] as string;EmsModel.Model = dr["Model"] as string;EmsModel.Count = dr["Count"] as int?;EmsModel.Unit = dr["Unit"] as string;EmsModel.Type = dr["Type"] as int?;EmsModel.WarehouseId = dr["WarehouseId"] as int?;EmsModel.Company = dr["Company"] as string;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.UseStatus = dr["UseStatus"] as Byte?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.InstrumentEquip> GetList(DataTable dt)
        {
            List<EmsModel.InstrumentEquip> lst = new List<EmsModel.InstrumentEquip>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.InstrumentEquip mod = new EmsModel.InstrumentEquip();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.InstrumentEquip EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Number = dr["Number"] as string;EmsModel.Name = dr["Name"] as string;EmsModel.Model = dr["Model"] as string;EmsModel.Count = dr["Count"] as int?;EmsModel.Unit = dr["Unit"] as string;EmsModel.Type = dr["Type"] as int?;EmsModel.WarehouseId = dr["WarehouseId"] as int?;EmsModel.Company = dr["Company"] as string;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.UseStatus = dr["UseStatus"] as Byte?;
        }		

    }

	/// </summary>
	///	教学计划表实体类28
	/// </summary>
    public partial class InventoryList: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.InventoryList EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO InventoryList(");
						sbSql.Append("PlanId,RoomId,Quantity,RealQuantity,BorrowQuantity,LossQuantity,Status,Operator,Creator,CreateTime,Editor,UpdateTime,IsDelete)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_PlanId,@in_RoomId,@in_Quantity,@in_RealQuantity,@in_BorrowQuantity,@in_LossQuantity,@in_Status,@in_Operator,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_PlanId", DbType.Int32, EmsModel.PlanId),dbHelper.CreateInDbParameter("@in_RoomId", DbType.Int32, EmsModel.RoomId),dbHelper.CreateInDbParameter("@in_Quantity", DbType.Int32, EmsModel.Quantity),dbHelper.CreateInDbParameter("@in_RealQuantity", DbType.Int32, EmsModel.RealQuantity),dbHelper.CreateInDbParameter("@in_BorrowQuantity", DbType.Int32, EmsModel.BorrowQuantity),dbHelper.CreateInDbParameter("@in_LossQuantity", DbType.Int32, EmsModel.LossQuantity),dbHelper.CreateInDbParameter("@in_Status", DbType.Byte, EmsModel.Status),dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsModel.Operator),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.InventoryList EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO InventoryList(");
						sbSql.Append("PlanId,RoomId,Quantity,RealQuantity,BorrowQuantity,LossQuantity,Status,Operator,Creator,CreateTime,Editor,UpdateTime,IsDelete)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_PlanId,@in_RoomId,@in_Quantity,@in_RealQuantity,@in_BorrowQuantity,@in_LossQuantity,@in_Status,@in_Operator,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_PlanId", DbType.Int32, EmsModel.PlanId),dbHelper.CreateInDbParameter("@in_RoomId", DbType.Int32, EmsModel.RoomId),dbHelper.CreateInDbParameter("@in_Quantity", DbType.Int32, EmsModel.Quantity),dbHelper.CreateInDbParameter("@in_RealQuantity", DbType.Int32, EmsModel.RealQuantity),dbHelper.CreateInDbParameter("@in_BorrowQuantity", DbType.Int32, EmsModel.BorrowQuantity),dbHelper.CreateInDbParameter("@in_LossQuantity", DbType.Int32, EmsModel.LossQuantity),dbHelper.CreateInDbParameter("@in_Status", DbType.Byte, EmsModel.Status),dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsModel.Operator),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.InventoryList EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update InventoryList set ");
					sbSql.Append("PlanId=@in_PlanId,RoomId=@in_RoomId,Quantity=@in_Quantity,RealQuantity=@in_RealQuantity,BorrowQuantity=@in_BorrowQuantity,LossQuantity=@in_LossQuantity,Status=@in_Status,Operator=@in_Operator,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_PlanId", DbType.Int32, EmsModel.PlanId),dbHelper.CreateInDbParameter("@in_RoomId", DbType.Int32, EmsModel.RoomId),dbHelper.CreateInDbParameter("@in_Quantity", DbType.Int32, EmsModel.Quantity),dbHelper.CreateInDbParameter("@in_RealQuantity", DbType.Int32, EmsModel.RealQuantity),dbHelper.CreateInDbParameter("@in_BorrowQuantity", DbType.Int32, EmsModel.BorrowQuantity),dbHelper.CreateInDbParameter("@in_LossQuantity", DbType.Int32, EmsModel.LossQuantity),dbHelper.CreateInDbParameter("@in_Status", DbType.Byte, EmsModel.Status),dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsModel.Operator),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.InventoryList EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update InventoryList set ");
					sbSql.Append("PlanId=@in_PlanId,RoomId=@in_RoomId,Quantity=@in_Quantity,RealQuantity=@in_RealQuantity,BorrowQuantity=@in_BorrowQuantity,LossQuantity=@in_LossQuantity,Status=@in_Status,Operator=@in_Operator,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_PlanId", DbType.Int32, EmsModel.PlanId),dbHelper.CreateInDbParameter("@in_RoomId", DbType.Int32, EmsModel.RoomId),dbHelper.CreateInDbParameter("@in_Quantity", DbType.Int32, EmsModel.Quantity),dbHelper.CreateInDbParameter("@in_RealQuantity", DbType.Int32, EmsModel.RealQuantity),dbHelper.CreateInDbParameter("@in_BorrowQuantity", DbType.Int32, EmsModel.BorrowQuantity),dbHelper.CreateInDbParameter("@in_LossQuantity", DbType.Int32, EmsModel.LossQuantity),dbHelper.CreateInDbParameter("@in_Status", DbType.Byte, EmsModel.Status),dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsModel.Operator),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM InventoryList");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM InventoryList");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM InventoryList");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.InventoryList> GetListByPage(EmsModel.InventoryList EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "InventoryList";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.PlanId != null){strWhere += " and PlanId=@in_PlanId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PlanId", DbType.String, EmsMod.PlanId)); }if (EmsMod.RoomId != null){strWhere += " and RoomId=@in_RoomId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RoomId", DbType.String, EmsMod.RoomId)); }if (EmsMod.Quantity != null){strWhere += " and Quantity=@in_Quantity ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Quantity", DbType.String, EmsMod.Quantity)); }if (EmsMod.RealQuantity != null){strWhere += " and RealQuantity=@in_RealQuantity ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RealQuantity", DbType.String, EmsMod.RealQuantity)); }if (EmsMod.BorrowQuantity != null){strWhere += " and BorrowQuantity=@in_BorrowQuantity ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BorrowQuantity", DbType.String, EmsMod.BorrowQuantity)); }if (EmsMod.LossQuantity != null){strWhere += " and LossQuantity=@in_LossQuantity ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LossQuantity", DbType.String, EmsMod.LossQuantity)); }if (EmsMod.Status != null){strWhere += " and Status=@in_Status ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Status", DbType.String, EmsMod.Status)); }if (EmsMod.Operator != null){strWhere += " and Operator=@in_Operator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsMod.Operator)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.InventoryList> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.InventoryList EmsMod)
        {
            string TableName = "InventoryList";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.PlanId != null){strWhere += " and PlanId=@in_PlanId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PlanId", DbType.String, EmsMod.PlanId)); }if (EmsMod.RoomId != null){strWhere += " and RoomId=@in_RoomId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RoomId", DbType.String, EmsMod.RoomId)); }if (EmsMod.Quantity != null){strWhere += " and Quantity=@in_Quantity ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Quantity", DbType.String, EmsMod.Quantity)); }if (EmsMod.RealQuantity != null){strWhere += " and RealQuantity=@in_RealQuantity ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RealQuantity", DbType.String, EmsMod.RealQuantity)); }if (EmsMod.BorrowQuantity != null){strWhere += " and BorrowQuantity=@in_BorrowQuantity ";parmsList.Add(dbHelper.CreateInDbParameter("@in_BorrowQuantity", DbType.String, EmsMod.BorrowQuantity)); }if (EmsMod.LossQuantity != null){strWhere += " and LossQuantity=@in_LossQuantity ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LossQuantity", DbType.String, EmsMod.LossQuantity)); }if (EmsMod.Status != null){strWhere += " and Status=@in_Status ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Status", DbType.String, EmsMod.Status)); }if (EmsMod.Operator != null){strWhere += " and Operator=@in_Operator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Operator", DbType.String, EmsMod.Operator)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.InventoryList EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.PlanId = dr["PlanId"] as int?;EmsModel.RoomId = dr["RoomId"] as int?;EmsModel.Quantity = dr["Quantity"] as int?;EmsModel.RealQuantity = dr["RealQuantity"] as int?;EmsModel.BorrowQuantity = dr["BorrowQuantity"] as int?;EmsModel.LossQuantity = dr["LossQuantity"] as int?;EmsModel.Status = dr["Status"] as Byte?;EmsModel.Operator = dr["Operator"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.InventoryList> GetList(DataTable dt)
        {
            List<EmsModel.InventoryList> lst = new List<EmsModel.InventoryList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.InventoryList mod = new EmsModel.InventoryList();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.InventoryList EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.PlanId = dr["PlanId"] as int?;EmsModel.RoomId = dr["RoomId"] as int?;EmsModel.Quantity = dr["Quantity"] as int?;EmsModel.RealQuantity = dr["RealQuantity"] as int?;EmsModel.BorrowQuantity = dr["BorrowQuantity"] as int?;EmsModel.LossQuantity = dr["LossQuantity"] as int?;EmsModel.Status = dr["Status"] as Byte?;EmsModel.Operator = dr["Operator"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;
        }		

    }

	/// </summary>
	///	教学计划表实体类29
	/// </summary>
    public partial class InventoryListDetail: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.InventoryListDetail EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO InventoryListDetail(");
						sbSql.Append("InventoryListId,EquipId,AssetNumber,AssetName,RoomId,SourceRoomId,Status,IsLoss,Remarks)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_InventoryListId,@in_EquipId,@in_AssetNumber,@in_AssetName,@in_RoomId,@in_SourceRoomId,@in_Status,@in_IsLoss,@in_Remarks)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_InventoryListId", DbType.Int32, EmsModel.InventoryListId),dbHelper.CreateInDbParameter("@in_EquipId", DbType.Int32, EmsModel.EquipId),dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsModel.AssetNumber),dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsModel.AssetName),dbHelper.CreateInDbParameter("@in_RoomId", DbType.Int32, EmsModel.RoomId),dbHelper.CreateInDbParameter("@in_SourceRoomId", DbType.Int32, EmsModel.SourceRoomId),dbHelper.CreateInDbParameter("@in_Status", DbType.Int32, EmsModel.Status),dbHelper.CreateInDbParameter("@in_IsLoss", DbType.Boolean, EmsModel.IsLoss),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.InventoryListDetail EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO InventoryListDetail(");
						sbSql.Append("InventoryListId,EquipId,AssetNumber,AssetName,RoomId,SourceRoomId,Status,IsLoss,Remarks)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_InventoryListId,@in_EquipId,@in_AssetNumber,@in_AssetName,@in_RoomId,@in_SourceRoomId,@in_Status,@in_IsLoss,@in_Remarks)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_InventoryListId", DbType.Int32, EmsModel.InventoryListId),dbHelper.CreateInDbParameter("@in_EquipId", DbType.Int32, EmsModel.EquipId),dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsModel.AssetNumber),dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsModel.AssetName),dbHelper.CreateInDbParameter("@in_RoomId", DbType.Int32, EmsModel.RoomId),dbHelper.CreateInDbParameter("@in_SourceRoomId", DbType.Int32, EmsModel.SourceRoomId),dbHelper.CreateInDbParameter("@in_Status", DbType.Int32, EmsModel.Status),dbHelper.CreateInDbParameter("@in_IsLoss", DbType.Boolean, EmsModel.IsLoss),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.InventoryListDetail EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update InventoryListDetail set ");
					sbSql.Append("InventoryListId=@in_InventoryListId,EquipId=@in_EquipId,AssetNumber=@in_AssetNumber,AssetName=@in_AssetName,RoomId=@in_RoomId,SourceRoomId=@in_SourceRoomId,Status=@in_Status,IsLoss=@in_IsLoss,Remarks=@in_Remarks");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_InventoryListId", DbType.Int32, EmsModel.InventoryListId),dbHelper.CreateInDbParameter("@in_EquipId", DbType.Int32, EmsModel.EquipId),dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsModel.AssetNumber),dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsModel.AssetName),dbHelper.CreateInDbParameter("@in_RoomId", DbType.Int32, EmsModel.RoomId),dbHelper.CreateInDbParameter("@in_SourceRoomId", DbType.Int32, EmsModel.SourceRoomId),dbHelper.CreateInDbParameter("@in_Status", DbType.Int32, EmsModel.Status),dbHelper.CreateInDbParameter("@in_IsLoss", DbType.Boolean, EmsModel.IsLoss),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.InventoryListDetail EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update InventoryListDetail set ");
					sbSql.Append("InventoryListId=@in_InventoryListId,EquipId=@in_EquipId,AssetNumber=@in_AssetNumber,AssetName=@in_AssetName,RoomId=@in_RoomId,SourceRoomId=@in_SourceRoomId,Status=@in_Status,IsLoss=@in_IsLoss,Remarks=@in_Remarks");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_InventoryListId", DbType.Int32, EmsModel.InventoryListId),dbHelper.CreateInDbParameter("@in_EquipId", DbType.Int32, EmsModel.EquipId),dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsModel.AssetNumber),dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsModel.AssetName),dbHelper.CreateInDbParameter("@in_RoomId", DbType.Int32, EmsModel.RoomId),dbHelper.CreateInDbParameter("@in_SourceRoomId", DbType.Int32, EmsModel.SourceRoomId),dbHelper.CreateInDbParameter("@in_Status", DbType.Int32, EmsModel.Status),dbHelper.CreateInDbParameter("@in_IsLoss", DbType.Boolean, EmsModel.IsLoss),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM InventoryListDetail");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM InventoryListDetail");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM InventoryListDetail");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.InventoryListDetail> GetListByPage(EmsModel.InventoryListDetail EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "InventoryListDetail";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.InventoryListId != null){strWhere += " and InventoryListId=@in_InventoryListId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InventoryListId", DbType.String, EmsMod.InventoryListId)); }if (EmsMod.EquipId != null){strWhere += " and EquipId=@in_EquipId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipId", DbType.String, EmsMod.EquipId)); }if (EmsMod.AssetNumber != null){strWhere += " and AssetNumber=@in_AssetNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsMod.AssetNumber)); }if (EmsMod.AssetName != null){strWhere += " and AssetName=@in_AssetName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsMod.AssetName)); }if (EmsMod.RoomId != null){strWhere += " and RoomId=@in_RoomId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RoomId", DbType.String, EmsMod.RoomId)); }if (EmsMod.SourceRoomId != null){strWhere += " and SourceRoomId=@in_SourceRoomId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_SourceRoomId", DbType.String, EmsMod.SourceRoomId)); }if (EmsMod.Status != null){strWhere += " and Status=@in_Status ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Status", DbType.String, EmsMod.Status)); }if (EmsMod.IsLoss != null){strWhere += " and IsLoss=@in_IsLoss ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsLoss", DbType.String, EmsMod.IsLoss)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.InventoryListDetail> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.InventoryListDetail EmsMod)
        {
            string TableName = "InventoryListDetail";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.InventoryListId != null){strWhere += " and InventoryListId=@in_InventoryListId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InventoryListId", DbType.String, EmsMod.InventoryListId)); }if (EmsMod.EquipId != null){strWhere += " and EquipId=@in_EquipId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipId", DbType.String, EmsMod.EquipId)); }if (EmsMod.AssetNumber != null){strWhere += " and AssetNumber=@in_AssetNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetNumber", DbType.String, EmsMod.AssetNumber)); }if (EmsMod.AssetName != null){strWhere += " and AssetName=@in_AssetName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AssetName", DbType.String, EmsMod.AssetName)); }if (EmsMod.RoomId != null){strWhere += " and RoomId=@in_RoomId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RoomId", DbType.String, EmsMod.RoomId)); }if (EmsMod.SourceRoomId != null){strWhere += " and SourceRoomId=@in_SourceRoomId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_SourceRoomId", DbType.String, EmsMod.SourceRoomId)); }if (EmsMod.Status != null){strWhere += " and Status=@in_Status ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Status", DbType.String, EmsMod.Status)); }if (EmsMod.IsLoss != null){strWhere += " and IsLoss=@in_IsLoss ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsLoss", DbType.String, EmsMod.IsLoss)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.InventoryListDetail EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.InventoryListId = dr["InventoryListId"] as int?;EmsModel.EquipId = dr["EquipId"] as int?;EmsModel.AssetNumber = dr["AssetNumber"] as string;EmsModel.AssetName = dr["AssetName"] as string;EmsModel.RoomId = dr["RoomId"] as int?;EmsModel.SourceRoomId = dr["SourceRoomId"] as int?;EmsModel.Status = dr["Status"] as int?;EmsModel.IsLoss = dr["IsLoss"] as bool?;EmsModel.Remarks = dr["Remarks"] as string;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.InventoryListDetail> GetList(DataTable dt)
        {
            List<EmsModel.InventoryListDetail> lst = new List<EmsModel.InventoryListDetail>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.InventoryListDetail mod = new EmsModel.InventoryListDetail();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.InventoryListDetail EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.InventoryListId = dr["InventoryListId"] as int?;EmsModel.EquipId = dr["EquipId"] as int?;EmsModel.AssetNumber = dr["AssetNumber"] as string;EmsModel.AssetName = dr["AssetName"] as string;EmsModel.RoomId = dr["RoomId"] as int?;EmsModel.SourceRoomId = dr["SourceRoomId"] as int?;EmsModel.Status = dr["Status"] as int?;EmsModel.IsLoss = dr["IsLoss"] as bool?;EmsModel.Remarks = dr["Remarks"] as string;
        }		

    }

	/// </summary>
	///	教学计划表实体类30
	/// </summary>
    public partial class InventoryPlan: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.InventoryPlan EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO InventoryPlan(");
						sbSql.Append("Name,InventoryNo,InventoryTime,Type,Status,Creator,CreateTime,Editor,UpdateTime,IsDelete,IsGenerate)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_InventoryNo,@in_InventoryTime,@in_Type,@in_Status,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_IsGenerate)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_InventoryNo", DbType.String, EmsModel.InventoryNo),dbHelper.CreateInDbParameter("@in_InventoryTime", DbType.DateTime, EmsModel.InventoryTime),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Status", DbType.Byte, EmsModel.Status),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_IsGenerate", DbType.Byte, EmsModel.IsGenerate)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.InventoryPlan EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO InventoryPlan(");
						sbSql.Append("Name,InventoryNo,InventoryTime,Type,Status,Creator,CreateTime,Editor,UpdateTime,IsDelete,IsGenerate)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_InventoryNo,@in_InventoryTime,@in_Type,@in_Status,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_IsGenerate)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_InventoryNo", DbType.String, EmsModel.InventoryNo),dbHelper.CreateInDbParameter("@in_InventoryTime", DbType.DateTime, EmsModel.InventoryTime),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Status", DbType.Byte, EmsModel.Status),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_IsGenerate", DbType.Byte, EmsModel.IsGenerate)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.InventoryPlan EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update InventoryPlan set ");
					sbSql.Append("Name=@in_Name,InventoryNo=@in_InventoryNo,InventoryTime=@in_InventoryTime,Type=@in_Type,Status=@in_Status,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,IsGenerate=@in_IsGenerate");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_InventoryNo", DbType.String, EmsModel.InventoryNo),dbHelper.CreateInDbParameter("@in_InventoryTime", DbType.DateTime, EmsModel.InventoryTime),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Status", DbType.Byte, EmsModel.Status),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_IsGenerate", DbType.Byte, EmsModel.IsGenerate)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.InventoryPlan EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update InventoryPlan set ");
					sbSql.Append("Name=@in_Name,InventoryNo=@in_InventoryNo,InventoryTime=@in_InventoryTime,Type=@in_Type,Status=@in_Status,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,IsGenerate=@in_IsGenerate");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_InventoryNo", DbType.String, EmsModel.InventoryNo),dbHelper.CreateInDbParameter("@in_InventoryTime", DbType.DateTime, EmsModel.InventoryTime),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Status", DbType.Byte, EmsModel.Status),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_IsGenerate", DbType.Byte, EmsModel.IsGenerate)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM InventoryPlan");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM InventoryPlan");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM InventoryPlan");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.InventoryPlan> GetListByPage(EmsModel.InventoryPlan EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "InventoryPlan";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.InventoryNo != null){strWhere += " and InventoryNo=@in_InventoryNo ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InventoryNo", DbType.String, EmsMod.InventoryNo)); }if (EmsMod.InventoryTime != null){strWhere += " and InventoryTime=@in_InventoryTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InventoryTime", DbType.String, EmsMod.InventoryTime)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.Status != null){strWhere += " and Status=@in_Status ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Status", DbType.String, EmsMod.Status)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.IsGenerate != null){strWhere += " and IsGenerate=@in_IsGenerate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsGenerate", DbType.String, EmsMod.IsGenerate)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.InventoryPlan> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.InventoryPlan EmsMod)
        {
            string TableName = "InventoryPlan";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.InventoryNo != null){strWhere += " and InventoryNo=@in_InventoryNo ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InventoryNo", DbType.String, EmsMod.InventoryNo)); }if (EmsMod.InventoryTime != null){strWhere += " and InventoryTime=@in_InventoryTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InventoryTime", DbType.String, EmsMod.InventoryTime)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.Status != null){strWhere += " and Status=@in_Status ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Status", DbType.String, EmsMod.Status)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.IsGenerate != null){strWhere += " and IsGenerate=@in_IsGenerate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsGenerate", DbType.String, EmsMod.IsGenerate)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.InventoryPlan EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.InventoryNo = dr["InventoryNo"] as string;EmsModel.InventoryTime = dr["InventoryTime"] as DateTime?;EmsModel.Type = dr["Type"] as Byte?;EmsModel.Status = dr["Status"] as Byte?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.IsGenerate = dr["IsGenerate"] as Byte?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.InventoryPlan> GetList(DataTable dt)
        {
            List<EmsModel.InventoryPlan> lst = new List<EmsModel.InventoryPlan>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.InventoryPlan mod = new EmsModel.InventoryPlan();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.InventoryPlan EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.InventoryNo = dr["InventoryNo"] as string;EmsModel.InventoryTime = dr["InventoryTime"] as DateTime?;EmsModel.Type = dr["Type"] as Byte?;EmsModel.Status = dr["Status"] as Byte?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.IsGenerate = dr["IsGenerate"] as Byte?;
        }		

    }

	/// </summary>
	///	教学计划表实体类31
	/// </summary>
    public partial class LearnYear: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.LearnYear EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO LearnYear(");
						sbSql.Append("Name,StartDate,EndDate,DataCollectionTime,Creator,CreateTime,Editor,UpdateTime,IsDelete,Remarks,UseStatus)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_StartDate,@in_EndDate,@in_DataCollectionTime,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_Remarks,@in_UseStatus)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_EndDate", DbType.DateTime, EmsModel.EndDate),dbHelper.CreateInDbParameter("@in_DataCollectionTime", DbType.Byte, EmsModel.DataCollectionTime),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.LearnYear EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO LearnYear(");
						sbSql.Append("Name,StartDate,EndDate,DataCollectionTime,Creator,CreateTime,Editor,UpdateTime,IsDelete,Remarks,UseStatus)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_StartDate,@in_EndDate,@in_DataCollectionTime,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_Remarks,@in_UseStatus)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_EndDate", DbType.DateTime, EmsModel.EndDate),dbHelper.CreateInDbParameter("@in_DataCollectionTime", DbType.Byte, EmsModel.DataCollectionTime),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.LearnYear EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update LearnYear set ");
					sbSql.Append("Name=@in_Name,StartDate=@in_StartDate,EndDate=@in_EndDate,DataCollectionTime=@in_DataCollectionTime,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,Remarks=@in_Remarks,UseStatus=@in_UseStatus");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_EndDate", DbType.DateTime, EmsModel.EndDate),dbHelper.CreateInDbParameter("@in_DataCollectionTime", DbType.Byte, EmsModel.DataCollectionTime),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.LearnYear EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update LearnYear set ");
					sbSql.Append("Name=@in_Name,StartDate=@in_StartDate,EndDate=@in_EndDate,DataCollectionTime=@in_DataCollectionTime,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,Remarks=@in_Remarks,UseStatus=@in_UseStatus");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_EndDate", DbType.DateTime, EmsModel.EndDate),dbHelper.CreateInDbParameter("@in_DataCollectionTime", DbType.Byte, EmsModel.DataCollectionTime),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM LearnYear");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM LearnYear");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM LearnYear");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.LearnYear> GetListByPage(EmsModel.LearnYear EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "LearnYear";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.StartDate != null){strWhere += " and StartDate=@in_StartDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StartDate", DbType.String, EmsMod.StartDate)); }if (EmsMod.EndDate != null){strWhere += " and EndDate=@in_EndDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EndDate", DbType.String, EmsMod.EndDate)); }if (EmsMod.DataCollectionTime != null){strWhere += " and DataCollectionTime=@in_DataCollectionTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_DataCollectionTime", DbType.String, EmsMod.DataCollectionTime)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.LearnYear> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.LearnYear EmsMod)
        {
            string TableName = "LearnYear";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.StartDate != null){strWhere += " and StartDate=@in_StartDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StartDate", DbType.String, EmsMod.StartDate)); }if (EmsMod.EndDate != null){strWhere += " and EndDate=@in_EndDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EndDate", DbType.String, EmsMod.EndDate)); }if (EmsMod.DataCollectionTime != null){strWhere += " and DataCollectionTime=@in_DataCollectionTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_DataCollectionTime", DbType.String, EmsMod.DataCollectionTime)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.LearnYear EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.StartDate = dr["StartDate"] as DateTime?;EmsModel.EndDate = dr["EndDate"] as DateTime?;EmsModel.DataCollectionTime = dr["DataCollectionTime"] as Byte?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.UseStatus = dr["UseStatus"] as Byte?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.LearnYear> GetList(DataTable dt)
        {
            List<EmsModel.LearnYear> lst = new List<EmsModel.LearnYear>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.LearnYear mod = new EmsModel.LearnYear();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.LearnYear EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.StartDate = dr["StartDate"] as DateTime?;EmsModel.EndDate = dr["EndDate"] as DateTime?;EmsModel.DataCollectionTime = dr["DataCollectionTime"] as Byte?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.UseStatus = dr["UseStatus"] as Byte?;
        }		

    }

	/// </summary>
	///	教学计划表实体类32
	/// </summary>
    public partial class LogInfo: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.LogInfo EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO LogInfo(");
						sbSql.Append("LoginName,IP,Module,Type,Operation,CreateTime,Remarks)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_LoginName,@in_IP,@in_Module,@in_Type,@in_Operation,@in_CreateTime,@in_Remarks)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsModel.LoginName),dbHelper.CreateInDbParameter("@in_IP", DbType.String, EmsModel.IP),dbHelper.CreateInDbParameter("@in_Module", DbType.String, EmsModel.Module),dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Operation", DbType.String, EmsModel.Operation),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.LogInfo EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO LogInfo(");
						sbSql.Append("LoginName,IP,Module,Type,Operation,CreateTime,Remarks)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_LoginName,@in_IP,@in_Module,@in_Type,@in_Operation,@in_CreateTime,@in_Remarks)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsModel.LoginName),dbHelper.CreateInDbParameter("@in_IP", DbType.String, EmsModel.IP),dbHelper.CreateInDbParameter("@in_Module", DbType.String, EmsModel.Module),dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Operation", DbType.String, EmsModel.Operation),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.LogInfo EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update LogInfo set ");
					sbSql.Append("LoginName=@in_LoginName,IP=@in_IP,Module=@in_Module,Type=@in_Type,Operation=@in_Operation,CreateTime=@in_CreateTime,Remarks=@in_Remarks");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsModel.LoginName),dbHelper.CreateInDbParameter("@in_IP", DbType.String, EmsModel.IP),dbHelper.CreateInDbParameter("@in_Module", DbType.String, EmsModel.Module),dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Operation", DbType.String, EmsModel.Operation),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.LogInfo EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update LogInfo set ");
					sbSql.Append("LoginName=@in_LoginName,IP=@in_IP,Module=@in_Module,Type=@in_Type,Operation=@in_Operation,CreateTime=@in_CreateTime,Remarks=@in_Remarks");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsModel.LoginName),dbHelper.CreateInDbParameter("@in_IP", DbType.String, EmsModel.IP),dbHelper.CreateInDbParameter("@in_Module", DbType.String, EmsModel.Module),dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Operation", DbType.String, EmsModel.Operation),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM LogInfo");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM LogInfo");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM LogInfo");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.LogInfo> GetListByPage(EmsModel.LogInfo EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "LogInfo";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.LoginName != null){strWhere += " and LoginName=@in_LoginName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsMod.LoginName)); }if (EmsMod.IP != null){strWhere += " and IP=@in_IP ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IP", DbType.String, EmsMod.IP)); }if (EmsMod.Module != null){strWhere += " and Module=@in_Module ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Module", DbType.String, EmsMod.Module)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.Operation != null){strWhere += " and Operation=@in_Operation ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Operation", DbType.String, EmsMod.Operation)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.LogInfo> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.LogInfo EmsMod)
        {
            string TableName = "LogInfo";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.LoginName != null){strWhere += " and LoginName=@in_LoginName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsMod.LoginName)); }if (EmsMod.IP != null){strWhere += " and IP=@in_IP ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IP", DbType.String, EmsMod.IP)); }if (EmsMod.Module != null){strWhere += " and Module=@in_Module ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Module", DbType.String, EmsMod.Module)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.Operation != null){strWhere += " and Operation=@in_Operation ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Operation", DbType.String, EmsMod.Operation)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.LogInfo EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.LoginName = dr["LoginName"] as string;EmsModel.IP = dr["IP"] as string;EmsModel.Module = dr["Module"] as string;EmsModel.Type = dr["Type"] as string;EmsModel.Operation = dr["Operation"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Remarks = dr["Remarks"] as string;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.LogInfo> GetList(DataTable dt)
        {
            List<EmsModel.LogInfo> lst = new List<EmsModel.LogInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.LogInfo mod = new EmsModel.LogInfo();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.LogInfo EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.LoginName = dr["LoginName"] as string;EmsModel.IP = dr["IP"] as string;EmsModel.Module = dr["Module"] as string;EmsModel.Type = dr["Type"] as string;EmsModel.Operation = dr["Operation"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Remarks = dr["Remarks"] as string;
        }		

    }

	/// </summary>
	///	教学计划表实体类33
	/// </summary>
    public partial class MenuInfo: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.MenuInfo EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO MenuInfo(");
						sbSql.Append("Name,Pid,Url,Description,isMeu,isShow,iconClass,sortId)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_Pid,@in_Url,@in_Description,@in_isMeu,@in_isShow,@in_iconClass,@in_sortId)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Pid", DbType.Int32, EmsModel.Pid),dbHelper.CreateInDbParameter("@in_Url", DbType.String, EmsModel.Url),dbHelper.CreateInDbParameter("@in_Description", DbType.String, EmsModel.Description),dbHelper.CreateInDbParameter("@in_isMeu", DbType.Boolean, EmsModel.isMeu),dbHelper.CreateInDbParameter("@in_isShow", DbType.Byte, EmsModel.isShow),dbHelper.CreateInDbParameter("@in_iconClass", DbType.String, EmsModel.iconClass),dbHelper.CreateInDbParameter("@in_sortId", DbType.Int32, EmsModel.sortId)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.MenuInfo EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO MenuInfo(");
						sbSql.Append("Name,Pid,Url,Description,isMeu,isShow,iconClass,sortId)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_Pid,@in_Url,@in_Description,@in_isMeu,@in_isShow,@in_iconClass,@in_sortId)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Pid", DbType.Int32, EmsModel.Pid),dbHelper.CreateInDbParameter("@in_Url", DbType.String, EmsModel.Url),dbHelper.CreateInDbParameter("@in_Description", DbType.String, EmsModel.Description),dbHelper.CreateInDbParameter("@in_isMeu", DbType.Boolean, EmsModel.isMeu),dbHelper.CreateInDbParameter("@in_isShow", DbType.Byte, EmsModel.isShow),dbHelper.CreateInDbParameter("@in_iconClass", DbType.String, EmsModel.iconClass),dbHelper.CreateInDbParameter("@in_sortId", DbType.Int32, EmsModel.sortId)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.MenuInfo EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update MenuInfo set ");
					sbSql.Append("Name=@in_Name,Pid=@in_Pid,Url=@in_Url,Description=@in_Description,isMeu=@in_isMeu,isShow=@in_isShow,iconClass=@in_iconClass,sortId=@in_sortId");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Pid", DbType.Int32, EmsModel.Pid),dbHelper.CreateInDbParameter("@in_Url", DbType.String, EmsModel.Url),dbHelper.CreateInDbParameter("@in_Description", DbType.String, EmsModel.Description),dbHelper.CreateInDbParameter("@in_isMeu", DbType.Boolean, EmsModel.isMeu),dbHelper.CreateInDbParameter("@in_isShow", DbType.Byte, EmsModel.isShow),dbHelper.CreateInDbParameter("@in_iconClass", DbType.String, EmsModel.iconClass),dbHelper.CreateInDbParameter("@in_sortId", DbType.Int32, EmsModel.sortId)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.MenuInfo EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update MenuInfo set ");
					sbSql.Append("Name=@in_Name,Pid=@in_Pid,Url=@in_Url,Description=@in_Description,isMeu=@in_isMeu,isShow=@in_isShow,iconClass=@in_iconClass,sortId=@in_sortId");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Pid", DbType.Int32, EmsModel.Pid),dbHelper.CreateInDbParameter("@in_Url", DbType.String, EmsModel.Url),dbHelper.CreateInDbParameter("@in_Description", DbType.String, EmsModel.Description),dbHelper.CreateInDbParameter("@in_isMeu", DbType.Boolean, EmsModel.isMeu),dbHelper.CreateInDbParameter("@in_isShow", DbType.Byte, EmsModel.isShow),dbHelper.CreateInDbParameter("@in_iconClass", DbType.String, EmsModel.iconClass),dbHelper.CreateInDbParameter("@in_sortId", DbType.Int32, EmsModel.sortId)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM MenuInfo");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM MenuInfo");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM MenuInfo");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.MenuInfo> GetListByPage(EmsModel.MenuInfo EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "MenuInfo";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.Pid != null){strWhere += " and Pid=@in_Pid ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Pid", DbType.String, EmsMod.Pid)); }if (EmsMod.Url != null){strWhere += " and Url=@in_Url ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Url", DbType.String, EmsMod.Url)); }if (EmsMod.Description != null){strWhere += " and Description=@in_Description ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Description", DbType.String, EmsMod.Description)); }if (EmsMod.isMeu != null){strWhere += " and isMeu=@in_isMeu ";parmsList.Add(dbHelper.CreateInDbParameter("@in_isMeu", DbType.String, EmsMod.isMeu)); }if (EmsMod.isShow != null){strWhere += " and isShow=@in_isShow ";parmsList.Add(dbHelper.CreateInDbParameter("@in_isShow", DbType.String, EmsMod.isShow)); }if (EmsMod.iconClass != null){strWhere += " and iconClass=@in_iconClass ";parmsList.Add(dbHelper.CreateInDbParameter("@in_iconClass", DbType.String, EmsMod.iconClass)); }if (EmsMod.sortId != null){strWhere += " and sortId=@in_sortId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_sortId", DbType.String, EmsMod.sortId)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.MenuInfo> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.MenuInfo EmsMod)
        {
            string TableName = "MenuInfo";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.Pid != null){strWhere += " and Pid=@in_Pid ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Pid", DbType.String, EmsMod.Pid)); }if (EmsMod.Url != null){strWhere += " and Url=@in_Url ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Url", DbType.String, EmsMod.Url)); }if (EmsMod.Description != null){strWhere += " and Description=@in_Description ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Description", DbType.String, EmsMod.Description)); }if (EmsMod.isMeu != null){strWhere += " and isMeu=@in_isMeu ";parmsList.Add(dbHelper.CreateInDbParameter("@in_isMeu", DbType.String, EmsMod.isMeu)); }if (EmsMod.isShow != null){strWhere += " and isShow=@in_isShow ";parmsList.Add(dbHelper.CreateInDbParameter("@in_isShow", DbType.String, EmsMod.isShow)); }if (EmsMod.iconClass != null){strWhere += " and iconClass=@in_iconClass ";parmsList.Add(dbHelper.CreateInDbParameter("@in_iconClass", DbType.String, EmsMod.iconClass)); }if (EmsMod.sortId != null){strWhere += " and sortId=@in_sortId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_sortId", DbType.String, EmsMod.sortId)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.MenuInfo EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.Pid = dr["Pid"] as int?;EmsModel.Url = dr["Url"] as string;EmsModel.Description = dr["Description"] as string;EmsModel.isMeu = dr["isMeu"] as bool?;EmsModel.isShow = dr["isShow"] as Byte?;EmsModel.iconClass = dr["iconClass"] as string;EmsModel.sortId = dr["sortId"] as int?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.MenuInfo> GetList(DataTable dt)
        {
            List<EmsModel.MenuInfo> lst = new List<EmsModel.MenuInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.MenuInfo mod = new EmsModel.MenuInfo();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.MenuInfo EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.Pid = dr["Pid"] as int?;EmsModel.Url = dr["Url"] as string;EmsModel.Description = dr["Description"] as string;EmsModel.isMeu = dr["isMeu"] as bool?;EmsModel.isShow = dr["isShow"] as Byte?;EmsModel.iconClass = dr["iconClass"] as string;EmsModel.sortId = dr["sortId"] as int?;
        }		

    }

	/// </summary>
	///	教学计划表实体类34
	/// </summary>
    public partial class OrderEquipDetail: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.OrderEquipDetail EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO OrderEquipDetail(");
						sbSql.Append("InventoryKindId,OrderId,InstrumentEquip,EquipDetailName,EquipId,Count,LendTime,ReturnTime,Damage,Type,Remarks,Attachment)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_InventoryKindId,@in_OrderId,@in_InstrumentEquip,@in_EquipDetailName,@in_EquipId,@in_Count,@in_LendTime,@in_ReturnTime,@in_Damage,@in_Type,@in_Remarks,@in_Attachment)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_InventoryKindId", DbType.Int32, EmsModel.InventoryKindId),dbHelper.CreateInDbParameter("@in_OrderId", DbType.Int32, EmsModel.OrderId),dbHelper.CreateInDbParameter("@in_InstrumentEquip", DbType.String, EmsModel.InstrumentEquip),dbHelper.CreateInDbParameter("@in_EquipDetailName", DbType.String, EmsModel.EquipDetailName),dbHelper.CreateInDbParameter("@in_EquipId", DbType.String, EmsModel.EquipId),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_LendTime", DbType.DateTime, EmsModel.LendTime),dbHelper.CreateInDbParameter("@in_ReturnTime", DbType.DateTime, EmsModel.ReturnTime),dbHelper.CreateInDbParameter("@in_Damage", DbType.String, EmsModel.Damage),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Attachment", DbType.String, EmsModel.Attachment)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.OrderEquipDetail EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO OrderEquipDetail(");
						sbSql.Append("InventoryKindId,OrderId,InstrumentEquip,EquipDetailName,EquipId,Count,LendTime,ReturnTime,Damage,Type,Remarks,Attachment)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_InventoryKindId,@in_OrderId,@in_InstrumentEquip,@in_EquipDetailName,@in_EquipId,@in_Count,@in_LendTime,@in_ReturnTime,@in_Damage,@in_Type,@in_Remarks,@in_Attachment)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_InventoryKindId", DbType.Int32, EmsModel.InventoryKindId),dbHelper.CreateInDbParameter("@in_OrderId", DbType.Int32, EmsModel.OrderId),dbHelper.CreateInDbParameter("@in_InstrumentEquip", DbType.String, EmsModel.InstrumentEquip),dbHelper.CreateInDbParameter("@in_EquipDetailName", DbType.String, EmsModel.EquipDetailName),dbHelper.CreateInDbParameter("@in_EquipId", DbType.String, EmsModel.EquipId),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_LendTime", DbType.DateTime, EmsModel.LendTime),dbHelper.CreateInDbParameter("@in_ReturnTime", DbType.DateTime, EmsModel.ReturnTime),dbHelper.CreateInDbParameter("@in_Damage", DbType.String, EmsModel.Damage),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Attachment", DbType.String, EmsModel.Attachment)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.OrderEquipDetail EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update OrderEquipDetail set ");
					sbSql.Append("InventoryKindId=@in_InventoryKindId,OrderId=@in_OrderId,InstrumentEquip=@in_InstrumentEquip,EquipDetailName=@in_EquipDetailName,EquipId=@in_EquipId,Count=@in_Count,LendTime=@in_LendTime,ReturnTime=@in_ReturnTime,Damage=@in_Damage,Type=@in_Type,Remarks=@in_Remarks,Attachment=@in_Attachment");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_InventoryKindId", DbType.Int32, EmsModel.InventoryKindId),dbHelper.CreateInDbParameter("@in_OrderId", DbType.Int32, EmsModel.OrderId),dbHelper.CreateInDbParameter("@in_InstrumentEquip", DbType.String, EmsModel.InstrumentEquip),dbHelper.CreateInDbParameter("@in_EquipDetailName", DbType.String, EmsModel.EquipDetailName),dbHelper.CreateInDbParameter("@in_EquipId", DbType.String, EmsModel.EquipId),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_LendTime", DbType.DateTime, EmsModel.LendTime),dbHelper.CreateInDbParameter("@in_ReturnTime", DbType.DateTime, EmsModel.ReturnTime),dbHelper.CreateInDbParameter("@in_Damage", DbType.String, EmsModel.Damage),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Attachment", DbType.String, EmsModel.Attachment)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.OrderEquipDetail EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update OrderEquipDetail set ");
					sbSql.Append("InventoryKindId=@in_InventoryKindId,OrderId=@in_OrderId,InstrumentEquip=@in_InstrumentEquip,EquipDetailName=@in_EquipDetailName,EquipId=@in_EquipId,Count=@in_Count,LendTime=@in_LendTime,ReturnTime=@in_ReturnTime,Damage=@in_Damage,Type=@in_Type,Remarks=@in_Remarks,Attachment=@in_Attachment");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_InventoryKindId", DbType.Int32, EmsModel.InventoryKindId),dbHelper.CreateInDbParameter("@in_OrderId", DbType.Int32, EmsModel.OrderId),dbHelper.CreateInDbParameter("@in_InstrumentEquip", DbType.String, EmsModel.InstrumentEquip),dbHelper.CreateInDbParameter("@in_EquipDetailName", DbType.String, EmsModel.EquipDetailName),dbHelper.CreateInDbParameter("@in_EquipId", DbType.String, EmsModel.EquipId),dbHelper.CreateInDbParameter("@in_Count", DbType.Int32, EmsModel.Count),dbHelper.CreateInDbParameter("@in_LendTime", DbType.DateTime, EmsModel.LendTime),dbHelper.CreateInDbParameter("@in_ReturnTime", DbType.DateTime, EmsModel.ReturnTime),dbHelper.CreateInDbParameter("@in_Damage", DbType.String, EmsModel.Damage),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_Attachment", DbType.String, EmsModel.Attachment)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM OrderEquipDetail");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM OrderEquipDetail");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM OrderEquipDetail");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.OrderEquipDetail> GetListByPage(EmsModel.OrderEquipDetail EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "OrderEquipDetail";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.InventoryKindId != null){strWhere += " and InventoryKindId=@in_InventoryKindId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InventoryKindId", DbType.String, EmsMod.InventoryKindId)); }if (EmsMod.OrderId != null){strWhere += " and OrderId=@in_OrderId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_OrderId", DbType.String, EmsMod.OrderId)); }if (EmsMod.InstrumentEquip != null){strWhere += " and InstrumentEquip=@in_InstrumentEquip ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InstrumentEquip", DbType.String, EmsMod.InstrumentEquip)); }if (EmsMod.EquipDetailName != null){strWhere += " and EquipDetailName=@in_EquipDetailName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipDetailName", DbType.String, EmsMod.EquipDetailName)); }if (EmsMod.EquipId != null){strWhere += " and EquipId=@in_EquipId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipId", DbType.String, EmsMod.EquipId)); }if (EmsMod.Count != null){strWhere += " and Count=@in_Count ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Count", DbType.String, EmsMod.Count)); }if (EmsMod.LendTime != null){strWhere += " and LendTime=@in_LendTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LendTime", DbType.String, EmsMod.LendTime)); }if (EmsMod.ReturnTime != null){strWhere += " and ReturnTime=@in_ReturnTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ReturnTime", DbType.String, EmsMod.ReturnTime)); }if (EmsMod.Damage != null){strWhere += " and Damage=@in_Damage ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Damage", DbType.String, EmsMod.Damage)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.Attachment != null){strWhere += " and Attachment=@in_Attachment ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Attachment", DbType.String, EmsMod.Attachment)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.OrderEquipDetail> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.OrderEquipDetail EmsMod)
        {
            string TableName = "OrderEquipDetail";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.InventoryKindId != null){strWhere += " and InventoryKindId=@in_InventoryKindId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InventoryKindId", DbType.String, EmsMod.InventoryKindId)); }if (EmsMod.OrderId != null){strWhere += " and OrderId=@in_OrderId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_OrderId", DbType.String, EmsMod.OrderId)); }if (EmsMod.InstrumentEquip != null){strWhere += " and InstrumentEquip=@in_InstrumentEquip ";parmsList.Add(dbHelper.CreateInDbParameter("@in_InstrumentEquip", DbType.String, EmsMod.InstrumentEquip)); }if (EmsMod.EquipDetailName != null){strWhere += " and EquipDetailName=@in_EquipDetailName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipDetailName", DbType.String, EmsMod.EquipDetailName)); }if (EmsMod.EquipId != null){strWhere += " and EquipId=@in_EquipId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipId", DbType.String, EmsMod.EquipId)); }if (EmsMod.Count != null){strWhere += " and Count=@in_Count ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Count", DbType.String, EmsMod.Count)); }if (EmsMod.LendTime != null){strWhere += " and LendTime=@in_LendTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LendTime", DbType.String, EmsMod.LendTime)); }if (EmsMod.ReturnTime != null){strWhere += " and ReturnTime=@in_ReturnTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ReturnTime", DbType.String, EmsMod.ReturnTime)); }if (EmsMod.Damage != null){strWhere += " and Damage=@in_Damage ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Damage", DbType.String, EmsMod.Damage)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.Attachment != null){strWhere += " and Attachment=@in_Attachment ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Attachment", DbType.String, EmsMod.Attachment)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.OrderEquipDetail EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.InventoryKindId = dr["InventoryKindId"] as int?;EmsModel.OrderId = dr["OrderId"] as int?;EmsModel.InstrumentEquip = dr["InstrumentEquip"] as string;EmsModel.EquipDetailName = dr["EquipDetailName"] as string;EmsModel.EquipId = dr["EquipId"] as string;EmsModel.Count = dr["Count"] as int?;EmsModel.LendTime = dr["LendTime"] as DateTime?;EmsModel.ReturnTime = dr["ReturnTime"] as DateTime?;EmsModel.Damage = dr["Damage"] as string;EmsModel.Type = dr["Type"] as Byte?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.Attachment = dr["Attachment"] as string;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.OrderEquipDetail> GetList(DataTable dt)
        {
            List<EmsModel.OrderEquipDetail> lst = new List<EmsModel.OrderEquipDetail>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.OrderEquipDetail mod = new EmsModel.OrderEquipDetail();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.OrderEquipDetail EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.InventoryKindId = dr["InventoryKindId"] as int?;EmsModel.OrderId = dr["OrderId"] as int?;EmsModel.InstrumentEquip = dr["InstrumentEquip"] as string;EmsModel.EquipDetailName = dr["EquipDetailName"] as string;EmsModel.EquipId = dr["EquipId"] as string;EmsModel.Count = dr["Count"] as int?;EmsModel.LendTime = dr["LendTime"] as DateTime?;EmsModel.ReturnTime = dr["ReturnTime"] as DateTime?;EmsModel.Damage = dr["Damage"] as string;EmsModel.Type = dr["Type"] as Byte?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.Attachment = dr["Attachment"] as string;
        }		

    }

	/// </summary>
	///	教学计划表实体类35
	/// </summary>
    public partial class OrderInfo: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.OrderInfo EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO OrderInfo(");
						sbSql.Append("OrderNo,LoanName,IDCard,ExperimentId,Attachment,Type,Status,Remarks,LendTime,ReturnTime,Creator,CreateTime,Editor,UpdateTime,IsDelete,stuLoanIDCard)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_OrderNo,@in_LoanName,@in_IDCard,@in_ExperimentId,@in_Attachment,@in_Type,@in_Status,@in_Remarks,@in_LendTime,@in_ReturnTime,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_stuLoanIDCard)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_OrderNo", DbType.String, EmsModel.OrderNo),dbHelper.CreateInDbParameter("@in_LoanName", DbType.String, EmsModel.LoanName),dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsModel.IDCard),dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.Int32, EmsModel.ExperimentId),dbHelper.CreateInDbParameter("@in_Attachment", DbType.String, EmsModel.Attachment),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Status", DbType.Int32, EmsModel.Status),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_LendTime", DbType.DateTime, EmsModel.LendTime),dbHelper.CreateInDbParameter("@in_ReturnTime", DbType.DateTime, EmsModel.ReturnTime),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_stuLoanIDCard", DbType.String, EmsModel.stuLoanIDCard)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.OrderInfo EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO OrderInfo(");
						sbSql.Append("OrderNo,LoanName,IDCard,ExperimentId,Attachment,Type,Status,Remarks,LendTime,ReturnTime,Creator,CreateTime,Editor,UpdateTime,IsDelete,stuLoanIDCard)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_OrderNo,@in_LoanName,@in_IDCard,@in_ExperimentId,@in_Attachment,@in_Type,@in_Status,@in_Remarks,@in_LendTime,@in_ReturnTime,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_stuLoanIDCard)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_OrderNo", DbType.String, EmsModel.OrderNo),dbHelper.CreateInDbParameter("@in_LoanName", DbType.String, EmsModel.LoanName),dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsModel.IDCard),dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.Int32, EmsModel.ExperimentId),dbHelper.CreateInDbParameter("@in_Attachment", DbType.String, EmsModel.Attachment),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Status", DbType.Int32, EmsModel.Status),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_LendTime", DbType.DateTime, EmsModel.LendTime),dbHelper.CreateInDbParameter("@in_ReturnTime", DbType.DateTime, EmsModel.ReturnTime),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_stuLoanIDCard", DbType.String, EmsModel.stuLoanIDCard)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.OrderInfo EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update OrderInfo set ");
					sbSql.Append("OrderNo=@in_OrderNo,LoanName=@in_LoanName,IDCard=@in_IDCard,ExperimentId=@in_ExperimentId,Attachment=@in_Attachment,Type=@in_Type,Status=@in_Status,Remarks=@in_Remarks,LendTime=@in_LendTime,ReturnTime=@in_ReturnTime,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,stuLoanIDCard=@in_stuLoanIDCard");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_OrderNo", DbType.String, EmsModel.OrderNo),dbHelper.CreateInDbParameter("@in_LoanName", DbType.String, EmsModel.LoanName),dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsModel.IDCard),dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.Int32, EmsModel.ExperimentId),dbHelper.CreateInDbParameter("@in_Attachment", DbType.String, EmsModel.Attachment),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Status", DbType.Int32, EmsModel.Status),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_LendTime", DbType.DateTime, EmsModel.LendTime),dbHelper.CreateInDbParameter("@in_ReturnTime", DbType.DateTime, EmsModel.ReturnTime),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_stuLoanIDCard", DbType.String, EmsModel.stuLoanIDCard)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.OrderInfo EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update OrderInfo set ");
					sbSql.Append("OrderNo=@in_OrderNo,LoanName=@in_LoanName,IDCard=@in_IDCard,ExperimentId=@in_ExperimentId,Attachment=@in_Attachment,Type=@in_Type,Status=@in_Status,Remarks=@in_Remarks,LendTime=@in_LendTime,ReturnTime=@in_ReturnTime,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,stuLoanIDCard=@in_stuLoanIDCard");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_OrderNo", DbType.String, EmsModel.OrderNo),dbHelper.CreateInDbParameter("@in_LoanName", DbType.String, EmsModel.LoanName),dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsModel.IDCard),dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.Int32, EmsModel.ExperimentId),dbHelper.CreateInDbParameter("@in_Attachment", DbType.String, EmsModel.Attachment),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_Status", DbType.Int32, EmsModel.Status),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_LendTime", DbType.DateTime, EmsModel.LendTime),dbHelper.CreateInDbParameter("@in_ReturnTime", DbType.DateTime, EmsModel.ReturnTime),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_stuLoanIDCard", DbType.String, EmsModel.stuLoanIDCard)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM OrderInfo");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM OrderInfo");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM OrderInfo");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.OrderInfo> GetListByPage(EmsModel.OrderInfo EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "OrderInfo";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.OrderNo != null){strWhere += " and OrderNo=@in_OrderNo ";parmsList.Add(dbHelper.CreateInDbParameter("@in_OrderNo", DbType.String, EmsMod.OrderNo)); }if (EmsMod.LoanName != null){strWhere += " and LoanName=@in_LoanName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LoanName", DbType.String, EmsMod.LoanName)); }if (EmsMod.IDCard != null){strWhere += " and IDCard=@in_IDCard ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsMod.IDCard)); }if (EmsMod.ExperimentId != null){strWhere += " and ExperimentId=@in_ExperimentId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.String, EmsMod.ExperimentId)); }if (EmsMod.Attachment != null){strWhere += " and Attachment=@in_Attachment ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Attachment", DbType.String, EmsMod.Attachment)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.Status != null){strWhere += " and Status=@in_Status ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Status", DbType.String, EmsMod.Status)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.LendTime != null){strWhere += " and LendTime=@in_LendTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LendTime", DbType.String, EmsMod.LendTime)); }if (EmsMod.ReturnTime != null){strWhere += " and ReturnTime=@in_ReturnTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ReturnTime", DbType.String, EmsMod.ReturnTime)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.stuLoanIDCard != null){strWhere += " and stuLoanIDCard=@in_stuLoanIDCard ";parmsList.Add(dbHelper.CreateInDbParameter("@in_stuLoanIDCard", DbType.String, EmsMod.stuLoanIDCard)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.OrderInfo> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.OrderInfo EmsMod)
        {
            string TableName = "OrderInfo";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.OrderNo != null){strWhere += " and OrderNo=@in_OrderNo ";parmsList.Add(dbHelper.CreateInDbParameter("@in_OrderNo", DbType.String, EmsMod.OrderNo)); }if (EmsMod.LoanName != null){strWhere += " and LoanName=@in_LoanName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LoanName", DbType.String, EmsMod.LoanName)); }if (EmsMod.IDCard != null){strWhere += " and IDCard=@in_IDCard ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsMod.IDCard)); }if (EmsMod.ExperimentId != null){strWhere += " and ExperimentId=@in_ExperimentId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ExperimentId", DbType.String, EmsMod.ExperimentId)); }if (EmsMod.Attachment != null){strWhere += " and Attachment=@in_Attachment ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Attachment", DbType.String, EmsMod.Attachment)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.Status != null){strWhere += " and Status=@in_Status ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Status", DbType.String, EmsMod.Status)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.LendTime != null){strWhere += " and LendTime=@in_LendTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LendTime", DbType.String, EmsMod.LendTime)); }if (EmsMod.ReturnTime != null){strWhere += " and ReturnTime=@in_ReturnTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ReturnTime", DbType.String, EmsMod.ReturnTime)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.stuLoanIDCard != null){strWhere += " and stuLoanIDCard=@in_stuLoanIDCard ";parmsList.Add(dbHelper.CreateInDbParameter("@in_stuLoanIDCard", DbType.String, EmsMod.stuLoanIDCard)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.OrderInfo EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.OrderNo = dr["OrderNo"] as string;EmsModel.LoanName = dr["LoanName"] as string;EmsModel.IDCard = dr["IDCard"] as string;EmsModel.ExperimentId = dr["ExperimentId"] as int?;EmsModel.Attachment = dr["Attachment"] as string;EmsModel.Type = dr["Type"] as Byte?;EmsModel.Status = dr["Status"] as int?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.LendTime = dr["LendTime"] as DateTime?;EmsModel.ReturnTime = dr["ReturnTime"] as DateTime?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.stuLoanIDCard = dr["stuLoanIDCard"] as string;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.OrderInfo> GetList(DataTable dt)
        {
            List<EmsModel.OrderInfo> lst = new List<EmsModel.OrderInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.OrderInfo mod = new EmsModel.OrderInfo();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.OrderInfo EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.OrderNo = dr["OrderNo"] as string;EmsModel.LoanName = dr["LoanName"] as string;EmsModel.IDCard = dr["IDCard"] as string;EmsModel.ExperimentId = dr["ExperimentId"] as int?;EmsModel.Attachment = dr["Attachment"] as string;EmsModel.Type = dr["Type"] as Byte?;EmsModel.Status = dr["Status"] as int?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.LendTime = dr["LendTime"] as DateTime?;EmsModel.ReturnTime = dr["ReturnTime"] as DateTime?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.stuLoanIDCard = dr["stuLoanIDCard"] as string;
        }		

    }

	/// </summary>
	///	教学计划表实体类36
	/// </summary>
    public partial class PlanExperiment: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.PlanExperiment EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO PlanExperiment(");
						sbSql.Append("Name,Type,IsOpen,StartDate,Week,Weekday,ClassHour,Part,Place,ComputerRoom,GroupMemberNumber,GroupNumber,NeedEquip,Contents,PlanId,Status,Creator,CreateTime,Editor,UpdateTime,IsDelete,ClassName,Category)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_Type,@in_IsOpen,@in_StartDate,@in_Week,@in_Weekday,@in_ClassHour,@in_Part,@in_Place,@in_ComputerRoom,@in_GroupMemberNumber,@in_GroupNumber,@in_NeedEquip,@in_Contents,@in_PlanId,@in_Status,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_ClassName,@in_Category)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_IsOpen", DbType.Byte, EmsModel.IsOpen),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_Week", DbType.Int32, EmsModel.Week),dbHelper.CreateInDbParameter("@in_Weekday", DbType.Int32, EmsModel.Weekday),dbHelper.CreateInDbParameter("@in_ClassHour", DbType.Int32, EmsModel.ClassHour),dbHelper.CreateInDbParameter("@in_Part", DbType.String, EmsModel.Part),dbHelper.CreateInDbParameter("@in_Place", DbType.Int32, EmsModel.Place),dbHelper.CreateInDbParameter("@in_ComputerRoom", DbType.Int32, EmsModel.ComputerRoom),dbHelper.CreateInDbParameter("@in_GroupMemberNumber", DbType.Int32, EmsModel.GroupMemberNumber),dbHelper.CreateInDbParameter("@in_GroupNumber", DbType.Int32, EmsModel.GroupNumber),dbHelper.CreateInDbParameter("@in_NeedEquip", DbType.String, EmsModel.NeedEquip),dbHelper.CreateInDbParameter("@in_Contents", DbType.String, EmsModel.Contents),dbHelper.CreateInDbParameter("@in_PlanId", DbType.Int32, EmsModel.PlanId),dbHelper.CreateInDbParameter("@in_Status", DbType.Byte, EmsModel.Status),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_ClassName", DbType.String, EmsModel.ClassName),dbHelper.CreateInDbParameter("@in_Category", DbType.Byte, EmsModel.Category)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.PlanExperiment EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO PlanExperiment(");
						sbSql.Append("Name,Type,IsOpen,StartDate,Week,Weekday,ClassHour,Part,Place,ComputerRoom,GroupMemberNumber,GroupNumber,NeedEquip,Contents,PlanId,Status,Creator,CreateTime,Editor,UpdateTime,IsDelete,ClassName,Category)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_Type,@in_IsOpen,@in_StartDate,@in_Week,@in_Weekday,@in_ClassHour,@in_Part,@in_Place,@in_ComputerRoom,@in_GroupMemberNumber,@in_GroupNumber,@in_NeedEquip,@in_Contents,@in_PlanId,@in_Status,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_ClassName,@in_Category)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_IsOpen", DbType.Byte, EmsModel.IsOpen),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_Week", DbType.Int32, EmsModel.Week),dbHelper.CreateInDbParameter("@in_Weekday", DbType.Int32, EmsModel.Weekday),dbHelper.CreateInDbParameter("@in_ClassHour", DbType.Int32, EmsModel.ClassHour),dbHelper.CreateInDbParameter("@in_Part", DbType.String, EmsModel.Part),dbHelper.CreateInDbParameter("@in_Place", DbType.Int32, EmsModel.Place),dbHelper.CreateInDbParameter("@in_ComputerRoom", DbType.Int32, EmsModel.ComputerRoom),dbHelper.CreateInDbParameter("@in_GroupMemberNumber", DbType.Int32, EmsModel.GroupMemberNumber),dbHelper.CreateInDbParameter("@in_GroupNumber", DbType.Int32, EmsModel.GroupNumber),dbHelper.CreateInDbParameter("@in_NeedEquip", DbType.String, EmsModel.NeedEquip),dbHelper.CreateInDbParameter("@in_Contents", DbType.String, EmsModel.Contents),dbHelper.CreateInDbParameter("@in_PlanId", DbType.Int32, EmsModel.PlanId),dbHelper.CreateInDbParameter("@in_Status", DbType.Byte, EmsModel.Status),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_ClassName", DbType.String, EmsModel.ClassName),dbHelper.CreateInDbParameter("@in_Category", DbType.Byte, EmsModel.Category)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.PlanExperiment EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update PlanExperiment set ");
					sbSql.Append("Name=@in_Name,Type=@in_Type,IsOpen=@in_IsOpen,StartDate=@in_StartDate,Week=@in_Week,Weekday=@in_Weekday,ClassHour=@in_ClassHour,Part=@in_Part,Place=@in_Place,ComputerRoom=@in_ComputerRoom,GroupMemberNumber=@in_GroupMemberNumber,GroupNumber=@in_GroupNumber,NeedEquip=@in_NeedEquip,Contents=@in_Contents,PlanId=@in_PlanId,Status=@in_Status,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,ClassName=@in_ClassName,Category=@in_Category");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_IsOpen", DbType.Byte, EmsModel.IsOpen),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_Week", DbType.Int32, EmsModel.Week),dbHelper.CreateInDbParameter("@in_Weekday", DbType.Int32, EmsModel.Weekday),dbHelper.CreateInDbParameter("@in_ClassHour", DbType.Int32, EmsModel.ClassHour),dbHelper.CreateInDbParameter("@in_Part", DbType.String, EmsModel.Part),dbHelper.CreateInDbParameter("@in_Place", DbType.Int32, EmsModel.Place),dbHelper.CreateInDbParameter("@in_ComputerRoom", DbType.Int32, EmsModel.ComputerRoom),dbHelper.CreateInDbParameter("@in_GroupMemberNumber", DbType.Int32, EmsModel.GroupMemberNumber),dbHelper.CreateInDbParameter("@in_GroupNumber", DbType.Int32, EmsModel.GroupNumber),dbHelper.CreateInDbParameter("@in_NeedEquip", DbType.String, EmsModel.NeedEquip),dbHelper.CreateInDbParameter("@in_Contents", DbType.String, EmsModel.Contents),dbHelper.CreateInDbParameter("@in_PlanId", DbType.Int32, EmsModel.PlanId),dbHelper.CreateInDbParameter("@in_Status", DbType.Byte, EmsModel.Status),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_ClassName", DbType.String, EmsModel.ClassName),dbHelper.CreateInDbParameter("@in_Category", DbType.Byte, EmsModel.Category)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.PlanExperiment EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update PlanExperiment set ");
					sbSql.Append("Name=@in_Name,Type=@in_Type,IsOpen=@in_IsOpen,StartDate=@in_StartDate,Week=@in_Week,Weekday=@in_Weekday,ClassHour=@in_ClassHour,Part=@in_Part,Place=@in_Place,ComputerRoom=@in_ComputerRoom,GroupMemberNumber=@in_GroupMemberNumber,GroupNumber=@in_GroupNumber,NeedEquip=@in_NeedEquip,Contents=@in_Contents,PlanId=@in_PlanId,Status=@in_Status,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,ClassName=@in_ClassName,Category=@in_Category");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Type", DbType.Byte, EmsModel.Type),dbHelper.CreateInDbParameter("@in_IsOpen", DbType.Byte, EmsModel.IsOpen),dbHelper.CreateInDbParameter("@in_StartDate", DbType.DateTime, EmsModel.StartDate),dbHelper.CreateInDbParameter("@in_Week", DbType.Int32, EmsModel.Week),dbHelper.CreateInDbParameter("@in_Weekday", DbType.Int32, EmsModel.Weekday),dbHelper.CreateInDbParameter("@in_ClassHour", DbType.Int32, EmsModel.ClassHour),dbHelper.CreateInDbParameter("@in_Part", DbType.String, EmsModel.Part),dbHelper.CreateInDbParameter("@in_Place", DbType.Int32, EmsModel.Place),dbHelper.CreateInDbParameter("@in_ComputerRoom", DbType.Int32, EmsModel.ComputerRoom),dbHelper.CreateInDbParameter("@in_GroupMemberNumber", DbType.Int32, EmsModel.GroupMemberNumber),dbHelper.CreateInDbParameter("@in_GroupNumber", DbType.Int32, EmsModel.GroupNumber),dbHelper.CreateInDbParameter("@in_NeedEquip", DbType.String, EmsModel.NeedEquip),dbHelper.CreateInDbParameter("@in_Contents", DbType.String, EmsModel.Contents),dbHelper.CreateInDbParameter("@in_PlanId", DbType.Int32, EmsModel.PlanId),dbHelper.CreateInDbParameter("@in_Status", DbType.Byte, EmsModel.Status),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_ClassName", DbType.String, EmsModel.ClassName),dbHelper.CreateInDbParameter("@in_Category", DbType.Byte, EmsModel.Category)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM PlanExperiment");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM PlanExperiment");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM PlanExperiment");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.PlanExperiment> GetListByPage(EmsModel.PlanExperiment EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "PlanExperiment";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.IsOpen != null){strWhere += " and IsOpen=@in_IsOpen ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsOpen", DbType.String, EmsMod.IsOpen)); }if (EmsMod.StartDate != null){strWhere += " and StartDate=@in_StartDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StartDate", DbType.String, EmsMod.StartDate)); }if (EmsMod.Week != null){strWhere += " and Week=@in_Week ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Week", DbType.String, EmsMod.Week)); }if (EmsMod.Weekday != null){strWhere += " and Weekday=@in_Weekday ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Weekday", DbType.String, EmsMod.Weekday)); }if (EmsMod.ClassHour != null){strWhere += " and ClassHour=@in_ClassHour ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ClassHour", DbType.String, EmsMod.ClassHour)); }if (EmsMod.Part != null){strWhere += " and Part=@in_Part ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Part", DbType.String, EmsMod.Part)); }if (EmsMod.Place != null){strWhere += " and Place=@in_Place ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Place", DbType.String, EmsMod.Place)); }if (EmsMod.ComputerRoom != null){strWhere += " and ComputerRoom=@in_ComputerRoom ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ComputerRoom", DbType.String, EmsMod.ComputerRoom)); }if (EmsMod.GroupMemberNumber != null){strWhere += " and GroupMemberNumber=@in_GroupMemberNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_GroupMemberNumber", DbType.String, EmsMod.GroupMemberNumber)); }if (EmsMod.GroupNumber != null){strWhere += " and GroupNumber=@in_GroupNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_GroupNumber", DbType.String, EmsMod.GroupNumber)); }if (EmsMod.NeedEquip != null){strWhere += " and NeedEquip=@in_NeedEquip ";parmsList.Add(dbHelper.CreateInDbParameter("@in_NeedEquip", DbType.String, EmsMod.NeedEquip)); }if (EmsMod.Contents != null){strWhere += " and Contents=@in_Contents ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Contents", DbType.String, EmsMod.Contents)); }if (EmsMod.PlanId != null){strWhere += " and PlanId=@in_PlanId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PlanId", DbType.String, EmsMod.PlanId)); }if (EmsMod.Status != null){strWhere += " and Status=@in_Status ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Status", DbType.String, EmsMod.Status)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.ClassName != null){strWhere += " and ClassName=@in_ClassName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ClassName", DbType.String, EmsMod.ClassName)); }if (EmsMod.Category != null){strWhere += " and Category=@in_Category ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Category", DbType.String, EmsMod.Category)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.PlanExperiment> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.PlanExperiment EmsMod)
        {
            string TableName = "PlanExperiment";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.Type != null){strWhere += " and Type=@in_Type ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); }if (EmsMod.IsOpen != null){strWhere += " and IsOpen=@in_IsOpen ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsOpen", DbType.String, EmsMod.IsOpen)); }if (EmsMod.StartDate != null){strWhere += " and StartDate=@in_StartDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_StartDate", DbType.String, EmsMod.StartDate)); }if (EmsMod.Week != null){strWhere += " and Week=@in_Week ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Week", DbType.String, EmsMod.Week)); }if (EmsMod.Weekday != null){strWhere += " and Weekday=@in_Weekday ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Weekday", DbType.String, EmsMod.Weekday)); }if (EmsMod.ClassHour != null){strWhere += " and ClassHour=@in_ClassHour ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ClassHour", DbType.String, EmsMod.ClassHour)); }if (EmsMod.Part != null){strWhere += " and Part=@in_Part ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Part", DbType.String, EmsMod.Part)); }if (EmsMod.Place != null){strWhere += " and Place=@in_Place ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Place", DbType.String, EmsMod.Place)); }if (EmsMod.ComputerRoom != null){strWhere += " and ComputerRoom=@in_ComputerRoom ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ComputerRoom", DbType.String, EmsMod.ComputerRoom)); }if (EmsMod.GroupMemberNumber != null){strWhere += " and GroupMemberNumber=@in_GroupMemberNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_GroupMemberNumber", DbType.String, EmsMod.GroupMemberNumber)); }if (EmsMod.GroupNumber != null){strWhere += " and GroupNumber=@in_GroupNumber ";parmsList.Add(dbHelper.CreateInDbParameter("@in_GroupNumber", DbType.String, EmsMod.GroupNumber)); }if (EmsMod.NeedEquip != null){strWhere += " and NeedEquip=@in_NeedEquip ";parmsList.Add(dbHelper.CreateInDbParameter("@in_NeedEquip", DbType.String, EmsMod.NeedEquip)); }if (EmsMod.Contents != null){strWhere += " and Contents=@in_Contents ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Contents", DbType.String, EmsMod.Contents)); }if (EmsMod.PlanId != null){strWhere += " and PlanId=@in_PlanId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_PlanId", DbType.String, EmsMod.PlanId)); }if (EmsMod.Status != null){strWhere += " and Status=@in_Status ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Status", DbType.String, EmsMod.Status)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.ClassName != null){strWhere += " and ClassName=@in_ClassName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ClassName", DbType.String, EmsMod.ClassName)); }if (EmsMod.Category != null){strWhere += " and Category=@in_Category ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Category", DbType.String, EmsMod.Category)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.PlanExperiment EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.Type = dr["Type"] as Byte?;EmsModel.IsOpen = dr["IsOpen"] as Byte?;EmsModel.StartDate = dr["StartDate"] as DateTime?;EmsModel.Week = dr["Week"] as int?;EmsModel.Weekday = dr["Weekday"] as int?;EmsModel.ClassHour = dr["ClassHour"] as int?;EmsModel.Part = dr["Part"] as string;EmsModel.Place = dr["Place"] as int?;EmsModel.ComputerRoom = dr["ComputerRoom"] as int?;EmsModel.GroupMemberNumber = dr["GroupMemberNumber"] as int?;EmsModel.GroupNumber = dr["GroupNumber"] as int?;EmsModel.NeedEquip = dr["NeedEquip"] as string;EmsModel.Contents = dr["Contents"] as string;EmsModel.PlanId = dr["PlanId"] as int?;EmsModel.Status = dr["Status"] as Byte?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.ClassName = dr["ClassName"] as string;EmsModel.Category = dr["Category"] as Byte?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.PlanExperiment> GetList(DataTable dt)
        {
            List<EmsModel.PlanExperiment> lst = new List<EmsModel.PlanExperiment>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.PlanExperiment mod = new EmsModel.PlanExperiment();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.PlanExperiment EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.Type = dr["Type"] as Byte?;EmsModel.IsOpen = dr["IsOpen"] as Byte?;EmsModel.StartDate = dr["StartDate"] as DateTime?;EmsModel.Week = dr["Week"] as int?;EmsModel.Weekday = dr["Weekday"] as int?;EmsModel.ClassHour = dr["ClassHour"] as int?;EmsModel.Part = dr["Part"] as string;EmsModel.Place = dr["Place"] as int?;EmsModel.ComputerRoom = dr["ComputerRoom"] as int?;EmsModel.GroupMemberNumber = dr["GroupMemberNumber"] as int?;EmsModel.GroupNumber = dr["GroupNumber"] as int?;EmsModel.NeedEquip = dr["NeedEquip"] as string;EmsModel.Contents = dr["Contents"] as string;EmsModel.PlanId = dr["PlanId"] as int?;EmsModel.Status = dr["Status"] as Byte?;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.ClassName = dr["ClassName"] as string;EmsModel.Category = dr["Category"] as Byte?;
        }		

    }

	/// </summary>
	///	教学计划表实体类37
	/// </summary>
    public partial class Repair: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.Repair EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO Repair(");
						sbSql.Append("RepairMan,EquipID,RepairTime,DamageCauses,Damagetime,RepairLocation,CostOfRepairs,CompleteTime,Remark,RepairStatus,IsDelete)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_RepairMan,@in_EquipID,@in_RepairTime,@in_DamageCauses,@in_Damagetime,@in_RepairLocation,@in_CostOfRepairs,@in_CompleteTime,@in_Remark,@in_RepairStatus,@in_IsDelete)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_RepairMan", DbType.String, EmsModel.RepairMan),dbHelper.CreateInDbParameter("@in_EquipID", DbType.Int32, EmsModel.EquipID),dbHelper.CreateInDbParameter("@in_RepairTime", DbType.DateTime, EmsModel.RepairTime),dbHelper.CreateInDbParameter("@in_DamageCauses", DbType.String, EmsModel.DamageCauses),dbHelper.CreateInDbParameter("@in_Damagetime", DbType.DateTime, EmsModel.Damagetime),dbHelper.CreateInDbParameter("@in_RepairLocation", DbType.String, EmsModel.RepairLocation),dbHelper.CreateInDbParameter("@in_CostOfRepairs", DbType.String, EmsModel.CostOfRepairs),dbHelper.CreateInDbParameter("@in_CompleteTime", DbType.String, EmsModel.CompleteTime),dbHelper.CreateInDbParameter("@in_Remark", DbType.String, EmsModel.Remark),dbHelper.CreateInDbParameter("@in_RepairStatus", DbType.Int32, EmsModel.RepairStatus),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Int32, EmsModel.IsDelete)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.Repair EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO Repair(");
						sbSql.Append("RepairMan,EquipID,RepairTime,DamageCauses,Damagetime,RepairLocation,CostOfRepairs,CompleteTime,Remark,RepairStatus,IsDelete)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_RepairMan,@in_EquipID,@in_RepairTime,@in_DamageCauses,@in_Damagetime,@in_RepairLocation,@in_CostOfRepairs,@in_CompleteTime,@in_Remark,@in_RepairStatus,@in_IsDelete)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_RepairMan", DbType.String, EmsModel.RepairMan),dbHelper.CreateInDbParameter("@in_EquipID", DbType.Int32, EmsModel.EquipID),dbHelper.CreateInDbParameter("@in_RepairTime", DbType.DateTime, EmsModel.RepairTime),dbHelper.CreateInDbParameter("@in_DamageCauses", DbType.String, EmsModel.DamageCauses),dbHelper.CreateInDbParameter("@in_Damagetime", DbType.DateTime, EmsModel.Damagetime),dbHelper.CreateInDbParameter("@in_RepairLocation", DbType.String, EmsModel.RepairLocation),dbHelper.CreateInDbParameter("@in_CostOfRepairs", DbType.String, EmsModel.CostOfRepairs),dbHelper.CreateInDbParameter("@in_CompleteTime", DbType.String, EmsModel.CompleteTime),dbHelper.CreateInDbParameter("@in_Remark", DbType.String, EmsModel.Remark),dbHelper.CreateInDbParameter("@in_RepairStatus", DbType.Int32, EmsModel.RepairStatus),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Int32, EmsModel.IsDelete)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.Repair EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update Repair set ");
					sbSql.Append("RepairMan=@in_RepairMan,EquipID=@in_EquipID,RepairTime=@in_RepairTime,DamageCauses=@in_DamageCauses,Damagetime=@in_Damagetime,RepairLocation=@in_RepairLocation,CostOfRepairs=@in_CostOfRepairs,CompleteTime=@in_CompleteTime,Remark=@in_Remark,RepairStatus=@in_RepairStatus,IsDelete=@in_IsDelete");
					sbSql.Append("  where ID=@in_ID");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.Int32, EmsModel.ID),
						dbHelper.CreateInDbParameter("@in_RepairMan", DbType.String, EmsModel.RepairMan),dbHelper.CreateInDbParameter("@in_EquipID", DbType.Int32, EmsModel.EquipID),dbHelper.CreateInDbParameter("@in_RepairTime", DbType.DateTime, EmsModel.RepairTime),dbHelper.CreateInDbParameter("@in_DamageCauses", DbType.String, EmsModel.DamageCauses),dbHelper.CreateInDbParameter("@in_Damagetime", DbType.DateTime, EmsModel.Damagetime),dbHelper.CreateInDbParameter("@in_RepairLocation", DbType.String, EmsModel.RepairLocation),dbHelper.CreateInDbParameter("@in_CostOfRepairs", DbType.String, EmsModel.CostOfRepairs),dbHelper.CreateInDbParameter("@in_CompleteTime", DbType.String, EmsModel.CompleteTime),dbHelper.CreateInDbParameter("@in_Remark", DbType.String, EmsModel.Remark),dbHelper.CreateInDbParameter("@in_RepairStatus", DbType.Int32, EmsModel.RepairStatus),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Int32, EmsModel.IsDelete)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.Repair EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update Repair set ");
					sbSql.Append("RepairMan=@in_RepairMan,EquipID=@in_EquipID,RepairTime=@in_RepairTime,DamageCauses=@in_DamageCauses,Damagetime=@in_Damagetime,RepairLocation=@in_RepairLocation,CostOfRepairs=@in_CostOfRepairs,CompleteTime=@in_CompleteTime,Remark=@in_Remark,RepairStatus=@in_RepairStatus,IsDelete=@in_IsDelete");
					sbSql.Append("  where ID=@in_ID");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.Int32, EmsModel.ID),
						dbHelper.CreateInDbParameter("@in_RepairMan", DbType.String, EmsModel.RepairMan),dbHelper.CreateInDbParameter("@in_EquipID", DbType.Int32, EmsModel.EquipID),dbHelper.CreateInDbParameter("@in_RepairTime", DbType.DateTime, EmsModel.RepairTime),dbHelper.CreateInDbParameter("@in_DamageCauses", DbType.String, EmsModel.DamageCauses),dbHelper.CreateInDbParameter("@in_Damagetime", DbType.DateTime, EmsModel.Damagetime),dbHelper.CreateInDbParameter("@in_RepairLocation", DbType.String, EmsModel.RepairLocation),dbHelper.CreateInDbParameter("@in_CostOfRepairs", DbType.String, EmsModel.CostOfRepairs),dbHelper.CreateInDbParameter("@in_CompleteTime", DbType.String, EmsModel.CompleteTime),dbHelper.CreateInDbParameter("@in_Remark", DbType.String, EmsModel.Remark),dbHelper.CreateInDbParameter("@in_RepairStatus", DbType.Int32, EmsModel.RepairStatus),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Int32, EmsModel.IsDelete)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM Repair");
						sbSql.Append(" WHERE ID in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM Repair");
						sbSql.Append(" WHERE ID in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 ID)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM Repair");
					sbSql.Append(" where ID=@in_ID");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.Int32, ID)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.Repair> GetListByPage(EmsModel.Repair EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "Repair";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.RepairMan != null){strWhere += " and RepairMan=@in_RepairMan ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairMan", DbType.String, EmsMod.RepairMan)); }if (EmsMod.EquipID != null){strWhere += " and EquipID=@in_EquipID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipID", DbType.String, EmsMod.EquipID)); }if (EmsMod.RepairTime != null){strWhere += " and RepairTime=@in_RepairTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairTime", DbType.String, EmsMod.RepairTime)); }if (EmsMod.DamageCauses != null){strWhere += " and DamageCauses=@in_DamageCauses ";parmsList.Add(dbHelper.CreateInDbParameter("@in_DamageCauses", DbType.String, EmsMod.DamageCauses)); }if (EmsMod.Damagetime != null){strWhere += " and Damagetime=@in_Damagetime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Damagetime", DbType.String, EmsMod.Damagetime)); }if (EmsMod.RepairLocation != null){strWhere += " and RepairLocation=@in_RepairLocation ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairLocation", DbType.String, EmsMod.RepairLocation)); }if (EmsMod.CostOfRepairs != null){strWhere += " and CostOfRepairs=@in_CostOfRepairs ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CostOfRepairs", DbType.String, EmsMod.CostOfRepairs)); }if (EmsMod.CompleteTime != null){strWhere += " and CompleteTime=@in_CompleteTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CompleteTime", DbType.String, EmsMod.CompleteTime)); }if (EmsMod.Remark != null){strWhere += " and Remark=@in_Remark ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remark", DbType.String, EmsMod.Remark)); }if (EmsMod.RepairStatus != null){strWhere += " and RepairStatus=@in_RepairStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairStatus", DbType.String, EmsMod.RepairStatus)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.Repair> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.Repair EmsMod)
        {
            string TableName = "Repair";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.RepairMan != null){strWhere += " and RepairMan=@in_RepairMan ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairMan", DbType.String, EmsMod.RepairMan)); }if (EmsMod.EquipID != null){strWhere += " and EquipID=@in_EquipID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_EquipID", DbType.String, EmsMod.EquipID)); }if (EmsMod.RepairTime != null){strWhere += " and RepairTime=@in_RepairTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairTime", DbType.String, EmsMod.RepairTime)); }if (EmsMod.DamageCauses != null){strWhere += " and DamageCauses=@in_DamageCauses ";parmsList.Add(dbHelper.CreateInDbParameter("@in_DamageCauses", DbType.String, EmsMod.DamageCauses)); }if (EmsMod.Damagetime != null){strWhere += " and Damagetime=@in_Damagetime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Damagetime", DbType.String, EmsMod.Damagetime)); }if (EmsMod.RepairLocation != null){strWhere += " and RepairLocation=@in_RepairLocation ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairLocation", DbType.String, EmsMod.RepairLocation)); }if (EmsMod.CostOfRepairs != null){strWhere += " and CostOfRepairs=@in_CostOfRepairs ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CostOfRepairs", DbType.String, EmsMod.CostOfRepairs)); }if (EmsMod.CompleteTime != null){strWhere += " and CompleteTime=@in_CompleteTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CompleteTime", DbType.String, EmsMod.CompleteTime)); }if (EmsMod.Remark != null){strWhere += " and Remark=@in_Remark ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remark", DbType.String, EmsMod.Remark)); }if (EmsMod.RepairStatus != null){strWhere += " and RepairStatus=@in_RepairStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairStatus", DbType.String, EmsMod.RepairStatus)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.Repair EmsModel, DbDataReader dr)
        {
            EmsModel.ID = dr["ID"] as int?;EmsModel.RepairMan = dr["RepairMan"] as string;EmsModel.EquipID = dr["EquipID"] as int?;EmsModel.RepairTime = dr["RepairTime"] as DateTime?;EmsModel.DamageCauses = dr["DamageCauses"] as string;EmsModel.Damagetime = dr["Damagetime"] as DateTime?;EmsModel.RepairLocation = dr["RepairLocation"] as string;EmsModel.CostOfRepairs = dr["CostOfRepairs"] as string;EmsModel.CompleteTime = dr["CompleteTime"] as string;EmsModel.Remark = dr["Remark"] as string;EmsModel.RepairStatus = dr["RepairStatus"] as int?;EmsModel.IsDelete = dr["IsDelete"] as int?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.Repair> GetList(DataTable dt)
        {
            List<EmsModel.Repair> lst = new List<EmsModel.Repair>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.Repair mod = new EmsModel.Repair();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.Repair EmsModel, DataRow dr)
        {
            EmsModel.ID = dr["ID"] as int?;EmsModel.RepairMan = dr["RepairMan"] as string;EmsModel.EquipID = dr["EquipID"] as int?;EmsModel.RepairTime = dr["RepairTime"] as DateTime?;EmsModel.DamageCauses = dr["DamageCauses"] as string;EmsModel.Damagetime = dr["Damagetime"] as DateTime?;EmsModel.RepairLocation = dr["RepairLocation"] as string;EmsModel.CostOfRepairs = dr["CostOfRepairs"] as string;EmsModel.CompleteTime = dr["CompleteTime"] as string;EmsModel.Remark = dr["Remark"] as string;EmsModel.RepairStatus = dr["RepairStatus"] as int?;EmsModel.IsDelete = dr["IsDelete"] as int?;
        }		

    }

	/// </summary>
	///	教学计划表实体类38
	/// </summary>
    public partial class RepairAttachment: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.RepairAttachment EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO RepairAttachment(");
						sbSql.Append("Id,RepairDetailsID,AttachmentName,AttachmentPath)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Id,@in_RepairDetailsID,@in_AttachmentName,@in_AttachmentPath)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_RepairDetailsID", DbType.Int32, EmsModel.RepairDetailsID),dbHelper.CreateInDbParameter("@in_AttachmentName", DbType.String, EmsModel.AttachmentName),dbHelper.CreateInDbParameter("@in_AttachmentPath", DbType.String, EmsModel.AttachmentPath)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.RepairAttachment EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO RepairAttachment(");
						sbSql.Append("Id,RepairDetailsID,AttachmentName,AttachmentPath)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Id,@in_RepairDetailsID,@in_AttachmentName,@in_AttachmentPath)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_RepairDetailsID", DbType.Int32, EmsModel.RepairDetailsID),dbHelper.CreateInDbParameter("@in_AttachmentName", DbType.String, EmsModel.AttachmentName),dbHelper.CreateInDbParameter("@in_AttachmentPath", DbType.String, EmsModel.AttachmentPath)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.RepairAttachment EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update RepairAttachment set ");
					sbSql.Append("Id=@in_Id,RepairDetailsID=@in_RepairDetailsID,AttachmentName=@in_AttachmentName,AttachmentPath=@in_AttachmentPath");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_RepairDetailsID", DbType.Int32, EmsModel.RepairDetailsID),dbHelper.CreateInDbParameter("@in_AttachmentName", DbType.String, EmsModel.AttachmentName),dbHelper.CreateInDbParameter("@in_AttachmentPath", DbType.String, EmsModel.AttachmentPath)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.RepairAttachment EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update RepairAttachment set ");
					sbSql.Append("Id=@in_Id,RepairDetailsID=@in_RepairDetailsID,AttachmentName=@in_AttachmentName,AttachmentPath=@in_AttachmentPath");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_RepairDetailsID", DbType.Int32, EmsModel.RepairDetailsID),dbHelper.CreateInDbParameter("@in_AttachmentName", DbType.String, EmsModel.AttachmentName),dbHelper.CreateInDbParameter("@in_AttachmentPath", DbType.String, EmsModel.AttachmentPath)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM RepairAttachment");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM RepairAttachment");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists( )
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM RepairAttachment");
					sbSql.Append("");

					parms = new DbParameter[]{
						
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.RepairAttachment> GetListByPage(EmsModel.RepairAttachment EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "RepairAttachment";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Id != null){strWhere += " and Id=@in_Id ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Id", DbType.String, EmsMod.Id)); }if (EmsMod.RepairDetailsID != null){strWhere += " and RepairDetailsID=@in_RepairDetailsID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairDetailsID", DbType.String, EmsMod.RepairDetailsID)); }if (EmsMod.AttachmentName != null){strWhere += " and AttachmentName=@in_AttachmentName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AttachmentName", DbType.String, EmsMod.AttachmentName)); }if (EmsMod.AttachmentPath != null){strWhere += " and AttachmentPath=@in_AttachmentPath ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AttachmentPath", DbType.String, EmsMod.AttachmentPath)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.RepairAttachment> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.RepairAttachment EmsMod)
        {
            string TableName = "RepairAttachment";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Id != null){strWhere += " and Id=@in_Id ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Id", DbType.String, EmsMod.Id)); }if (EmsMod.RepairDetailsID != null){strWhere += " and RepairDetailsID=@in_RepairDetailsID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairDetailsID", DbType.String, EmsMod.RepairDetailsID)); }if (EmsMod.AttachmentName != null){strWhere += " and AttachmentName=@in_AttachmentName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AttachmentName", DbType.String, EmsMod.AttachmentName)); }if (EmsMod.AttachmentPath != null){strWhere += " and AttachmentPath=@in_AttachmentPath ";parmsList.Add(dbHelper.CreateInDbParameter("@in_AttachmentPath", DbType.String, EmsMod.AttachmentPath)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.RepairAttachment EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.RepairDetailsID = dr["RepairDetailsID"] as int?;EmsModel.AttachmentName = dr["AttachmentName"] as string;EmsModel.AttachmentPath = dr["AttachmentPath"] as string;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.RepairAttachment> GetList(DataTable dt)
        {
            List<EmsModel.RepairAttachment> lst = new List<EmsModel.RepairAttachment>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.RepairAttachment mod = new EmsModel.RepairAttachment();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.RepairAttachment EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.RepairDetailsID = dr["RepairDetailsID"] as int?;EmsModel.AttachmentName = dr["AttachmentName"] as string;EmsModel.AttachmentPath = dr["AttachmentPath"] as string;
        }		

    }

	/// </summary>
	///	教学计划表实体类39
	/// </summary>
    public partial class RepairDetail: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.RepairDetail EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO RepairDetail(");
						sbSql.Append("Id,RepairID,Record,RecordDate)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Id,@in_RepairID,@in_Record,@in_RecordDate)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_RepairID", DbType.Int32, EmsModel.RepairID),dbHelper.CreateInDbParameter("@in_Record", DbType.String, EmsModel.Record),dbHelper.CreateInDbParameter("@in_RecordDate", DbType.DateTime, EmsModel.RecordDate)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.RepairDetail EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO RepairDetail(");
						sbSql.Append("Id,RepairID,Record,RecordDate)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Id,@in_RepairID,@in_Record,@in_RecordDate)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_RepairID", DbType.Int32, EmsModel.RepairID),dbHelper.CreateInDbParameter("@in_Record", DbType.String, EmsModel.Record),dbHelper.CreateInDbParameter("@in_RecordDate", DbType.DateTime, EmsModel.RecordDate)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.RepairDetail EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update RepairDetail set ");
					sbSql.Append("Id=@in_Id,RepairID=@in_RepairID,Record=@in_Record,RecordDate=@in_RecordDate");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_RepairID", DbType.Int32, EmsModel.RepairID),dbHelper.CreateInDbParameter("@in_Record", DbType.String, EmsModel.Record),dbHelper.CreateInDbParameter("@in_RecordDate", DbType.DateTime, EmsModel.RecordDate)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.RepairDetail EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update RepairDetail set ");
					sbSql.Append("Id=@in_Id,RepairID=@in_RepairID,Record=@in_Record,RecordDate=@in_RecordDate");
					sbSql.Append(" ");

					parms = new DbParameter[]{
						
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),dbHelper.CreateInDbParameter("@in_RepairID", DbType.Int32, EmsModel.RepairID),dbHelper.CreateInDbParameter("@in_Record", DbType.String, EmsModel.Record),dbHelper.CreateInDbParameter("@in_RecordDate", DbType.DateTime, EmsModel.RecordDate)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM RepairDetail");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM RepairDetail");
						sbSql.Append(" WHERE  in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists( )
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM RepairDetail");
					sbSql.Append("");

					parms = new DbParameter[]{
						
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.RepairDetail> GetListByPage(EmsModel.RepairDetail EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "RepairDetail";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Id != null){strWhere += " and Id=@in_Id ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Id", DbType.String, EmsMod.Id)); }if (EmsMod.RepairID != null){strWhere += " and RepairID=@in_RepairID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairID", DbType.String, EmsMod.RepairID)); }if (EmsMod.Record != null){strWhere += " and Record=@in_Record ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Record", DbType.String, EmsMod.Record)); }if (EmsMod.RecordDate != null){strWhere += " and RecordDate=@in_RecordDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RecordDate", DbType.String, EmsMod.RecordDate)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.RepairDetail> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.RepairDetail EmsMod)
        {
            string TableName = "RepairDetail";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Id != null){strWhere += " and Id=@in_Id ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Id", DbType.String, EmsMod.Id)); }if (EmsMod.RepairID != null){strWhere += " and RepairID=@in_RepairID ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RepairID", DbType.String, EmsMod.RepairID)); }if (EmsMod.Record != null){strWhere += " and Record=@in_Record ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Record", DbType.String, EmsMod.Record)); }if (EmsMod.RecordDate != null){strWhere += " and RecordDate=@in_RecordDate ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RecordDate", DbType.String, EmsMod.RecordDate)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.RepairDetail EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.RepairID = dr["RepairID"] as int?;EmsModel.Record = dr["Record"] as string;EmsModel.RecordDate = dr["RecordDate"] as DateTime?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.RepairDetail> GetList(DataTable dt)
        {
            List<EmsModel.RepairDetail> lst = new List<EmsModel.RepairDetail>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.RepairDetail mod = new EmsModel.RepairDetail();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.RepairDetail EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.RepairID = dr["RepairID"] as int?;EmsModel.Record = dr["Record"] as string;EmsModel.RecordDate = dr["RecordDate"] as DateTime?;
        }		

    }

	/// </summary>
	///	教学计划表实体类40
	/// </summary>
    public partial class Role: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.Role EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO Role(");
						sbSql.Append("Name,Creator,CreateTime,Editor,UpdateTime,IsDelete)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.Role EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO Role(");
						sbSql.Append("Name,Creator,CreateTime,Editor,UpdateTime,IsDelete)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.Role EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update Role set ");
					sbSql.Append("Name=@in_Name,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.Role EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update Role set ");
					sbSql.Append("Name=@in_Name,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM Role");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM Role");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM Role");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.Role> GetListByPage(EmsModel.Role EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "Role";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.Role> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.Role EmsMod)
        {
            string TableName = "Role";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.Role EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.Role> GetList(DataTable dt)
        {
            List<EmsModel.Role> lst = new List<EmsModel.Role>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.Role mod = new EmsModel.Role();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.Role EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;
        }		

    }

	/// </summary>
	///	教学计划表实体类41
	/// </summary>
    public partial class RoleOfMenu: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.RoleOfMenu EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO RoleOfMenu(");
						sbSql.Append("RoleId,MenuId)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_RoleId,@in_MenuId)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_RoleId", DbType.Int32, EmsModel.RoleId),dbHelper.CreateInDbParameter("@in_MenuId", DbType.Int32, EmsModel.MenuId)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.RoleOfMenu EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO RoleOfMenu(");
						sbSql.Append("RoleId,MenuId)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_RoleId,@in_MenuId)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_RoleId", DbType.Int32, EmsModel.RoleId),dbHelper.CreateInDbParameter("@in_MenuId", DbType.Int32, EmsModel.MenuId)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.RoleOfMenu EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update RoleOfMenu set ");
					sbSql.Append("RoleId=@in_RoleId,MenuId=@in_MenuId");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_RoleId", DbType.Int32, EmsModel.RoleId),dbHelper.CreateInDbParameter("@in_MenuId", DbType.Int32, EmsModel.MenuId)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.RoleOfMenu EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update RoleOfMenu set ");
					sbSql.Append("RoleId=@in_RoleId,MenuId=@in_MenuId");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_RoleId", DbType.Int32, EmsModel.RoleId),dbHelper.CreateInDbParameter("@in_MenuId", DbType.Int32, EmsModel.MenuId)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM RoleOfMenu");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM RoleOfMenu");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM RoleOfMenu");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.RoleOfMenu> GetListByPage(EmsModel.RoleOfMenu EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "RoleOfMenu";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.RoleId != null){strWhere += " and RoleId=@in_RoleId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RoleId", DbType.String, EmsMod.RoleId)); }if (EmsMod.MenuId != null){strWhere += " and MenuId=@in_MenuId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_MenuId", DbType.String, EmsMod.MenuId)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.RoleOfMenu> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.RoleOfMenu EmsMod)
        {
            string TableName = "RoleOfMenu";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.RoleId != null){strWhere += " and RoleId=@in_RoleId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RoleId", DbType.String, EmsMod.RoleId)); }if (EmsMod.MenuId != null){strWhere += " and MenuId=@in_MenuId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_MenuId", DbType.String, EmsMod.MenuId)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.RoleOfMenu EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.RoleId = dr["RoleId"] as int?;EmsModel.MenuId = dr["MenuId"] as int?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.RoleOfMenu> GetList(DataTable dt)
        {
            List<EmsModel.RoleOfMenu> lst = new List<EmsModel.RoleOfMenu>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.RoleOfMenu mod = new EmsModel.RoleOfMenu();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.RoleOfMenu EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.RoleId = dr["RoleId"] as int?;EmsModel.MenuId = dr["MenuId"] as int?;
        }		

    }

	/// </summary>
	///	教学计划表实体类42
	/// </summary>
    public partial class RoleOfUser: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.RoleOfUser EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO RoleOfUser(");
						sbSql.Append("RoleId,LoginName)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_RoleId,@in_LoginName)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_RoleId", DbType.Int32, EmsModel.RoleId),dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsModel.LoginName)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.RoleOfUser EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO RoleOfUser(");
						sbSql.Append("RoleId,LoginName)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_RoleId,@in_LoginName)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_RoleId", DbType.Int32, EmsModel.RoleId),dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsModel.LoginName)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.RoleOfUser EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update RoleOfUser set ");
					sbSql.Append("RoleId=@in_RoleId,LoginName=@in_LoginName");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_RoleId", DbType.Int32, EmsModel.RoleId),dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsModel.LoginName)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.RoleOfUser EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update RoleOfUser set ");
					sbSql.Append("RoleId=@in_RoleId,LoginName=@in_LoginName");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_RoleId", DbType.Int32, EmsModel.RoleId),dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsModel.LoginName)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM RoleOfUser");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM RoleOfUser");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM RoleOfUser");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.RoleOfUser> GetListByPage(EmsModel.RoleOfUser EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "RoleOfUser";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.RoleId != null){strWhere += " and RoleId=@in_RoleId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RoleId", DbType.String, EmsMod.RoleId)); }if (EmsMod.LoginName != null){strWhere += " and LoginName=@in_LoginName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsMod.LoginName)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.RoleOfUser> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.RoleOfUser EmsMod)
        {
            string TableName = "RoleOfUser";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.RoleId != null){strWhere += " and RoleId=@in_RoleId ";parmsList.Add(dbHelper.CreateInDbParameter("@in_RoleId", DbType.String, EmsMod.RoleId)); }if (EmsMod.LoginName != null){strWhere += " and LoginName=@in_LoginName ";parmsList.Add(dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsMod.LoginName)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.RoleOfUser EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.RoleId = dr["RoleId"] as int?;EmsModel.LoginName = dr["LoginName"] as string;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.RoleOfUser> GetList(DataTable dt)
        {
            List<EmsModel.RoleOfUser> lst = new List<EmsModel.RoleOfUser>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.RoleOfUser mod = new EmsModel.RoleOfUser();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.RoleOfUser EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.RoleId = dr["RoleId"] as int?;EmsModel.LoginName = dr["LoginName"] as string;
        }		

    }

	/// </summary>
	///	教学计划表实体类43
	/// </summary>
    public partial class SectionPlace: DALHelper 
    {

			/// <summary>
			/// 增加一条数据
			/// </summary>
			public int Add(EmsModel.SectionPlace EmsModel)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO SectionPlace(");
						sbSql.Append("Name,Director,ViceDirector,Creator,CreateTime,Editor,UpdateTime,IsDelete,Remarks,UseStatus)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_Director,@in_ViceDirector,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_Remarks,@in_UseStatus)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Director", DbType.String, EmsModel.Director),dbHelper.CreateInDbParameter("@in_ViceDirector", DbType.String, EmsModel.ViceDirector),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
						};

						object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 增加一条数据 事务中
			/// </summary>
			public int Add(SqlTransaction trans,EmsModel.SectionPlace EmsModel) 
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("INSERT INTO SectionPlace(");
						sbSql.Append("Name,Director,ViceDirector,Creator,CreateTime,Editor,UpdateTime,IsDelete,Remarks,UseStatus)");
						sbSql.Append(" VALUES (");
						sbSql.Append("@in_Name,@in_Director,@in_ViceDirector,@in_Creator,@in_CreateTime,@in_Editor,@in_UpdateTime,@in_IsDelete,@in_Remarks,@in_UseStatus)");
						sbSql.Append(";select @@identity");

						parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Director", DbType.String, EmsModel.Director),dbHelper.CreateInDbParameter("@in_ViceDirector", DbType.String, EmsModel.ViceDirector),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
						};

						object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
						if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
					}
					catch (Exception)
					{
						//写入日志
						//throw;
						return 0;
					}
			}

			/// <summary>
			/// 更新一条数据
			/// </summary>
			public int Update(EmsModel.SectionPlace EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update SectionPlace set ");
					sbSql.Append("Name=@in_Name,Director=@in_Director,ViceDirector=@in_ViceDirector,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,Remarks=@in_Remarks,UseStatus=@in_UseStatus");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Director", DbType.String, EmsModel.Director),dbHelper.CreateInDbParameter("@in_ViceDirector", DbType.String, EmsModel.ViceDirector),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
					};

					return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}
			/// <summary>
			/// 更新一条数据 事务中
			/// </summary>
			public int Update(SqlTransaction trans,EmsModel.SectionPlace EmsModel)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("update SectionPlace set ");
					sbSql.Append("Name=@in_Name,Director=@in_Director,ViceDirector=@in_ViceDirector,Creator=@in_Creator,CreateTime=@in_CreateTime,Editor=@in_Editor,UpdateTime=@in_UpdateTime,IsDelete=@in_IsDelete,Remarks=@in_Remarks,UseStatus=@in_UseStatus");
					sbSql.Append("  where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, EmsModel.Id),
						dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsModel.Name),dbHelper.CreateInDbParameter("@in_Director", DbType.String, EmsModel.Director),dbHelper.CreateInDbParameter("@in_ViceDirector", DbType.String, EmsModel.ViceDirector),dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsModel.Creator),dbHelper.CreateInDbParameter("@in_CreateTime", DbType.DateTime, EmsModel.CreateTime),dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsModel.Editor),dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.DateTime, EmsModel.UpdateTime),dbHelper.CreateInDbParameter("@in_IsDelete", DbType.Byte, EmsModel.IsDelete),dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsModel.Remarks),dbHelper.CreateInDbParameter("@in_UseStatus", DbType.Byte, EmsModel.UseStatus)
					};

					return dbHelper.ExecuteNonQuery(trans,CommandType.Text, sbSql.ToString(), parms);
				}
				catch (Exception)
				{
					//写入日志
					//throw;
					return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM SectionPlace");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}

			/// <summary>
			/// 删除数据 可批量
			/// </summary>
			public int Delete(SqlTransaction trans,string strID)
			{
				try
					{
						StringBuilder sbSql;
						DbParameter[] parms;

						sbSql = new StringBuilder();
						sbSql.Append("DELETE FROM SectionPlace");
						sbSql.Append(" WHERE Id in (@in_ID)");

						parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.String, strID)};
							return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
						}
				catch (Exception)
					{
							//写入日志
							//throw;
							return 0;
					}
			}	
				
			/// <summary>
			/// 是否存在该记录
			/// </summary>
			public bool Exists(Int32 Id)
			{
				try
					{
					StringBuilder sbSql;
					DbParameter[] parms;

					sbSql = new StringBuilder();
					sbSql.Append("SELECT COUNT(1) FROM SectionPlace");
					sbSql.Append(" where Id=@in_Id");

					parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
						};

					object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
						return int.Parse(obj.ToString()) > 0;
						}
				catch (Exception)
						{
							//写入日志
							//throw;
							return false;
						}
			}

		
		///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.SectionPlace> GetListByPage(EmsModel.SectionPlace EmsMod,int startIndex, int endIndex)
        {
            //表名
            string TableName = "SectionPlace";
            //条件
            string strWhere="";
            //排序
            string orderby="";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.Director != null){strWhere += " and Director=@in_Director ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Director", DbType.String, EmsMod.Director)); }if (EmsMod.ViceDirector != null){strWhere += " and ViceDirector=@in_ViceDirector ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ViceDirector", DbType.String, EmsMod.ViceDirector)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }
            

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds= GetListByPage( TableName, strWhere,  orderby,  startIndex,  endIndex, parms);
            List<EmsModel.SectionPlace> list = GetList(ds.Tables[0]);
            return list;
        }

		public int GetListByPageCount(EmsModel.SectionPlace EmsMod)
        {
            string TableName = "SectionPlace";
            string strWhere="";

            List<DbParameter> parmsList = new List<DbParameter>();
			if (EmsMod.Name != null){strWhere += " and Name=@in_Name ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); }if (EmsMod.Director != null){strWhere += " and Director=@in_Director ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Director", DbType.String, EmsMod.Director)); }if (EmsMod.ViceDirector != null){strWhere += " and ViceDirector=@in_ViceDirector ";parmsList.Add(dbHelper.CreateInDbParameter("@in_ViceDirector", DbType.String, EmsMod.ViceDirector)); }if (EmsMod.Creator != null){strWhere += " and Creator=@in_Creator ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); }if (EmsMod.CreateTime != null){strWhere += " and CreateTime=@in_CreateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); }if (EmsMod.Editor != null){strWhere += " and Editor=@in_Editor ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); }if (EmsMod.UpdateTime != null){strWhere += " and UpdateTime=@in_UpdateTime ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); }if (EmsMod.IsDelete != null){strWhere += " and IsDelete=@in_IsDelete ";parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }if (EmsMod.Remarks != null){strWhere += " and Remarks=@in_Remarks ";parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }if (EmsMod.UseStatus != null){strWhere += " and UseStatus=@in_UseStatus ";parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }
            
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
				
		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DbDataReaderToModel(EmsModel.SectionPlace EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.Director = dr["Director"] as string;EmsModel.ViceDirector = dr["ViceDirector"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.UseStatus = dr["UseStatus"] as Byte?;
        }

		/// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.SectionPlace> GetList(DataTable dt)
        {
            List<EmsModel.SectionPlace> lst = new List<EmsModel.SectionPlace>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.SectionPlace mod = new EmsModel.SectionPlace();
                DataRowToModel(mod,dt.Rows[i]);
                lst.Add(mod);
            }
            
            return lst;
        }

		/// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.SectionPlace EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?;EmsModel.Name = dr["Name"] as string;EmsModel.Director = dr["Director"] as string;EmsModel.ViceDirector = dr["ViceDirector"] as string;EmsModel.Creator = dr["Creator"] as string;EmsModel.CreateTime = dr["CreateTime"] as DateTime?;EmsModel.Editor = dr["Editor"] as string;EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?;EmsModel.IsDelete = dr["IsDelete"] as Byte?;EmsModel.Remarks = dr["Remarks"] as string;EmsModel.UseStatus = dr["UseStatus"] as Byte?;
        }		

    }
}