using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models {
    public class UserModel {

        [Display(Name = "ID Usuário")]
        public int UsrId { get; set; }

        [Display(Name = "Dt. Cadastro")]
        public DateTime UsrDtCad { get; set; }

        [Display(Name = "Nome")]
        public string UsrNome { get; set; }

        [Display(Name = "Sobrenome")]
        public string UsrSbnome { get; set; }

        [Display(Name = "Dt. Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UsrNasci { get; set; }

        [Display(Name = "Email")]
        public string UsrEmail { get; set; }

        [Display(Name = "Biografia")]
        public string UsrBio { get; set; }

    }
}
