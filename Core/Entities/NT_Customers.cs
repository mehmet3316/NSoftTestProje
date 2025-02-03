using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class NT_Customers 
    {
        public int? ID { get; set; }
        public Int16? AKTIF { get; set; }
        public string? KAYITKODU { get; set; }
        public DateTime? KAYITTARIHI { get; set; }
        public string? ADI { get; set; }
        public string? SOYADI { get; set; }
        public string? KIMLIKNO { get; set; }
    }
}
