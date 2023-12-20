namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssetStatus
    {
        [Key]
        [ColumnDef(Display = "���A�s��", Sortable = true)]
        [StringLength(6)]
        public string StatusID { get; set; }

        [ColumnDef(Display = "���A�W��", Sortable = true)]
        [StringLength(10)]
        public string Name { get; set; }
    }
}
