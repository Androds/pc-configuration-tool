using PCConfigurationClient.ViewModels;

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
                TotalPrice = 0M,
            };

            return viewModel;
        }
    }
}
