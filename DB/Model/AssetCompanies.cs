namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssetCompanies
    {
        [Key]
        [ColumnDef(Display = "編號", VisibleEdit = false, Sortable = true)]
        public int Id { get; set; }

        [ColumnDef(Display = "公司名稱", Sortable = true)]
        public string Name { get; set; }

        [ColumnDef(Display = "統一編號", Sortable = true)]
        public string TaxId { get; set; }
    }
}
