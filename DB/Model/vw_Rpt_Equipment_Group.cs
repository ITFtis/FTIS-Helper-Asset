namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_Rpt_Equipment_Group
    {
        [Key]
        [ColumnDef(Display = "組別", Sortable = true)]
        [StringLength(5)]
        public string Dnickname { get; set; }

        [ColumnDef(Display = "桌機", Sortable = true)]
        public int? PC { get; set; }

        [ColumnDef(Display = "筆電", Sortable = true)]
        public int? NB { get; set; }

        [ColumnDef(Display = "平板", Sortable = true)]
        public int? PAD { get; set; }

        [ColumnDef(Display = "顯示器", Sortable = true)]
        public int? Monitor { get; set; }

        [ColumnDef(Display = "M365", Sortable = true)]
        public int? M365 { get; set; }
    }
}
