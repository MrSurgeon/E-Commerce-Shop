namespace E_Commerce_Shop.Business.Abstract
{
    public interface IValidator<T>
    {
        string ErrorMessage { get; set; }
        bool IsValidation(T entity);
    }
}