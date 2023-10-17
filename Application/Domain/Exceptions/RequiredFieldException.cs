using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAPI.Application.Domain.Exceptions
{
    public class RequiredFieldException : Exception
    {
        public string FieldName { get; }
        public RequiredFieldException(string message, string fieldName) : base(message) { FieldName = fieldName; }
    }
}