﻿using Bondlog.Server.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bondlog.Server.Controllers
{
    [Authorize(Roles = "Operative, Administrator")]
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
        //work in progress
    }
}
