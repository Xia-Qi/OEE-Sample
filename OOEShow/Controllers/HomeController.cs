using Acme.Core.EquipmentManagement.Model;
using DevExpress.Utils;
using DevExpress.Web;
using DevExpress.Web.Mvc;
using OOEShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OOEShow.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Show(DateTimeOffset? t)
        {
            //var data = new List<Models.Test>() {
            //new Models.Test(){ A="a",B=2,C=1,D="d"},
            //new Models.Test(){ A="a2",B=4,C=2,D="d2"},
            //new Models.Test(){ A="a3",B=6,C=3,D="d3"},
            //};
            IList<Procedure> data = new List<Procedure>();
            IList<OOEChartData> formatData = new List<OOEChartData>();
            if (t == null)
            {
                ViewBag.GridData = formatData;
                return View(data);
            }

            data = new Acme.Core.EquipmentManagement.WebService.Impl.EquipmentManagement().GetProcedures(t.Value);

            foreach (var procedure in data)
            {
                formatData.Add(new OOEChartData() { TypeName = "时间稼动率", Value = procedure.RateOfTimeMovement, EquipmentName = procedure.Equipment.Name });
                formatData.Add(new OOEChartData() { TypeName = "性能稼动率", Value = procedure.PerformanceYield, EquipmentName = procedure.Equipment.Name });
                formatData.Add(new OOEChartData() { TypeName = "合格率", Value = procedure.Yield, EquipmentName = procedure.Equipment.Name });
                formatData.Add(new OOEChartData() { TypeName = "全局设备效率", Value = procedure.GlobalPlantEfficiency, EquipmentName = procedure.Equipment.Name });
            }
            ViewBag.GridData = formatData;
            return View(data);
        }
        public ActionResult OEEGridPartial()
        {
            var data = new Acme.Core.EquipmentManagement.WebService.Impl.EquipmentManagement().GetProcedures();
            return PartialView("OEEGridPartial", data);
        }
        public ActionResult OOEBarChartPartial()
        {
            var data = new Acme.Core.EquipmentManagement.WebService.Impl.EquipmentManagement().GetProcedures();
            IList<OOEChartData> formatData = new List<OOEChartData>();
            foreach (var procedure in data)
            {
                formatData.Add(new OOEChartData() { TypeName = "时间稼动率", Value = procedure.RateOfTimeMovement, EquipmentName = procedure.Equipment.Name });
                formatData.Add(new OOEChartData() { TypeName = "性能稼动率", Value = procedure.PerformanceYield, EquipmentName = procedure.Equipment.Name });
                formatData.Add(new OOEChartData() { TypeName = "合格率", Value = procedure.Yield, EquipmentName = procedure.Equipment.Name });
                formatData.Add(new OOEChartData() { TypeName = "全局设备效率", Value = procedure.GlobalPlantEfficiency, EquipmentName = procedure.Equipment.Name });
            }
            return PartialView("OOEBarChartPartial", formatData);
        }

        // This action method sends a document with the exported Grid to response.
        public ActionResult ExportTo()
        {
            var data = new Acme.Core.EquipmentManagement.WebService.Impl.EquipmentManagement().GetProcedures();
            return GridViewExtension.ExportToXls(GetGridSettings(), data);
        }
        public static GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            //settings.Name = "GridView";
            //settings.CallbackRouteValues = new { Controller = "Home", Action = "OEEGridPartial" };

            // Export-specific settings 
            settings.SettingsExport.ExportSelectedRowsOnly = false;
            settings.SettingsExport.FileName = "OOE（设备综合效率表）.xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;
            //settings.Settings.ShowFooter = true;
            //settings.Settings.ShowGroupPanel = true;
            settings.SettingsExport.EnableClientSideExportAPI = true;
            settings.SettingsExport.ExcelExportMode = DevExpress.Export.ExportType.WYSIWYG;

            //settings.KeyFieldName = "ProductID";
            //settings.Columns.Add("ProductName");
            //settings.Columns.Add("UnitPrice").PropertiesEdit.DisplayFormatString = "c";
            //settings.Columns.Add("QuantityPerUnit");
            //settings.Columns.Add("Discontinued", MVCxGridViewColumnType.CheckBox);

            settings.Name = "OOE（设备综合效率表）";
            settings.CallbackRouteValues = new { Controller = "Home", Action = "OEEGridPartial" };
            settings.Width = Unit.Percentage(100);

            //settings.Columns.Add("UnitPrice").PropertiesEdit.DisplayFormatString = "c";
            //settings.Columns.Add(c => {
            //    c.FieldName = "Total";
            //    c.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            //    c.PropertiesEdit.DisplayFormatString = "c";
            //});
            settings.Columns.Add("Number", "工序号");
            settings.Columns.Add("Equipment.Code", "设备编码");
            settings.Columns.Add("Equipment.Name", "设备名称");
            settings.Columns.Add(column =>
            {
                column.FieldName = "FormatProduction";
                column.Caption = "日产量";
                column.UnboundType = DevExpress.Data.UnboundColumnType.String;
            });
            settings.Columns.Add(column =>
            {
                column.FieldName = "FormatRejects";
                column.Caption = "不合格数量";
                column.UnboundType = DevExpress.Data.UnboundColumnType.String;
            });
            settings.Columns.Add("RunTime", "运行时间（秒）");
            settings.Columns.Add("PlanHaltTime", "计划停机时间（秒）");
            settings.Columns.Add(column =>
            {
                column.FieldName = "FormatTheoreticallyMeter";
                column.Caption = "理论节拍（秒每件）";
                column.UnboundType = DevExpress.Data.UnboundColumnType.String;
            });
            settings.Columns.Add("RateOfTimeMovement", "时间稼动率");
            settings.Columns.Add("PerformanceYield", "性能稼动率");
            settings.Columns.Add("Yield", "合格率");
            settings.Columns.Add("GlobalPlantEfficiency", "全局设备效率");

            //settings.Toolbars.Add(t => {
            //    t.SettingsAdaptivity.Enabled = true;
            //    t.SettingsAdaptivity.EnableCollapseRootItemsToIcons = true;
            //    t.Items.Add(GridViewToolbarCommand.Refresh).Text = "刷新";
            //    t.Items.Add(GridViewToolbarCommand.ExportToXlsx).Text = "导出数据/打印";

            //});

            //settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Count, "CompanyName");
            //settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total");
            //settings.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total");
            //settings.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, "CompanyName");
            settings.CustomColumnDisplayText = (sender, e) =>
            {
                if (e.Column.FieldName == "Yield")
                {
                    e.DisplayText = ((decimal)e.Value).ToString("#.##");
                }
            };
            settings.CustomUnboundColumnData = (sender, e) =>
            {
                if (e.Column.FieldName == "Total")
                {
                    decimal price = (decimal)e.GetListSourceFieldValue("C");
                    int quantity = 10;
                    e.Value = price * quantity;
                }
                if (e.Column.FieldName == "FormatProduction")
                {
                    var production = (decimal)e.GetListSourceFieldValue("Production");
                    var unit = (Acme.Core.EquipmentManagement.Model.Procedure.ExpendUnitType)e.GetListSourceFieldValue("ConsumptionUnit");
                    var consumption = (decimal)e.GetListSourceFieldValue("Consumption");
                    e.Value = string.Format("{0:#.#}{1}:{2:#.}", consumption, unit.ToString(), production);
                }
                if (e.Column.FieldName == "FormatRejects")
                {
                    var rejects = (decimal)e.GetListSourceFieldValue("Rejects");
                    var unit = (Acme.Core.EquipmentManagement.Model.Procedure.ExpendUnitType)e.GetListSourceFieldValue("ConsumptionUnit");
                    var consumption = (decimal)e.GetListSourceFieldValue("Consumption");
                    e.Value = string.Format("{0:#.#}{1}:{2:0.#}", consumption, unit.ToString(), rejects);
                }
                if (e.Column.FieldName == "FormatTheoreticallyMeter")
                {
                    var theoreticallyMeter = (decimal)e.GetListSourceFieldValue("TheoreticallyMeter");
                    var unit = (Acme.Core.EquipmentManagement.Model.Procedure.ExpendUnitType)e.GetListSourceFieldValue("ConsumptionUnit");
                    var consumption = (decimal)e.GetListSourceFieldValue("Consumption");
                    e.Value = string.Format("{0:#.#}{1}:{2}", consumption, unit.ToString(), theoreticallyMeter);
                }
            };
            settings.SettingsExport.RenderBrick = (sender, e) =>
            {
                if (e.RowType == GridViewRowType.Data && e.VisibleIndex % 2 == 0)
                    e.BrickStyle.BackColor = System.Drawing.Color.FromArgb(0xEE, 0xEE, 0xEE);
            };
            settings.PreRender = (sender, e) =>
            {
                ((MVCxGridView)sender).ExpandAll();
            };

            settings.EnablePagingGestures = AutoBoolean.False;
            settings.SettingsPager.EnableAdaptivity = true;
            settings.SettingsPager.PageSize = 10;
            settings.Styles.Header.Wrap = DefaultBoolean.True;
            settings.Styles.GroupPanel.CssClass = "GridNoWrapGroupPanel";

            return settings;
        }
    }
}