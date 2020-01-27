using System.Threading.Tasks;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoCardController"/> class.
        /// </summary>
        /// <param name="videoCardService">The video card service.</param>
        public VideoCardController(IService<IRepository<VideoCard>, VideoCard> videoCardService)
        {
            this.videoCardService = videoCardService;
        }

        // GET: CPU
        public async Task<IActionResult> Index()
        {
            return View(await this.videoCardService.GetAllAsync());
        }

        public async Task<IActionResult> Add(int id, int quantity)
        {
            if (id <= 0 && quantity <= 0)
            {
                return BadRequest();
            }

            var videoCard = await this.videoCardService.GetByIdAsync(id);
            var videoCardName = videoCard.Name;
            var videoCardPrice = await this.videoCardService.CalculatePrice(id, quantity);

            var inputModel = new PCItemInputModel() { Price = videoCardPrice, Name = videoCardName };
            var summaryViewModel = SummaryFactory.CreateSummaryViewModel(inputModel);
            var serialized = JsonConvert.SerializeObject(summaryViewModel);

            var key = "VideoCard" + id;
            TempData[key] = serialized;
            TempData.Keep();

            return new JsonResult(summaryViewModel);
        }
    }
}