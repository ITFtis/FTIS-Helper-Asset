namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    public partial class F22cmmDep
    {
        [Key]
        [Column(Order = 0)]
        [ColumnDef(Display = "部門代碼(新)")]
        [StringLength(2)]
        public string DCode { get; set; }

        [Required]
        [Column(Order = 1)]
        [ColumnDef(Display = "部門名稱")]
        [StringLength(20)]
        public string DName { get; set; }

        [Required]
        [Column(Order = 2)]
        [ColumnDef(Display = "部門簡稱", ColSize = 3)]
        [StringLength(20)]
        public string Dnickname { get; set; }

        [ColumnDef(Display = "部門名稱(英)", ColSize = 3)]
        [StringLength(50)]
        public string En_DName { get; set; }

        [ColumnDef(Display = "督導人1")]
        [StringLength(6)]
        public string DCkNo1 { get; set; }

        [ColumnDef(Display = "督導人2")]
        [StringLength(6)]
        public string DCkNo2 { get; set; }

        [ColumnDef(Display = "督導人3")]
        [StringLength(6)]
        public string DCkNo3 { get; set; }

        [ColumnDef(Display = "管理師")]
        [StringLength(6)]
        public string DAdmino { get; set; }

        [ColumnDef(Display = "最高主管")]
        [StringLength(6)]
        public string DCkTopNo { get; set; }

        [Required]
        [Column(Order = 3)]
        [ColumnDef(Display = "啟用與否")]
        [StringLength(1)]
        public string IsUsed { get; set; }

        [Required]
        [Column(Order = 4)]
        [ColumnDef(Display = "部門代碼(舊)")]
        [StringLength(2)]
        public string DCode_ { get; set; }

        public List<F22cmmEmpData> EmpDatas { get; set; }   
    }
}
