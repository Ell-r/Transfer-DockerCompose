using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Interfaces;
using Core.Models.User;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserService(IAuthService authService,
        AppDbTransferContext transferContext,
        IMapper mapper) : IUserService
    {
        public async Task<UserProfileModel> GetUserProfileAsync()
        {
            var userId = await authService.GetUserIdAsync();

            var profile = await transferContext.Users
                .ProjectTo<UserProfileModel>(mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(u => u.Id == userId!);

            return profile!;
        }
    }
}
