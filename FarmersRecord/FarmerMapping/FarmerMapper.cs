using AutoMapper;
using FarmersRecord.Dtos;
using FarmersRecord.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmersRecord.FarmerMapping
{
    public class FarmerMapper: Profile
    {
        public FarmerMapper()
        {
            CreateMap<FarmerModel, FarmerDto>().ReverseMap();
        }
    }
}
