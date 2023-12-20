namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssetITAttributes
    {
        [Key]
        [ColumnDef(Display = "�ݩʽs��", Visible = false, Sortable = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttrId { get; set; }

        [ColumnDef(Display = "�겣�s��", VisibleEdit = false, Sortable = true)]
        [StringLength(20)]
        public string AssetsAssetID { get; set; }

        [ColumnDef(Display = "�Ǹ�", Sortable = true)]
        [StringLength(50)]
        public string SN { get; set; }

        [ColumnDef(Display = "�@�~�t��", Sortable = true)]
        [StringLength(10)]
        public string OS { get; set; }

        [ColumnDef(Display = "Office����", Sortable = true)]
        [StringLength(4)]
        public string OfficeVersion { get; set; }

        [ColumnDef(Display = "CPU", Sortable = true)]
        [StringLength(50)]
        public string Iserise { get; set; }

        [ColumnDef(Display = "�O����(���GG)", Sortable = true)]
        [StringLength(10)]
        public string RAM { get; set; }

        [ColumnDef(Display = "�T�A�w�Юe�q(���GG)", Sortable = true)]
        [StringLength(10)]
        public string SSD { get; set; }

        [ColumnDef(Display = "�ǲεw�Юe�q(���GG)", Sortable = true)]
        [StringLength(10)]
        public string HDD { get; set; }
    }
}
