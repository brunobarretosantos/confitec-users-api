namespace UserManagementAPI.Application.Domain.Exceptions
{
    public class InvalidFieldException : BadRequestException
    {
        public InvalidFieldException(string fieldName) : base($"O campo {fieldName} é inválido") { }
    }
}