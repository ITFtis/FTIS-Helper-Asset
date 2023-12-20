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
        [ColumnDef(Display = "�겣�s��", EditType = EditType.TextList, SelectItemsClassNamespace = AssetIDSelectItemsClassImp.AssemblyQualifiedName
            , Filter = true, FilterAssign = FilterAssignType.Contains, Sortable = true, ColSize = 3)]
        [StringLength(13)]
        public string AssetID { get; set; }

        [ColumnDef(Display = "�б��ʳ渹", Visible = false, ColSize = 3, Sortable = true)]
        [StringLength(20)]
        public string OrderNo { get; set; }

        [ColumnDef(Display = "�W��", ColSize = 3, Sortable = true)]
        [StringLength(50)]
        public string Name { get; set; }

        [ColumnDef(Display = "���q", EditType = EditType.Select, SelectItemsClassNamespace = CompanySelectItemsClassImp.AssemblyQualifiedName
            , Filter = true, FilterAssign = FilterAssignType.Equal, Visible = false, ColSize = 3, Sortable = true)]
        [StringLength(50)]
        public string Company { get; set; }

        [ColumnDef(Display = "�D���O", EditType = EditType.Select, SelectGearingWith = "SubCateID,CateID", 
            SelectItemsClassNamespace = CatesSelectItemsClassImp.AssemblyQualifiedName, Filter = true, FilterAssign = FilterAssignType.Contains, 
            ColSize = 3, Sortable = true)]
        [StringLength(5)]
        public string CateID { get; set; }

        [ColumnDef(Display = "�l���O", EditType = EditType.Select, SelectItemsClassNamespace = SubCatesSelectItemsClassImp.AssemblyQualifiedName
            , Filter = true, FilterAssign = FilterAssignType.Contains, ColSize = 3, Sortable = true)]
        [StringLength(5)]
        public string SubCateID { get; set; }

        [ColumnDef(Display = "�W��/����", ColSize = 3, Sortable = true)]
        [StringLength(50)]
        public string Specification { get; set; }

        [ColumnDef(Display = "�ƶq", Visible = false, ColSize = 3, Sortable = true)]
        public int? Quantity { get; set; }

        [ColumnDef(Display = "���", EditType = EditType.Select, 
            SelectItemsClassNamespace = UnitSelectItemsClassImp.AssemblyQualifiedName, Visible = false, ColSize = 3, Sortable = true)]
        [StringLength(6)]
        public string Unit_ID { get; set; }

        [Column(TypeName = "money")]
        [ColumnDef(Display = "���(���|)", Visible = false, ColSize = 3, Sortable = true)]
        public decimal? UnitPrice { get; set; }

        [Column(TypeName = "money")]
        [ColumnDef(Display = "���o���B", Visible = false, ColSize = 3, Sortable = true)]
        public decimal? PurchasePrice { get; set; }

        [ColumnDef(Display = "�Ҧb��m", EditType = EditType.Select, SelectItemsClassNamespace = LocationsSelectItemsClassImp.AssemblyQualifiedName,
            Filter = true, FilterAssign = FilterAssignType.Contains, ColSize = 3, Sortable = true)]
        [StringLength(6)]
        public string LocationID { get; set; }

        [ColumnDef(Display = "����", EditType = EditType.Select, SelectGearingWith = "CustodianID,Dcode", 
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
        [ColumnDef(Display = "�O�ޤH", EditType = EditType.TextList, SelectItemsClassNamespace = EmpSelectItemsClassImp.AssemblyQualifiedName,
            Filter = true, FilterAssign = FilterAssignType.Contains, ColSize = 3, Sortable = true)]
        [StringLength(6)]
        public string CustodianID { get; set; }

        [Column(TypeName = "date")]
        [ColumnDef(Display = "�ʶR���", EditType = EditType.Date, Filter = true, FilterAssign = FilterAssignType.Between, ColSize = 3, Sortable = true)]
        public DateTime? PurchaseDate { get; set; }

        [ColumnDef(Display = "������", EditType = EditType.Select, SelectItemsClassNamespace = SuppliersSelectItemsClassImp.AssemblyQualifiedName, 
            ColSize = 3, Sortable = true)]
        [StringLength(6)]
        public string SupplierID { get; set; }

        [ColumnDef(Display = "�O�T��(�~)", Visible = false, ColSize = 3, Sortable = true)]
        [StringLength(4)]
        public string Warranty { get; set; }

        [ColumnDef(Display = "�@�Φ~��", Visible = false, ColSize = 3, Sortable = true)]
        [StringLength(4)]
        public string Durability { get; set; }

        [Required]
        [ColumnDef(Display = "�n���H��", EditType = EditType.TextList, SelectItemsClassNamespace = EmpSelectItemsClassImp.AssemblyQualifiedName,
            Visible =false, VisibleEdit = false, ColSize = 3, Sortable = true)]
        [StringLength(6)]
        public string RecorderID { get; set; }

        [ColumnDef(Display = "�̫�L�I���", Visible = true, VisibleEdit = false)]
        [StringLength(10)]
        public string InventoryTime/* { get; set; }*/
        {
            get
            {
                //var tt = FtisHelperAsset.DB.Helpe.Asset.GetAssetInventoryLogTime(this.AssetID)?.InventoryTime.ToString("yyyy/MM/dd");
                return FtisHelperAsset.DB.Helpe.Asset.GetAssetInventoryLogTime(this.AssetID)?.InventoryTime.ToString("yyyy/MM/dd");
            }
        }

        [ColumnDef(Display = "���A", EditType = EditType.Select, SelectItemsClassNamespace = StatusSelectItemsClassImp.AssemblyQualifiedName,
            Filter = true, FilterAssign = FilterAssignType.Contains, ColSize = 3, Sortable = true)]
        [StringLength(6)]
        public string StatusID { get; set; }

        //20230911, add by markhong �`�Ȱl�[����B����_����B����(�~)
        [ColumnDef(EditType = EditType.Select, Display = "����", SelectItems = "{\"true\":\"�O\",\"false\":\"�_\"}", DefaultValue = "false", ColSize = 3, Sortable = true)]
        public bool? IsLease { get; set; }

        [ColumnDef(EditType = EditType.Date, Display = "������(�_)", Visible = false, ColSize = 3)]
        public DateTime? LeaseBeginDate { get; set; }

        [ColumnDef(EditType = EditType.Date, Display = "������(��)", Visible = false, ColSize = 3)]
        public DateTime? LeaseEndDate { get; set; }

        [ColumnDef(Display = "����(�~)", Visible = false, ColSize = 3, Sortable = true)]
        public decimal? LeasingAmount { get; set; }

        [ColumnDef(Display = "�Ƶ�", ColSize = 3, Sortable = true)]
        public string Remark { get; set; }

        [ColumnDef(Display = "�O�_����T�겣", ColSize = 3, Visible = false, Sortable = true)]
        public bool? IsIT { get; set; }

        public virtual ICollection<AssetUsageLog> UsageLog { get; set; }

        public virtual ICollection<AssetITAttributes> ITAttr { get; set; }

    }
}
