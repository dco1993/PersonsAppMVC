using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models {
    public class UserModel {

        public int UsrId { get; set; }

        public DateTime UsrDtCad { get; set; }

        public string UsrNome { get; set; }

        public string UsrSbnome { get; set; }

        public DateTime UsrNasci { get; set; }

        public string UsrEmail { get; set; }

        public string UsrBio { get; set; }

    }
}
