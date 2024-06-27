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
        [ColumnDef(Display = "資產編號", EditType = EditType.TextList, SelectItemsClassNamespace = AssetIDSelectItemsClassImp.AssemblyQualifiedName
            , Filter = true, FilterAssign = FilterAssignType.Contains, Sortable = true)]
        [StringLength(20)]
        public string AssetID { get; set; }

        [ColumnDef(Display = "報廢日期", EditType = EditType.Date, Filter = true,
            FilterAssign = FilterAssignType.Between, Sortable = true)]
        public DateTime? DisposalDate { get; set; }

        [ColumnDef(Display = "報廢年度", Filter = true, FilterAssign = FilterAssignType.Equal, VisibleEdit = false, Sortable = true)]
        public int DisposalYear { get; set; }

        [ColumnDef(Display = "報廢原因", Sortable = true)]
        [StringLength(255)]
        public string Reason { get; set; }

        [ColumnDef(Display = "資產圖片", EditType = EditType.Image,
            ImageMaxWidth = 200, ImageMaxHeight = 100, Sortable = true)]
        public string AssetImage { get; set; }

        [ColumnDef(Display = "申請人員", Visible = false, VisibleEdit = false, Sortable = true)]
        public string Applicants { get; set; }

        [ColumnDef(Display = "申請時間", Visible = false, VisibleEdit = false, Sortable = true)]
        public DateTime? ApplicationTime { get; set; }


    }
}
