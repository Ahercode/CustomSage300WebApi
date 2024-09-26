using AutoMapper;
using CustomSage300WebApi.Dtos;
using CustomSage300WebApi.Entities;
using Microsoft.Win32.SafeHandles;

namespace CustomSage300WebApi.MappingProfile;

public class RequestMapping : Profile
{
    public RequestMapping()
    {
        CreateMap<POPORI, POResponse>();
        CreateMap<PORequest, POPORI>().ReverseMap();
        CreateMap<SageUserRequest, SageUser>().ReverseMap();
        CreateMap<SageUser, SageUserResponse>();
        CreateMap<SageModuleRequest, SageModule>();
        CreateMap<SageModule, SageModuleResponse>();
        CreateMap<SageModuleUser, SageModuleUserResponse>();
        CreateMap<SageModuleUserRequest, SageModuleUser>();
        CreateMap<SageFileRequest, SageFile>().ReverseMap();
        CreateMap<WorkFlowDetail, WorkFlowDetailResponse>();
        CreateMap<WorkFlowDetailRequest, WorkFlowDetail>();
    }
}