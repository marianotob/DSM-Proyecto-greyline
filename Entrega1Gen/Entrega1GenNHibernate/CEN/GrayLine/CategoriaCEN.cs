

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Entrega1GenNHibernate.Exceptions;

using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CAD.GrayLine;


namespace Entrega1GenNHibernate.CEN.GrayLine
{
/*
 *      Definition of the class CategoriaCEN
 *
 */
public partial class CategoriaCEN
{
private ICategoriaCAD _ICategoriaCAD;

public CategoriaCEN()
{
        this._ICategoriaCAD = new CategoriaCAD ();
}

public CategoriaCEN(ICategoriaCAD _ICategoriaCAD)
{
        this._ICategoriaCAD = _ICategoriaCAD;
}

public ICategoriaCAD get_ICategoriaCAD ()
{
        return this._ICategoriaCAD;
}

public int New_ (Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum p_nombre_categoria)
{
        CategoriaEN categoriaEN = null;
        int oid;

        //Initialized CategoriaEN
        categoriaEN = new CategoriaEN ();
        categoriaEN.Nombre_categoria = p_nombre_categoria;

        //Call to CategoriaCAD

        oid = _ICategoriaCAD.New_ (categoriaEN);
        return oid;
}

public void Destroy (int id_categoria
                     )
{
        _ICategoriaCAD.Destroy (id_categoria);
}
}
}
