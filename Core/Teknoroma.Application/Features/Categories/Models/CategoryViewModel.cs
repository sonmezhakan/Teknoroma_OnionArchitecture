﻿using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.Categories.Constants;


namespace Teknoroma.Application.Features.Categories.Models
{
    public class CategoryViewModel
    {
		[Display(Name = CategoryColumnNames.ID)]
        [Required(ErrorMessage = CategoryMessages.IDNotNull)]
		public Guid ID { get; set; }

        [Display(Name = CategoryColumnNames.CategoryName)]
        [Required(ErrorMessage = CategoryMessages.CategoryNameNotNull)]
        public string CategoryName { get; set; }

		[Display(Name = CategoryColumnNames.Description)]
		public string? Description { get; set; }
    }
}
