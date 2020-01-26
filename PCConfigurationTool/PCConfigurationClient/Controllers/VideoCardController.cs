using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using PCConfigurationClient.Factories;
using PCConfigurationClient.ViewModels;

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
        public async Task<JsonResult> Add(int id, int quantity)
        {
            var videoCard = await this.videoCardService.GetByIdAsync(id);
            var videoCardName = videoCard.Name;
            var videoCardPrice = await this.videoCardService.CalculatePrice(id, quantity);

            var inputModel = new PCItemInputModel() { Price = videoCardPrice, Name = videoCardName, CurrencySymbol = "$" };
            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(inputModel);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "VideoCard" + id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}