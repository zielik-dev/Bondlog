﻿using Microsoft.AspNetCore.Identity;

namespace Bondlog.Client.Services.Interfaces
{
    public interface IRemoveRoleService
    {
        public Task<bool> DeleteRoleAsync(string roleName);
    }
}
