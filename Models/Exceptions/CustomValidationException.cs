using Backend.ErrorHandling;

namespace Backend.Exceptions;

public class CustomValidationException : Exception
{
    public CustomValidationException(List<ValidationErrorHandling> validationErrors)
    {
        ValidationErrors = validationErrors;
    }
    
    public List<ValidationErrorHandling> ValidationErrors { get; set; }
}