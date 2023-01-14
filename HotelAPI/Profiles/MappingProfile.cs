using AutoMapper;
using Infrastructure.Data.DTO;
using Infrastructure.Data.Entities;

namespace HotelAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeEntity, EmployeeDTO>();
            CreateMap<EmployeeDTO, EmployeeEntity>();

            CreateMap<AccountEntity, AccountDTO>();
            CreateMap<AccountDTO, AccountEntity>();

            CreateMap<ReservationEntity, ReservationDTO>();
            CreateMap<ReservationDTO, ReservationEntity>();
        }
    }
}
