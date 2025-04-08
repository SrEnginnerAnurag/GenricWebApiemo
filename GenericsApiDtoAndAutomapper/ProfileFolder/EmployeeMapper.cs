using AutoMapper;
using GenericsApiDtoAndAutomapper.DtoFolder;
using GenericsApiDtoAndAutomapper.ModelFolder;

namespace GenericsApiDtoAndAutomapper.ProfileFolder
{
    public class EmployeeMapper:Profile
    {
        public EmployeeMapper()
        {
            CreateMap<EmployeeModel, EmployeeDto>()
                .ForMember(dest => dest.EmpId, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.EmpName, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.EmpCompanyName, act => act.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.EmpEmail, act => act.MapFrom(src => src.Email)).ReverseMap();

            CreateMap<CochingModel , CochingDto>()
               .ForMember(dest => dest.CochingId, act => act.MapFrom(src => src.Id))
               .ForMember(dest => dest.CochingName, act => act.MapFrom(src => src.Name))
               .ForMember(dest => dest.CochingAddress, act => act.MapFrom(src => src.Address)).ReverseMap();

        }
    }
}
