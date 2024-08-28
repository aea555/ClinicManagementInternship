﻿using ClinicManagementInternship.Enums;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Patient
{
    public class CreatePatient : GenericDTO
    {
        public required int AccountId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime BirthDate { get; set; }
        public required GenderEnum Gender { get; set; }
    }
}
