using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Validators
{
   public class ValidationErrorResult
    {
        /// <summary>
        /// Hangi propertyde alanda hata olduğu bilgisii için
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Hata mesajı için
        /// </summary>
        public string ValidationMessage { get; set; }
    }
    public class ValidationResult
    {
        public bool IsValid { get; private set; } = true;
        /// <summary>
        /// Nesne içerisinde birden fazla hata olma ihtimaline göre eklendi.
        /// </summary>
        public List<ValidationErrorResult> Errors { get; private set; }
        public void AddError(ValidationErrorResult error)
        {
            IsValid = false; // tek bir hata bile varsa bu nesne valid doğrulanamaz.
            Errors.Add(error);
        }
    }
    public interface IValidator<TDto> where TDto:class
    {
        /// <summary>
        /// Validate işlemei sonrası nesnenin valid mi değil mi
        /// </summary>
        ValidationResult ValidationResult { get; set; }
        
        /// <summary>
        /// Frontend tarafında gönderilen dtonun validasyon kurallarına uyup uymadığını kontrol ederiz.
        /// </summary>
        /// <param name="dto"></param>
        void Validate(TDto dto);
    }
}
