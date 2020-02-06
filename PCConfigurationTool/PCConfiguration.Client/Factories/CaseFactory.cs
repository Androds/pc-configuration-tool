using PCConfiguration.Client.ViewModels;
using PCConfiguration.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCConfiguration.Client.Factories
{
    public class CaseFactory
    {
        public static IEnumerable<CaseViewModel> MapCaseToCaseViewModel(IEnumerable<Case> compCases)
        {
            var compCasesViewModels = new List<CaseViewModel>();
            foreach (var compCase in compCases)
            {
                var caseViewModel = new CaseViewModel();
                caseViewModel.Id = compCase.Id;
                caseViewModel.Name = compCase.Name;
                caseViewModel.Price = compCase.Price;
                caseViewModel.Type = compCase.Type.Name;
                caseViewModel.Window = compCase.Window;
                caseViewModel.PowerSupply = compCase.PowerSupply;
                caseViewModel.InternalBays = compCase.InternalBays;
                caseViewModel.ExternalBays = compCase.ExternalBays;
                caseViewModel.Color = compCase.Color;
                caseViewModel.ImageSrc = compCase.ImageSrc;
                compCasesViewModels.Add(caseViewModel);
            }

            return compCasesViewModels;
        }
    }
}
