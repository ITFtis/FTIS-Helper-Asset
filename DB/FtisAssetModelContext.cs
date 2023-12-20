using FtisHelperAsset.DB.Model;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Configuration;

namespace FtisHelperAsset.DB
{
    public class FtisAssetModelContext : DbContext
    {
        //public new static FtisT8ModelContext CreateT8(bool printLog = false)
        //{
        //    var cxt = new FtisT8ModelContext();
        //    if (printLog) cxt.Database.Log = (log) => Debug.WriteLine(log);
        //    return cxt;
        //}
        public new static FtisAssetModelContext Create(bool printLog = false)
        {           
            var cxt = new FtisAssetModelContext();
            if (printLog) cxt.Database.Log = (log) => Debug.WriteLine(log);
            return cxt;
        }

        // 您的內容已設定為使用應用程式組態檔 (App.config 或 Web.config)
        // 中的 'FtisModelContext' 連接字串。根據預設，這個連接字串的目標是
        // 您的 LocalDb 執行個體上的 'FtisHelperAsset.DB.FtisModelContext' 資料庫。
        // 
        // 如果您的目標是其他資料庫和 (或) 提供者，請修改
        // 應用程式組態檔中的 'FtisModelContext' 連接字串。
        public FtisAssetModelContext()
            : base(serverconn)
        {
            Database.SetInitializer<FtisAssetModelContext>(null);
        }

        public static bool LocalTest
        {
            set
            {
                serverconn = value ? localconn : conn;
                Console.Write(serverconn);
            }
        }
        static string conn = "data source=120.100.102.109;initial catalog=ASSETSYS_1017;persist security info=True;user id=ftismis;password=Ftis12341234;MultipleActiveResultSets=True;App=EntityFramework";
        static string localconn = "name=FtisAssetModelContext";
        static string serverconn = conn; //預設正式

        // 針對您要包含在模型中的每種實體類型新增 DbSet。如需有關設定和使用
        // Code First 模型的詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<AssetCategories> AssetCategories { get; set; }
        public virtual DbSet<AssetDisposals> AssetDisposals { get; set; }
        public virtual DbSet<AssetInventories> AssetInventories { get; set; }
        public virtual DbSet<AssetInventoryLog> AssetInventoryLog { get; set; }
        public virtual DbSet<AssetITAttributes> AssetITAttributes { get; set; }
        public virtual DbSet<AssetLoans> AssetLoans { get; set; }
        public virtual DbSet<AssetLocations> AssetLocations { get; set; }
        public virtual DbSet<AssetRepairs> AssetRepairs { get; set; }
        public virtual DbSet<Assets> Assets { get; set; }
        public virtual DbSet<AssetStatus> AssetStatus { get; set; }
        public virtual DbSet<AssetSubCategories> AssetSubCategories { get; set; }
        public virtual DbSet<AssetSuppliers> AssetSuppliers { get; set; }
        public virtual DbSet<AssetUnits> AssetUnits { get; set; }
        public virtual DbSet<AssetUsageLog> AssetUsageLog { get; set; }
        public virtual DbSet<AssetCompanies> AssetCompanies { get; set; }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<F22cmmEmpData>().HasOptional(s=>s.Seat);
            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}