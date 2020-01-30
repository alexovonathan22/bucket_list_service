using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BucketListService
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<BucketList, BucketDto>();
            CreateMap<BucketListForCreationDto, BucketList>();

            CreateMap<Item, ItemDto>();
            CreateMap<BucketList, BucketDto>();

            CreateMap<BucketListForUpdateDto, BucketList>();

        }
    }
}
