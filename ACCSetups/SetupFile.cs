using ACCSetups.Models.AccSetupJson;
using AutoMapper;
using System;
using System.IO;
using System.Text.Json;
using AccSetupJson = ACCSetups.Models.AccSetupJson;
using AccSetup = ACCSetups.Models.AccSetup;
using ACCSetups.Models.AccSetup;

namespace ACCSetups
{
    public class SetupFile : ISetupFile
    {
        public BaseSetup LoadedSetup { get; private set; }
        public JsonDocument JsonSetup { get; private set; }

        private readonly string _filepath;
        private readonly string _filename;
        private IMapper _mapper;

        public SetupFile(string filepath, string filename)
        {
            if (string.IsNullOrWhiteSpace(filepath))
            {
                throw new ArgumentNullException(nameof(filepath));
            }
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException(nameof(filename));
            }

            _filename = filename;
            _filepath = filepath;

            SetupMapper();
        }

        public void Load()
        {
            var file = File.ReadAllText($"{_filepath}\\{_filename}");
            JsonSetup = JsonDocument.Parse(file);
            var rootSetup = JsonSerializer.Deserialize<Root>(file);
            LoadedSetup = _mapper.Map<AccSetupJson.Root, AccSetup.BaseSetup>(rootSetup);
        }

        private void SetupMapper()
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<AccSetupJson.AdvancedSetup, AccSetup.AdvancedSetup>().ReverseMap();
                c.CreateMap<AccSetupJson.AeroBalance, AccSetup.AeroBalance>().ReverseMap();
                c.CreateMap<AccSetupJson.Alignment, AccSetup.Alignment>().ReverseMap();
                c.CreateMap<AccSetupJson.BasicSetup, AccSetup.BasicSetup>().ReverseMap();
                c.CreateMap<AccSetupJson.Dampers, AccSetup.Dampers>().ReverseMap();
                c.CreateMap<AccSetupJson.Drivetrain, AccSetup.Drivetrain>().ReverseMap();
                c.CreateMap<AccSetupJson.Electronics, AccSetup.Electronics>().ReverseMap();
                c.CreateMap<AccSetupJson.MechanicalBalance, AccSetup.MechanicalBalance>().ReverseMap();
                c.CreateMap<AccSetupJson.PitStrategy, AccSetup.PitStrategy>().ReverseMap();
                c.CreateMap<AccSetupJson.Root, AccSetup.BaseSetup>().ReverseMap();
                c.CreateMap<AccSetupJson.Strategy, AccSetup.Strategy>().ReverseMap();
                c.CreateMap<AccSetupJson.Tyre, AccSetup.Tyre>().ReverseMap();
            });

            _mapper = new Mapper(config);
        }

        public void Save(BaseSetup setup, string filepath, string filename)
        {
            var prepSetup = _mapper.Map<AccSetup.BaseSetup, AccSetupJson.Root>(setup);
            var json = JsonSerializer.Serialize<AccSetupJson.Root>(prepSetup);

            File.WriteAllText($"{filepath}\\{filename}", json);
        }
    }
}
