namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AssetInventoryLog")]
    public partial class AssetInventoryLog
    {
        [Key]
        [Column(Order = 0)]
        [ColumnDef(Display = "資產編號", Filter = true, FilterAssign = FilterAssignType.Contains, VisibleEdit = false, Sortable = true)]
        [StringLength(20)]
        public string AssetID { get; set; }

        [Key]
        [Column(Order = 1)]
        [ColumnDef(Display = "盤點時間", EditType = EditType.Datetime, Filter = true, FilterAssign = FilterAssignType.Between, VisibleEdit = false, Sortable = true)]
        public DateTime InventoryTime { get; set; }

        [ColumnDef(Display = "盤點年度", Filter = true, FilterAssign = FilterAssignType.Contains, VisibleEdit = false, Sortable = true)]
        public string InventoryYear { get; set; }

        [Required]
        [ColumnDef(Display = "盤點者", EditType = EditType.Select, SelectItemsClassNamespace = EmpSelectItemsClassImp.AssemblyQualifiedName, VisibleEdit = false, Sortable = true)]
        [StringLength(6)]
        public string InventoryFno { get; set; }

        [ColumnDef(Display = "輸入方式", EditType = EditType.Select, SelectItems = "{'B':'條碼掃描','K':'自行輸入'}",
            Filter = true, FilterAssign = FilterAssignType.Contains, VisibleEdit = false, Sortable = true)]
        public string InventoryInput { get; set; }

        [ColumnDef(Display = "備註", Sortable = true)]
        public string InventoryMemo { get; set; }
    }
}
