using JQuery_Datatable.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Dynamic;

namespace JQuery_Datatable.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatatableContext _context;

        public HomeController(DatatableContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<object> GetData(int start, int length, Dictionary<string, string> search)
        {
            var alunos = new List<Aluno>();
            var filtro = search["value"];

            if (!string.IsNullOrEmpty(search["value"]))
            {
                alunos = await _context.Aluno.Where(x => x.Nome.ToLower().Contains(filtro.ToLower())).ToListAsync();
                if (alunos.Count > length)
                {
                    alunos = alunos.Skip(start).Take(length).ToList();
                }
            }
            else
            {
                alunos = await _context.Aluno.Skip(start).Take(length).ToListAsync();
            }

            dynamic obj = new ExpandoObject();
            obj.alunos = alunos;
            obj.recordsTotal = 200000;
            obj.recordsFiltered = 200000;
            return obj;
        }
    }
}