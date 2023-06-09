﻿using System.ComponentModel.DataAnnotations;

namespace WaterLogger.Models
{
    public class DrinkingWaterModel
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Value for {0} must be positive")]
        public float Quantity { get; set; }
    }
}
