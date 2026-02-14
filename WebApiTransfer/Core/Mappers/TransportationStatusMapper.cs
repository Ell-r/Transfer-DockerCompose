using AutoMapper;
using Core.Models.TransportationStatus;
using Domain.Entities.Transportation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers
{
    public class TransportationStatusMapper : Profile
    {
        public TransportationStatusMapper()
        {
            CreateMap<TransportationStatusSeedModel, TransportationStatusEntity>();
        }
    }
}
