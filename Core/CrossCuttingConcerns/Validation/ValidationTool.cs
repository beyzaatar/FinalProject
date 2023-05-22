using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool //bu tip tool'lar static olur. çünkü uygulama boyunce tek bir instance oluşturulur ve o kullanılır. tekrar tekrar new'lememek için
    {
        public static void Validate(IValidator validator,object entity) //productvalidator'ı tutar
        {
            //validation yaparken yazılacak standart kod
            var context = new ValidationContext<object>(entity); //product için generic bir doğrulama context'i oluştur.Product için doğrulama yapacağım.
            var result = validator.Validate(context); //productvalidator'daki kurallara göre context' yani product'ı doğrula
            if (!result.IsValid) //eğer sonuç geçerli değilse
            {
                throw new ValidationException(result.Errors); //hata fırlat
            }
        }
    }
}
