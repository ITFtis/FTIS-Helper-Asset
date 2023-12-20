using Dou.Misc.Attr;
using FtisHelperAsset.DB.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FtisHelperAsset.DB
{
    public class CatesSelectItemsClassImp : SelectItemsClass
    {
        public const string AssemblyQualifiedName = "FtisHelperAsset.DB.CatesSelectItemsClassImp, FtisHelperAsset";

        protected static List<AssetCategories> _Cates;
        internal static List<AssetCategories> Cates
        {
            get
            {
                _Cates = DouHelper.Misc.GetCache<List<AssetCategories>>(2 * 60 * 1000, AssemblyQualifiedName);
                if (_Cates == null || _Cates.Count == 0)
                {
                    //取得DB指定table的所有資料
                    var _allSubCates = FtisHelperAsset.DB.Helpe.Asset.GetAllSubCategories();
                    var _allCates = FtisHelperAsset.DB.Helpe.Asset.GetAllCategories();
                    //Newtonsoft.Json序列化(重要)
                    string jsonAC = JsonConvert.SerializeObject(_allCates);
                    string jsonSC = JsonConvert.SerializeObject(_allSubCates);
                    //Newtonsoft.Json反序列化(重要)
                    var jacs = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(jsonAC);
                    var jscs = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(jsonSC);
                    _Cates = new List<AssetCategories>();
                    //逐一將資料匯入newlist的主類中
                    foreach (var ja in jacs)
                    {
                        AssetCategories ac = new AssetCategories();
                        ac.CateID = ja.Value<string>("CateID");
                        ac.Name = ja.Value<string>("Name");
                        ac.SubCate = new List<AssetSubCategories>();
                        //再逐一匯入newlist的次類資料
                        foreach (var js in jscs)
                        {
                            if (js.Value<string>("CateID") == ac.CateID)
                            {
                                //根據class裡面有什麼欄位就對應匯入
                                ac.SubCate.Add(new AssetSubCategories { SubCateID = js.Value<string>("SubCateID"), Name = js.Value<string>("Name"), CateID = ac.CateID });
                            }
                        }
                        //匯入最外層的list中
                        _Cates.Add(ac);
                    }
                    DouHelper.Misc.AddCache(_Cates, AssemblyQualifiedName);
                }
                return _Cates;
            }
        }
        public override IEnumerable<KeyValuePair<string, object>> GetSelectItems()
        {
            return Cates.Select(s => new KeyValuePair<string, object>(s.CateID, s.Name));
        }
    }

    public class SubCatesSelectItemsClassImp : SelectItemsClass
    {
        public const string AssemblyQualifiedName = "FtisHelperAsset.DB.SubCatesSelectItemsClassImp, FtisHelperAsset";
        public override IEnumerable<KeyValuePair<string, object>> GetSelectItems()
        {
            List<AssetSubCategories> ts = new List<AssetSubCategories>();
            CatesSelectItemsClassImp.Cates.ForEach(s => ts.AddRange(s.SubCate));
            return ts.Select(s => new KeyValuePair<string, object>(s.SubCateID, "{\"v\":\"" + s.Name + "\",\"CateId\":\"" + s.CateID + "\"}"));
        }
    }

    public class StatusSelectItemsClassImp : SelectItemsClass
    {
        public const string AssemblyQualifiedName = "FtisHelperAsset.DB.StatusSelectItemsClassImp, FtisHelperAsset";

        protected static IEnumerable<AssetStatus> _Status;

        protected static new IEnumerable<FtisHelperAsset.DB.Model.AssetStatus> Status
        {
            get
            {
                _Status = DouHelper.Misc.GetCache<IEnumerable<AssetStatus>>(2 * 60 * 1000, AssemblyQualifiedName);
                _Status = null;
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
    }

    public class SuppliersSelectItemsClassImp : SelectItemsClass
    {
        public const string AssemblyQualifiedName = "FtisHelperAsset.DB.SuppliersSelectItemsClassImp, FtisHelperAsset";

        protected static IEnumerable<AssetSuppliers> _Suppliers;
        protected static new IEnumerable<FtisHelperAsset.DB.Model.AssetSuppliers> Suppliers
        {
            get
            {
                _Suppliers = DouHelper.Misc.GetCache<IEnumerable<AssetSuppliers>>(2 * 60 * 1000, AssemblyQualifiedName);
                _Suppliers = null;
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
            return Suppliers.Select(s => new KeyValuePair<string, object>(s.ID, s.Name));
        }
    }

    public class UnitSelectItemsClassImp : SelectItemsClass
    {
        public const string AssemblyQualifiedName = "FtisHelperAsset.DB.UnitSelectItemsClassImp, FtisHelperAsset";

        protected static IEnumerable<AssetUnits> _Units;
        protected static new IEnumerable<FtisHelperAsset.DB.Model.AssetUnits> Units
        {
            get
            {
                _Units = DouHelper.Misc.GetCache<IEnumerable<AssetUnits>>(2 * 60 * 1000, AssemblyQualifiedName);
                _Units = null;
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
            return Units.Select(s => new KeyValuePair<string, object>(s.UnitID, s.Name));
        }
    }

    public class LocationsSelectItemsClassImp : SelectItemsClass
    {
        public const string AssemblyQualifiedName = "FtisHelperAsset.DB.LocationsSelectItemsClassImp, FtisHelperAsset";

        protected static IEnumerable<AssetLocations> _Locations;
        protected static new IEnumerable<FtisHelperAsset.DB.Model.AssetLocations> Locations
        {
            get
            {
                _Locations = DouHelper.Misc.GetCache<IEnumerable<AssetLocations>>(2 * 60 * 1000, AssemblyQualifiedName);
                _Locations = null;
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
            return Locations.Select(s => new KeyValuePair<string, object>(s.ID, s.Name));
        }
    }
}
