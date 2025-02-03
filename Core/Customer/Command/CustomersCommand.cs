using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Customer.Command
{
    public class CustomersCommand : IRequest<ApiResponse<NT_Customers>>
    {
        public string? KAYITKODU { get; set; }

        [Required(ErrorMessage = "Adı alanı zorunlu doldurulması gereken alan.")]
        [MaxLength(50, ErrorMessage = "Adı alanı en fazla 50 karakter olmalıdır.")]
        public string? ADI { get; set; }
        [Required(ErrorMessage = "Soyadı alanı zorunlu doldurulması gereken alan.")]
        [MaxLength(50, ErrorMessage = "Soyadı alanı en fazla 50 karakter olmalıdır.")]
        public string? SOYADI { get; set; }
        [Required(ErrorMessage = "Kimlik No alanı zorunlu doldurulması gereken alan.")]
        [MaxLength(15, ErrorMessage = "Kimlik No alanı en fazla 15 karakter olmalıdır.")]
        public string? KIMLIKNO { get; set; }
    }
}
