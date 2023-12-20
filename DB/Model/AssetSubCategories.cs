namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssetSubCategories
    {
        [Key]
        [ColumnDef(Display = "子類別編號", Sortable = true)]
        [StringLength(5)]
        public string SubCateID { get; set; }

        [ColumnDef(Display = "主類別編號", EditType = EditType.Select, SelectItemsClassNamespace = CatesSelectItemsClassImp.AssemblyQualifiedName
            , Filter = true, FilterAssign = FilterAssignType.Contains, Sortable = true)]
        [StringLength(5)]
        public string CateID { get; set; }

        [ColumnDef(Display = "子類別名稱", Sortable = true)]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
