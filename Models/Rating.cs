﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Jobify.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public string Comment { get; set; }
        public int Note { get; set; }
        public Guid RatedUserId { get; set; }
        [ForeignKey("RatedUserId")]
        public User RatedUser { get; set; }
        public Guid RaterUserId { get; set; }
        [ForeignKey("RaterUserId")]
        public User RaterUser { get; set; }
    }
}
