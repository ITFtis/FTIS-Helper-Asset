namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssetRepairs
    {
        [Key]
        [ColumnDef(Display = "�겣�s��", Sortable = true)]
        [StringLength(20)]
        public string AssetID { get; set; }

        [ColumnDef(Display = "�겣�y�z", Sortable = true)]
        [StringLength(255)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        [ColumnDef(Display = "���׮ɶ�", Sortable = true)]
        public DateTime? RepairDate { get; set; }

        [Column(TypeName = "money")]
        [ColumnDef(Display = "���׶O��", Sortable = true)]
        public decimal? Cost { get; set; }
    }
}
