using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDcomMYSQL.Models;

namespace CRUDcomMYSQL.Controllers
{
    [Route("Usuario")]
    public class HomeController : Controller
    {   
        private DataContext Db = new DataContext();

        [Route("")]
        [Route("Index")]
        [Route("~/")]
        public IActionResult Index()
        {
            ViewBag.MSG = "";
            return View();
        }

        [HttpPost]
        public IActionResult Login(Logar dados)
        {
            string mensagem = "";
            string caminho = "";
            var Banco = Db.Usuarios.ToList();
            foreach (var item in Banco)
            {
                if (dados.Email == item.Email && dados.Senha == item.Senha)
                {
                    mensagem = item.Nome_social;
                    caminho = "Login";
                    break;           
                }
                else
                {
                    mensagem = "usuario não encontrado ou email/senha estão incorretos";
                    caminho = "Index";
                }
            }
            ViewBag.MSG = mensagem;
            ViewBag.Banco = Banco;
            return View(caminho);
        }

        
        [Route("Cadastro")]
        public IActionResult Cadastro()
        {
            ViewBag.Titulacao = Db.Titulacoes.ToList();
            return View();
        }

        [HttpPost]
        [Route("Cadastro")]
        public IActionResult Cadastro(Usuario dados)
        {
            string mensagem;
            bool verificador = false;
            var Banco = Db.Usuarios.ToList();
            foreach (var item in Banco)
            {
                if (dados.Email == item.Email)
                {
                    verificador = false;
                    break;
                }
                else
                {
                    verificador = true;
                }
            }
            if (verificador == true)
            {
                dados.Social = "ajudando";
                Db.Usuarios.Add(dados);
                Db.SaveChanges(); 
                //Console.WriteLine(dados.Email.ToString());
                mensagem = "Usuario cadastrado com sucesso";
            }
            else
            {
                mensagem = "Usuario já cadastrado";
            }
            ViewBag.MSG = mensagem;
            return View("Index");
        }
    }
}