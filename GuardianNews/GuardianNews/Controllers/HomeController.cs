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
using Microsoft.AspNetCore.Authorization;

namespace GuardianNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        public HomeController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;

        }

        public IActionResult Index()
        {
            ViewData["Success"] = "";
            return View();
        }

        [Authorize(Roles = "Admin")]
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
            ViewData["success"] = "Articles uploaded to server";
            return View("Index");
        }

        [Authorize]
        public async Task<IActionResult> Display()
        {
            var articles = Mapper.MapToModel(await _articleRepository.GetAllAsync());
            ViewData["Articles"] = articles;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
