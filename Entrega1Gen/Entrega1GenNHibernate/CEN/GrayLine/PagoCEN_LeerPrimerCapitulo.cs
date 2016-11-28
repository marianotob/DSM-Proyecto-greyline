
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Pago_leerPrimerCapitulo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class PagoCEN
{
public void LeerPrimerCapitulo (int p_oid)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Pago_leerPrimerCapitulo) ENABLED START*/

        // Write here your custom code...

        // INCOMPLETO

        PagoEN pagoEn = new PagoEN ();
        IPagoCAD _IPagoCAD = new PagoCAD ();

        PagoCEN pagoCEN = new PagoCEN (_IPagoCAD);

        // comprobamos el id pasado con el del libro y creamo sla lista de capituloa
        if (p_oid == pagoEn.Id_libro) {
                // System.Console.WriteLine (pagoEn.Capitulo.ToString ());
                if (pagoEn.Capitulo.Count != 0) {
                }
        }



        // throw new NotImplementedException ("Method LeerPrimerCapitulo() not yet implemented.");



        /*PROTECTED REGION END*/
}
}
}
