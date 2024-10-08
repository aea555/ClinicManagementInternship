﻿using ClinicManagementInternship.Dto.BiochemistSignupRequest;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Services.BiochemistSignupRequest;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiochemistSignupRequestController(IBiochemistSignupRequestService service) : GenericController<CreateBiochemistSignupRequest, UpdateBiochemistSignupRequest, Models.BiochemistSignupRequest>(service)
    {
        private readonly IBiochemistSignupRequestService _service = service;

        [HttpPost]
        [Authorize(Roles = "ADMIN,NONE")]
        public override async Task<ActionResult<ServiceResult<BiochemistSignupRequest>>> CreateNew([FromBody] CreateBiochemistSignupRequest CreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.CreateNew(CreateDto);
            return HandleResponse(response);
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public override async Task<ActionResult<ServiceResult<Models.BiochemistSignupRequest>>> Update([FromBody] UpdateBiochemistSignupRequest updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.Update(updateDto);
            return HandleResponse(response);
        }
    }
}
