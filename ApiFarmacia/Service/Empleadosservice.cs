using Microsoft.EntityFrameworkCore;
using Model;
using Persistences;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IEmpleadosservices
    { 
        IEnumerable<Empleados> GetAll();
        Empleados Get(int id);
        bool Add(Empleados model);
        bool Update(Empleados model);
        bool Delete(int id);
    }
    public class Empleadosservices : IEmpleadosservices

    {
        private readonly FarmaciaDbContex _FarmaciaDbContex;
        public Empleadosservices(
            FarmaciaDbContex farmaciaDbContex
             )
        {
            _FarmaciaDbContex = farmaciaDbContex;

        }
        public IEnumerable<Empleados> GetAll()
        {
            var result = new List<Empleados>();
            try
            {
                result = _FarmaciaDbContex.Empleados.ToList();
            }
            catch (Exception)
            {


            }

            return result;
        }
        public Empleados Get(int id)
        {
            var result = new Empleados();
            try
            {
                result = _FarmaciaDbContex.Empleados.Single(x => x.Id == id);
            }
            catch (Exception)
            {


            }

            return result;
        }
        public bool Add(Empleados model)
        {
            try
            {
                _FarmaciaDbContex.Add(model);
                _FarmaciaDbContex.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }
        public bool Update(Empleados model)
        {
            try
            {
                var originalModel = _FarmaciaDbContex.Empleados.Single(x =>
                 x.Id == model.Id
                );

                originalModel.Nombre = model.Nombre;
                originalModel.Telefono = model.Telefono;


                _FarmaciaDbContex.Update(model);
                _FarmaciaDbContex.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                _FarmaciaDbContex.Entry(new Empleados { Id = id }).State = EntityState.Deleted; ;
                _FarmaciaDbContex.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

    }
}
