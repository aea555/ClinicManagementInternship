﻿using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public required int AccountId { get; set; }
        public Account? Account { get; set; }
        public required int ClinicId { get; set; }
        public Clinic? Clinic { get; set; }
        public required int ClinicRoomId { get; set; }
        public ClinicRoom? ClinicRoom { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
