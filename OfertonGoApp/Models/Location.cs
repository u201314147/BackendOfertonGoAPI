namespace OfertonGoApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Location")]
    public partial class Location
    {
        [Key]
        public int id_location { get; set; }

        public int? id_store { get; set; }

        public double? latitude { get; set; }

        public double? longitude { get; set; }

    //    public virtual Store Store { get; set; }
    }
}
