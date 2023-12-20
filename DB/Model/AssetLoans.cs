namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssetLoans
    {
        [Key]
        [ColumnDef(Display = "�겣�s��", Sortable = true)]
        [StringLength(20)]
        public string AssetID { get; set; }

        [ColumnDef(Display = "���ɭ��u�s��", Sortable = true)]
        [StringLength(6)]
        public string BorrowerID { get; set; }

        [Column(TypeName = "date")]
        [ColumnDef(Display = "���ɮɶ�", Sortable = true)]
        public DateTime? LoanDate { get; set; }

        [Column(TypeName = "date")]
        [ColumnDef(Display = "�k�ٮɶ�", Sortable = true)]
        public DateTime? ReturnDate { get; set; }

        [ColumnDef(Display = "�Ƶ�", Sortable = true)]
        [StringLength(255)]
        public string Comment { get; set; }
    }
}
