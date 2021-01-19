namespace ConcessionariaDominio.Entidades
{
    public class RetornoGenerico
    {
        public RetornoGenerico(bool sucesso, string mensagem, object data)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Data { get; set; }
    }
}