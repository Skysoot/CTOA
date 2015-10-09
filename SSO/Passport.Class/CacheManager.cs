using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace SSO.Passport.Class
{
    public class CacheManager
    {
        public static void InsertToken(string token, UserInfo user)
        {
            if (HttpContext.Current.Cache["PASSPORT.TOKEN"] == null)
            {
                CacheInit();
            }
            Dictionary<string, UserInfo> tokenList = HttpContext.Current.Cache["PASSPORT.TOKEN"] as Dictionary<string, UserInfo>;
            tokenList.Add(token, user);
        }

        /// <summary>
        /// 初始化缓存中登录用户的数据结构
        /// </summary>
        private static void CacheInit()
        {
            Dictionary<string, UserInfo> tokenList = new Dictionary<string, UserInfo>();
            HttpContext.Current.Cache.Insert("PASSPORT.TOKEN", tokenList, null, DateTime.MaxValue,
                TimeSpan.FromMinutes(double.Parse(System.Configuration.ConfigurationManager.AppSettings["CacheTimeout"])));
        }

        /// <summary>
        /// 移除Token
        /// </summary>
        /// <param name="token"></param>
        public static bool RemoveToken(string token)
        {
            Dictionary<string, UserInfo> tokenList = HttpContext.Current.Cache["PASSPORT.TOKEN"] as Dictionary<string, UserInfo>;
            if (tokenList != null && tokenList.Keys.Contains(token))
            {
                tokenList.Remove(token);
                HttpContext.Current.Cache["PASSPORT.TOKEN"] = tokenList;
                return true;
            }
            return false;
        }
    }
}