using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class SupportTickets
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Cliente")]
        public string Cliente { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required]
        [Display(Name = "Titulo del problema")]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Detalle del problema")]
        public string Detalle { get; set; }

        [Required]
        [Display(Name = "Estado actual")]
        public string Estado { get; set; }
    }
}