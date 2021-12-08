using System;
using System.ComponentModel.DataAnnotations;

namespace PersonsAppMVC.Models {
    public class PersonsModel {

        [Display(Name = "ID Usuário")]
        public int UsrId { get; set; }

        [Display(Name = "Data de Cadastro")]
        public DateTime UsrDtCad { get; set; }

        [Display(Name = "Nome")]
        public string UsrNome { get; set; }

        [Display(Name = "Sobrenome")]
        public string UsrSbnome { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime UsrNasci { get; set; }

        [Display(Name = "Email")]
        public string UsrEmail { get; set; }

        [Display(Name = "Biografia")]
        public string UsrBio { get; set; }

    }
}
