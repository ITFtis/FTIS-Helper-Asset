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

    public partial class AssetUser
    {
        [Key]
        [ColumnDef(Display = "資產編號", EditType = EditType.TextList, SelectItemsClassNamespace = AssetIDSelectItemsClassImp.AssemblyQualifiedName
            , Filter = true, FilterAssign = FilterAssignType.Contains, Sortable = true, ColSize = 3)]
        [StringLength(13)]
        public string AssetID { get; set; }

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

        [ColumnDef(Display = "所在位置", EditType = EditType.Select, SelectItemsClassNamespace = LocationsSelectItemsClassImp.AssemblyQualifiedName,
            Filter = true, FilterAssign = FilterAssignType.Contains, ColSize = 3, Sortable = true)]
        [StringLength(6)]
        public string LocationID { get; set; }

        [ColumnDef(Display = "部門", EditType = EditType.Select, SelectGearingWith = "CustodianID,Dcode", 
            SelectItemsClassNamespace = DepartmentSelectItemsClassImp.AssemblyQualifiedName,
            Filter = false, FilterAssign = FilterAssignType.Contains, Visible = true, ColSize = 3)]
        [StringLength(6)]
        public string CustodianDep/* { set; get; }*/
        {
            get
            {
                var emp = FtisHelperAsset.DB.Helpe.Employee.GetEmployee(this.CustodianID);
                return emp?.DCode;
            }
        }

        [ColumnDef(Display = "保管人", EditType = EditType.TextList, SelectItemsClassNamespace = EmpSelectItemsClassImp.AssemblyQualifiedName,
            Filter = false, FilterAssign = FilterAssignType.Contains, ColSize = 3, Sortable = true)]
        [StringLength(6)]
        public string CustodianID { get; set; }

        [Column(TypeName = "date")]
        [ColumnDef(Display = "購買日期", EditType = EditType.Date, Filter = false, FilterAssign = FilterAssignType.Between,
            Visible = false, VisibleEdit = false, ColSize = 3, Sortable = true)]
        public DateTime? PurchaseDate { get; set; }

        [ColumnDef(Display = "最後盤點日期", Visible = false, VisibleEdit = false)]
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
            Filter = false, FilterAssign = FilterAssignType.Contains, ColSize = 3, Visible = false, Sortable = true)]
        [StringLength(6)]
        public string StatusID { get; set; }

        [ColumnDef(Display = "備註", ColSize = 3, Sortable = true)]
        public string Remark { get; set; }
    }
}
