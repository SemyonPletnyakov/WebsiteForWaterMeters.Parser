using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser_09_2022
{
    public class Check
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string OfdName { get; set; }
        public string InnOfd { get; set; }
        public string InnCompany { get; set; }
        public string DocumentNumber { get; set; }
        public string SmenaNumber { get; set; }
        public string DocumentIndex { get; set; }
        public string Date { get; set; }
        public string FN { get; set; }
        public string FP { get; set; }
        public string LS { get; set; }
        public string UslugaName { get; set; }
        public double Price { get; set; }
        public bool PaymentStatus { get; set; }
        public long PayId { get; set; }
    }
}
