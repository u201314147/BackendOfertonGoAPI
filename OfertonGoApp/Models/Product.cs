namespace OfertonGoApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            PromotionProduct = new HashSet<PromotionProduct>();
        }
        */
        [Key]
        public int id_product { get; set; }

        public int? id_store { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public Double? price { get; set; }

        [StringLength(300)]
        public string image_url { get; set; }

    //    public virtual Store Store { get; set; }

      /*  [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromotionProduct> PromotionProduct { get; set; }*/
    }
}
