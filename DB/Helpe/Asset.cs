using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FtisHelperAsset.DB.Model;
using DouHelper;

namespace FtisHelperAsset.DB.Helpe
{
    public class Asset
    {
        static object lockGetAllDepartment = new object();
        static object lockGetAllCategories = new object();
        static object lockGetAllSubCategories = new object();
        static object lockGetAllStatus = new object();
        static object lockGetAllSuppliers = new object();
        static object lockGetAllUnits = new object();
        static object lockGetAllLocations = new object();
        static object lockGetAllAssets = new object();
        static object lockGetAllAssetInvecntoryLog = new object();
        static object lockGetAllDisposals = new object();
        static object lockGetAllCompanies = new object();

        /// <summary>
        /// 取所有盤點紀錄
        /// </summary>
        /// <param name="cachetimer">資料快取時間(毫秒),預設30分</param>
        /// <returns>IEnumerable<AssetInventoryLog></returns>
        public static IEnumerable<AssetInventoryLog> GetAllAssetInventoryLog(int cachetimer = Helper.shortcacheduration)
        {
            string key = "FtisHelperAsset.DB.Model.AssetInventoryLog";
            var allAssetInvecntoryLog = DouHelper.Misc.GetCache<IEnumerable<AssetInventoryLog>>(cachetimer, key);
            lock (lockGetAllAssetInvecntoryLog)
            {
                if (allAssetInvecntoryLog == null)
                {
                    using (var cxt = Helper.CreateFtisAssetModelContext())
                    {
                        allAssetInvecntoryLog = cxt.AssetInventoryLog.ToArray();
                        DouHelper.Misc.AddCache(allAssetInvecntoryLog, key);
                    }
                }
            }
            return allAssetInvecntoryLog;
        }
        public static void ResetGetAllAssetInventoryLog()
        {
            string key = "FtisHelperAsset.DB.Model.AssetInventoryLog";
            DouHelper.Misc.ClearCache(key);
        }
        /// <summary>
        /// 依AssetID取資產盤點最新一筆時間
        /// </summary>
        /// <param name="assetid">員工編號</param>
        /// <param name="cachetimer">資料快取時間(毫秒),預設30分</param>
        /// <returns>Employee</returns>
        public static AssetInventoryLog GetAssetInventoryLogTime(string assetid, int cachetimer = Helper.shortcacheduration)
        {
            if (string.IsNullOrEmpty(assetid))
                return null;           
            return GetAllAssetInventoryLog().OrderByDescending(m => m.InventoryTime).FirstOrDefault(m => m.AssetID == assetid);
        }
        public static void ResetGetAssetInventoryLogTime()
        {
            string key = "FtisHelperAsset.DB.Model.AssetInventoryLog";
            DouHelper.Misc.ClearCache(key);
        }
        /// <summary>
        /// 更新Asset-Status
        /// </summary>
        /// <param name="Status"></param>
        public static void UpdateAssetStatus(List<Assets> assetstatus)
        {
            string ss = assetstatus[0].AssetID.ToString();
            using (var cxt = Helper.CreateFtisAssetModelContext())
            {
                var me = new Dou.Models.DB.ModelEntity<Assets>(cxt);
                var sss = me.FirstOrDefault(s => s.AssetID == ss).ToString();
                if (me.FirstOrDefault(s => s.AssetID == ss) != null)
                {
                    me.Update(assetstatus[0]);
                }
            }
            DouHelper.Misc.ClearCache("FtisHelperAsset.DB.Model.Assets");
        }
        /// <summary>
        /// 新增或更新Attrs
        /// </summary>
        /// <param name="seat"></param>
        public static void AddOrUpdateAttrs(AssetITAttributes Attr)
        {
            using (var cxt = Helper.CreateFtisAssetModelContext())
            {
                var me = new Dou.Models.DB.ModelEntity<AssetITAttributes>(cxt);
                var ss = me.FirstOrDefault(s => s.AssetsAssetID == Attr.AssetsAssetID);
                //Attr["OS"] == null ? "" : Attr["OS"];
                //Attr["HDD"] == null ? "" : Attr["HDD"];
                //Attr["SSD"] == null ? "" : Attr["SSD"];
                //Attr["Ierise"] == null ? "" : Attr["Ierise"];
                //Attr["OfficeVersion"] == null ? "" : Attr["OfficeVersion"];
                //Attr["RAM"] == null ? "" : Attr["RAM"];
                //Attr["SN"] == null ? "" : Attr["SN"];
                if (me.FirstOrDefault(s => s.AssetsAssetID == Attr.AssetsAssetID) == null)
                {
                    me.Add(Attr);
                }
                else
                {
                    Attr.AttrId = ss.AttrId;
                    me.Update(Attr);
                }
            }
            DouHelper.Misc.ClearCache("FtisHelperAsset.DB.Model.AssetITAttributes");
            DouHelper.Misc.ClearCache("FtisHelperAsset.DB.Model.AssetUsageLog");
            //DouHelper.Misc.ClearCache(GetEmployeeIncludeSeat_Cache_Key);
        }
        /// <summary>
        /// 新增或更新DisposalLog
        /// </summary>
        /// <param name="log"></param>
        public static void AddOrUpdateDisposalLog(AssetDisposals log)
        {
            using (var cxt = Helper.CreateFtisAssetModelContext())
            {
                var me = new Dou.Models.DB.ModelEntity<AssetDisposals>(cxt);
                var ss = me.FirstOrDefault(s => s.AssetID == log.AssetID);
                if (me.FirstOrDefault(s => s.AssetID == log.AssetID) == null)
                {
                    me.Add(log);
                }
                else
                {
                    log.AssetID = ss.AssetID;
                    me.Update(log);
                }
            }
            DouHelper.Misc.ClearCache("FtisHelperAsset.DB.Model.AssetDisposals");
        }

