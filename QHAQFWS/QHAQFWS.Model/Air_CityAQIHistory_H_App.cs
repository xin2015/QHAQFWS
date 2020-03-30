namespace QHAQFWS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Air_CityAQIHistory_H_App
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

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityCode { get; set; }

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
