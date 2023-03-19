﻿using System.ComponentModel.DataAnnotations;

namespace Order_Food_Online.Areas.Customer.Models
{
    public class StringLengthAttribute : ValidationAttribute
    {
        private readonly int _maxLength;

        public StringLengthAttribute(int maxLength)
        {
            _maxLength = maxLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var stringValue = value as string;

            if (stringValue != null && stringValue.Length > _maxLength)
            {
                return new ValidationResult($"The length of {validationContext.DisplayName} should not exceed {_maxLength} characters.");
            }

            return ValidationResult.Success;
        }
    }
}
