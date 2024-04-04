using AutoMapper;
using CustomSage300WebApi.Dtos;
using CustomSage300WebApi.Entities;

namespace CustomSage300WebApi.MappingProfile;

public class RequestMapping : Profile
{
    public RequestMapping()
    {
        CreateMap<POPORI, POResponse>();
        CreateMap<SageUserRequest, SageUser>();
        CreateMap<SageUser, SageUserResponse>();
        CreateMap<SageModuleRequest, SageModule>();
        CreateMap<SageModule, SageModuleResponse>();
        CreateMap<SageModuleUser, SageModuleUserResponse>();
        CreateMap<SageModuleUserRequest, SageModuleUser>();
    }
}