using Blog_Projeto.Data;
using Blog_Projeto.Models.dto;
using System.Text.RegularExpressions;

namespace Blog_Projeto.Services.Profile.ProfExtra
{
    public static class EmailValidation
    {        
        public static bool EmailExists(DadosUser_dto User, Blog_Context _context)
        {
            var item = _context.DadosUser.FirstOrDefault(x => x.Email == User.Email);
            if (item == null)
            {
                return false;
            }
            return true;
        }
        public static bool EmailValid(string Email)
        {
            string regex = @"(gmail\.com|email\.com|yahoo\.com)$";
            var Regex = new Regex(regex);
            return Regex.IsMatch(Email);
        }
    }
}
