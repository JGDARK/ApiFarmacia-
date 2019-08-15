using Microsoft.EntityFrameworkCore;
using Model;
using Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IMedicamentoservice
    {
        IEnumerable<Medicamentos> GetAll();
        Medicamentos Get(int id);
        bool Add(Medicamentos model);
        bool Update(Medicamentos model);
        bool Delete(int id);
    }
    public class Medicamentoservice : IMedicamentoservice

    {
        private readonly FarmaciaDbContex _FarmaciaDbContex;
        public Medicamentoservice(
            FarmaciaDbContex farmaciaDbContex
             )
        {
            _FarmaciaDbContex = farmaciaDbContex;

        }
        public IEnumerable<Medicamentos> GetAll()
        {
            var result = new List<Medicamentos>();
            try
            {
                result = _FarmaciaDbContex.Medicamentos.ToList();
            }
            catch (Exception)
            {

              
            }

            return result; 
        }
        public Medicamentos Get(int id)
        {
            var result = new Medicamentos();
            try
            {
                result = _FarmaciaDbContex.Medicamentos.Single( x=> x.Id == id);
            }
            catch (Exception)
            {


            }

            return result;
        }
        public bool Add(Medicamentos model) {
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
        public bool Update(Medicamentos model)
        {
            try
            {
                var originalModel =_FarmaciaDbContex.Medicamentos.Single(x => 
                x.Id == model.Id
                );

                originalModel.Nombre = model.Nombre;
                originalModel.precio = model.precio;


                _FarmaciaDbContex.Update(model);
                _FarmaciaDbContex.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }
        public bool Delete (int id)
        {
            try
            {
                _FarmaciaDbContex.Entry(new Medicamentos { Id=id}).State= EntityState.Deleted; ;                
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
