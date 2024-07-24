using AuthMicroservice.Models.Auth;
using AutoMapper;

namespace AuthMicroservice.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AuthResult, AuthResponse>();
        }
    }
}
