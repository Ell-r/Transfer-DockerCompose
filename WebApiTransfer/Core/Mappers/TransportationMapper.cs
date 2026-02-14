using AutoMapper;
using Core.Models.Transportation;
using Domain.Entities.Transportation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers
{
    public class TransportationMapper : Profile
    {
        public TransportationMapper()
        {
            CreateMap<TransportationSeedModel, TransportationEntity>();
        }
    }
}
