using Microsoft.AspNetCore.Mvc;
using WebApp_Noite.Models;

namespace WebApp_Noite.Controllers
{
    public class ProdutoController : Controller
    {
        public static List<ProdutoModel> dbp = new List<ProdutoModel>();
        public IActionResult Lista()
        {
            return View();
        }
        public IActionResult Cadastrar()
        {
            ProdutoModel model = new ProdutoModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult SalvarDados(ProdutoModel produto)
        {
            if (produto.Id == 0)
            {
                Random rand = new Random();
                produto.Id = rand.Next(1, 9999);
                dbp.Add(produto);
            }
            else
            {
                int indice = dbp.FindIndex(a => a.Id == produto.Id);
                dbp[indice] = produto;
            }
            return RedirectToAction("Listar");
        }
        public IActionResult Excluir(int id)
        {
            ProdutoModel item = dbp.Find(a => a.Id == id);
            if (item != null)
            {
                dbp.Remove(item);
            }
            return RedirectToAction("Lista");
        }
        public IActionResult Editar(int id)
        {
            ProdutoModel item = dbp.Find(a => a.Id == id);
            if (item != null)
            {
                return View(item);
            }
            else
            {
                return RedirectToAction("Lista");
            }
        }
    }
}
