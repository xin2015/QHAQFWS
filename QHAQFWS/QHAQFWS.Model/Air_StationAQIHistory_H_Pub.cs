namespace QHAQFWS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Air_StationAQIHistory_H_Pub
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime TimePoint { get; set; }

        [StringLength(50)]
        public string Area { get; set; }

        public int CityCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string UniqueCode { get; set; }

        [StringLength(50)]
        public string PositionName { get; set; }

        [StringLength(8)]
        public string CO { get; set; }

        [StringLength(5)]
        public string NO2 { get; set; }

        [StringLength(5)]
        public string O3 { get; set; }

        [StringLength(5)]
        public string PM10 { get; set; }

        [StringLength(5)]
        public string PM2_5 { get; set; }

        [StringLength(5)]
        public string SO2 { get; set; }

        [StringLength(5)]
        public string AQI { get; set; }

        [StringLength(255)]
        public string PrimaryPollutant { get; set; }

        [StringLength(255)]
        public string Quality { get; set; }

        [StringLength(255)]
        public string Measure { get; set; }

        [StringLength(255)]
        public string Unheathful { get; set; }

        public DateTime? CreatetTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
