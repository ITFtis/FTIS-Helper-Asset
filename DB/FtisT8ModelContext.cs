using FtisHelperAsset.DB.Model;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace FtisHelperAsset.DB
{
    public class FtisT8ModelContext : DbContext
    {
        public new static FtisT8ModelContext Create(bool printLog = false)
        {
            var cxt = new FtisT8ModelContext();
            if (printLog) cxt.Database.Log = (log) => Debug.WriteLine(log);
            return cxt;
        }

        // 您的內容已設定為使用應用程式組態檔 (App.config 或 Web.config)
        // 中的 'FtisModelContext' 連接字串。根據預設，這個連接字串的目標是
        // 您的 LocalDb 執行個體上的 'FtisHelperAsset.DB.FtisModelContext' 資料庫。
        // 
        // 如果您的目標是其他資料庫和 (或) 提供者，請修改
        // 應用程式組態檔中的 'FtisModelContext' 連接字串。
        public FtisT8ModelContext()
            : base("name=FtisT8ModelContext")
        {
            Database.SetInitializer<FtisT8ModelContext>(null);
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
        public virtual DbSet<F22cmmEmpData> F22cmmEmpData { get; set; }

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