 
 
  
using System;
namespace EmsModel
{
    
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class View_EquipListDetail
    {

		/// <summary>
		/// 
		/// </summary>
		public int? ELId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? Count { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? RelationID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Number { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Model { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Unit { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class View_orderCount
    {

		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? RelationID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? EquipKindId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string EQNAME { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string EQNUM { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string EQUNIT { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? Count { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? countL { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? countE { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class View_LoanDate
    {

		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string CName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string stuLoanIDCard { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? StartDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? isStatus { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? orderID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string OrderNo { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string LoanName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string stuLoanName { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class View_InvenRoomEquip
    {

		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? InventoryListId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? EquipId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string AssetNumber { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string AssetName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? RoomId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? SourceRoomId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? Status { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Boolean? IsLoss { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Remarks { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Barcode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ImageName { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class View_LoanANDEscheat
    {

		/// <summary>
		/// 
		/// </summary>
		public int? OrderId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? InventoryKindId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string InstrumentEquip { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? countL { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? countE { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class View_Calendar
    {

		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string title { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string start { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? StartDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string planName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? isStatus { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? orderid { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public long? num { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class View_RepairList
    {

		/// <summary>
		/// 
		/// </summary>
		public int? ID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string RepairMan { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? EquipID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RepairTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string DamageCauses { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Damagetime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string RepairLocation { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string CostOfRepairs { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string CompleteTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Remark { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? RepairStatus { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? IsDelete { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Byte? EQtype { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string name { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string userName { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class View_EquipDatail
    {

		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? EquipKindId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string AssetNumber { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? EquipIntoID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? EquipStatus { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Byte? Type { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Barcode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ImageName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? Count { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ClassNumber { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string AssetsClassName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string IntlClassCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string IntlClassName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string AssetName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Unit { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string UsageStatus { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string UsageDirection { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string JYBBBSYFX { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string AcquisitionMethod { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AcquisitionDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string BrandStandardModel { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string EquipmentUse { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string UseDepartment { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string UsePeople { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Factory { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string StorageLocation { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string WorthType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string UseNature { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal? Worth { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string FinanceRecordType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal? FiscalFunds { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal? NonFiscalFunds { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FinanceRecordDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string VoucherNumber { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? UseTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ExpectedScrapDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string DepreciationState { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal? NetWorth { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string OutFactoryNumber { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Supplier { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string FundsSubject { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string PurchaseModality { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string CountryCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Operator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? GuaranteeEndDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string EquipmentNumber { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string InvoiceNumber { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string CompactNumber { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string BasicFunds { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ItemFunds1 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ItemFunds2 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ItemFunds3 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ItemFunds4 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal? ItemFundsMoney1 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal? ItemFundsMoney2 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal? ItemFundsMoney3 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal? ItemFundsMoney4 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Remarks { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Byte? IsDelete { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Byte? UseStatus { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string StorageLocation1 { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Byte? IsConsume { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Byte? EquipSource { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string EquipOwner { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Byte? ManualModify { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ImageUrl { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Byte? BorrowYN { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string WarehouseName { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class View_Calendar_Land
    {

		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string title { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string start { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? StartDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string planName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? planId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? tpDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? isStatus { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? orderid { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public long? num { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class Student
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///学生姓名 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		///身份证号 
		/// </summary>
		public string IDCard { get; set; }
		/// <summary>
		///班级Id 
		/// </summary>
		public int? ClassId { get; set; }
		/// <summary>
		///性别 0那;1女 
		/// </summary>
		public string Sex { get; set; }
		/// <summary>
		///电话 
		/// </summary>
		public string Phone { get; set; }
		/// <summary>
		///卡号 
		/// </summary>
		public string KaNo { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///修改人 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		///修改时间 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		///是否删除 0正常1删除2归档 
		/// </summary>
		public Byte? IsDelete { get; set; }
		/// <summary>
		///禁用启用状态，0启用(默认值);  1禁用 
		/// </summary>
		public Byte? UseStatus { get; set; }
		/// <summary>
		///备注 
		/// </summary>
		public string Remarks { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class TeachingPlan
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///课程名称 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		///主讲教师 
		/// </summary>
		public string MainTeacher { get; set; }
		/// <summary>
		///指导教师1 
		/// </summary>
		public string GuideTeacher1 { get; set; }
		/// <summary>
		///指导教师2 
		/// </summary>
		public string GuideTeacher2 { get; set; }
		/// <summary>
		///课程内容 
		/// </summary>
		public string Contents { get; set; }
		/// <summary>
		///学年学期 
		/// </summary>
		public int? LearnYear { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///修改人 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		///修改时间 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		///是否删除 0 正常;1 删除;2归档 
		/// </summary>
		public Byte? IsDelete { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class UserInfo
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///登录名 
		/// </summary>
		public string LoginName { get; set; }
		/// <summary>
		///用户名 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		///密码 
		/// </summary>
		public string PassWord { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///修改人 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		///修改时间 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		///是否删除(0 正常;1 删除;2归档) 
		/// </summary>
		public Byte? IsDelete { get; set; }
		/// <summary>
		///性别 
		/// </summary>
		public string Sex { get; set; }
		/// <summary>
		///卡号 
		/// </summary>
		public string KaNo { get; set; }
		/// <summary>
		///卡等级 
		/// </summary>
		public string KaLv { get; set; }
		/// <summary>
		///禁用启用状态，0启用(默认值);  1禁用 
		/// </summary>
		public Byte? UseStatus { get; set; }
		/// <summary>
		///身份证号 
		/// </summary>
		public string IDCard { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class AttachmentInfo
    {

		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///附件名称 
		/// </summary>
		public string AttachmentName { get; set; }
		/// <summary>
		///附件路径 
		/// </summary>
		public string AttachmentPath { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建日期 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///0 正常;1 删除;2归档 
		/// </summary>
		public Byte? IsDelete { get; set; }
		/// <summary>
		///合同ID 
		/// </summary>
		public int? ContractID { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class Warehouse
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///仓库名称 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		///类型0楼房1仪器室2实验室 
		/// </summary>
		public Byte? Type { get; set; }
		/// <summary>
		///备注 
		/// </summary>
		public string Remarks { get; set; }
		/// <summary>
		///平面图 
		/// </summary>
		public string PlaneGraph { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///修改人 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		///修改时间 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		///是否删除(0 正常;1 删除;2归档) 
		/// </summary>
		public Byte? IsDelete { get; set; }
		/// <summary>
		///禁用启用状态，0启用(默认值);  1禁用 
		/// </summary>
		public Byte? UseStatus { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class BorrowRecord
    {

		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BeginDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string BorrowReason { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Notes { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? BorrowStatus { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string IDCard { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class BorrowRecordDetail
    {

		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? BorrowRecord { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? EquipDatailID { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class Building
    {

		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///名称 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		///楼层Id 
		/// </summary>
		public int? PID { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///修改人 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		///修改时间 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		///是否删除 0正常1删除2归档 
		/// </summary>
		public Byte? IsDelete { get; set; }
		/// <summary>
		///备注 
		/// </summary>
		public string Remarks { get; set; }
		/// <summary>
		///房间编号 
		/// </summary>
		public string RoomNo { get; set; }
		/// <summary>
		///房间类型（ 0 仪器室 ；1 实验室；2 办公室） 
		/// </summary>
		public Byte? Type { get; set; }
		/// <summary>
		///科所Id 
		/// </summary>
		public int? SectionPlaceId { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class ClassInfo
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///班级名称 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///修改人 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		///修改时间 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		///备注 
		/// </summary>
		public string Remarks { get; set; }
		/// <summary>
		///0启用 1禁用 
		/// </summary>
		public Byte? UseStatus { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class ContractEquip
    {

		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///合同ID 
		/// </summary>
		public int? ContractID { get; set; }
		/// <summary>
		///设备ID 
		/// </summary>
		public int? EquipDetailID { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建日期 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///0 正常;1 删除;2归档 
		/// </summary>
		public Byte? IsDelete { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class ContractInfo
    {

		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///合同名称 
		/// </summary>
		public string ContractName { get; set; }
		/// <summary>
		///合同编号 
		/// </summary>
		public string ContractNumber { get; set; }
		/// <summary>
		///合同描述 
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建日期 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///0 正常;1 删除;2归档 
		/// </summary>
		public Byte? IsDelete { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string PartyB { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal? Money { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class Dictionary
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///字典名称 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		///父级ID 
		/// </summary>
		public int? PID { get; set; }
		/// <summary>
		///路径 
		/// </summary>
		public string Path { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///修改人 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		///修改时间 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		///备注 
		/// </summary>
		public string Remarks { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class EquipDetail
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///设备分类Id 
		/// </summary>
		public int? EquipKindId { get; set; }
		/// <summary>
		///资产号 
		/// </summary>
		public string AssetNumber { get; set; }
		/// <summary>
		///设备入库Id 
		/// </summary>
		public int? EquipIntoID { get; set; }
		/// <summary>
		///设备状态 0  未借出 ; 1 已借出;2 维修;3 停用;4 报废 
		/// </summary>
		public int? EquipStatus { get; set; }
		/// <summary>
		///0教学资产;1科研资产;2办公资产 
		/// </summary>
		public Byte? Type { get; set; }
		/// <summary>
		///条形码 
		/// </summary>
		public string Barcode { get; set; }
		/// <summary>
		///图片名称 
		/// </summary>
		public string ImageName { get; set; }
		/// <summary>
		///数量 
		/// </summary>
		public int? Count { get; set; }
		/// <summary>
		///分类号 
		/// </summary>
		public string ClassNumber { get; set; }
		/// <summary>
		///资产分类名称 
		/// </summary>
		public string AssetsClassName { get; set; }
		/// <summary>
		///国际分类代码 
		/// </summary>
		public string IntlClassCode { get; set; }
		/// <summary>
		///国际分类名称 
		/// </summary>
		public string IntlClassName { get; set; }
		/// <summary>
		///资产名称 
		/// </summary>
		public string AssetName { get; set; }
		/// <summary>
		///计量单位 
		/// </summary>
		public string Unit { get; set; }
		/// <summary>
		///使用状况 
		/// </summary>
		public string UsageStatus { get; set; }
		/// <summary>
		///使用方向 
		/// </summary>
		public string UsageDirection { get; set; }
		/// <summary>
		///教育部报表使用方向 
		/// </summary>
		public string JYBBBSYFX { get; set; }
		/// <summary>
		///取得方式 
		/// </summary>
		public string AcquisitionMethod { get; set; }
		/// <summary>
		///取得日期 
		/// </summary>
		public DateTime? AcquisitionDate { get; set; }
		/// <summary>
		///品牌及规格型号 
		/// </summary>
		public string BrandStandardModel { get; set; }
		/// <summary>
		///设备用途 
		/// </summary>
		public string EquipmentUse { get; set; }
		/// <summary>
		///使用/管理部门 
		/// </summary>
		public string UseDepartment { get; set; }
		/// <summary>
		///使用人 
		/// </summary>
		public string UsePeople { get; set; }
		/// <summary>
		///厂家 
		/// </summary>
		public string Factory { get; set; }
		/// <summary>
		///存放地点 
		/// </summary>
		public string StorageLocation { get; set; }
		/// <summary>
		///价值类型 
		/// </summary>
		public string WorthType { get; set; }
		/// <summary>
		///使用性质 
		/// </summary>
		public string UseNature { get; set; }
		/// <summary>
		///价值 
		/// </summary>
		public decimal? Worth { get; set; }
		/// <summary>
		///财务入账形式 
		/// </summary>
		public string FinanceRecordType { get; set; }
		/// <summary>
		///财政性资金 
		/// </summary>
		public decimal? FiscalFunds { get; set; }
		/// <summary>
		///非财政性资金 
		/// </summary>
		public decimal? NonFiscalFunds { get; set; }
		/// <summary>
		///财政入账日期 
		/// </summary>
		public DateTime? FinanceRecordDate { get; set; }
		/// <summary>
		///凭证号 
		/// </summary>
		public string VoucherNumber { get; set; }
		/// <summary>
		///使用年限（月） 
		/// </summary>
		public int? UseTime { get; set; }
		/// <summary>
		///预计报废时间 
		/// </summary>
		public DateTime? ExpectedScrapDate { get; set; }
		/// <summary>
		///折旧状态 
		/// </summary>
		public string DepreciationState { get; set; }
		/// <summary>
		///净值 
		/// </summary>
		public decimal? NetWorth { get; set; }
		/// <summary>
		///出厂号 
		/// </summary>
		public string OutFactoryNumber { get; set; }
		/// <summary>
		///供货商 
		/// </summary>
		public string Supplier { get; set; }
		/// <summary>
		///经费科目 
		/// </summary>
		public string FundsSubject { get; set; }
		/// <summary>
		///采购组织形式 
		/// </summary>
		public string PurchaseModality { get; set; }
		/// <summary>
		///国别码 
		/// </summary>
		public string CountryCode { get; set; }
		/// <summary>
		///经手人 
		/// </summary>
		public string Operator { get; set; }
		/// <summary>
		///保修截止日期 
		/// </summary>
		public DateTime? GuaranteeEndDate { get; set; }
		/// <summary>
		///设备号 
		/// </summary>
		public string EquipmentNumber { get; set; }
		/// <summary>
		///发票号 
		/// </summary>
		public string InvoiceNumber { get; set; }
		/// <summary>
		///合同号 
		/// </summary>
		public string CompactNumber { get; set; }
		/// <summary>
		///基本经费 
		/// </summary>
		public string BasicFunds { get; set; }
		/// <summary>
		///项目经费1 
		/// </summary>
		public string ItemFunds1 { get; set; }
		/// <summary>
		///项目经费2 
		/// </summary>
		public string ItemFunds2 { get; set; }
		/// <summary>
		///项目经费3 
		/// </summary>
		public string ItemFunds3 { get; set; }
		/// <summary>
		///项目经费4 
		/// </summary>
		public string ItemFunds4 { get; set; }
		/// <summary>
		///项目经费1金额 
		/// </summary>
		public decimal? ItemFundsMoney1 { get; set; }
		/// <summary>
		///项目经费1金额 
		/// </summary>
		public decimal? ItemFundsMoney2 { get; set; }
		/// <summary>
		///项目经费1金额 
		/// </summary>
		public decimal? ItemFundsMoney3 { get; set; }
		/// <summary>
		///项目经费1金额 
		/// </summary>
		public decimal? ItemFundsMoney4 { get; set; }
		/// <summary>
		///备注 
		/// </summary>
		public string Remarks { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///修改人 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		///修改时间 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		///是否删除 0 正常;1 删除;2归档 
		/// </summary>
		public Byte? IsDelete { get; set; }
		/// <summary>
		///使用状态 0 启用;1 禁用; 
		/// </summary>
		public Byte? UseStatus { get; set; }
		/// <summary>
		///存放地点1 
		/// </summary>
		public string StorageLocation1 { get; set; }
		/// <summary>
		///是否耗材   0 非耗材;1 耗材; 
		/// </summary>
		public Byte? IsConsume { get; set; }
		/// <summary>
		///设备来源 （0本院资产;1资产系统;） 
		/// </summary>
		public Byte? EquipSource { get; set; }
		/// <summary>
		///负责人 
		/// </summary>
		public string EquipOwner { get; set; }
		/// <summary>
		///手动修改  0未修改1修改 
		/// </summary>
		public Byte? ManualModify { get; set; }
		/// <summary>
		///图片上传路径 
		/// </summary>
		public string ImageUrl { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Byte? BorrowYN { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class EquipInto
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///仓库Id 
		/// </summary>
		public int? WarehouseId { get; set; }
		/// <summary>
		///设备分类Id 
		/// </summary>
		public int? EquipKindId { get; set; }
		/// <summary>
		///数量 
		/// </summary>
		public int? Count { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///是否删除 0 正常;1 删除;2归档 
		/// </summary>
		public Byte? IsDelete { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class EquipList
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///实验Id 
		/// </summary>
		public int? RelationID { get; set; }
		/// <summary>
		///设备分类Id 
		/// </summary>
		public int? EquipKindId { get; set; }
		/// <summary>
		///设备名称 
		/// </summary>
		public string EquipName { get; set; }
		/// <summary>
		///配件 
		/// </summary>
		public string Parts { get; set; }
		/// <summary>
		///数量 
		/// </summary>
		public int? Count { get; set; }
		/// <summary>
		///备注 
		/// </summary>
		public string Remarks { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class EqWorth
    {

		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal? Worth { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class ExperimentClassInfo
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///实验Id 
		/// </summary>
		public int? ExperimentId { get; set; }
		/// <summary>
		///班级Id 
		/// </summary>
		public int? ClassId { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class Honor
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///奖项名称 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		///级别 
		/// </summary>
		public int? HonorLevel { get; set; }
		/// <summary>
		///教学计划实验Id 
		/// </summary>
		public int? ExperimentId { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///修改人 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		///修改时间 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		///是否删除 0 正常;1 删除;2归档 
		/// </summary>
		public Byte? IsDelete { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class InstrumentEquip
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///仪器编码 
		/// </summary>
		public string Number { get; set; }
		/// <summary>
		///仪器名称 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		///仪器型号 
		/// </summary>
		public string Model { get; set; }
		/// <summary>
		///数量 
		/// </summary>
		public int? Count { get; set; }
		/// <summary>
		///单位 
		/// </summary>
		public string Unit { get; set; }
		/// <summary>
		///类型 0 非耗材 ;1 耗材 
		/// </summary>
		public int? Type { get; set; }
		/// <summary>
		///仓库Id 
		/// </summary>
		public int? WarehouseId { get; set; }
		/// <summary>
		///厂家 
		/// </summary>
		public string Company { get; set; }
		/// <summary>
		///备注 
		/// </summary>
		public string Remarks { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///修改人 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		///修改时间 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		///是否删除 0 正常;1 删除;2归档 
		/// </summary>
		public Byte? IsDelete { get; set; }
		/// <summary>
		///禁用启用状态，0启用(默认值);  1禁用 
		/// </summary>
		public Byte? UseStatus { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class InventoryList
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///盘点计划Id 
		/// </summary>
		public int? PlanId { get; set; }
		/// <summary>
		///房间Id 
		/// </summary>
		public int? RoomId { get; set; }
		/// <summary>
		///账面数量 
		/// </summary>
		public int? Quantity { get; set; }
		/// <summary>
		///实盘数量 
		/// </summary>
		public int? RealQuantity { get; set; }
		/// <summary>
		///外借数量 
		/// </summary>
		public int? BorrowQuantity { get; set; }
		/// <summary>
		///缺失数量 
		/// </summary>
		public int? LossQuantity { get; set; }
		/// <summary>
		///状态（0 未盘点;1 已盘点；） 
		/// </summary>
		public Byte? Status { get; set; }
		/// <summary>
		///盘点人 
		/// </summary>
		public string Operator { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///修改人 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		///修改时间 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		///是否删除 0 正常;1 删除;2归档 
		/// </summary>
		public Byte? IsDelete { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class InventoryListDetail
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///盘点单Id 
		/// </summary>
		public int? InventoryListId { get; set; }
		/// <summary>
		///仪器设备Id 
		/// </summary>
		public int? EquipId { get; set; }
		/// <summary>
		///资产号 
		/// </summary>
		public string AssetNumber { get; set; }
		/// <summary>
		///资产名称 
		/// </summary>
		public string AssetName { get; set; }
		/// <summary>
		///存放处Id 
		/// </summary>
		public int? RoomId { get; set; }
		/// <summary>
		///原存放处Id 
		/// </summary>
		public int? SourceRoomId { get; set; }
		/// <summary>
		///状态 0  未借出 ; 1 已借出;2 维修;3 停用;4 报废 
		/// </summary>
		public int? Status { get; set; }
		/// <summary>
		///是否缺失 0 缺失; 1 不缺失 
		/// </summary>
		public Boolean? IsLoss { get; set; }
		/// <summary>
		///备注 
		/// </summary>
		public string Remarks { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class InventoryPlan
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///盘点名称 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		///盘点单号 
		/// </summary>
		public string InventoryNo { get; set; }
		/// <summary>
		///盘点日期 
		/// </summary>
		public DateTime? InventoryTime { get; set; }
		/// <summary>
		///类型0仪器设备盘点1固定资产盘点 
		/// </summary>
		public Byte? Type { get; set; }
		/// <summary>
		///状态 0 未盘点;1 已盘点；2归档 
		/// </summary>
		public Byte? Status { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///修改人 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		///修改时间 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		///是否删除 0 正常;1 删除;2归档 
		/// </summary>
		public Byte? IsDelete { get; set; }
		/// <summary>
		///是否已生成盘点单(0 未生成; 1 已生成) 
		/// </summary>
		public Byte? IsGenerate { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class LearnYear
    {

		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///学期名称 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		///开学日期 
		/// </summary>
		public DateTime? StartDate { get; set; }
		/// <summary>
		///结束日期 
		/// </summary>
		public DateTime? EndDate { get; set; }
		/// <summary>
		///数据采集时间 
		/// </summary>
		public Byte? DataCollectionTime { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///修改人 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		///修改时间 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		///是否删除 0正常1删除2归档 
		/// </summary>
		public Byte? IsDelete { get; set; }
		/// <summary>
		///备注 
		/// </summary>
		public string Remarks { get; set; }
		/// <summary>
		///0启用 1禁用 
		/// </summary>
		public Byte? UseStatus { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class LogInfo
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///用户登录名 
		/// </summary>
		public string LoginName { get; set; }
		/// <summary>
		///当前IP 
		/// </summary>
		public string IP { get; set; }
		/// <summary>
		///模块 
		/// </summary>
		public string Module { get; set; }
		/// <summary>
		///操作类型 
		/// </summary>
		public string Type { get; set; }
		/// <summary>
		///操作内容 
		/// </summary>
		public string Operation { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///备注 
		/// </summary>
		public string Remarks { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class MenuInfo
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///菜单名称 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		///菜单父Id 
		/// </summary>
		public int? Pid { get; set; }
		/// <summary>
		///菜单Url 
		/// </summary>
		public string Url { get; set; }
		/// <summary>
		///菜单描述 
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		///是否菜单(0.非菜单；1.菜单) 
		/// </summary>
		public Boolean? isMeu { get; set; }
		/// <summary>
		///是否显示菜单(0.不显示;1.显示导航;2.显示权限列表;3.都显示) 
		/// </summary>
		public Byte? isShow { get; set; }
		/// <summary>
		///样式名称 
		/// </summary>
		public string iconClass { get; set; }
		/// <summary>
		///排序 
		/// </summary>
		public int? sortId { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class OrderEquipDetail
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///设备分类Id 
		/// </summary>
		public int? InventoryKindId { get; set; }
		/// <summary>
		///订单Id 
		/// </summary>
		public int? OrderId { get; set; }
		/// <summary>
		///分类名 
		/// </summary>
		public string InstrumentEquip { get; set; }
		/// <summary>
		///设备名 
		/// </summary>
		public string EquipDetailName { get; set; }
		/// <summary>
		///仪器设备资产 
		/// </summary>
		public string EquipId { get; set; }
		/// <summary>
		///数量 
		/// </summary>
		public int? Count { get; set; }
		/// <summary>
		///借出日期 
		/// </summary>
		public DateTime? LendTime { get; set; }
		/// <summary>
		///归还日期 
		/// </summary>
		public DateTime? ReturnTime { get; set; }
		/// <summary>
		///损坏情况 
		/// </summary>
		public string Damage { get; set; }
		/// <summary>
		///状态 1.未归还；2.归还；3.未借出 
		/// </summary>
		public Byte? Type { get; set; }
		/// <summary>
		///备注 
		/// </summary>
		public string Remarks { get; set; }
		/// <summary>
		///附件 
		/// </summary>
		public string Attachment { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class OrderInfo
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///订单编号 
		/// </summary>
		public string OrderNo { get; set; }
		/// <summary>
		///借用人 
		/// </summary>
		public string LoanName { get; set; }
		/// <summary>
		///学生领取人 
		/// </summary>
		public string IDCard { get; set; }
		/// <summary>
		///教学计划实验Id 
		/// </summary>
		public int? ExperimentId { get; set; }
		/// <summary>
		///附件 
		/// </summary>
		public string Attachment { get; set; }
		/// <summary>
		///类型 0 教学计划订单;1 外借订单 
		/// </summary>
		public Byte? Type { get; set; }
		/// <summary>
		///订单状态 0 未借出;1 部分借出;2 已借出;3 部分归还 4 完成 
		/// </summary>
		public int? Status { get; set; }
		/// <summary>
		///备注 
		/// </summary>
		public string Remarks { get; set; }
		/// <summary>
		///借出日期 
		/// </summary>
		public DateTime? LendTime { get; set; }
		/// <summary>
		///归还日期 
		/// </summary>
		public DateTime? ReturnTime { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///修改人 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		///修改时间 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		///是否删除 0 正常;1 删除;2归档 
		/// </summary>
		public Byte? IsDelete { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string stuLoanIDCard { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class PlanExperiment
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///实验名称 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		///实验类型 
		/// </summary>
		public Byte? Type { get; set; }
		/// <summary>
		///是否开放 
		/// </summary>
		public Byte? IsOpen { get; set; }
		/// <summary>
		///开课日期 
		/// </summary>
		public DateTime? StartDate { get; set; }
		/// <summary>
		///周次 
		/// </summary>
		public int? Week { get; set; }
		/// <summary>
		///星期 
		/// </summary>
		public int? Weekday { get; set; }
		/// <summary>
		///学时 
		/// </summary>
		public int? ClassHour { get; set; }
		/// <summary>
		///节次 
		/// </summary>
		public string Part { get; set; }
		/// <summary>
		///实验地点 
		/// </summary>
		public int? Place { get; set; }
		/// <summary>
		///机房 
		/// </summary>
		public int? ComputerRoom { get; set; }
		/// <summary>
		///每组人数 
		/// </summary>
		public int? GroupMemberNumber { get; set; }
		/// <summary>
		///每次组数 
		/// </summary>
		public int? GroupNumber { get; set; }
		/// <summary>
		///使用仪器设备 
		/// </summary>
		public string NeedEquip { get; set; }
		/// <summary>
		///实验内容 
		/// </summary>
		public string Contents { get; set; }
		/// <summary>
		///教学计划Id 
		/// </summary>
		public int? PlanId { get; set; }
		/// <summary>
		///状态 0 未生成订单;1 已生成订单 
		/// </summary>
		public Byte? Status { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///修改人 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		///修改时间 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		///是否删除 0 正常;1 删除;2归档 
		/// </summary>
		public Byte? IsDelete { get; set; }
		/// <summary>
		///上课班级 
		/// </summary>
		public string ClassName { get; set; }
		/// <summary>
		///实验类别 
		/// </summary>
		public Byte? Category { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class Repair
    {

		/// <summary>
		/// 
		/// </summary>
		public int? ID { get; set; }
		/// <summary>
		///报修人 
		/// </summary>
		public string RepairMan { get; set; }
		/// <summary>
		///仪器设备ID 
		/// </summary>
		public int? EquipID { get; set; }
		/// <summary>
		///填报时间 
		/// </summary>
		public DateTime? RepairTime { get; set; }
		/// <summary>
		///损坏原因 
		/// </summary>
		public string DamageCauses { get; set; }
		/// <summary>
		///损坏时间 
		/// </summary>
		public DateTime? Damagetime { get; set; }
		/// <summary>
		///修理地点 
		/// </summary>
		public string RepairLocation { get; set; }
		/// <summary>
		///修理费用 
		/// </summary>
		public string CostOfRepairs { get; set; }
		/// <summary>
		///修理完成时间 
		/// </summary>
		public string CompleteTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Remark { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? RepairStatus { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? IsDelete { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class RepairAttachment
    {

		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? RepairDetailsID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string AttachmentName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string AttachmentPath { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class RepairDetail
    {

		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? RepairID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Record { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RecordDate { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class Role
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///角色名称 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///修改人 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		///修改时间 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		///是否删除(0 正常;1 删除;2归档) 
		/// </summary>
		public Byte? IsDelete { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class RoleOfMenu
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///角色Id 
		/// </summary>
		public int? RoleId { get; set; }
		/// <summary>
		///菜单Id 
		/// </summary>
		public int? MenuId { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class RoleOfUser
    {

		/// <summary>
		///Id 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///角色Id 
		/// </summary>
		public int? RoleId { get; set; }
		/// <summary>
		///用户登录名 
		/// </summary>
		public string LoginName { get; set; }
    }
 
	/// </summary>
	///	教学计划表实体类
	/// </summary>
	[Serializable]
    public partial class SectionPlace
    {

		/// <summary>
		///Id主键 
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		///所名称 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		///所长 
		/// </summary>
		public string Director { get; set; }
		/// <summary>
		///副所长 
		/// </summary>
		public string ViceDirector { get; set; }
		/// <summary>
		///创建人 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		///创建时间 
		/// </summary>
		public DateTime? CreateTime { get; set; }
		/// <summary>
		///修改人 
		/// </summary>
		public string Editor { get; set; }
		/// <summary>
		///修改时间 
		/// </summary>
		public DateTime? UpdateTime { get; set; }
		/// <summary>
		///是否删除 0正常1删除2归档 
		/// </summary>
		public Byte? IsDelete { get; set; }
		/// <summary>
		///备注 
		/// </summary>
		public string Remarks { get; set; }
		/// <summary>
		///0启用 1禁用 
		/// </summary>
		public Byte? UseStatus { get; set; }
    }
}
