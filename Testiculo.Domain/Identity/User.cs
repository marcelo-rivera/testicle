
using Microsoft.AspNetCore.Identity;
using Testiculo.Domain.Enum;

namespace Testiculo.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public string PrimeiroNome {get; set;}   
        public string UltimoNome { get; set; } 
        public Titulo Titulo { get; set; }
        public string? Descricao { get; set; }
        public Funcao Funcao { get; set; }
        public string? ImagemURL { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }

    }
}