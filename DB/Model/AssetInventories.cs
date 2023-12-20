namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssetInventories
    {
        [Key]
        [ColumnDef(Display = "�겣�s��", Sortable = true)]
        [StringLength(20)]
        public string AssetID { get; set; }

        [ColumnDef(Display = "�L�I�ɶ�", Sortable = true)]
        [Column(TypeName = "date")]
        public DateTime? InventoryDate { get; set; }

        [ColumnDef(Display = "�Ƶ�", Sortable = true)]
        [StringLength(255)]
        public string Comment { get; set; }
    }
}
