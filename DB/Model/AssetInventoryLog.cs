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
        [ColumnDef(Display = "�겣�s��", Filter = true, FilterAssign = FilterAssignType.Contains, VisibleEdit = false, Sortable = true)]
        [StringLength(20)]
        public string AssetID { get; set; }

        [Key]
        [Column(Order = 1)]
        [ColumnDef(Display = "�L�I�ɶ�", EditType = EditType.Datetime, Filter = true, FilterAssign = FilterAssignType.Between, VisibleEdit = false, Sortable = true)]
        public DateTime InventoryTime { get; set; }

        [ColumnDef(Display = "�L�I�~��", Filter = true, FilterAssign = FilterAssignType.Contains, VisibleEdit = false, Sortable = true)]
        public string InventoryYear { get; set; }

        [Required]
        [ColumnDef(Display = "�L�I��", EditType = EditType.Select, SelectItemsClassNamespace = EmpSelectItemsClassImp.AssemblyQualifiedName, VisibleEdit = false, Sortable = true)]
        [StringLength(6)]
        public string InventoryFno { get; set; }

        [ColumnDef(Display = "��J�覡", EditType = EditType.Select, SelectItems = "{'B':'���X���y','K':'�ۦ��J'}",
            Filter = true, FilterAssign = FilterAssignType.Contains, VisibleEdit = false, Sortable = true)]
        public string InventoryInput { get; set; }

        [ColumnDef(Display = "�Ƶ�", Sortable = true)]
        public string InventoryMemo { get; set; }
    }
}
