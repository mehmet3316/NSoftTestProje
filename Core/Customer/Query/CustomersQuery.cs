using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Customer.Query
{
    public class CustomersQuery : IRequest<ApiResponse<NT_Customers>>
    {
        [Required(ErrorMessage = "Uniq alan zorunludur.")]
        public string? KAYITKODU { get; set; }
    }
}
