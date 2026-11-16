using Clientes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClientesDbContext _context;

        public ClientesController(ClientesDbContext context)
        {
            _context = context;
        }

        // READ: GET Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.AsNoTracking().OrderBy(c => c.id).ToListAsync());
        }

        // READ: GET Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var cliente = await _context.Clientes.AsNoTracking()
                .FirstOrDefaultAsync(m => m.id == id);
            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // CREATE: GET Clientes/Create
        public IActionResult Create()
        {
            return View(new ClienteModel());
        }

        // CREATE: POST Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("cedula,nombre,apellido,direccion,telefono,mail,ciudad,provincia,fechaNacimiento,activo")]
            ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Cliente registrado correctamente";
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }

        // UPDATE: GET Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // UPDATE: POST Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("id,cedula,nombre,apellido,direccion,telefono,mail,ciudad,provincia,fechaNacimiento,activo")]
            ClienteModel cliente)
        {
            if (id != cliente.id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteModelExists(cliente.id)) return NotFound();
                    throw;
                }

                TempData["Mensaje"] = "Cliente actualizado correctamente";
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }

        // DELETE: GET Clientes/Delete/5 (confirmación)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var cliente = await _context.Clientes.AsNoTracking()
                .FirstOrDefaultAsync(m => m.id == id);
            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // DELETE: POST Clientes/Delete/5 (elimina definitivamente)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            TempData["Mensaje"] = "Cliente eliminado correctamente";
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteModelExists(int id)
        {
            return _context.Clientes.Any(e => e.id == id);
        }
    }
}
