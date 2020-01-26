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
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        #region fields
        private IService<IRepository<CPU>, CPU> cpuService;
        private IService<IRepository<Case>, Case> caseService;
        private IService<IRepository<CPUCooler>, CPUCooler> cpuCoolerService;
        private IService<IRepository<Memory>, Memory> memoryService;
        private IService<IRepository<Motherboard>, Motherboard> motherboardService;
        private IService<IRepository<PowerSupply>, PowerSupply> powerSupplyService;
        private IService<IRepository<Storage>, Storage> storageService;
        private IService<IRepository<VideoCard>, VideoCard> videoCardService;
        #endregion
        public SeedController(IService<IRepository<Case>, Case> caseService,
            IService<IRepository<CPU>, CPU> cpuService,
            IService<IRepository<CPUCooler>, CPUCooler> cpuCoolerService,
            IService<IRepository<Memory>, Memory> memoryService,
            IService<IRepository<Motherboard>, Motherboard> motherboardService,
            IService<IRepository<PowerSupply>, PowerSupply> powerSupplyService,
            IService<IRepository<Storage>, Storage> storageService,
            IService<IRepository<VideoCard>, VideoCard> videoCardService)
        {
            this.caseService = caseService;
            this.cpuService = cpuService;
            this.cpuCoolerService = cpuCoolerService;
            this.memoryService = memoryService;
            this.motherboardService = motherboardService;
            this.powerSupplyService = powerSupplyService;
            this.storageService = storageService;
            this.videoCardService = videoCardService;
        }

        // GET: api/Seed
        [HttpGet]
        public void Get()
        {
            this.CreateCPUs();
            this.CreateCPUCoolers();
            this.CreateCases();
            this.CreateMemories();
            this.CreateMotherboards();
            this.CreatePowerSupplies();
            this.CreateStorages();
            this.CreateVideoCards();
        }

        private  void CreateCPUs()
        {
            this.cpuService.Create(new CPU() { Name = "AMD Ryzen 5 3600", CoreClock = "3.6GHz", BoostClock = "4.2GHz", CoresCount = 6, IntegratedGPU = false, Price = 179.99M });
            this.cpuService.Create(new CPU() { Name = "AMD Ryzen 5 2600", CoreClock = "3.4GHz", BoostClock = "3.9GHz", CoresCount = 6, IntegratedGPU = false, Price = 119.99M });
            this.cpuService.Create(new CPU() { Name = "AMD Ryzen 7 2700X", CoreClock = "3.7GHz", BoostClock = "4.3Ghz", CoresCount = 8, IntegratedGPU = false, Price = 164.49M });
            this.cpuService.Create(new CPU() { Name = "Intel Core i7-9700K", CoreClock = "3.6GHz", BoostClock = "4.9Ghz", CoresCount = 8, IntegratedGPU = true, Price = 389.99M });
            this.cpuService.Create(new CPU() { Name = "Intel Core i9-9900K", CoreClock = "3.6GHz", BoostClock = "5Ghz", CoresCount = 8, IntegratedGPU = true, Price = 523.89M });
            this.cpuService.Create(new CPU() { Name = "Intel Core i5-9400F", CoreClock = "2.9GHz", BoostClock = "4.1Ghz", CoresCount = 6, IntegratedGPU = false, Price = 149.99M });
        }

        private  void CreateCPUCoolers ()
        {
            this.cpuCoolerService.Create(new CPUCooler() { Name = "Cooler Master Hyper 212 EVO", NoiseLevel = 36, Size = 120, FanRPM = 2000, Price = 139.99M });
            this.cpuCoolerService.Create(new CPUCooler() { Name = "Corsair H100i RGB PLATINUM", NoiseLevel = 37, Size = 240, FanRPM = 2400, Price = 34.49M });
            this.cpuCoolerService.Create(new CPUCooler() { Name = "Cooler Master Hyper 212 RGB Black Edition", NoiseLevel = 30, Size = 120, FanRPM = 2000, Price = 39.49M });
            this.cpuCoolerService.Create(new CPUCooler() { Name = "Corsair H100i PRO", NoiseLevel = 37, Size = 240, FanRPM = 2400, Price = 131.99M });
            this.cpuCoolerService.Create(new CPUCooler() { Name = "NZXT Kraken X62 Rev 2", NoiseLevel = 38, Size = 280, FanRPM = 1800, Price = 141.99M });
            this.cpuCoolerService.Create(new CPUCooler() { Name = "be quiet! Dark Rock Pro 4", NoiseLevel = 24, Size = 120, FanRPM = 1500, Price = 89.90M });
        }

        private  void CreateCases()
        {
            var midTower = new PCItemType() { Name = "ATX Mid Tower" };
            this.caseService.Create(new Case() { Name = "NZXT H510", Color = "Black", PowerSupply = "None", ExternalBays = 0, InternalBays = 2, Window = true, Price = 69.98M, Type = midTower });
            midTower = new PCItemType() { Name = "ATX Mid Tower" };
            this.caseService.Create(new Case() { Name = "Phanteks P300", Color = "Black", PowerSupply = "None", ExternalBays = 0, InternalBays = 2, Window = false, Price = 49.99M, Type = midTower });
            var miniTower = new PCItemType() { Name = "ATX Mini Tower" };
            this.caseService.Create(new Case() { Name = "Cooler Master MasterBox Q300L", Color = "Black", PowerSupply = "None", ExternalBays = 0, InternalBays = 1, Window = false, Price = 47.49M, Type = miniTower });
            miniTower = new PCItemType() { Name = "ATX Mini Tower" };
            this.caseService.Create(new Case() { Name = "Deepcool MATREXX 30", Color = "Black", PowerSupply = "None", ExternalBays = 1, InternalBays = 3, Window = true, Price = 39.98M, Type = miniTower });
            var fullTower = new PCItemType() { Name = "ATX Full Tower" };
            this.caseService.Create(new Case() { Name = "Lian Li PC-O11 Dynamic", Color = "Black", PowerSupply = "None", ExternalBays = 0, InternalBays = 2, Window = false, Price = 139.98M, Type = fullTower });
            fullTower = new PCItemType() { Name = "ATX Full Tower" };
            this.caseService.Create(new Case() { Name = "Corsair 750D", Color = "Black", PowerSupply = "None", ExternalBays = 3, InternalBays = 6, Window = true, Price = 169.98M, Type = fullTower });
        }

        private  void CreateMemories()
        {
            var casLatency15 = new MemoryLatency() { Name = "15" };
            var modulesType = new PCItemType() { Name = "288-pin DIMM" };
            this.memoryService.Create(new Memory() { Name = "Corsair Vengeance LPX 16 GB", Modules = 2, Speed = 3000, Price = 75.98M, CASLatency = casLatency15, Type =  modulesType});
            modulesType = new PCItemType() { Name = "288-pin DIMM" };
            var casLatency16 = new MemoryLatency() { Name = "16" };
            this.memoryService.Create(new Memory() { Name = "G.Skill Trident Z RGB 16 GB", Modules = 2, Speed = 3000, Price = 93.99M, CASLatency = casLatency16, Type = modulesType });
            modulesType = new PCItemType() { Name = "288-pin DIMM" };
            casLatency16 = new MemoryLatency() { Name = "16" };
            this.memoryService.Create(new Memory() { Name = "Corsair Vengeance RGB Pro 32 GB", Modules = 2, Speed = 3200, Price = 162.99M, CASLatency = casLatency16, Type = modulesType });
            modulesType = new PCItemType() { Name = "288-pin DIMM" };
            casLatency16 = new MemoryLatency() { Name = "16" };
            this.memoryService.Create(new Memory() { Name = "G.Skill Ripjaws V Series 16 GB", Modules = 2, Speed = 3200, Price = 69.99M, CASLatency = casLatency16, Type = modulesType });
            modulesType = new PCItemType() { Name = "288-pin DIMM" };
            casLatency16 = new MemoryLatency() { Name = "16" };
            this.memoryService.Create(new Memory() { Name = "G.Skill Trident Z Neo 32 GB", Modules = 2, Speed = 3600, Price = 179.99M, CASLatency = casLatency16, Type = modulesType });
            modulesType = new PCItemType() { Name = "288-pin DIMM" };
            casLatency16 = new MemoryLatency() { Name = "16" };
            this.memoryService.Create(new Memory() { Name = "G.Skill Ripjaws V 32 GB", Modules = 2, Speed = 3600, Price = 149.99M, CASLatency = casLatency16, Type = modulesType });
        }

        private  void CreateMotherboards()
        {
            var am4SocketType = new PCItemType() { Name = "AM4" };
            var lga1151SockeType = new PCItemType() { Name = "LGA1151" };
            var motherboardFormFactor = new FormFactor() { Name = "ATX" };
            this.motherboardService.Create(new Motherboard() { Name = "MSI B450 TOMAHAWK", MaxRam = 64, RamSlots = 4, Price = 111.99M, FormFactor = motherboardFormFactor, SocketType = am4SocketType });
            motherboardFormFactor = new FormFactor() { Name = "ATX" };
            am4SocketType = new PCItemType() { Name = "AM4" };
            this.motherboardService.Create(new Motherboard() { Name = "Asus ROG STRIX B450-F GAMING", MaxRam = 64, RamSlots = 4, Price = 129.99M, FormFactor = motherboardFormFactor, SocketType = am4SocketType });
            am4SocketType = new PCItemType() { Name = "AM4" };
            motherboardFormFactor = new FormFactor() { Name = "ATX" };
            this.motherboardService.Create(new Motherboard() { Name = "Gigabyte GA-A320M-S2H", MaxRam = 32, RamSlots = 4, Price = 54.99M, FormFactor = motherboardFormFactor, SocketType = am4SocketType });
            lga1151SockeType = new PCItemType() { Name = "LGA1151" };
            motherboardFormFactor = new FormFactor() { Name = "ATX" };
            this.motherboardService.Create(new Motherboard() { Name = "Gigabyte Z390 AORUS PRO WIFI", MaxRam = 128, RamSlots = 4, Price = 183.98M, FormFactor = motherboardFormFactor, SocketType = lga1151SockeType });
            lga1151SockeType = new PCItemType() { Name = "LGA1151" };
            motherboardFormFactor = new FormFactor() { Name = "ATX" };
            this.motherboardService.Create(new Motherboard() { Name = "MSI MPG Z390 GAMING EDGE AC", MaxRam = 128, RamSlots = 4, Price = 189.99M, FormFactor = motherboardFormFactor, SocketType = lga1151SockeType });
            lga1151SockeType = new PCItemType() { Name = "LGA1151" };
            motherboardFormFactor = new FormFactor() { Name = "ATX" };
            this.motherboardService.Create(new Motherboard() { Name = "Gigabyte Z390 UD", MaxRam = 128, RamSlots = 4, Price = 114.99M, FormFactor = motherboardFormFactor, SocketType = lga1151SockeType });
        }

        private  void CreatePowerSupplies()
        {
            var formFactor = new FormFactor() { Name = "ATX" };
            this.powerSupplyService.Create(new PowerSupply() { Name = "Corsair RM(2019)", Modular=true, Wattage=750, Price=119.99M, Efficiency=80, FormFactor=formFactor });
            formFactor = new FormFactor() { Name = "ATX" };
            this.powerSupplyService.Create(new PowerSupply() { Name = "EVGA BR", Modular = false, Wattage = 500, Price = 40.98M, Efficiency = 80, FormFactor = formFactor });
            formFactor = new FormFactor() { Name = "ATX" };
            this.powerSupplyService.Create(new PowerSupply() { Name = "EVGA SuperNOVA G3", Modular = true, Wattage = 650, Price = 112.98M, Efficiency = 80, FormFactor = formFactor });
            formFactor = new FormFactor() { Name = "ATX" };
            this.powerSupplyService.Create(new PowerSupply() { Name = "Thermaltake Smart", Modular = false, Wattage = 500, Price = 33.98M, Efficiency = 80, FormFactor = formFactor });
            formFactor = new FormFactor() { Name = "ATX" };
            this.powerSupplyService.Create(new PowerSupply() { Name = "Seasonic M12II 520 Bronze", Modular = true, Wattage = 520, Price = 74.99M, Efficiency = 80, FormFactor = formFactor });
            formFactor = new FormFactor() { Name = "ATX" };
            this.powerSupplyService.Create(new PowerSupply() { Name = "Cooler Master Silent Pro Hybrid", Modular = true, Wattage = 1300, Price = 669.20M, Efficiency = 80, FormFactor = formFactor });
        }

        private  void CreateStorages()
        {
            var formFactor35 = new FormFactor() { Name = "3.5" };
            var conInterface = new ConnectionInterface() { Name = "SATA 6 GB/s" };
            var hdd = new PCItemType() { Name = "7200RPM" };
            this.storageService.Create(new Storage() { Name = "Western Digital Caviar Blue", Capacity = "1TB", Cache = 64, FormFactor = formFactor35, Interface = conInterface, Type = hdd, Price = 44.08M });            
            var formFactor25 = new FormFactor() { Name = "M2" };
            var ssd = new PCItemType() { Name = "SSD" };
            conInterface = new ConnectionInterface() { Name = "SATA 6 GB/s" };
            this.storageService.Create(new Storage() { Name = "Samsung 860 Evo", Capacity = "1TB", Cache = 1024, FormFactor = formFactor25, Interface = conInterface, Type = ssd, Price=149.99M });
            formFactor25 = new FormFactor() { Name = "M2" };
            ssd = new PCItemType() { Name = "SSD" };
            conInterface = new ConnectionInterface() { Name = "SATA 6 GB/s" };
            this.storageService.Create(new Storage() { Name = "Smasung 970 Evo", Capacity = "250GB", Cache = 64, FormFactor = formFactor25, Interface = conInterface, Type = ssd, Price = 87.99M });
            formFactor25 = new FormFactor() { Name = "M2" };
            ssd = new PCItemType() { Name = "SSD" };
            conInterface = new ConnectionInterface() { Name = "SATA 6 GB/s" };
            this.storageService.Create(new Storage() { Name = "Samsung 860 QVO", Capacity = "500GB", Cache = 64, FormFactor = formFactor25, Interface = conInterface, Type = ssd, Price = 49.99M});
            formFactor25 = new FormFactor() { Name = "M2" };
            ssd = new PCItemType() { Name = "SSD" };
            conInterface = new ConnectionInterface() { Name = "SATA 6 GB/s" };
            this.storageService.Create(new Storage() { Name = "Kingston A400", Capacity = "480GB", Cache = 64, FormFactor = formFactor25, Interface = conInterface, Type =ssd, Price =168.99M });
            formFactor25 = new FormFactor() { Name = "M2" };
            ssd = new PCItemType() { Name = "SSD" };
            conInterface = new ConnectionInterface() { Name = "SATA 6 GB/s" };
            this.storageService.Create(new Storage() { Name = "Intel 660p Series", Capacity = "2TB", Cache = 64, FormFactor = formFactor25, Interface = conInterface, Type = ssd, Price= 79.98M});
        }

        private  void CreateVideoCards()
        {
            var conInterface1 = new ConnectionInterface() { Name = "PCIe x16" };
            var conInterface2 = new ConnectionInterface() { Name = "PCIe x16" };
            var conInterface3 = new ConnectionInterface() { Name = "PCIe x16" };
            var conInterface4 = new ConnectionInterface() { Name = "PCIe x16" };
            var conInterface5 = new ConnectionInterface() { Name = "PCIe x16" };
            var conInterface6 = new ConnectionInterface() { Name = "PCIe x16" };
            this.videoCardService.Create(new VideoCard() { Name="MSI VENTUS XS OC", Chipset="GeForce GTX 1660", MemorySize=6, CoreSpeed=1530, BoostSpeed=1830, Price=189.99M, Interface=conInterface1 });
            this.videoCardService.Create(new VideoCard() { Name = "Asus ROG Strix Gaming OC", Chipset = "GeForce RTX 2080 Ti", MemorySize = 11, CoreSpeed = 1665, BoostSpeed = 1830, Price = 1229.99M, Interface = conInterface2 });
            this.videoCardService.Create(new VideoCard() { Name = "NVIDIA 900-1G180-2515-000", Chipset = "GeForce RTX 20700 SUPER", MemorySize = 8, CoreSpeed = 1770, BoostSpeed = 1830, Price = 499.99M, Interface = conInterface3 });
            this.videoCardService.Create(new VideoCard() { Name = "XFX GTS XXX ED", Chipset = "GeForce GTX 1660 Ti", MemorySize = 6, CoreSpeed = 1530, BoostSpeed = 1830, Price = 274.99M, Interface = conInterface4 });
            this.videoCardService.Create(new VideoCard() { Name = "Gigabyte GAMING OC", Chipset = "Radeon RX 580", MemorySize = 8, CoreSpeed = 1366, BoostSpeed = 1386, Price = 159.99M, Interface = conInterface5 });
            this.videoCardService.Create(new VideoCard() { Name = "EVGA SC ULTRA GAMING", Chipset = "Radeon RX 5700 XT", MemorySize = 6, CoreSpeed = 1650, BoostSpeed = 1905, Price = 406.99M, Interface = conInterface6 });
        }
    }
}
