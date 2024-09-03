﻿using ClinicManagementInternship.Data;
using ClinicManagementInternship.Dto.Admin;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementInternship.Services.Admin
{
    public class AdminService(IGenericRepository<Models.Admin> repository, DataContext context) : GenericService<CreateAdmin, UpdateAdmin, Models.Admin>(repository), IAdminService
    {
        private readonly DataContext _context = context;

        public override async Task<ServiceResult<Models.Admin>> CreateNew(CreateAdmin CreateDto)
        {
            try
            {
                var account = await _context.Accounts.FindAsync(CreateDto.AccountId);
                var admin = await _context.Admins.FirstOrDefaultAsync(a => a.AccountId == CreateDto.AccountId);
                if (account is not null && admin is null)
                {
                    var response = await base.CreateNew(CreateDto);
                    account.Role = Enums.AccountRole.ADMIN;
                    await _context.SaveChangesAsync();
                    return response;
                }
                else
                {
                    return new ServiceResult<Models.Admin>
                    {
                        Success = false,
                        ErrorMessage = "Invalid request.",
                        StatusCode = 400
                    };
                }
            }
            catch (Exception)
            {
                return new ServiceResult<Models.Admin>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }

        }
    }
}
