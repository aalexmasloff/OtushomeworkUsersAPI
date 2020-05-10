using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Otushomework.Users.API.Entities;
using Otushomework.Users.API.Models;
using Otushomework.Users.API.Stores;

namespace Otushomework.Users.API.Controllers
{
    /// <summary>
    ///  User Service.
    ///  Operations about user.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly UsersDbConext _dbConext;
        private readonly IMapper _mapper;

        public UsersController(ILogger<UsersController> logger, UsersDbConext dbConext, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dbConext = dbConext ?? throw new ArgumentNullException(nameof(dbConext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

           
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = _dbConext.Users.ToList();
            return await Task.FromResult(Ok(users));
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            //_dbConext.Database.EnsureCreated();

            var user = _dbConext.Users.FirstOrDefault(x => x.Id == userId);
            return await Task.FromResult(Ok(user));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserModel model)
        {
            var enitity = _mapper.Map<User>(model);

            await _dbConext.Users.AddAsync(enitity);
            await _dbConext.SaveChangesAsync();
            return await Task.FromResult(Ok(enitity));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserModel model)
        {
            User enitity = null;

            if (model.Id.HasValue)
            {
                enitity = _dbConext.Users.FirstOrDefault(x => x.Id == model.Id.Value);
                if (enitity == null)
                    return await Task.FromResult(BadRequest("Provided User ID is invalid."));
            }

            enitity = _mapper.Map<User>(model);

            if (!model.Id.HasValue)
                await _dbConext.Users.AddAsync(enitity);

            await _dbConext.SaveChangesAsync();
            return await Task.FromResult(Ok(enitity));
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var user = _dbConext.Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
                _dbConext.Users.Remove(user);
            await _dbConext.SaveChangesAsync();

            return await Task.FromResult(NoContent());
        }
    }
}