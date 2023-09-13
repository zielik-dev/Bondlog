using Bondlog.Server.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bondlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncorrectDeliveryController : ControllerBase
    {
        private readonly IApplicationDbContext _dbContext;

        public IncorrectDeliveryController(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //[HttpGet]
        //public async
    }
}
