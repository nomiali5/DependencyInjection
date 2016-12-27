﻿namespace MedicalJournal.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class PublisherModel
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime AddedDate { get; set; }
    }
}