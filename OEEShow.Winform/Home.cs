using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OEEShow.Winform
{
    public partial class Home : DevExpress.XtraEditors.XtraForm
    {
        public Home()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var data = new Acme.Core.EquipmentManagement.WebService.Impl.EquipmentManagement().GetProcedures();

            gridControl1.DataSource = data;
            DataSet ds = new DataSet();
            var tb = new DataTable();
            tb.Columns.Add("Number");
            tb.Columns.Add("Equipment.Code");
            tb.Columns.Add("Equipment.Name");
            tb.Columns.Add("FormatProduction");
            tb.Columns.Add("FormatRejects");
            tb.Columns.Add("RunTime");
            tb.Columns.Add("PlanHaltTime");
            tb.Columns.Add("FormatTheoreticallyMeter");
            tb.Columns.Add("RateOfTimeMovement");
            tb.Columns.Add("PerformanceYield");
            tb.Columns.Add("Yield");
            tb.Columns.Add("GlobalPlantEfficiency");
            foreach (var a in data)
            {
                var newRow = tb.NewRow();

                newRow.ItemArray = new object[] {
                    a.Number,
                    a.Equipment.Code, a.Equipment.Name,
                    a.Production, a.Rejects, a.RunTime, a.PlanHaltTime, a.TheoreticallyMeter, a.RateOfTimeMovement, a.PerformanceYield, a.Yield, a.GlobalPlantEfficiency
                };
                tb.Rows.Add(newRow);
            }
            ds.Tables.Add(tb);
            

            gridControl1.DataSource = ds.Tables[0];


            IList<OOEChartData> formatData = new List<OOEChartData>();
            foreach (var procedure in data)
            {
                formatData.Add(new OOEChartData() { TypeName = "时间稼动率", Value = procedure.RateOfTimeMovement, EquipmentName = procedure.Equipment.Name });
                formatData.Add(new OOEChartData() { TypeName = "性能稼动率", Value = procedure.PerformanceYield, EquipmentName = procedure.Equipment.Name });
                formatData.Add(new OOEChartData() { TypeName = "合格率", Value = procedure.Yield, EquipmentName = procedure.Equipment.Name });
                formatData.Add(new OOEChartData() { TypeName = "全局设备效率", Value = procedure.GlobalPlantEfficiency, EquipmentName = procedure.Equipment.Name });
            }
            chartControl1.BindToData(ViewType.Bar, formatData, "TypeName", "EquipmentName", "Value");
            //chartControl1.Series[0].Points.Add(new SeriesPoint("TypeName",)

        }
        private class OOEChartData
        {
            public string TypeName { get; set; }
            public decimal Value { get; set; }
            public string EquipmentName { get; set; }
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
