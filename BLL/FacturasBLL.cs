using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL
{
    public class FacturasBLL
    {
        /*public static Facturas facturasReturned = null;
        public static List<Facturas> facturasReturnedList = null;*/


        public static bool Guardar(Facturas facturas)
        {
            using (var context = new Repository<Facturas>())
            {
                try
                {
                    if (Buscar(p => p.FacturaId == facturas.FacturaId) == null)
                    {
                        return context.Guardar(facturas);
                    }
                    else
                    {
                        return context.Modificar(facturas);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static bool Eliminar(Facturas factura)
        {
            using (var context = new DAL.Repository<Facturas>())
            {
                try
                {
                    return context.Eliminar(factura);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


        public static Facturas Buscar(Expression<Func<Facturas, bool>> criterio)
        {
            Facturas retorno = null;

            using (var conec = new Repository<Facturas>())
            {
                try
                {
                    retorno =  conec.Buscar(criterio);

                    if (retorno != null)
                    {
                        retorno.Relacion.Count();
                    }
                }
                catch (Exception)
                {

                    throw;
                }

                return retorno;
            }
        }


        public static List<Facturas> GetList(Expression<Func<Facturas, bool>> criterio)
        {
            using (var conec = new Repository<Facturas>())
            {
                try
                {
                    return conec.GetList(criterio);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        public static List<Facturas> GetListAll()
        {
            using (var conec = new Repository<Facturas>())
            {
                try
                {
                    return conec.GetListAll();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


    }
}
