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
        [ColumnDef(Display = "���O�s��", EditType = EditType.Select,
            SelectItemsClassNamespace = CatesSelectItemsClassImp.AssemblyQualifiedName
            , Filter = true, FilterAssign = FilterAssignType.Equal, Sortable = true)]
        [StringLength(5)]
        public string CateID { get; set; }

        [Key]
        [ColumnDef(Display = "�����O�s��", EditType = EditType.Select,
            SelectItemsClassNamespace = SubCatesSelectItemsClassImp.AssemblyQualifiedName, Sortable = true)]
        [StringLength(5)]
        public string SubCateID { get; set; }

        [ColumnDef(Display = "���L�ƶq(A)", Sortable = true)]
        public int? Counts_Default_Inventory { get; set; }

        [ColumnDef(Display = "�s�W(B)", Sortable = true)]
        public int? Counts_NewAdd { get; set; }

        [ColumnDef(Display = "���o(C)", Sortable = true)]
        public int? Counts_Disposal { get; set; }

        [ColumnDef(Display = "�������L��(A+B-C)", Sortable = true)]
        public int? Counts_Period { get; set; }

        [ColumnDef(Display = "��ڽL�I��", Sortable = true)]
        public int? Counts_Actual_Inventory { get; set; }

        [ColumnDef(Display = "�L��", Sortable = true)]
        public int? Counts_Surplus { get; set; }

        [ColumnDef(Display = "�L��", Sortable = true)]
        public int? Counts_Losses { get; set; }
    }
}
