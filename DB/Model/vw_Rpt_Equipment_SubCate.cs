namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_Rpt_Equipment_SubCate
    {
        [ColumnDef(Display = "類別編號", EditType = EditType.Select,
            SelectItemsClassNamespace = CatesSelectItemsClassImp.AssemblyQualifiedName
            , Filter = true, FilterAssign = FilterAssignType.Equal, Sortable = true)]
        [StringLength(5)]
        public string CateID { get; set; }

        [Key]
        [ColumnDef(Display = "次類別編號", EditType = EditType.Select,
            SelectItemsClassNamespace = SubCatesSelectItemsClassImp.AssemblyQualifiedName, Sortable = true)]
        [StringLength(5)]
        public string SubCateID { get; set; }

        [ColumnDef(Display = "應盤數量(A)", Sortable = true)]
        public int? Counts_Default_Inventory { get; set; }

        [ColumnDef(Display = "新增(B)", Sortable = true)]
        public int? Counts_NewAdd { get; set; }

        [ColumnDef(Display = "報廢(C)", Sortable = true)]
        public int? Counts_Disposal { get; set; }

        [ColumnDef(Display = "本期應盤數(A+B-C)", Sortable = true)]
        public int? Counts_Period { get; set; }

        [ColumnDef(Display = "實際盤點數", Sortable = true)]
        public int? Counts_Actual_Inventory { get; set; }

        [ColumnDef(Display = "盤盈", Sortable = true)]
        public int? Counts_Surplus { get; set; }

        [ColumnDef(Display = "盤虧", Sortable = true)]
        public int? Counts_Losses { get; set; }
    }
}
