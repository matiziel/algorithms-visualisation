using System;
using System.ComponentModel.DataAnnotations;
using Common;

namespace Contracts.DataTransferObjects.Validation {
    public class AllowedMetricTypeAttribute : ValidationAttribute {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {

            MetricType? metric = value as MetricType?;

            if (!metric.HasValue)
                throw new ValidationException($"Incorrect metric type");

            return Enum.IsDefined(typeof(MetricType), metric.Value) ?
                ValidationResult.Success :
                new ValidationResult($"Incorrect metric type {metric.Value}");
        }
    }
}