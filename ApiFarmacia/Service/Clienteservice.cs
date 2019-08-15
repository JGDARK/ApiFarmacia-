using Microsoft.EntityFrameworkCore;
using Model;
using Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IClienteservice
    {
        IEnumerable<Clientes> GetAll();
        Clientes Get(int id);
        bool Add(Clientes model);
        bool Update(Clientes model);
        bool Delete(int id);
    }
    public class Clienteservice : IClienteservice

    {
        private readonly FarmaciaDbContex _FarmaciaDbContex;
        public Clienteservice(
            FarmaciaDbContex farmaciaDbContex
             )
        {
            _FarmaciaDbContex = farmaciaDbContex;

        }
        public IEnumerable<Clientes> GetAll()
        {
            var result = new List<Clientes>();
            try
            {
                result = _FarmaciaDbContex.Clientes.ToList();
            }
            catch (Exception)
            {


            }

            return result;
        }
        public Clientes Get(int id)
        {
            var result = new Clientes();
            try
            {
                result = _FarmaciaDbContex.Clientes.Single(x => x.Id == id);
            }
            catch (Exception)
            {


            }

            return result;
        }
        public bool Add(Clientes model)
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
        public bool Update(Clientes model)
        {
            try
            {
                var originalModel = _FarmaciaDbContex.Clientes.Single(x =>
                 x.Id == model.Id
                );

                originalModel.Nombre = model.Nombre;
                originalModel.Numero = model.Numero;


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
                _FarmaciaDbContex.Entry(new Clientes { Id = id }).State = EntityState.Deleted; ;
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
