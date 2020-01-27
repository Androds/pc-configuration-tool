using PCConfigurationClient.ViewModels;

namespace PCConfigurationClient.Factories
{
    public static class SummaryFactory
    {
        /// <summary>
        /// Creates the summary view model.
        /// </summary>
        /// <param name="inputModel">The input model.</param>
        /// <returns><see cref="SummaryViewModel"/></returns>
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
