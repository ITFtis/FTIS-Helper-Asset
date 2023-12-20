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
        [ColumnDef(Display = "�����ӽs��", VisibleEdit = false, Sortable = true)]
        public int Id { get; set; }

        [ColumnDef(Display = "�W��", Sortable = true)]
        [StringLength(50)]
        public string Name { get; set; }

        [ColumnDef(Display = "�q�l�l��", Sortable = true)]
        [StringLength(50)]
        public string Email { get; set; }

        [ColumnDef(Display = "�a�}", Sortable = true)]
        [StringLength(50)]
        public string Address { get; set; }

        [ColumnDef(Display = "�q��", Sortable = true)]
        [StringLength(15)]
        public string Phone { get; set; }
    }
}
