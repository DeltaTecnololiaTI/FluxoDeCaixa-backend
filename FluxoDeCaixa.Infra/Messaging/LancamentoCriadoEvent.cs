namespace FluxoDeCaixa.Infra.Messaging
{
    public class LancamentoCriadoEvent
    {
        public int LancamentoId { get; }

        public LancamentoCriadoEvent(int lancamentoId)
        {
            LancamentoId = lancamentoId;
        }
    }
}
