
namespace UserManagementAPI.Application.Validators
{
    public static class DataNascimentoValidator
    {
        public static bool IsValid(DateTime dataNascimento)
        {            
            if (dataNascimento > DateTime.Now)
            {
                return false;
            }

            return true;
        }
    }

}