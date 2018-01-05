namespace Infrastructure.Infrastructure.Contract
{
    public interface IValidator<TContext>
    {
        void Validate(TContext context);
    }
}
