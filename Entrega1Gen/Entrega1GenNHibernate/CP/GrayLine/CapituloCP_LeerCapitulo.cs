
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CAD.GrayLine;
using Entrega1GenNHibernate.CEN.GrayLine;

/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CP.GrayLine_Capitulo_leerCapitulo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CP.GrayLine
{
public partial class CapituloCP : BasicCP
{
public System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> LeerCapitulo (int ? id_libro)
{

    
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CP.GrayLine_Capitulo_leerCapitulo) ENABLED START*/

    ICapituloCAD capituloCAD = null;
    CapituloCEN capituloCEN = null;

    System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> result = null;

    try
    {
        
        SessionInitializeTransaction();
        capituloCAD = new CapituloCAD(session);
        capituloCEN = new CapituloCEN(capituloCAD);

        LibroCAD libroCAD = new LibroCAD(session);
        LibroEN libroEN = libroCAD.ReadOIDDefault((int)id_libro);

        System.Console.WriteLine("Capitulo: "+libroEN.Capitulo.ToString());
        System.Console.WriteLine("Tipo de libro: " + libroEN.GetType().ToString());
       
        /*Estas condiciones no funcionan- Debemos buscar una solucion */
                // libroEN.GetType().Name.Equals("GratuitoEN")
        // libroEN.GetType()==typeof ("GratuitoEN")
        if (1==1)
        {
            
            // guardamos todos los capitulos
            result = capituloCAD.ReadAll(0, -1); // -1 para leerlos todos
        }
        else
        {
            // como es de pago solo devuelvo el primer capitulo
            result.Add(capituloCAD.ReadAll(0, 1)[0]);
        }

        SessionCommit();
    }
    catch (Exception ex)
    {
        SessionRollBack();
        // System.Console.WriteLine(ex.ToString());
        throw ex;
    }
    finally
    {
        SessionClose();
    }
    return result;


        /*PROTECTED REGION END*/
}
}
}
