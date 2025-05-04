using AutoMapper;
using Wypozyczalnia.Models;
using Wypozyczalnia.ViewModels;

namespace Wypozyczalnia.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Klient, KlientViewModel>().ReverseMap();
        }
    }
}
