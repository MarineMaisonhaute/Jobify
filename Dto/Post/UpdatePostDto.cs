﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Jobify.Dto.Post
{
    public class UpdatePostDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }
        public int JobId { get; set; }
        public int Price { get; set; }
        public DateTime FinishDate { get; set; }
        public string Department { get; set; }

    }
}
