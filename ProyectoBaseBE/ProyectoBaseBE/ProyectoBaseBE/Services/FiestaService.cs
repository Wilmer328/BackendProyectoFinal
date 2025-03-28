using Microsoft.EntityFrameworkCore;
using ProyectoBaseBE.Data;
using ProyectoBaseBE.Models;

namespace ProyectoBaseBE.Services;

public class FiestaService
{
    private readonly DataContext _context;
    public FiestaService(DataContext context)
    {
        _context = context;
    }
    //obtener todos los usuarios
    public async Task<List<Fiestas>> ObtenerFiestas()
    {
        return await _context.Fiestas.ToListAsync();
    }
    //obtener un usuario por id
    public async Task<Fiestas?> ObtenerFiestasPorId(Guid id)
    {
        return await _context.Fiestas.FirstOrDefaultAsync(u => u.Id == id);
    }
    //crear un usuario 
    public async Task<Fiestas> CrearFiestas(Fiestas fiestas)
    {
        fiestas.Id = Guid.NewGuid();
        

        _context.Fiestas.Add(fiestas);
        await _context.SaveChangesAsync();

        return fiestas;
    }
    //actualizar un usuario
    public async Task<bool> ActualizarFiestas(Guid id, Fiestas fiestasActualizada)
    {
        var fiestas = await _context.Fiestas.FindAsync(id);
        if (fiestas == null) return false;

        fiestas.Nombre = fiestasActualizada.Nombre;
        fiestas.Invitados = fiestasActualizada.Invitados;
        fiestas.Comida = fiestasActualizada.Comida;
        fiestas.Decoracion = fiestasActualizada.Decoracion;
        fiestas.Fecha = fiestasActualizada.Fecha;

        await _context.SaveChangesAsync();
        return true;
    }
    //eliminar un usuario
    public async Task<bool> EliminarFiestas(Guid id)
    {
        var fiestas = await _context.Fiestas.FindAsync(id);
        if (fiestas == null) return false;

        _context.Fiestas.Remove(fiestas);
        await _context.SaveChangesAsync();
        return true;
    }
}