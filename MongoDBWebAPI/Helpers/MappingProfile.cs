using AutoMapper;
using MongoDBWebAPI.Core.DTO.Requests;
using MongoDBWebAPI.Core.Entities.Database;

namespace MongoDBWebAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<CreateBookRequestDTO, Book>();

        }
    }
}
