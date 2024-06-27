namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    [Table("AssetUsageLog")]
    public partial class AssetUsageLog
    {
        [Key]
        [ColumnDef(Display = "使用編號", Visible = false, Sortable = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int DId { get; set; }

        [ColumnDef(Display = "資產編號", VisibleEdit = false, Sortable = true)]
        [StringLength(20)]
        public string AssetsAssetID { get; set; }

        [Required]
        [ColumnDef(Display = "原保管人", VisibleEdit = false, EditType = EditType.Select, SelectItemsClassNamespace = EmpSelectAllItemsClassImp.AssemblyQualifiedName, Sortable = true)]
        [StringLength(6)]
        public string CustodianSourceID { get; set; }

        [Required]
        [ColumnDef(Display = "目標保管人", VisibleEdit = false, EditType = EditType.Select, SelectItemsClassNamespace = EmpSelectAllItemsClassImp.AssemblyQualifiedName, Sortable = true)]
        [StringLength(6)]
        public string CustodianTargetID { get; set; }

        [Required]
        [ColumnDef(Display = "異動人員", VisibleEdit = false, EditType = EditType.Select, SelectItemsClassNamespace = EmpSelectAllItemsClassImp.AssemblyQualifiedName, Sortable = true)]
        [StringLength(6)]
        public string UpdateMan { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        [ColumnDef(Display = "異動時間", VisibleEdit = false, Sortable = true)]
        public DateTime? UpdateTime { get; set; }

        [Required]
        [ColumnDef(Display = "異動原因", VisibleEdit = false, Sortable = true)]
        [StringLength(255)]
        public string ModifiyReason { get; set; }

        [Required]
        [ColumnDef(Display = "資產位置", VisibleEdit = false, EditType = EditType.Select, SelectItemsClassNamespace = LocationsSelectItemsClassImp.AssemblyQualifiedName, Sortable = true)]
        [StringLength(6)]
        public string LocationID { get; set; }

        [Required]
        [ColumnDef(Display = "備註", Sortable = true)]
        [StringLength(255)]
        public string Notes { get; set; }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
    }
}
