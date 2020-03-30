namespace QHAQFWS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SyncDataQueue")]
    public partial class SyncDataQueue
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string ModelName { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Time { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool Status { get; set; }

        public DateTime LastTime { get; set; }
    }
}
