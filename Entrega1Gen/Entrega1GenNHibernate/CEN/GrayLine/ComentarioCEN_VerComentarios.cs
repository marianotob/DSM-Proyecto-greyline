
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Comentario_verComentarios) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class ComentarioCEN
{
public System.Collections.Generic.IList<ComentarioEN> VerComentarios (int first, int size)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Comentario_verComentarios_customized) START*/

        System.Collections.Generic.IList<ComentarioEN> list = null;

        list = _IComentarioCAD.VerComentarios (first, size);

        return list;
        /*PROTECTED REGION END*/
}
}
}