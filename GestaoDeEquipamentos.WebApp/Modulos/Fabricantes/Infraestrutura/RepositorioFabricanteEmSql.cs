using Dapper;
using Microsoft.Data.SqlClient;
using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Dominio;

namespace GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Infraestrutura;

public sealed class RepositorioFabricanteEmSql : IRepositorioFabricante
{
    private readonly string connectionString;

    public RepositorioFabricanteEmSql(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Cadastrar(Fabricante novoRegistro)
    {
        throw new NotImplementedException();
    }

    public bool Editar(int idSelecionado, Fabricante entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public bool Excluir(int idSelecionado)
    {
        throw new NotImplementedException();
    }

    public Fabricante? SelecionarPorId(int idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Fabricante> SelecionarTodos()
    {
        const string query =
            """
                SELECT Id, Nome, Email, Telefone
                FROM dbo.TBFabricantes
                ORDER BY Id
            """;

        using SqlConnection conexao = new(connectionString);  //using = para garantir que a conexão será descartada/fechada qdo bater no final do método que precisa dessa conexão

        //Query = consulta no banco
        return conexao.Query<Fabricante>(query).ToList();
    }
}
