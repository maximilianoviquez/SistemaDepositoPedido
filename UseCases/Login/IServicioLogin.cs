namespace Obligatorio2_P3.UseCases
{
    public interface IServicioLogin<I, O>
    {
        public O Login(I dto);
    }
}
