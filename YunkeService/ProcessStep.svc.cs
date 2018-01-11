using System;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

using TOPSUN.ERP.Common.Data.Manufacture;
using TOPSUN.ERP.BusinessFacade.ManufactureSystem;

namespace TOPSUN.YunkeService
{
    public class ProcessStep : IProcessStep
    {

        public bool SaveProcessStep(ProcessStepData stepdata)
        {
            ManufacturePlanSystem mSystem = new ManufacturePlanSystem();
            ProcessRecordData data = new ProcessRecordData();
            DataRow dr = data.Tables[ProcessRecordData.ProcessRecord_TABLE].NewRow();

            dr[ProcessRecordData.CardID_FIELD] = stepdata.CardID;
            dr[ProcessRecordData.ProcessID_FIELD] = stepdata.ProcessID;
            dr[ProcessRecordData.RawNum_FIELD] = Int16.Parse(stepdata.TR_Number);
            dr[ProcessRecordData.QualifiedNum_FIELD] = Int16.Parse(stepdata.HG_Number);
            dr[ProcessRecordData.RejectNum_FIELD] = Int16.Parse(stepdata.BF_Number);
            //dr[ProcessRecordData.MachineID_FIELD] = stepdata.MachineID;
            dr[ProcessRecordData.WorkerID_FIELD] = stepdata.UserID;
            dr[ProcessRecordData.FinishedDate_FIELD] = DateTime.Now;

            data.Tables[ProcessRecordData.ProcessRecord_TABLE].Rows.Add(dr);

            return mSystem.SaveProcessRecord(data);
        }

        public IList<ProcessInfo> GetProcessInfo(string cardid)
        {
            ManufacturePlanSystem mSystem = new ManufacturePlanSystem();
            ManufactureProcessDate data = mSystem.LoadUnfinishedProcessTemplate(cardid);
            if (data.Tables[ManufactureProcessDate.ManufactureProcess_TABLE].Rows.Count > 0)
            {
                IList<ProcessInfo> result = new List<ProcessInfo>();

                DataView dv = data.Tables[ManufactureProcessDate.ManufactureProcess_TABLE].DefaultView;
                foreach (DataRowView drv in dv)
                {
                    ProcessInfo proc = new ProcessInfo();
                    proc.ProcessID = drv[ManufactureProcessDate.ProcessID_FIELD].ToString().Trim();
                    proc.ProcessName = drv[ManufactureProcessDate.Name_FIELD].ToString().Trim();
                    result.Add(proc);                
                }

                return result;
            }
            else
                return null;
        }

        public CardInfo GetCardInfo(string id)
        {
            ManufacturePlanDetailData data = (new ManufacturePlanSystem()).LoadManufacturePlanDetailByCardID(id);

            if (data.Tables[ManufacturePlanDetailData.ManufacturePlanDetail_TABLE].Rows.Count == 1)
            {
                CardInfo result = new CardInfo();

                result.CPXH = data.Tables[ManufacturePlanDetailData.ManufacturePlanDetail_TABLE].Rows[0][ManufacturePlanDetailData.Model_FIELD].ToString().Trim();
                result.ZZDH = data.Tables[ManufacturePlanDetailData.ManufacturePlanDetail_TABLE].Rows[0][ManufacturePlanDetailData.ResistanceCode_FIELD].ToString().Trim();
                result.SCPH = data.Tables[ManufacturePlanDetailData.ManufacturePlanDetail_TABLE].Rows[0][ManufacturePlanDetailData.ManufactureBatch_FIELD].ToString().Trim();
                result.CPZZ = data.Tables[ManufacturePlanDetailData.ManufacturePlanDetail_TABLE].Rows[0][ManufacturePlanDetailData.ResistanceValue_FIELD].ToString().Trim();
                result.JDDJ = data.Tables[ManufacturePlanDetailData.ManufacturePlanDetail_TABLE].Rows[0][ManufacturePlanDetailData.AccuracyLevel_FIELD].ToString().Trim();
                result.WDTX = data.Tables[ManufacturePlanDetailData.ManufacturePlanDetail_TABLE].Rows[0][ManufacturePlanDetailData.TemperatureChar_FIELD].ToString().Trim();
                result.ZLDJ = data.Tables[ManufacturePlanDetailData.ManufacturePlanDetail_TABLE].Rows[0][ManufacturePlanDetailData.QualityRating_FIELD].ToString().Trim();
                result.ZXBZ = data.Tables[ManufacturePlanDetailData.ManufacturePlanDetail_TABLE].Rows[0][ManufacturePlanDetailData.Standard_FIELD].ToString().Trim();
                //result.FHRQ = ((DateTime)data.Tables[ManufacturePlanDetailData.ManufacturePlanDetail_TABLE].Rows[0][ManufacturePlanDetailData.DeliveryDate_FIELD]).ToString("yyyy-MM-dd");
                result.HTH = data.Tables[ManufacturePlanDetailData.ManufacturePlanDetail_TABLE].Rows[0][ManufacturePlanDetailData.ContractID_FIELD].ToString().Trim();
                result.TCSL = data.Tables[ManufacturePlanDetailData.ManufacturePlanDetail_TABLE].Rows[0][ManufacturePlanDetailData.Num_FIELD].ToString().Trim();
                result.SM = data.Tables[ManufacturePlanDetailData.ManufacturePlanDetail_TABLE].Rows[0][ManufacturePlanDetailData.Directions_FIELD].ToString().Trim();

                return result;
            }
            else
                return null;
        }
    }
}
