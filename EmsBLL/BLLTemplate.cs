


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace EmsBLL
{

	/// </summary>
	///	教学计划表实体类1
	/// </summary>
    public partial class View_LoanDate 
    {
		internal readonly EmsDAL.View_LoanDate dal = new EmsDAL.View_LoanDate(); 
        public View_LoanDate()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.View_LoanDate EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.View_LoanDate EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists( )
				{
					bool bln = dal.Exists();
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.View_LoanDate> GetListByPage(EmsModel.View_LoanDate EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.View_LoanDate EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类2
	/// </summary>
    public partial class View_LoanANDEscheat 
    {
		internal readonly EmsDAL.View_LoanANDEscheat dal = new EmsDAL.View_LoanANDEscheat(); 
        public View_LoanANDEscheat()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.View_LoanANDEscheat EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.View_LoanANDEscheat EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists( )
				{
					bool bln = dal.Exists();
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.View_LoanANDEscheat> GetListByPage(EmsModel.View_LoanANDEscheat EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.View_LoanANDEscheat EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类3
	/// </summary>
    public partial class View_RepairList 
    {
		internal readonly EmsDAL.View_RepairList dal = new EmsDAL.View_RepairList(); 
        public View_RepairList()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.View_RepairList EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.View_RepairList EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists( )
				{
					bool bln = dal.Exists();
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.View_RepairList> GetListByPage(EmsModel.View_RepairList EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.View_RepairList EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类4
	/// </summary>
    public partial class View_Calendar_Land 
    {
		internal readonly EmsDAL.View_Calendar_Land dal = new EmsDAL.View_Calendar_Land(); 
        public View_Calendar_Land()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.View_Calendar_Land EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.View_Calendar_Land EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists( )
				{
					bool bln = dal.Exists();
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.View_Calendar_Land> GetListByPage(EmsModel.View_Calendar_Land EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.View_Calendar_Land EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类5
	/// </summary>
    public partial class Student 
    {
		internal readonly EmsDAL.Student dal = new EmsDAL.Student(); 
        public Student()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.Student EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.Student EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.Student> GetListByPage(EmsModel.Student EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.Student EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类6
	/// </summary>
    public partial class TeachingPlan 
    {
		internal readonly EmsDAL.TeachingPlan dal = new EmsDAL.TeachingPlan(); 
        public TeachingPlan()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.TeachingPlan EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.TeachingPlan EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.TeachingPlan> GetListByPage(EmsModel.TeachingPlan EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.TeachingPlan EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类7
	/// </summary>
    public partial class UserInfo 
    {
		internal readonly EmsDAL.UserInfo dal = new EmsDAL.UserInfo(); 
        public UserInfo()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.UserInfo EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.UserInfo EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.UserInfo> GetListByPage(EmsModel.UserInfo EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.UserInfo EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类8
	/// </summary>
    public partial class AttachmentInfo 
    {
		internal readonly EmsDAL.AttachmentInfo dal = new EmsDAL.AttachmentInfo(); 
        public AttachmentInfo()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.AttachmentInfo EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.AttachmentInfo EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.AttachmentInfo> GetListByPage(EmsModel.AttachmentInfo EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.AttachmentInfo EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类9
	/// </summary>
    public partial class Warehouse 
    {
		internal readonly EmsDAL.Warehouse dal = new EmsDAL.Warehouse(); 
        public Warehouse()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.Warehouse EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.Warehouse EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.Warehouse> GetListByPage(EmsModel.Warehouse EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.Warehouse EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类10
	/// </summary>
    public partial class BorrowRecord 
    {
		internal readonly EmsDAL.BorrowRecord dal = new EmsDAL.BorrowRecord(); 
        public BorrowRecord()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.BorrowRecord EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.BorrowRecord EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.BorrowRecord> GetListByPage(EmsModel.BorrowRecord EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.BorrowRecord EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类11
	/// </summary>
    public partial class BorrowRecordDetail 
    {
		internal readonly EmsDAL.BorrowRecordDetail dal = new EmsDAL.BorrowRecordDetail(); 
        public BorrowRecordDetail()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.BorrowRecordDetail EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.BorrowRecordDetail EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.BorrowRecordDetail> GetListByPage(EmsModel.BorrowRecordDetail EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.BorrowRecordDetail EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类12
	/// </summary>
    public partial class Building 
    {
		internal readonly EmsDAL.Building dal = new EmsDAL.Building(); 
        public Building()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.Building EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.Building EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.Building> GetListByPage(EmsModel.Building EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.Building EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类13
	/// </summary>
    public partial class ClassInfo 
    {
		internal readonly EmsDAL.ClassInfo dal = new EmsDAL.ClassInfo(); 
        public ClassInfo()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.ClassInfo EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.ClassInfo EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.ClassInfo> GetListByPage(EmsModel.ClassInfo EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.ClassInfo EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类14
	/// </summary>
    public partial class ContractEquip 
    {
		internal readonly EmsDAL.ContractEquip dal = new EmsDAL.ContractEquip(); 
        public ContractEquip()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.ContractEquip EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.ContractEquip EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.ContractEquip> GetListByPage(EmsModel.ContractEquip EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.ContractEquip EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类15
	/// </summary>
    public partial class ContractInfo 
    {
		internal readonly EmsDAL.ContractInfo dal = new EmsDAL.ContractInfo(); 
        public ContractInfo()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.ContractInfo EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.ContractInfo EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.ContractInfo> GetListByPage(EmsModel.ContractInfo EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.ContractInfo EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类16
	/// </summary>
    public partial class Dictionary 
    {
		internal readonly EmsDAL.Dictionary dal = new EmsDAL.Dictionary(); 
        public Dictionary()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.Dictionary EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.Dictionary EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.Dictionary> GetListByPage(EmsModel.Dictionary EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.Dictionary EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类17
	/// </summary>
    public partial class EquipDetail 
    {
		internal readonly EmsDAL.EquipDetail dal = new EmsDAL.EquipDetail(); 
        public EquipDetail()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.EquipDetail EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.EquipDetail EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.EquipDetail> GetListByPage(EmsModel.EquipDetail EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.EquipDetail EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类18
	/// </summary>
    public partial class EquipInto 
    {
		internal readonly EmsDAL.EquipInto dal = new EmsDAL.EquipInto(); 
        public EquipInto()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.EquipInto EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.EquipInto EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.EquipInto> GetListByPage(EmsModel.EquipInto EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.EquipInto EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类19
	/// </summary>
    public partial class EquipList 
    {
		internal readonly EmsDAL.EquipList dal = new EmsDAL.EquipList(); 
        public EquipList()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.EquipList EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.EquipList EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.EquipList> GetListByPage(EmsModel.EquipList EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.EquipList EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类20
	/// </summary>
    public partial class EqWorth 
    {
		internal readonly EmsDAL.EqWorth dal = new EmsDAL.EqWorth(); 
        public EqWorth()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.EqWorth EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.EqWorth EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.EqWorth> GetListByPage(EmsModel.EqWorth EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.EqWorth EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类21
	/// </summary>
    public partial class ExperimentClassInfo 
    {
		internal readonly EmsDAL.ExperimentClassInfo dal = new EmsDAL.ExperimentClassInfo(); 
        public ExperimentClassInfo()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.ExperimentClassInfo EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.ExperimentClassInfo EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.ExperimentClassInfo> GetListByPage(EmsModel.ExperimentClassInfo EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.ExperimentClassInfo EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类22
	/// </summary>
    public partial class Honor 
    {
		internal readonly EmsDAL.Honor dal = new EmsDAL.Honor(); 
        public Honor()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.Honor EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.Honor EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.Honor> GetListByPage(EmsModel.Honor EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.Honor EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类23
	/// </summary>
    public partial class InstrumentEquip 
    {
		internal readonly EmsDAL.InstrumentEquip dal = new EmsDAL.InstrumentEquip(); 
        public InstrumentEquip()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.InstrumentEquip EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.InstrumentEquip EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.InstrumentEquip> GetListByPage(EmsModel.InstrumentEquip EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.InstrumentEquip EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类24
	/// </summary>
    public partial class InventoryList 
    {
		internal readonly EmsDAL.InventoryList dal = new EmsDAL.InventoryList(); 
        public InventoryList()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.InventoryList EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.InventoryList EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.InventoryList> GetListByPage(EmsModel.InventoryList EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.InventoryList EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类25
	/// </summary>
    public partial class InventoryListDetail 
    {
		internal readonly EmsDAL.InventoryListDetail dal = new EmsDAL.InventoryListDetail(); 
        public InventoryListDetail()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.InventoryListDetail EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.InventoryListDetail EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.InventoryListDetail> GetListByPage(EmsModel.InventoryListDetail EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.InventoryListDetail EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类26
	/// </summary>
    public partial class InventoryPlan 
    {
		internal readonly EmsDAL.InventoryPlan dal = new EmsDAL.InventoryPlan(); 
        public InventoryPlan()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.InventoryPlan EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.InventoryPlan EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.InventoryPlan> GetListByPage(EmsModel.InventoryPlan EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.InventoryPlan EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类27
	/// </summary>
    public partial class LearnYear 
    {
		internal readonly EmsDAL.LearnYear dal = new EmsDAL.LearnYear(); 
        public LearnYear()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.LearnYear EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.LearnYear EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.LearnYear> GetListByPage(EmsModel.LearnYear EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.LearnYear EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类28
	/// </summary>
    public partial class LogInfo 
    {
		internal readonly EmsDAL.LogInfo dal = new EmsDAL.LogInfo(); 
        public LogInfo()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.LogInfo EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.LogInfo EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.LogInfo> GetListByPage(EmsModel.LogInfo EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.LogInfo EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类29
	/// </summary>
    public partial class MenuInfo 
    {
		internal readonly EmsDAL.MenuInfo dal = new EmsDAL.MenuInfo(); 
        public MenuInfo()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.MenuInfo EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.MenuInfo EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.MenuInfo> GetListByPage(EmsModel.MenuInfo EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.MenuInfo EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类30
	/// </summary>
    public partial class OrderEquipDetail 
    {
		internal readonly EmsDAL.OrderEquipDetail dal = new EmsDAL.OrderEquipDetail(); 
        public OrderEquipDetail()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.OrderEquipDetail EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.OrderEquipDetail EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.OrderEquipDetail> GetListByPage(EmsModel.OrderEquipDetail EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.OrderEquipDetail EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类31
	/// </summary>
    public partial class OrderInfo 
    {
		internal readonly EmsDAL.OrderInfo dal = new EmsDAL.OrderInfo(); 
        public OrderInfo()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.OrderInfo EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.OrderInfo EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.OrderInfo> GetListByPage(EmsModel.OrderInfo EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.OrderInfo EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类32
	/// </summary>
    public partial class PlanExperiment 
    {
		internal readonly EmsDAL.PlanExperiment dal = new EmsDAL.PlanExperiment(); 
        public PlanExperiment()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.PlanExperiment EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.PlanExperiment EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.PlanExperiment> GetListByPage(EmsModel.PlanExperiment EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.PlanExperiment EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类33
	/// </summary>
    public partial class Repair 
    {
		internal readonly EmsDAL.Repair dal = new EmsDAL.Repair(); 
        public Repair()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.Repair EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.Repair EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int ID)
				{
					bool bln = dal.Exists(ID);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.Repair> GetListByPage(EmsModel.Repair EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.Repair EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类34
	/// </summary>
    public partial class RepairAttachment 
    {
		internal readonly EmsDAL.RepairAttachment dal = new EmsDAL.RepairAttachment(); 
        public RepairAttachment()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.RepairAttachment EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.RepairAttachment EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists( )
				{
					bool bln = dal.Exists();
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.RepairAttachment> GetListByPage(EmsModel.RepairAttachment EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.RepairAttachment EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类35
	/// </summary>
    public partial class RepairDetail 
    {
		internal readonly EmsDAL.RepairDetail dal = new EmsDAL.RepairDetail(); 
        public RepairDetail()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.RepairDetail EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.RepairDetail EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists( )
				{
					bool bln = dal.Exists();
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.RepairDetail> GetListByPage(EmsModel.RepairDetail EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.RepairDetail EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类36
	/// </summary>
    public partial class Role 
    {
		internal readonly EmsDAL.Role dal = new EmsDAL.Role(); 
        public Role()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.Role EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.Role EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.Role> GetListByPage(EmsModel.Role EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.Role EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类37
	/// </summary>
    public partial class RoleOfMenu 
    {
		internal readonly EmsDAL.RoleOfMenu dal = new EmsDAL.RoleOfMenu(); 
        public RoleOfMenu()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.RoleOfMenu EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.RoleOfMenu EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.RoleOfMenu> GetListByPage(EmsModel.RoleOfMenu EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.RoleOfMenu EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类38
	/// </summary>
    public partial class RoleOfUser 
    {
		internal readonly EmsDAL.RoleOfUser dal = new EmsDAL.RoleOfUser(); 
        public RoleOfUser()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.RoleOfUser EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.RoleOfUser EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.RoleOfUser> GetListByPage(EmsModel.RoleOfUser EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.RoleOfUser EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }

	/// </summary>
	///	教学计划表实体类39
	/// </summary>
    public partial class SectionPlace 
    {
		internal readonly EmsDAL.SectionPlace dal = new EmsDAL.SectionPlace(); 
        public SectionPlace()
        { }
				 /// <summary>
				/// 增加一条数据
				/// </summary>
				public int Add(EmsModel.SectionPlace EmsModel)
				{
					return dal.Add(EmsModel);
				}

				/// <summary>
				/// 更新一条数据
				/// </summary>
				public int Update(EmsModel.SectionPlace EmsModel)
				{
					int count = dal.Update(EmsModel);
            
					return count;

				}

				/// <summary>
				/// 删除数据， 可批量
				/// </summary>
				/// <param name="idlist">主键字符串 用,分开 如"1,2,3,4" 单个删除 传1个即可</param>
				/// <returns>返回 影响行数</returns>
				public int Delete(string strID)
				{
					int count = dal.Delete(strID);
            
					return count;

				}

				/// <summary>
				/// 是否存在该记录
				/// </summary>
				public bool Exists(int Id)
				{
					bool bln = dal.Exists(Id);
					return bln;
				}


				///<summary>
				///获取泛型数据列表 分页
				/// </summary>
				public List<EmsModel.SectionPlace> GetListByPage(EmsModel.SectionPlace EmsMod,int startIndex, int endIndex)
				{
					return dal.GetListByPage(EmsMod,startIndex,endIndex);
				}
				
				public int GetListByPageCount(EmsModel.SectionPlace EmsMod)
				{
					return dal.GetListByPageCount(EmsMod);
				}

    }
}