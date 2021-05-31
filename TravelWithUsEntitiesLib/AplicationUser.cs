using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


public class AplicationUser:IdentityUser
{
   [Required]
   [MaxLength(100)]
   public string Nombre{ get; set;}


   [Required]
   [MaxLength(100)]
   public string Naionalidad{ get; set;}
}