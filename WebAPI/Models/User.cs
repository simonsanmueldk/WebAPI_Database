using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WebAPI.Models
{
    public class User
    {
        [Key,JsonProperty("UserName")]
        public string UserName { get; set; }
        [Required,JsonProperty("SecurityLevel")]
        public int SecurityLevel { get; set; }
        [Required,JsonProperty("Password")]
        public string Password { get; set; }
    }
}