using FtisHelperAsset.DB.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtisHelperAsset.DB
{
    public class Helper
    {
        internal const int longcacheduration = 30 * 60 * 1000;
        internal const int shortcacheduration = 5 * 60 * 1000;
        internal const int onemincacheduration = 1 * 60 * 1000;

        /// <summary>
        /// 建立DBContext-FtisModelContext
        /// </summary>
        /// <param name="printlog">是否debug視窗輸出T-SQL</param>
        /// <returns>FtisModelContext</returns>
        public static FtisT8ModelContext CreateFtisT8ModelContext(bool printlog = false)
        {
            return FtisHelperAsset.DB.FtisT8ModelContext.Create(printlog);
        }

        public static FtisAssetModelContext CreateFtisAssetModelContext(bool printlog = false)
        {
            return FtisHelperAsset.DB.FtisAssetModelContext.Create(printlog);
        }

    }
}
