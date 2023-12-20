namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssetLocations
    {
        [Key]
        [ColumnDef(Display = "��m�s��", VisibleEdit = false, Sortable = true)]
        public int Id { get; set; }

        [ColumnDef(Display = "��m�W��", Sortable = true)]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
