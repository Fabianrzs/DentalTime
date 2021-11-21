using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class LoginInputModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        //[RegularExpression(@"^(?=.*\d)(?=.*[\u0021-\u002b\u003c-\u0040])(?=.*[A-Z])(?=.*[a-z])\S{8,16}$", ErrorMessage ="La contraseña debe tener al entre 8 y 16 caracteres, al menos un dígito, al menos una minúscula, al menos una mayúscula y al menos un caracter no alfanumérico.")] para para registrar 
        public string Password { get; set; }
    }
    public class LoginViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        [JsonIgnore] //os parámetros del constructor marcan una propiedad que se debe ignorar durante la serialización a JSON (o la deserialización de JSON). Consulte la documentación de referencia de anotaciones de Jackson para obtener más detalles.
        public string Password { get; set; }
        public string Token { get; set; }
    }


}
