namespace PB.Solicitacoes.DomainModel
{
    public interface IManipuladorDeEvento<TAgregador> where TAgregador : Agregador
    {
         void Executar(TAgregador entidade);
    }
}