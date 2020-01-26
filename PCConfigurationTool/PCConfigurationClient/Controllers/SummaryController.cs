using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PCConfigurationClient.ViewModels;

namespace PCConfigurationClient.Controllers
{
    public class SummaryController : Controller
    {
        // GET: Summary
        public ActionResult Index()
        {
            var totalSum = 0M;
            var orderedComponents = new List<SummaryViewModel>();
            foreach (var item in TempData)
            {
                TempData.TryGetValue(item.Key, out object o);
                var viewModel = (SummaryViewModel)JsonConvert.DeserializeObject<SummaryViewModel>((string)o);
                totalSum += viewModel.Price;
                viewModel.TotalPrice = totalSum;
                orderedComponents.Add(viewModel);
            }

            return View(orderedComponents);
        }
    }
}