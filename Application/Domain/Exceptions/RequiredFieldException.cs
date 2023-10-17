namespace UserManagementAPI.Application.Domain.Exceptions
{
    public class RequiredFieldException : BadRequestException
    {
        public RequiredFieldException(string fieldName) : base($"O campo {fieldName} é obrigatório") { }
    }
}