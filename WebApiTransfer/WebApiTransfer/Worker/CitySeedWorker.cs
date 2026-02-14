using AutoMapper;
using Core.Models.Location.City;
using Core.Models.Location.Country;
using Domain;
using Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;

namespace WebApiTransfer.Worker
{
    public class CitySeedWorker : BaseSeedWorker<CitySeedModel, CityEntity>
    {
        public CitySeedWorker(IMapper mapper, AppDbTransferContext context) : base(mapper, context)
        {
        }
    }
}
