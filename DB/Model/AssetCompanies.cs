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
        [ColumnDef(Display = "�s��", VisibleEdit = false, Sortable = true)]
        public int Id { get; set; }

        [ColumnDef(Display = "���q�W��", Sortable = true)]
        public string Name { get; set; }

        [ColumnDef(Display = "�Τ@�s��", Sortable = true)]
        public string TaxId { get; set; }
    }
}
