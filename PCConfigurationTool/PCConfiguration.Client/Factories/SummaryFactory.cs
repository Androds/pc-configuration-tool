
using PCConfigurationClient.Client.ViewModels;

namespace PCConfiguration.Client.Factories
{
    public static class SummaryFactory
    {
        /// <summary>
        /// Creates the summary view model.
        /// </summary>
        /// <param name="inputModel">The input model.</param>
        /// <returns><see cref="SummaryViewModel"/></returns>
        public static SummaryViewModel CreateSummaryViewModel(string name, decimal price, string imageSrc)
        {
            if (price <= 0 || string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            var viewModel = new SummaryViewModel
            {
                Name = name,
                Price = price,
                TotalPrice = 0M,
                ImageSrc = imageSrc
            };

            return viewModel;
        }
    }
}
