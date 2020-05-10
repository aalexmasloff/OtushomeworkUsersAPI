using Otushomework.Users.API.Entities;
using Otushomework.Users.API.Models;

namespace Otushomework.Users.API.Configuration
{
    public class AutoMapperApiProfile : AutoMapper.Profile
    {
        public AutoMapperApiProfile()
        {
            AllowNullCollections = true;

            CreateMap<AddUserModel, User>();
            CreateMap<UpdateUserModel, User>();
        }
    }
}