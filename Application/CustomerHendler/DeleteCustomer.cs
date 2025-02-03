using Core.Customer.Query;
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

namespace Application.CustpmerHendler
{
    public class DeleteCustomer : IRequestHandler<DeleteQuery, ApiResponse<NT_Customers>>
    {
        private readonly IDapperRepository _repository;

        public DeleteCustomer(IDapperRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<NT_Customers>> Handle(DeleteQuery request, CancellationToken cancellationToken)
        {
            //Validation işlemi 
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(request);
            bool isValid = Validator.TryValidateObject(request, validationContext, validationResults, true);

            if (!isValid)
            {
                var errorMessages = validationResults.Select(v => v.ErrorMessage).ToList();
                return ApiResponse<NT_Customers>.Fail(400, string.Join(", ", errorMessages));
            }

            //Dapper ile kayıt bul ve ApiResponse ile dönüş yap
            var product = await _repository.QuerySingleAsync<NT_Customers>("sp_DeactivateCustomer", new { KAYITKODU = request.KAYITKODU }, CommandType.StoredProcedure);

            if (product == null)
            {
                return ApiResponse<NT_Customers>.Fail(404, "Müşteri bilgileri bulunamadı");
            }

            return ApiResponse<NT_Customers>.Success(JsonConvert.SerializeObject(product), "Müşteri bilgileri silindi.");
        }
    }
}
