﻿using PruebaThinkUs.Datos;
using PruebaThinkUs.Models;

namespace PruebaThinkUs.Services
{
    public class EmpleadoService: IEmpleadoService
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Empleado> GetAll()
        {
            return _context.Empleado.ToList();
        }

        public Empleado GetById(int id)
        {
            return _context.Empleado.Find(id);
        }

        public void Add(Empleado empleado)
        {
            _context.Empleado.Add(empleado);
            _context.SaveChanges();
        }

        public void Update(Empleado empleado)
        {
            _context.Empleado.Update(empleado);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var empleado = _context.Empleado.Find(id);
            if (empleado != null)
            {
                _context.Empleado.Remove(empleado);
                _context.SaveChanges();
            }
        }
    }
}
