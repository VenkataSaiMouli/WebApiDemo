namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TWEET")]
    public partial class TWEET
    {
        [Key]
        public int tweet_id { get; set; }

        [Required]
        [StringLength(25)]
        public string user_id { get; set; }

        [Required]
        [StringLength(140)]
        public string message { get; set; }

        public DateTime created { get; set; }

        public virtual PERSON PERSON { get; set; }
    }
}
