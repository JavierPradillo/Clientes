using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Clientes.Models
{
    public class Client
    {
        [ScaffoldColumn(false)]
        public int      ClientID       { get; set; }
        [DisplayName("DNI/NIE")]
        [Required(ErrorMessage = "Campo Requerido")]
        [IdDoc(ErrorMessage = "Número de identificación no válido")]
        public string   Identification { get; set; }
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string   Name           { get; set; }
        [DisplayName("Apellidos")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string   Surname        { get; set; }
        [DisplayName("eMail")]
        [Required(ErrorMessage = "Campo Requerido")]
        [EmailAddress(ErrorMessage = "Formato de eMail no válido")]
        public string   Email          { get; set; }
        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "Campo Requerido")]
        [Phone(ErrorMessage = "Formato de eMail no válido")]
        public string   Phone          { get; set; }
        [DisplayName("País")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string   Country        { get; set; }
        [DisplayName("Fecha de nacimiento")]
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate      { get; set; }
    }
}