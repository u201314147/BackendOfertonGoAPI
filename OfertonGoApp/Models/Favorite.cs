namespace OfertonGoApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Favorite")]
    public partial class Favorite
    {
        [Key]
        public int id_favorite { get; set; }

        public int? id_user { get; set; }

        public int? id_promotion { get; set; }

      //  public virtual Promotion Promotion { get; set; }

     //   public virtual User User { get; set; }
    }
}
