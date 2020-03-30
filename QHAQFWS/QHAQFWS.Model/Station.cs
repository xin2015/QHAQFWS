namespace QHAQFWS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Station")]
    public partial class Station
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string PositionName { get; set; }

        [Required]
        [StringLength(50)]
        public string Area { get; set; }

        public int? DistrictCode { get; set; }

        [StringLength(20)]
        public string UniqueCode { get; set; }

        [StringLength(10)]
        public string StationCode { get; set; }

        [StringLength(255)]
        public string PollutantCodes { get; set; }

        public int? StationTypeId { get; set; }

        public bool Status { get; set; }

        [StringLength(15)]
        public string Longitude { get; set; }

        [StringLength(15)]
        public string Latitude { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(50)]
        public string StationPic { get; set; }

        public DateTime? BuildDate { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(10)]
        public string Manager { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? IsVirtual { get; set; }

        public int? IsContrast { get; set; }
    }
}
