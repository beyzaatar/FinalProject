using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product> //product için bir validatör
    {
        //kurallar constructor'a yazılır
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2); //bu kural kimin için ve nedir
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0); //0'dan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); //1 numaralı kategoride unitprice'ı 10'a eşit veya büyük
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("ürünler A harfi ile başlamalıdır"); //kendimiz özel bir kural yazabiliriz. mesaj verebiliriz. çünkü buranın karşılığı yok.
            //Bu mesaj visual studiodaki hatada görünür kullanıcıya değil
        }

        private bool StartWithA(string arg) //true ya da false döner . false dönerse rulefor patlar
        {
            return arg.StartsWith("A");
        }
    }
}
