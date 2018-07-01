namespace OfertonGoApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PromotionProduct")]
    public partial class PromotionProduct
    {
        [Key]
        public int id_promotion_product { get; set; }

        public int? id_promotion { get; set; }

        public int? id_product { get; set; }

        public int? id_store { get; set; }
        // public virtual Product Product { get; set; }

        //  public virtual Promotion Promotion { get; set; }
    }
}
