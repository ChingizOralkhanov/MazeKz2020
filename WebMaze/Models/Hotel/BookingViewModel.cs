using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.Controllers.CustomAttribute;

namespace WebMaze.Models.Hotel
{
    public class BookingViewModel
    {
        [Required]
        [Display(Name = "FirstName")]
        [UIHint("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        [UIHint("LastName")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [UIHint("Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Check-in Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }
        
        [Required]
        [Display(Name = "Check-out Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [CustomDateTimeRange]
        public DateTime CheckoutDate { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Accept the terms!")]
        [Display(Name = "I Accept all Terms")]
        public bool TermsAccepted { get; set; }

        [HiddenInput]
        public long RoomNumber { get; set; }
    }
}
