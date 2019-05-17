namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FOLLOWING")]
    public partial class FOLLOWING
    {
        [Key]
        public int demo_id { get; set; }

        [Required]
        [StringLength(25)]
        public string user_id { get; set; }

        [Required]
        [StringLength(25)]
        public string following_id { get; set; }

        public virtual PERSON PERSON { get; set; }

        public virtual PERSON PERSON1 { get; set; }
    }
}
