using Dou.Misc.Attr;
using DouHelper;
using FtisHelperAsset.DB.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FtisHelperAsset.DB
{
    /// <summary>
    /// 資產編號所有條列項目
    /// </summary>
    public class AssetIDSelectItemsClassImp : SelectItemsClass
    {
        public const string AssemblyQualifiedName = "FtisHelperAsset.DB.AssetIDSelectItemsClassImp, FtisHelperAsset";

        protected static IEnumerable<Assets> _assets;
        protected static new IEnumerable<Assets> ASSETS
        {
            get
            {
                _assets = DouHelper.Misc.GetCache<IEnumerable<Assets>>(2 * 60 * 1000, AssemblyQualifiedName);
                if (_assets == null)
                {
                    _assets = Helpe.Asset.GetAllAssets();
                    DouHelper.Misc.AddCache(_assets, AssemblyQualifiedName);
                }
                return _assets;
            }
        }
        public override IEnumerable<KeyValuePair<string, object>> GetSelectItems()
        {
            return ASSETS.Select(s => new KeyValuePair<string, object>(s.AssetID, s.AssetID));
        }
        public static void ResetAssets()
        {
            Misc.ClearCache("FtisHelperAsset.DB.AssetIDSelectItemsClassImp, FtisHelperAsset");
        }
    }
    /// <summary>
    /// 資產主類別所有條列項目
    /// </summary>
    public class CatesSelectItemsClassImp : SelectItemsClass
    {
        public const string AssemblyQualifiedName = "FtisHelperAsset.DB.CatesSelectItemsClassImp, FtisHelperAsset";

        protected static IEnumerable<AssetCategories> _Cates;
        internal static new IEnumerable<AssetCategories> Cates
        {
            get
            {
                _Cates = DouHelper.Misc.GetCache<IEnumerable<AssetCategories>>(2 * 60 * 1000, AssemblyQualifiedName);
                if (_Cates == null)
                {
                    _Cates = Helpe.Asset.GetAllCategories();
                    DouHelper.Misc.AddCache(_Cates, AssemblyQualifiedName);
                }
                return _Cates;
            }
        }
        public override IEnumerable<KeyValuePair<string, object>> GetSelectItems()
        {
            return Cates.Select(s => new KeyValuePair<string, object>(s.CateID, s.Name));
        }
        public static void ResetCategories()
        {
            Misc.ClearCache("FtisHelperAsset.DB.CatesSelectItemsClassImp, FtisHelperAsset");
        }
    }
    /// <summary>
    /// 資產次類別所有條列項目
    /// </summary>
    public class SubCatesSelectItemsClassImp : SelectItemsClass
    {
        public const string AssemblyQualifiedName = "FtisHelperAsset.DB.SubCatesSelectItemsClassImp, FtisHelperAsset";

        protected static IEnumerable<AssetSubCategories> _SubCates;
        protected static new IEnumerable<AssetSubCategories> SubCates
        {
            get
            {
                _SubCates = DouHelper.Misc.GetCache<IEnumerable<AssetSubCategories>>(2 * 60 * 1000, AssemblyQualifiedName);
                if (_SubCates == null)
                {
                    _SubCates = Helpe.Asset.GetAllSubCategories();// && s.Fno=="F01721");
                    DouHelper.Misc.AddCache(_SubCates, AssemblyQualifiedName);
                }
                return _SubCates;
            }
        }
        public override IEnumerable<KeyValuePair<string, object>> GetSelectItems()
        {
            return SubCates.Select(s => new KeyValuePair<string, object>(s.SubCateID, "{\"v\":\"" + s.Name + "\",\"CateID\":\"" + s.CateID + "\"}"));
        }
        public static void ResetSubCategories()
        {
            Misc.ClearCache("FtisHelperAsset.DB.SubCatesSelectItemsClassImp, FtisHelperAsset");
        }
    }
    /// <summary>
    /// 資產狀態所有條列項目
    /// </summary>
    public class StatusSelectItemsClassImp : SelectItemsClass
    {
        public const string AssemblyQualifiedName = "FtisHelperAsset.DB.StatusSelectItemsClassImp, FtisHelperAsset";

        protected static new IEnumerable<AssetStatus> _Status;

        protected static new IEnumerable<FtisHelperAsset.DB.Model.AssetStatus> Status
        {
            get
            {
                _Status = DouHelper.Misc.GetCache<IEnumerable<AssetStatus>>(2 * 60 * 1000, AssemblyQualifiedName);
                if (_Status == null)
                {
                    _Status = FtisHelperAsset.DB.Helpe.Asset.GetAllStatus();
                    DouHelper.Misc.AddCache(_Status, AssemblyQualifiedName);
                }
                return _Status;
            }
        }
        public override IEnumerable<KeyValuePair<string, object>> GetSelectItems()
        {
            return Status.Select(s => new KeyValuePair<string, object>(s.StatusID, s.Name));
        }
        public static void ResetStatus()
        {
            Misc.ClearCache("FtisHelperAsset.DB.StatusSelectItemsClassImp, FtisHelperAsset");
        }
    }
    /// <summary>
    /// 供應商所有條列項目
    /// </summary>
    public class SuppliersSelectItemsClassImp : SelectItemsClass
    {
        public const string AssemblyQualifiedName = "FtisHelperAsset.DB.SuppliersSelectItemsClassImp, FtisHelperAsset";

        protected static IEnumerable<AssetSuppliers> _Suppliers;
        protected static new IEnumerable<FtisHelperAsset.DB.Model.AssetSuppliers> Suppliers
        {
            get
            {
                _Suppliers = DouHelper.Misc.GetCache<IEnumerable<AssetSuppliers>>(2 * 60 * 1000, AssemblyQualifiedName);
                if (_Suppliers == null)
                {
                    _Suppliers = FtisHelperAsset.DB.Helpe.Asset.GetAllSuppliers();
                    DouHelper.Misc.AddCache(_Suppliers, AssemblyQualifiedName);
                }
                return _Suppliers;
            }
        }
        public override IEnumerable<KeyValuePair<string, object>> GetSelectItems()
        {
            return Suppliers.Select(s => new KeyValuePair<string, object>(s.Id.ToString(), s.Name));
        }
        public static void ResetSuppliers()
        {
            Misc.ClearCache("FtisHelperAsset.DB.SuppliersSelectItemsClassImp, FtisHelperAsset");
        }
    }
    /// <summary>
    /// 資產單位所有條列項目
    /// </summary>
    public class UnitSelectItemsClassImp : SelectItemsClass
    {
        public const string AssemblyQualifiedName = "FtisHelperAsset.DB.UnitSelectItemsClassImp, FtisHelperAsset";

        protected static IEnumerable<AssetUnits> _Units;
        protected static new IEnumerable<FtisHelperAsset.DB.Model.AssetUnits> Units
        {
            get
            {
                _Units = DouHelper.Misc.GetCache<IEnumerable<AssetUnits>>(2 * 60 * 1000, AssemblyQualifiedName);
                if (_Units == null)
                {
                    _Units = FtisHelperAsset.DB.Helpe.Asset.GetAllUnits();
                    DouHelper.Misc.AddCache(_Units, AssemblyQualifiedName);
                }
                return _Units;
            }
        }
        public override IEnumerable<KeyValuePair<string, object>> GetSelectItems()
        {
            return Units.Select(s => new KeyValuePair<string, object>(s.UnitID.ToString(), s.Name));
        }
        public static void ResetUnits()
        {
            Misc.ClearCache("FtisHelperAsset.DB.UnitSelectItemsClassImp, FtisHelperAsset");
        }
    }
    /// <summary>
    /// 資產位置所有條列項目
    /// </summary>
    public class LocationsSelectItemsClassImp : SelectItemsClass
    {
        public const string AssemblyQualifiedName = "FtisHelperAsset.DB.LocationsSelectItemsClassImp, FtisHelperAsset";

        protected static IEnumerable<AssetLocations> _Locations;
        protected static new IEnumerable<FtisHelperAsset.DB.Model.AssetLocations> Locations
        {
            get
            {
                _Locations = DouHelper.Misc.GetCache<IEnumerable<AssetLocations>>(2 * 60 * 1000, AssemblyQualifiedName);
                if (_Locations == null)
                {
                    _Locations = FtisHelperAsset.DB.Helpe.Asset.GetAllLocations();
                    DouHelper.Misc.AddCache(_Locations, AssemblyQualifiedName);
                }
                return _Locations;
            }
        }
        public override IEnumerable<KeyValuePair<string, object>> GetSelectItems()
        {
            return Locations.Select(s => new KeyValuePair<string, object>(s.Id.ToString(), s.Name));
        }
        public static void ResetLocations()
        {
            Misc.ClearCache("FtisHelperAsset.DB.LocationsSelectItemsClassImp, FtisHelperAsset");
        }
    }
    /// <summary>
    /// 資產公司所有條列項目
    /// </summary>
    public class CompanySelectItemsClassImp : SelectItemsClass
    {
        public const string AssemblyQualifiedName = "FtisHelperAsset.DB.CompanySelectItemsClassImp, FtisHelperAsset";

        protected static new IEnumerable<AssetCompanies> _Companies;

        protected static new IEnumerable<FtisHelperAsset.DB.Model.AssetCompanies> Companies
        {
            get
            {
                _Companies = DouHelper.Misc.GetCache<IEnumerable<AssetCompanies>>(2 * 60 * 1000, AssemblyQualifiedName);
                if (_Companies == null)
                {
                    _Companies = FtisHelperAsset.DB.Helpe.Asset.GetAllCompanies();
                    DouHelper.Misc.AddCache(_Companies, AssemblyQualifiedName);
                }
                return _Companies;
            }
        }
        public override IEnumerable<KeyValuePair<string, object>> GetSelectItems()
        {
            return Companies.Select(s => new KeyValuePair<string, object>(s.Id.ToString(), s.Name));
        }
        public static void ResetCompanies()
        {
            Misc.ClearCache("FtisHelperAsset.DB.CompanySelectItemsClassImp, FtisHelperAsset");
        }
    }
}
