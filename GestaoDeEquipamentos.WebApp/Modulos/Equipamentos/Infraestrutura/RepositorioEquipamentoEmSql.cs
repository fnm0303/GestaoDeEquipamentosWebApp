using Dapper;
using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Dominio;
using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Dominio;
using Microsoft.Data.SqlClient;

namespace GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Infraestrutura;

public sealed class RepositorioEquipamentoEmSql : IRepositorioEquipamento
{
    private readonly string connectionString;

    public RepositorioEquipamentoEmSql(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Cadastrar(Equipamento novoRegistro)
    {
        const string query =
        """
            INSERT INTO TBEquipamentos (Nome, PrecoAquisicao, DataFabricacao, FabricanteId)
            OUTPUT INSERTED.Id
            VALUES (@Nome, @PrecoAquisicao, @DataFabricacao, @FabricanteId)
        """;

        using SqlConnection conexao = new(connectionString);

        novoRegistro.Id = conexao.QuerySingle<int>(query, new
        {
            novoRegistro.Nome,
            novoRegistro.PrecoAquisicao,
            novoRegistro.DataFabricacao,
            FabricanteId = novoRegistro.Fabricante.Id
        });
    }

    public bool Editar(int idSelecionado, Equipamento entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public bool Excluir(int idSelecionado)
    {
        throw new NotImplementedException();
    }

    public Equipamento? SelecionarPorId(int idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Equipamento> SelecionarTodos()
    {
        const string query =
        """
        SELECT 
        e.Id,
        e.Nome,
        e.PrecoAquisicao,
        e.DataFabricacao,
        f.Id,
        f.Nome,
        f.Email,
        f.Telefone,
        FROM TBEquipamentos e
        INNER JOIN TBFabricantes f ON f.Id = e.FabricanteId
        ORDER BY e.Id
        """;

        using SqlConnection conexao = new(connectionString);

        return conexao.Query<Equipamento, Fabricante, Equipamento>(query, MapearEquipamentoCompleto).ToList();
    }

    private static Equipamento MapearEquipamentoCompleto(Equipamento equipamento, Fabricante fabricante)
    {
        equipamento.Fabricante = fabricante;
        return equipamento;
    }
}
