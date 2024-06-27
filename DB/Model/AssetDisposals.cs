namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssetDisposals
    {
        [Key]
        [ColumnDef(Display = "�겣�s��", EditType = EditType.TextList, SelectItemsClassNamespace = AssetIDSelectItemsClassImp.AssemblyQualifiedName
            , Filter = true, FilterAssign = FilterAssignType.Contains, Sortable = true)]
        [StringLength(20)]
        public string AssetID { get; set; }

        [ColumnDef(Display = "���o���", EditType = EditType.Date, Filter = true,
            FilterAssign = FilterAssignType.Between, Sortable = true)]
        public DateTime? DisposalDate { get; set; }

        [ColumnDef(Display = "���o�~��", Filter = true, FilterAssign = FilterAssignType.Equal, VisibleEdit = false, Sortable = true)]
        public int DisposalYear { get; set; }

        [ColumnDef(Display = "���o��]", Sortable = true)]
        [StringLength(255)]
        public string Reason { get; set; }

        [ColumnDef(Display = "�겣�Ϥ�", EditType = EditType.Image,
            ImageMaxWidth = 200, ImageMaxHeight = 100, Sortable = true)]
        public string AssetImage { get; set; }

        [ColumnDef(Display = "�ӽФH��", Visible = false, VisibleEdit = false, Sortable = true)]
        public string Applicants { get; set; }

        [ColumnDef(Display = "�ӽЮɶ�", Visible = false, VisibleEdit = false, Sortable = true)]
        public DateTime? ApplicationTime { get; set; }


    }
}
