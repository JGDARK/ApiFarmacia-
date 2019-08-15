using Microsoft.EntityFrameworkCore;
using Model;
using Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IProveedorservice
    {
        IEnumerable<Proveedor> GetAll();
        Proveedor Get(int id);
        bool Add(Proveedor model);
        bool Update(Proveedor model);
        bool Delete(int id);
    }
    public class Proveedorservice : IProveedorservice

    {
        private readonly FarmaciaDbContex _FarmaciaDbContex;
        public Proveedorservice(
            FarmaciaDbContex farmaciaDbContex
             )
        {
            _FarmaciaDbContex = farmaciaDbContex;

        }
        public IEnumerable<Proveedor> GetAll()
        {
            var result = new List<Proveedor>();
            try
            {
                result = _FarmaciaDbContex.Proveedor.ToList();
            }
            catch (Exception)
            {


            }

            return result;
        }
        public Proveedor Get(int id)
        {
            var result = new Proveedor();
            try
            {
                result = _FarmaciaDbContex.Proveedor.Single(x => x.Id == id);
            }
            catch (Exception)
            {


            }

            return result;
        }
        public bool Add(Proveedor model)
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
        public bool Update(Proveedor model)
        {
            try
            {
                var originalModel = _FarmaciaDbContex.Proveedor.Single(x =>
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
                _FarmaciaDbContex.Entry(new Proveedor { Id = id }).State = EntityState.Deleted; ;
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
