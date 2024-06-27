namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    [Table("AssetUsageLog")]
    public partial class AssetUsageLog
    {
        [Key]
        [ColumnDef(Display = "�ϥνs��", Visible = false, Sortable = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int DId { get; set; }

        [ColumnDef(Display = "�겣�s��", VisibleEdit = false, Sortable = true)]
        [StringLength(20)]
        public string AssetsAssetID { get; set; }

        [Required]
        [ColumnDef(Display = "��O�ޤH", VisibleEdit = false, EditType = EditType.Select, SelectItemsClassNamespace = EmpSelectAllItemsClassImp.AssemblyQualifiedName, Sortable = true)]
        [StringLength(6)]
        public string CustodianSourceID { get; set; }

        [Required]
        [ColumnDef(Display = "�ؼЫO�ޤH", VisibleEdit = false, EditType = EditType.Select, SelectItemsClassNamespace = EmpSelectAllItemsClassImp.AssemblyQualifiedName, Sortable = true)]
        [StringLength(6)]
        public string CustodianTargetID { get; set; }

        [Required]
        [ColumnDef(Display = "���ʤH��", VisibleEdit = false, EditType = EditType.Select, SelectItemsClassNamespace = EmpSelectAllItemsClassImp.AssemblyQualifiedName, Sortable = true)]
        [StringLength(6)]
        public string UpdateMan { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        [ColumnDef(Display = "���ʮɶ�", VisibleEdit = false, Sortable = true)]
        public DateTime? UpdateTime { get; set; }

        [Required]
        [ColumnDef(Display = "���ʭ�]", VisibleEdit = false, Sortable = true)]
        [StringLength(255)]
        public string ModifiyReason { get; set; }

        [Required]
        [ColumnDef(Display = "�겣��m", VisibleEdit = false, EditType = EditType.Select, SelectItemsClassNamespace = LocationsSelectItemsClassImp.AssemblyQualifiedName, Sortable = true)]
        [StringLength(6)]
        public string LocationID { get; set; }

        [Required]
        [ColumnDef(Display = "�Ƶ�", Sortable = true)]
        [StringLength(255)]
        public string Notes { get; set; }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
    }
}
