
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using Entrega1GenNHibernate.Exceptions;
using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CAD.GrayLine;
using Entrega1GenNHibernate.CEN.GrayLine;


namespace Entrega1GenNHibernate.CP.GrayLine
{
public partial class PagoCP : BasicCP
{
public PagoCP() : base ()
{
}

public PagoCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
