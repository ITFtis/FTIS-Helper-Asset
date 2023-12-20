namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssetLoans
    {
        [Key]
        [ColumnDef(Display = "資產編號", Sortable = true)]
        [StringLength(20)]
        public string AssetID { get; set; }

        [ColumnDef(Display = "租借員工編號", Sortable = true)]
        [StringLength(6)]
        public string BorrowerID { get; set; }

        [Column(TypeName = "date")]
        [ColumnDef(Display = "租借時間", Sortable = true)]
        public DateTime? LoanDate { get; set; }

        [Column(TypeName = "date")]
        [ColumnDef(Display = "歸還時間", Sortable = true)]
        public DateTime? ReturnDate { get; set; }

        [ColumnDef(Display = "備註", Sortable = true)]
        [StringLength(255)]
        public string Comment { get; set; }
    }
}
