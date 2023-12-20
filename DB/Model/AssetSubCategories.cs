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
        [ColumnDef(Display = "�l���O�s��", Sortable = true)]
        [StringLength(5)]
        public string SubCateID { get; set; }

        [ColumnDef(Display = "�D���O�s��", EditType = EditType.Select, SelectItemsClassNamespace = CatesSelectItemsClassImp.AssemblyQualifiedName
            , Filter = true, FilterAssign = FilterAssignType.Contains, Sortable = true)]
        [StringLength(5)]
        public string CateID { get; set; }

        [ColumnDef(Display = "�l���O�W��", Sortable = true)]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
