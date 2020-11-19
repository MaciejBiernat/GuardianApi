﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GuardianNews.Models;
using GuardianNews.Repositories;
using GuardianNews.GuardianApi;
using GuardianNews.Services;

namespace GuardianNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleRepository _articleRepository;

        public HomeController(ILogger<HomeController> logger, IArticleRepository articleRepository)
        {
            _logger = logger;
            _articleRepository = articleRepository;

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ApiGuardianAsync()
        {
            ApiProcessor.InitializeClient();
            var articles = await ArticleProcessor.LoadArticles();
            ViewData["Articles"] = articles;
            return View();
        }

        public async Task<IActionResult> UploadToDb()
        {
            var articles = await ArticleProcessor.LoadArticles();
            _articleRepository.AddRangeAsync(Mapper.MapToEntity(articles));
            return View("Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
