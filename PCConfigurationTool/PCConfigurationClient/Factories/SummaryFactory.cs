using PCConfigurationClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCConfigurationClient.Factories
{
    public static class SummaryFactory
    {
        public static SummaryViewModel CreateSummaryViewModel(PCItemInputModel inputModel)
        {
            if (inputModel == null)
            {
                return null;
            }

            var viewModel = new SummaryViewModel
            {
                Name = inputModel.Name,
                Price = inputModel.Price,
                Total = $"{inputModel.CurrencySymbol}{inputModel.Price}",
                OverallTotal="0"
            };

            return viewModel;
        }
    }
}
