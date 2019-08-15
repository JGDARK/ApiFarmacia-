using Model;
using Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IMedicamentoservice
    {


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
                _FarmaciaDbContex.Update(model);
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
