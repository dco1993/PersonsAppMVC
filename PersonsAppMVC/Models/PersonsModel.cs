using System;
using System.ComponentModel.DataAnnotations;

namespace PersonsAppMVC.Models {
    public class PersonsModel {

        [Display(Name = "Nome")]
        public string UsrNome { get; set; }

        [Display(Name = "Sobrenome")]
        public string UsrSbnome { get; set; }

        [Display(Name = "Dt. Nascimento")]
        [DataType(DataType.Date)]
        public DateTime UsrNasci { get; set; }

        [Display(Name = "Email")]
        public string UsrEmail { get; set; }

        [Display(Name = "Biografia")]
        public string UsrBio { get; set; }

    }
}