        /// <summary>
        /// 新增InventoryLog
        /// </summary>
        /// <param name="log"></param>
        public static void AddInventoryLog(AssetInventoryLog log)
        {
            using (var cxt = Helper.CreateFtisAssetModelContext())
            {
                var me = new Dou.Models.DB.ModelEntity<AssetInventoryLog>(cxt);
                //var ss = me.FirstOrDefault(s => s.AssetID == log.AssetID);
                me.Add(log);
                //if (me.FirstOrDefault(s => s.AssetID == log.AssetID) == null)
                //{
                //    me.Add(log);
                //}
                //else
                //{
                //    log.AssetID = ss.AssetID;
                //    me.Update(log);
                //}
            }
            DouHelper.Misc.ClearCache("FtisHelperAsset.DB.Model.AssetInventoryLog");
        }                   

        /// <summary>
        /// 取所有資產
        /// </summary>
        /// <param name="cachetimer">資料快取時間(毫秒),預設30分</param>
        /// <returns>IEnumerable<AssetCategories></returns>
        public static IEnumerable<Assets> GetAllAssets(int cachetimer = Helper.shortcacheduration)
        {
            string key = "FtisHelperAsset.DB.Model.Assets";
            var allAssets = DouHelper.Misc.GetCache<IEnumerable<Assets>>(cachetimer, key);
            lock (lockGetAllAssets)
            {
                if (allAssets == null)
                {
                    using (var cxt = Helper.CreateFtisAssetModelContext())
                    {
                        allAssets = cxt.Assets.ToArray();
                        DouHelper.Misc.AddCache(allAssets, key);
                    }
                }
            }
            return allAssets;
        }
        public static void ResetGetAllAssets()
        {
            string key = "FtisHelperAsset.DB.Model.Assets";
            DouHelper.Misc.ClearCache(key);
        }
        /// <summary>
        /// 取所有主類別
        /// </summary>
        /// <param name="cachetimer">資料快取時間(毫秒),預設30分</param>
        /// <returns>IEnumerable<AssetCategories></returns>
        public static IEnumerable<AssetCategories> GetAllCategories(int cachetimer = Helper.shortcacheduration)
        {
            string key = "FtisHelperAsset.DB.Model.AssetCategories";
            var allCategories = DouHelper.Misc.GetCache<IEnumerable<AssetCategories>>(cachetimer, key);
            lock (lockGetAllCategories)
            {
                if (allCategories == null)
                {
                    using (var cxt = Helper.CreateFtisAssetModelContext())
                    {
                        allCategories = cxt.AssetCategories.ToArray();
                        DouHelper.Misc.AddCache(allCategories, key);
                    }
                }
            }
            return allCategories;
        }
        public static void ResetGetAllCategories()
        {
            string key = "FtisHelperAsset.DB.Model.AssetCategories";
            DouHelper.Misc.ClearCache(key);
        }
        /// <summary>
        /// 取所有次類別
        /// </summary>
        /// <param name="cachetimer">資料快取時間(毫秒),預設30分</param>
        /// <returns>IEnumerable<AssetSubCategories></returns>
        public static IEnumerable<AssetSubCategories> GetAllSubCategories(int cachetimer = Helper.shortcacheduration)
        {
            string key = "FtisHelperAsset.DB.Model.AssetSubCategories";
            var allSubCategories = DouHelper.Misc.GetCache<IEnumerable<AssetSubCategories>>(cachetimer, key);
            lock (lockGetAllSubCategories)
            {
                if (allSubCategories == null)
                {
                    using (var cxt = Helper.CreateFtisAssetModelContext())
                    {
                        allSubCategories = cxt.AssetSubCategories.ToArray();
                        DouHelper.Misc.AddCache(allSubCategories, key);
                    }
                }
            }
            return allSubCategories;
        }
        public static void ResetGetAllSubCategories()
        {
            string key = "FtisHelperAsset.DB.Model.AssetSubCategories";
            DouHelper.Misc.ClearCache(key);
        }
        /// <summary>
        /// 取所有狀態
        /// </summary>
        /// <param name="cachetimer">資料快取時間(毫秒),預設30分</param>
        /// <returns>IEnumerable<AssetStatus></returns>
        public static IEnumerable<AssetStatus> GetAllStatus(int cachetimer = Helper.shortcacheduration)
        {
            string key = "FtisHelperAsset.DB.Model.AssetStatus";
            var allStatus = DouHelper.Misc.GetCache<IEnumerable<AssetStatus>>(cachetimer, key);
            lock (lockGetAllStatus)
            {
                if (allStatus == null)
                {
                    using (var cxt = Helper.CreateFtisAssetModelContext())
                    {
                        allStatus = cxt.AssetStatus.ToArray();
                        DouHelper.Misc.AddCache(allStatus, key);
                    }
                }
            }
            return allStatus;
        }
        public static void ResetGetAllStatus()
        {
            string key = "FtisHelperAsset.DB.Model.AssetStatus";
            DouHelper.Misc.ClearCache(key);
        }
        /// <summary>
        /// 取所有供應商
        /// </summary>
        /// <param name="cachetimer">資料快取時間(毫秒),預設30分</param>
        /// <returns>IEnumerable<AssetSuppliers></returns>
        public static IEnumerable<AssetSuppliers> GetAllSuppliers(int cachetimer = Helper.shortcacheduration)
        {
            string key = "FtisHelperAsset.DB.Model.AssetSuppliers";
            var allSuppliers = DouHelper.Misc.GetCache<IEnumerable<AssetSuppliers>>(cachetimer, key);
            lock (lockGetAllStatus)
            {
                if (allSuppliers == null)
                {
                    using (var cxt = Helper.CreateFtisAssetModelContext())
                    {
                        allSuppliers = cxt.AssetSuppliers.ToArray();
                        DouHelper.Misc.AddCache(allSuppliers, key);
                    }
                }
            }
            return allSuppliers;
        }
        public static void ResetGetAllSuppliers()
        {
            string key = "FtisHelperAsset.DB.Model.AssetSuppliers";
            DouHelper.Misc.ClearCache(key);
        }
        /// <summary>
        /// 取所有單位
        /// </summary>
        /// <param name="cachetimer">資料快取時間(毫秒),預設30分</param>
        /// <returns>IEnumerable<AssetUnits></returns>
        public static IEnumerable<AssetUnits> GetAllUnits(int cachetimer = Helper.shortcacheduration)
        {
            string key = "FtisHelperAsset.DB.Model.AssetUnits";
            var allUnits = DouHelper.Misc.GetCache<IEnumerable<AssetUnits>>(cachetimer, key);
            lock (lockGetAllStatus)
            {
                if (allUnits == null)
                {
                    using (var cxt = Helper.CreateFtisAssetModelContext())
                    {
                        allUnits = cxt.AssetUnits.ToArray();
                        DouHelper.Misc.AddCache(allUnits, key);
                    }
                }
            }
            return allUnits;
        }
        public static void ResetGetAllUnits()
        {
            string key = "FtisHelperAsset.DB.Model.AssetUnits";
            DouHelper.Misc.ClearCache(key);
        }
        /// <summary>
        /// 取所有位置
        /// </summary>
        /// <param name="cachetimer">資料快取時間(毫秒),預設30分</param>
        /// <returns>IEnumerable<AssetLocations></returns>
        public static IEnumerable<AssetLocations> GetAllLocations(int cachetimer = Helper.shortcacheduration)
        {
            string key = "FtisHelperAsset.DB.Model.AssetLocations";
            var allLocations = DouHelper.Misc.GetCache<IEnumerable<AssetLocations>>(cachetimer, key);
            lock (lockGetAllLocations)
            {
                if (allLocations == null)
                {
                    using (var cxt = Helper.CreateFtisAssetModelContext())
                    {
                        allLocations = cxt.AssetLocations.ToArray();
                        DouHelper.Misc.AddCache(allLocations, key);
                    }
                }
            }
            return allLocations;
        }
        public static void ResetGetAllLocations()
        {
            string key = "FtisHelperAsset.DB.Model.AssetLocations";
            DouHelper.Misc.ClearCache(key);
        }
        /// <summary>
        /// 取所有報廢
        /// </summary>
        /// <param name="cachetimer">資料快取時間(毫秒),預設30分</param>
        /// <returns>IEnumerable<AssetDisposals></returns>
        public static IEnumerable<AssetDisposals> GetAllDisposals(int cachetimer = Helper.shortcacheduration)
        {
            string key = "FtisHelperAsset.DB.Model.AssetDisposals";
            var allDisposals = DouHelper.Misc.GetCache<IEnumerable<AssetDisposals>>(cachetimer, key);
            lock (lockGetAllDisposals)
            {
                if (allDisposals == null)
                {
                    using (var cxt = Helper.CreateFtisAssetModelContext())
                    {
                        allDisposals = cxt.AssetDisposals.ToArray();
                        DouHelper.Misc.AddCache(allDisposals, key);
                    }
                }
            }
            return allDisposals;
        }
        public static void ResetGetAllDisposals()
        {
            string key = "FtisHelperAsset.DB.Model.AssetDisposals";
            DouHelper.Misc.ClearCache(key);
        }
        /// <summary>
        /// 取所有公司
        /// </summary>
        /// <param name="cachetimer">資料快取時間(毫秒),預設30分</param>
        /// <returns>IEnumerable<AssetUnits></returns>
        public static IEnumerable<AssetCompanies> GetAllCompanies(int cachetimer = Helper.shortcacheduration)
        {
            string key = "FtisHelperAsset.DB.Model.AssetCompanies";
            var allCompanies = DouHelper.Misc.GetCache<IEnumerable<AssetCompanies>>(cachetimer, key);
            lock (lockGetAllCompanies)
            {
                if (allCompanies == null)
                {
                    using (var cxt = Helper.CreateFtisAssetModelContext())
                    {
                        allCompanies = cxt.AssetCompanies.ToArray();
                        DouHelper.Misc.AddCache(allCompanies, key);
                    }
                }
            }
            return allCompanies;
        }
        public static void ResetGetAllCompanies()
        {
            string key = "FtisHelperAsset.DB.Model.AssetCompanies";
            DouHelper.Misc.ClearCache(key);
        }
    }
}
