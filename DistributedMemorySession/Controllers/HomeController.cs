﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace DistributedRedis.Controllers
{
    public class HomeController : Controller
    {
        #region 内存中缓存
        private IMemoryCache _cache;

        public HomeController(IMemoryCache memorycache)
        {
            _cache = memorycache;
        }
        #endregion

        #region redis分布式
        //private readonly IDistributedCache _cache;
        /// <summary>
        /// 构造注入
        /// </summary>
        /// <param name="cache"></param>
        //public HomeController(IDistributedCache cache)
        //{
        //    _cache = cache;
        //}
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SetSession(string key, string value)
        {
            _cache.Set(key, value); //内存中缓存

            //_cache.SetString(key, value);
            return Json(new { success = true });
        }

        [HttpGet]
        public IActionResult GetSession(string key)
        {
            string value = _cache.Get<string>(key); //内存中缓存

           // string value = _cache.GetString(key);
            return Json(new { success = true, data = value });
        }
    }
}
