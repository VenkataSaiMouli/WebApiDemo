namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PERSON")]
    public partial class PERSON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERSON()
        {
            FOLLOWINGs = new HashSet<FOLLOWING>();
            FOLLOWINGs1 = new HashSet<FOLLOWING>();
            TWEETs = new HashSet<TWEET>();
        }

        [Key]
        [StringLength(25)]
        public string user_id { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(30)]
        public string fullname { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        public DateTime joined { get; set; }

        public bool active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FOLLOWING> FOLLOWINGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FOLLOWING> FOLLOWINGs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TWEET> TWEETs { get; set; }
    }
}
