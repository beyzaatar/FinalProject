using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //aspect'imiz:metodun başında, sonunda , hata verdiğinde çalışacak yapı. nerede istersek orada
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding(savunma odaklı kodlama):aslında bu kodu yazmasakta sistem çalışır ama attribute'ler typeof'la çalıştığı için
            //kullanıcılar kafalarına göre her şeyi yazabilirler. instance değil tip göndeririz .manager daki add metodu 
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //gçnderilen validatortype bir IValidator'mı
            {
                throw new System.Exception("bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation) //validation metodun başında yapılır
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //çalışma anında instance oluşturma . çünkü bize sadece tip göndermişti
            //productvalidator'ın bi instance'ını oluştur ve onu ıvalidator tipine getir.intellicensde kullanılabilir hale
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //validatorType'ın bir base'i var oradaki 0 indeksli generic'i al. product'ı yani
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//metodun argümanlarını gez. eğer oradaki bir tip entitytype yani product türündeyse
            //onları validate et
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
