using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FtisHelperAsset.DB.Model;

namespace FtisHelperAsset.DB.Helpe
{
    public class Employee
    {
        static object lockGetAllEmployee = new object();
        /// <summary>
        /// 取所有員工資料
        /// </summary>
        /// <param name="cachetimer">資料快取時間(毫秒),預設30分</param>
        /// <returns>IEnumerable<Employee></returns>
        public static IEnumerable<F22cmmEmpData> GetAllEmployee(int cachetimer = Helper.shortcacheduration)
        {
            string key = "FtisHelperAsset.DB.Model.F22cmmEmpData";
            var allEmployee = DouHelper.Misc.GetCache<IEnumerable<F22cmmEmpData>>(cachetimer, key);
            lock (lockGetAllEmployee)
            {
                if (allEmployee == null)
                {
                    using (var cxt = Helper.CreateFtisT8ModelContext())
                    {
                        allEmployee = cxt.F22cmmEmpData.ToArray();
                        DouHelper.Misc.AddCache(allEmployee, key);
                    }
                }
            }
            return allEmployee;
        }
        public static void ResetGetAllEmployee()
        {
            string key = "FtisHelperAsset.DB.Model.F22cmmEmpData";
            DouHelper.Misc.ClearCache(key);
        }
        /// <summary>
        /// 依Fno取Employee
        /// </summary>
        /// <param name="Fno">員工編號</param>
        /// <param name="cachetimer">資料快取時間(毫秒),預設30分</param>
        /// <returns>Employee</returns>
        public static F22cmmEmpData GetEmployee(string Fno, int cachetimer = Helper.shortcacheduration)
        {
            if (string.IsNullOrEmpty(Fno))
                return null;
            return GetAllEmployee(cachetimer).FirstOrDefault(m => m.Fno == Fno);
        }
    }
}
