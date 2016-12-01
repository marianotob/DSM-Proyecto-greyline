
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Entrega1GenNHibernate.Exceptions;
using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CAD.GrayLine;


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Libro_denunciar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class LibroCEN
{
public void Denunciar (int idlibro)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Libro_denunciar) ENABLED START*/

        try
        {
                // capturamos el usuario baneado
                LibroEN libroEN = _ILibroCAD.ReadOIDDefault ((int)idlibro);
                /* Como comprobamos que el que realiza la accion es el administrador??*/
                if (libroEN.Baneado == false) {
                        libroEN.Num_denuncias++;
                        if (libroEN.Num_denuncias >= 4) {
                                System.Console.WriteLine ("NumDenuncias: " + libroEN.Num_denuncias);
                                libroEN.Baneado = true;
                                libroEN.Publicado = false;
                                
                            /* Como se deben guardar los daots?*/
                        }
                }
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }



        // throw new NotImplementedException ("Method Denunciar() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
