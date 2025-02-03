
using Core.Customer.Command;
using Core.Entities;
using Infrastructure;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler
{
    public class CreateOrUpdateCustomer : IRequestHandler<CustomersCommand, ApiResponse<NT_Customers>>
    {
        private readonly IDapperRepository _repository;

        public CreateOrUpdateCustomer(IDapperRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<NT_Customers>> Handle(CustomersCommand request, CancellationToken cancellationToken)
        {
            //Zorunlu alan kontrolleri
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(request);
            bool isValid = Validator.TryValidateObject(request, validationContext, validationResults, true);

            if (!isValid)
            {
                var errorMessages = validationResults.Select(v => v.ErrorMessage).ToList();
                return ApiResponse<NT_Customers>.Fail(400, string.Join(", ", errorMessages));
            }

            //Dapper ile StoredProcedure veritabanı kayıt işlemleri
            string productId = await _repository.QuerySingleAsync<string>("sp_InsertOrUpdateXCustomers", request, CommandType.StoredProcedure);

            if (String.IsNullOrEmpty(productId))
            {
                return ApiResponse<NT_Customers>.Fail(400, "Müşteri kayıt işlemi yapılamadı.");
            }

            return ApiResponse<NT_Customers>.Success(productId, "Müşteri kayıt işlemi başarılı.");
        }
    }
}
