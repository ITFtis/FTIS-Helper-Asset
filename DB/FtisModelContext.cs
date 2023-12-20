using FtisHelperV2.DB.Model;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace FtisHelperV2.DB
{
    public class FtisModelContext : DbContext
    {
        public new static FtisModelContext Create(bool printLog = false)
        {
            var cxt = new FtisModelContext();
            if (printLog) cxt.Database.Log = (log) => Debug.WriteLine(log);
            return cxt;
        }

        // 您的內容已設定為使用應用程式組態檔 (App.config 或 Web.config)
        // 中的 'FtisModelContext' 連接字串。根據預設，這個連接字串的目標是
        // 您的 LocalDb 執行個體上的 'FtisHelperV2.DB.FtisModelContext' 資料庫。
        // 
        // 如果您的目標是其他資料庫和 (或) 提供者，請修改
        // 應用程式組態檔中的 'FtisModelContext' 連接字串。
        public FtisModelContext()
            : base("name=FtisModelContext")
        {
            Database.SetInitializer<FtisModelContext>(null);
        }
        //public FtisModelContext()
        //   : base(conn)
        //{
        //    Database.SetInitializer<FtisModelContext>(null);
        //}
        //static string conn = "data source=120.100.100.216;initial catalog=FTIS-T8;user id=ftismis;password=Ftis12341234;MultipleActiveResultSets=True;App=EntityFramework";

        // 針對您要包含在模型中的每種實體類型新增 DbSet。如需有關設定和使用
        // Code First 模型的詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<F22cmmDep> F22cmmDep { get; set; }
        public virtual DbSet<F22cmmEmpDa4> F22cmmEmpDa4 { get; set; }
        public virtual DbSet<F22cmmEmpData> F22cmmEmpData { get; set; }
        public virtual DbSet<F22cmmGrade> F22cmmGrade { get; set; }
        public virtual DbSet<F22cmmProjectData> F22cmmProjectData { get; set; }
        public virtual DbSet<F22cmmTitle> F22cmmTitle { get; set; }
        public virtual DbSet<F22cmmCounty> F22cmmCounty { get; set; }
        public virtual DbSet<F22cmmMP> F22cmmMP { get; set; }
        public virtual DbSet<F22cmmSeat> F22cmmSeat { get; set; }

        public virtual DbSet<AssetCategories> AssetCategories { get; set; }
        public virtual DbSet<AssetDisposals> AssetDisposals { get; set; }
        public virtual DbSet<AssetInventories> AssetInventories { get; set; }
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