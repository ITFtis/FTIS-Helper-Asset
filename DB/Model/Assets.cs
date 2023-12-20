namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Spatial;
    using FtisHelperAsset.DB.Model;
    //using FtisHelperV2.DB;
    //using FtisHelperV2.DB.Helpe;

    public partial class Assets
    {
        [Key]
        [ColumnDef(Display = "資產編號", EditType = EditType.TextList, SelectItemsClassNamespace = AssetIDSelectItemsClassImp.AssemblyQualifiedName
            , Filter = true, FilterAssign = FilterAssignType.Contains, Sortable = true, ColSize = 3)]
        [StringLength(13)]
        public string AssetID { get; set; }

        [ColumnDef(Display = "請採購單號", Visible = false, ColSize = 3, Sortable = true)]
        [StringLength(20)]
        public string OrderNo { get; set; }

        [ColumnDef(Display = "名稱", ColSize = 3, Sortable = true)]
        [StringLength(50)]
        public string Name { get; set; }

        [ColumnDef(Display = "公司", EditType = EditType.Select, SelectItemsClassNamespace = CompanySelectItemsClassImp.AssemblyQualifiedName
            , Filter = true, FilterAssign = FilterAssignType.Equal, Visible = false, ColSize = 3, Sortable = true)]
        [StringLength(50)]
        public string Company { get; set; }

        [ColumnDef(Display = "主類別", EditType = EditType.Select, SelectGearingWith = "SubCateID,CateID", 
            SelectItemsClassNamespace = CatesSelectItemsClassImp.AssemblyQualifiedName, Filter = true, FilterAssign = FilterAssignType.Contains, 
            ColSize = 3, Sortable = true)]
        [StringLength(5)]
        public string CateID { get; set; }

        [ColumnDef(Display = "子類別", EditType = EditType.Select, SelectItemsClassNamespace = SubCatesSelectItemsClassImp.AssemblyQualifiedName
            , Filter = true, FilterAssign = FilterAssignType.Contains, ColSize = 3, Sortable = true)]
        [StringLength(5)]
        public string SubCateID { get; set; }

        [ColumnDef(Display = "規格/型號", ColSize = 3, Sortable = true)]
        [StringLength(50)]
        public string Specification { get; set; }

        [ColumnDef(Display = "數量", Visible = false, ColSize = 3, Sortable = true)]
        public int? Quantity { get; set; }

        [ColumnDef(Display = "單位", EditType = EditType.Select, 
            SelectItemsClassNamespace = UnitSelectItemsClassImp.AssemblyQualifiedName, Visible = false, ColSize = 3, Sortable = true)]
        [StringLength(6)]
        public string Unit_ID { get; set; }

        [Column(TypeName = "money")]
        [ColumnDef(Display = "單價(未稅)", Visible = false, ColSize = 3, Sortable = true)]
        public decimal? UnitPrice { get; set; }

        [Column(TypeName = "money")]
        [ColumnDef(Display = "取得金額", Visible = false, ColSize = 3, Sortable = true)]
        public decimal? PurchasePrice { get; set; }

        [ColumnDef(Display = "所在位置", EditType = EditType.Select, SelectItemsClassNamespace = LocationsSelectItemsClassImp.AssemblyQualifiedName,
            Filter = true, FilterAssign = FilterAssignType.Contains, ColSize = 3, Sortable = true)]
        [StringLength(6)]
        public string LocationID { get; set; }

        [ColumnDef(Display = "部門", EditType = EditType.Select, SelectGearingWith = "CustodianID,Dcode", 
            SelectItemsClassNamespace = DepartmentSelectItemsClassImp.AssemblyQualifiedName,
            Filter = true, FilterAssign = FilterAssignType.Contains, Visible = true, ColSize = 3)]
        [StringLength(6)]
        public string CustodianDep/* { set; get; }*/
        {
            get
            {
                var emp = FtisHelperAsset.DB.Helpe.Employee.GetEmployee(this.CustodianID);
                return emp?.DCode;
            }
        }

        [Required]
        [ColumnDef(Display = "保管人", EditType = EditType.TextList, SelectItemsClassNamespace = EmpSelectItemsClassImp.AssemblyQualifiedName,
            Filter = true, FilterAssign = FilterAssignType.Contains, ColSize = 3, Sortable = true)]
        [StringLength(6)]
        public string CustodianID { get; set; }

        [Column(TypeName = "date")]
        [ColumnDef(Display = "購買日期", EditType = EditType.Date, Filter = true, FilterAssign = FilterAssignType.Between, ColSize = 3, Sortable = true)]
        public DateTime? PurchaseDate { get; set; }

        [ColumnDef(Display = "供應商", EditType = EditType.Select, SelectItemsClassNamespace = SuppliersSelectItemsClassImp.AssemblyQualifiedName, 
            ColSize = 3, Sortable = true)]
        [StringLength(6)]
        public string SupplierID { get; set; }

        [ColumnDef(Display = "保固期(年)", Visible = false, ColSize = 3, Sortable = true)]
        [StringLength(4)]
        public string Warranty { get; set; }

        [ColumnDef(Display = "耐用年限", Visible = false, ColSize = 3, Sortable = true)]
        [StringLength(4)]
        public string Durability { get; set; }

        [Required]
        [ColumnDef(Display = "登錄人員", EditType = EditType.TextList, SelectItemsClassNamespace = EmpSelectItemsClassImp.AssemblyQualifiedName,
            Visible =false, VisibleEdit = false, ColSize = 3, Sortable = true)]
        [StringLength(6)]
        public string RecorderID { get; set; }

        [ColumnDef(Display = "最後盤點日期", Visible = true, VisibleEdit = false)]
        [StringLength(10)]
        public string InventoryTime/* { get; set; }*/
        {
            get
            {
                //var tt = FtisHelperAsset.DB.Helpe.Asset.GetAssetInventoryLogTime(this.AssetID)?.InventoryTime.ToString("yyyy/MM/dd");
                return FtisHelperAsset.DB.Helpe.Asset.GetAssetInventoryLogTime(this.AssetID)?.InventoryTime.ToString("yyyy/MM/dd");
            }
        }

        [ColumnDef(Display = "狀態", EditType = EditType.Select, SelectItemsClassNamespace = StatusSelectItemsClassImp.AssemblyQualifiedName,
            Filter = true, FilterAssign = FilterAssignType.Contains, ColSize = 3, Sortable = true)]
        [StringLength(6)]
        public string StatusID { get; set; }

        //20230911, add by markhong 總務追加租賃、租賃起迄日、租金(年)
        [ColumnDef(EditType = EditType.Select, Display = "租賃", SelectItems = "{\"true\":\"是\",\"false\":\"否\"}", DefaultValue = "false", ColSize = 3, Sortable = true)]
        public bool? IsLease { get; set; }

        [ColumnDef(EditType = EditType.Date, Display = "租賃日期(起)", Visible = false, ColSize = 3)]
        public DateTime? LeaseBeginDate { get; set; }

        [ColumnDef(EditType = EditType.Date, Display = "租賃日期(迄)", Visible = false, ColSize = 3)]
        public DateTime? LeaseEndDate { get; set; }

        [ColumnDef(Display = "租金(年)", Visible = false, ColSize = 3, Sortable = true)]
        public decimal? LeasingAmount { get; set; }

        [ColumnDef(Display = "備註", ColSize = 3, Sortable = true)]
        public string Remark { get; set; }

        [ColumnDef(Display = "是否為資訊資產", ColSize = 3, Visible = false, Sortable = true)]
        public bool? IsIT { get; set; }

        public virtual ICollection<AssetUsageLog> UsageLog { get; set; }

        public virtual ICollection<AssetITAttributes> ITAttr { get; set; }

    }
}
