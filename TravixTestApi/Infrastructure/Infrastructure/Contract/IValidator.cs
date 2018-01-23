namespace Core.Infrastructure.Contract
{
    public interface IValidator<TContext>
    {
        void Validate(TContext context);
    }
}
