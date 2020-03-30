using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.Sync.QHDataService
{
    public enum AirQualityDataType
    {
        /// <summary>
        /// 原始标况
        /// </summary>
        SourceStandard,
        /// <summary>
        /// 审核标况
        /// </summary>
        ApprovalStandard,
        /// <summary>
        /// 原始实况
        /// </summary>
        SourceLive,
        /// <summary>
        /// 审核实况
        /// </summary>
        ApprovalLive
    }
}
