namespace OfertonGoApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Store")]
    public partial class Store
    {
     /*   [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Store()
        {
            Location = new HashSet<Location>();
            Product = new HashSet<Product>();
        }
        */
        [Key]
        public int id_store { get; set; }

        public int? id_business { get; set; }

        [StringLength(50)]
        public string description { get; set; }

        [StringLength(50)]
        public string adress { get; set; }

        [StringLength(300)]
        public string icon_url { get; set; }

      //  public virtual Business Business { get; set; }

     /*   [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Location> Location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }*/
    }
}
