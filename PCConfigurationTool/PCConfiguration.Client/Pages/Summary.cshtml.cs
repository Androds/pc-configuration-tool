using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PCConfigurationClient.Client.ViewModels;
using System.Collections.Generic;

namespace PCConfiguration.Client
{
    public class SummaryModel : PageModel
    {
        public IEnumerable<SummaryViewModel> Summary { get; set; }

        public void OnGetAsync()
        {
            var totalSum = 0M;
            var orderedComponents = new List<SummaryViewModel>();
            foreach (var item in TempData)
            {
                if (TempData.TryGetValue(item.Key, out object o))
                {
                    var viewModel = (SummaryViewModel)JsonConvert.DeserializeObject<SummaryViewModel>((string)o);
                    totalSum += viewModel.Price;
                    viewModel.TotalPrice = totalSum;
                    orderedComponents.Add(viewModel);
                }

            }

            Summary = orderedComponents;
        }
    }
}