using Microsoft.AspNetCore.Mvc;
using WebApp_Noite.Models;

namespace WebApp_Noite.Controllers
{
    public class ClienteController : Controller
    {
        public static List<ClienteModel> db = new List<ClienteModel>();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cadastrar()
        {
            ClienteModel model = new ClienteModel();
            return View(model);
        }
        public IActionResult Listar()
        {
            return View(db);
        }

        [HttpPost]
        public IActionResult SalvarDados(ClienteModel cliente)
        {
            if (cliente.Id == 0)
            {
                Random rand = new Random();
                cliente.Id = rand.Next(1, 9999);
                db.Add(cliente);
            }
            else
            {
                int indice = db.FindIndex(a => a.Id == cliente.Id);
                db[indice] = cliente;
            }
            return RedirectToAction("Listar");
        }
        public IActionResult Excluir(int id)
        {
            ClienteModel item = db.Find(a => a.Id == id);
            if (item != null)
            {
                db.Remove(item);
            }
            return RedirectToAction("Listar");
        }
        public IActionResult Editar(int id)
        {
            ClienteModel item = db.Find(a => a.Id == id);
            if (item!=null)
            {
                return View(item);
            }
            else 
            {
                return RedirectToAction("Listar");
            }
        }
        
    }
}