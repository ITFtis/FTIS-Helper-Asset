namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssetSuppliers
    {
        [Key]
        [ColumnDef(Display = "供應商編號", VisibleEdit = false, Sortable = true)]
        public int Id { get; set; }

        [ColumnDef(Display = "名稱", Sortable = true)]
        [StringLength(50)]
        public string Name { get; set; }

        [ColumnDef(Display = "電子郵件", Sortable = true)]
        [StringLength(50)]
        public string Email { get; set; }

        [ColumnDef(Display = "地址", Sortable = true)]
        [StringLength(50)]
        public string Address { get; set; }

        [ColumnDef(Display = "電話", Sortable = true)]
        [StringLength(15)]
        public string Phone { get; set; }
    }
}
