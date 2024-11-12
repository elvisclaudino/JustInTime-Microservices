using AutoMapper;
using JustInTime.User.Shared.Communication.Requests;

namespace JustInTime.User.JustInTime.Application.Services.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping() 
    {
        RequestToDomain();
    }

    private void RequestToDomain() 
    {
        CreateMap<RequestRegisterUserJson, Domain.Entities.User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore());

        CreateMap<RequestEditUserJson, Domain.Entities.User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
