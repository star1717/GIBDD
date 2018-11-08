namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shtraf")]
    public partial class Shtraf
    {
        [Key]
        public int Kod_shtraf { get; set; }

        public int Kod_driver_FK { get; set; }

        [StringLength(300)]
        public string opisanie { get; set; }

        public int cost { get; set; }
        public bool discount { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
