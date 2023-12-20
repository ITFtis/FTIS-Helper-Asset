namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssetITAttributes
    {
        [Key]
        [ColumnDef(Display = "屬性編號", Visible = false, Sortable = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttrId { get; set; }

        [ColumnDef(Display = "資產編號", VisibleEdit = false, Sortable = true)]
        [StringLength(20)]
        public string AssetsAssetID { get; set; }

        [ColumnDef(Display = "序號", Sortable = true)]
        [StringLength(50)]
        public string SN { get; set; }

        [ColumnDef(Display = "作業系統", Sortable = true)]
        [StringLength(10)]
        public string OS { get; set; }

        [ColumnDef(Display = "Office版本", Sortable = true)]
        [StringLength(4)]
        public string OfficeVersion { get; set; }

        [ColumnDef(Display = "CPU", Sortable = true)]
        [StringLength(50)]
        public string Iserise { get; set; }

        [ColumnDef(Display = "記憶體(單位：G)", Sortable = true)]
        [StringLength(10)]
        public string RAM { get; set; }

        [ColumnDef(Display = "固態硬碟容量(單位：G)", Sortable = true)]
        [StringLength(10)]
        public string SSD { get; set; }

        [ColumnDef(Display = "傳統硬碟容量(單位：G)", Sortable = true)]
        [StringLength(10)]
        public string HDD { get; set; }
    }
}
