namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssetUnits
    {
        [Key]
        [ColumnDef(Display = "單位編號", VisibleEdit = false, Sortable = true)]
        public int UnitID { get; set; }

        [ColumnDef(Display = "單位名稱", Sortable = true)]
        [StringLength(5)]
        public string Name { get; set; }
    }
}
