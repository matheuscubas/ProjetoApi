using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioDesafiante.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        [MinLength(6, ErrorMessage = "A Senha deve possuir no minimo 6 caracteres")]
        public string Password { get; set; }

        public int RoleId { get; set; }

        [JsonIgnore]
        public Role Role { get; set; }

    }
}
