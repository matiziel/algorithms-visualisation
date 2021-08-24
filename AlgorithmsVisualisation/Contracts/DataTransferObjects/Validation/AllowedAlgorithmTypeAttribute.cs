using System;
using System.ComponentModel.DataAnnotations;
using Common;

namespace Contracts.DataTransferObjects.Validation {
    public class AllowedAlgorithmTypeAttribute : ValidationAttribute {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {

            AlgorithmType? algorithm = value as AlgorithmType?;

            if (!algorithm.HasValue)
                throw new ValidationException($"Incorrect metric type");

            return Enum.IsDefined(typeof(AlgorithmType), algorithm.Value) ?
                ValidationResult.Success :
                new ValidationResult($"Incorrect algorithm type {algorithm.Value}");
        }
    }
}