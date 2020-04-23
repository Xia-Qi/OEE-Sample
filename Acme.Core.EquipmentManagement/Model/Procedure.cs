using Acme.Core.Basic.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.EquipmentManagement.Model
{
    [Table("Procedure", Schema = "EquipmentManagement")]
    public class Procedure : BaseObject
    {
        public Procedure()
        {

        }
        public Procedure(string number, Equipment equipment, decimal production, decimal rejects, decimal consumption, int consumptionUnit, long runTime, long planHaltTime, decimal theoreticallyMeter, decimal rateOfTimeMovement, decimal performanceYield, decimal yield, decimal globalPlantEfficiency)
        {
            this.Number = number;
            this.Equipment = equipment;
            this.Production = production;
            this.Rejects = rejects;
            this.Consumption = consumption;
            this.ConsumptionUnit = (ExpendUnitType)consumptionUnit;
            this.RunTime = runTime;
            this.PlanHaltTime = planHaltTime;
            this.TheoreticallyMeter = theoreticallyMeter;
            this.RateOfTimeMovement = rateOfTimeMovement;
            this.PerformanceYield = performanceYield;
            this.Yield = yield;
            this.GlobalPlantEfficiency = globalPlantEfficiency;
        }
        public virtual string Number { get; set; }
        public virtual Equipment Equipment { get; set; }
        /// <summary>
        /// 产量
        /// </summary>
        public virtual decimal Production { get; set; }
        /// <summary>
        /// 次品
        /// </summary>
        public virtual decimal Rejects { get; set; }
        /// <summary>
        /// 消耗量
        /// </summary>
        public virtual decimal Consumption { get; set; }
        /// <summary>
        /// 消耗单位
        /// </summary>
        public virtual ExpendUnitType ConsumptionUnit { get; set; }
        /// <summary>
        /// 运行时间 秒
        /// </summary>
        public virtual long RunTime { get; set; }
        /// <summary>
        /// 计划停机时间 秒
        /// </summary>
        public virtual long PlanHaltTime { get; set; }
        /// <summary>
        /// 理论节拍 秒每件
        /// </summary>
        public virtual decimal TheoreticallyMeter { get; set; }
        /// <summary>
        /// 时间稼动率
        /// </summary>
        public virtual decimal RateOfTimeMovement { get; set; }
        /// <summary>
        /// 性能稼动率
        /// </summary>
        public virtual decimal PerformanceYield { get; set; }
        /// <summary>
        /// 合格率
        /// </summary>
        public virtual decimal Yield { get; set; }
        /// <summary>
        /// 全局设备效率
        /// </summary>
        public virtual decimal GlobalPlantEfficiency { get; set; }

        public enum ExpendUnitType
        {
            L = 0
        }
    }
}
