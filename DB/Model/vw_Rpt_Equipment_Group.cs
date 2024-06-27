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
        [ColumnDef(Display = "�էO", Sortable = true)]
        [StringLength(5)]
        public string Dnickname { get; set; }

        [ColumnDef(Display = "���", Sortable = true)]
        public int? PC { get; set; }

        [ColumnDef(Display = "���q", Sortable = true)]
        public int? NB { get; set; }

        [ColumnDef(Display = "���O", Sortable = true)]
        public int? PAD { get; set; }

        [ColumnDef(Display = "��ܾ�", Sortable = true)]
        public int? Monitor { get; set; }

        [ColumnDef(Display = "M365", Sortable = true)]
        public int? M365 { get; set; }
    }
}
