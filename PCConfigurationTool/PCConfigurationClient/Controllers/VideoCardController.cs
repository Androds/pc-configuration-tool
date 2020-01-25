using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;

namespace PCConfigurationClient.Controllers
{
    public class VideoCardController : Controller
    {
        private readonly IService<IRepository<VideoCard>, VideoCard> videoCardService;

        public VideoCardController(IService<IRepository<VideoCard>, VideoCard> videoCardService)
        {
            this.videoCardService = videoCardService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.videoCardService.GetAllAsync());
        }

        // GET: VideoCard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}