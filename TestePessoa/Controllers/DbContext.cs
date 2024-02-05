using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Pessoa> Pessoas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configuração da string de conexão com o SQL Server
        optionsBuilder.UseSqlServer("string_sql");
    }
}

public class PessoaRepository
{
    private readonly ApplicationDbContext _context;

    public PessoaRepository()
    {
        _context = new ApplicationDbContext();
    }

    public List<Pessoa> ObterTodasPessoas()
    {
        return _context.Pessoas.ToList();
    }

    public void AdicionarPessoa(Pessoa pessoa)
    {
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();
    }

    public void AtualizarPessoa(Pessoa pessoa)
    {
        _context.Pessoas.Update(pessoa);
        _context.SaveChanges();
    }

    public void ExcluirPessoa(int id)
    {
        var pessoa = _context.Pessoas.Find(id);
        if (pessoa != null)
        {
            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
        }
    }
}
