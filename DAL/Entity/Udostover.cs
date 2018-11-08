namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Udostover")]
    public partial class Udostover
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Number_udostover { get; set; }

        public int Kod_driver_FK { get; set; }

        [Required]
        [StringLength(10)]
        public string Kategori { get; set; }

        public DateTime Date_v { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
