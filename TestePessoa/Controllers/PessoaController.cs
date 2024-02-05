using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TestePessoa.Models;
using Microsoft.EntityFrameworkCore;

public class PessoaController : Controller
{
    private readonly ApplicationDbContext _context;

    public PessoaController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var pessoas = _context.Pessoas.ToList();
        return View(pessoas);
    }

    public IActionResult Detalhes(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == id);

        if (pessoa == null)
        {
            return NotFound();
        }

        return View(pessoa);
    }

    public IActionResult Criar()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Criar(Pessoa pessoa)
    {
        if (ModelState.IsValid)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(pessoa);
    }

    public IActionResult Editar(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == id);

        if (pessoa == null)
        {
            return NotFound();
        }

        return View(pessoa);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(int id, Pessoa pessoa)
    {
        if (id != pessoa.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(pessoa);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(pessoa);
    }

    public IActionResult Excluir(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == id);

        if (pessoa == null)
        {
            return NotFound();
        }

        return View(pessoa);
    }

    [HttpPost, ActionName("Excluir")]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmarExclusao(int id)
    {
        var pessoa = _context.Pessoas.Find(id);
        _context.Pessoas.Remove(pessoa);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
