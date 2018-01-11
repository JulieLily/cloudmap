using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.StoreManage
{
	/// <summary>
	/// StoreplaceMoveData 的摘要说明。
	/// </summary>
	/// 
	[SerializableAttribute]
	[System.ComponentModel.DesignerCategory("Code")]


	public class StoreplaceMoveData :DataSet
	{
		public const String STOREPLACEMOVE_TABLE               = "TBL_StoreplaceMove";

		public const String PMRID_FIELD                        = "PMRID";
		public const String PMRNAME_FIELD                      = "PMRName";
		public const String MATERIALID_FIELD                   = "MaterialID";
		public const String DEPARTMENTID_FIELD                 = "DepartmentID";
		public const String STOREHOUSEID_FIELD                 = "StorehouseID";
		public const String TARGETPLACEID_FIELD                = "TargetPlaceID";
		public const String SOUCEPLACEID_FIELD                 = "SourcePlaceID";

		public const String PUB_ATTRIBUTE_FIELD                = "PUB_Attribute";
		public const String BATCHNO_FIELD                      = "BatchNO";
		public const String INTIME_FIELD                       = "InTime";
		public const String MOVENUMBER_FIELD                   = "MoveNumber";
		public const String UNIT_FIELD                         = "Unit";

		public const String CHANGERATE_FIELD                   = "ChangeRate";
		public const String PRICE_FIELD                        = "Price";
		public const String DRAWPERSON_FIELD                   = "DrawPerson";
		public const String DRAWDATE_FIELD                     = "DrawDate";
		public const String STATUS_FIELD                       = "Status";

		public const String ACCOUNTDEP_FIELD                   = "AccountDep";
		public const String DESCRIPTION_FIELD                  = "Description";

		public StoreplaceMoveData()
		{
			BuildDataTables();
		}
		private void BuildDataTables()
		{
			DataTable  tables    = new DataTable(STOREPLACEMOVE_TABLE);
			DataColumnCollection  columns  =  tables.Columns;

			columns.Add(PMRID_FIELD ,typeof(System.String));
			columns.Add(PMRNAME_FIELD ,typeof(System.String));
			columns.Add(MATERIALID_FIELD ,typeof(System.String));
			columns.Add(DEPARTMENTID_FIELD ,typeof(System.String));
			columns.Add(STOREHOUSEID_FIELD ,typeof(System.String));
			columns.Add(TARGETPLACEID_FIELD ,typeof(System.String));
			columns.Add(SOUCEPLACEID_FIELD ,typeof(System.String));

			columns.Add(PUB_ATTRIBUTE_FIELD ,typeof(System.String));
			columns.Add(BATCHNO_FIELD ,typeof(System.String));
			columns.Add(INTIME_FIELD ,typeof(System.DateTime));
			columns.Add(MOVENUMBER_FIELD ,typeof(System.String));
			columns.Add(UNIT_FIELD ,typeof(System.String));

			columns.Add(CHANGERATE_FIELD ,typeof(System.String));
			columns.Add(PRICE_FIELD ,typeof(System.String));
			columns.Add(DRAWPERSON_FIELD ,typeof(System.String));
			columns.Add(DRAWDATE_FIELD ,typeof(System.DateTime));
			columns.Add(STATUS_FIELD ,typeof(System.String));

			columns.Add(ACCOUNTDEP_FIELD ,typeof(System.String));
			columns.Add(DESCRIPTION_FIELD ,typeof(System.String));



			this.Tables.Add(tables);

		}
	}
}
