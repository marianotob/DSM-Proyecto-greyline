
using System;
using System.Text;
using Entrega1GenNHibernate.CEN.GrayLine;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.Exceptions;


/*
 * Clase Libro:
 *
 */

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial class LibroCAD : BasicCAD, ILibroCAD
{
public LibroCAD() : base ()
{
}

public LibroCAD(ISession sessionAux) : base (sessionAux)
{
}



public LibroEN ReadOIDDefault (int id_libro
                               )
{
        LibroEN libroEN = null;

        try
        {
                SessionInitializeTransaction ();
                libroEN = (LibroEN)session.Get (typeof(LibroEN), id_libro);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return libroEN;
}

public System.Collections.Generic.IList<LibroEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LibroEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LibroEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<LibroEN>();
                        else
                                result = session.CreateCriteria (typeof(LibroEN)).List<LibroEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), libro.Id_libro);

                libroEN.Titulo = libro.Titulo;


                libroEN.Portada = libro.Portada;


                libroEN.Descripcion = libro.Descripcion;


                libroEN.Fecha = libro.Fecha;


                libroEN.Publicado = libro.Publicado;





                libroEN.Baneado = libro.Baneado;




                libroEN.Num_denuncias = libro.Num_denuncias;

                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearLibro (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                if (libro.Usuario != null) {
                        for (int i = 0; i < libro.Usuario.Count; i++) {
                                libro.Usuario [i] = (Entrega1GenNHibernate.EN.GrayLine.UsuarioEN)session.Load (typeof(Entrega1GenNHibernate.EN.GrayLine.UsuarioEN), libro.Usuario [i].Email);
                                libro.Usuario [i].Libro.Add (libro);
                        }
                }
                if (libro.Categoria != null) {
                        for (int i = 0; i < libro.Categoria.Count; i++) {
                                libro.Categoria [i] = (Entrega1GenNHibernate.EN.GrayLine.CategoriaEN)session.Load (typeof(Entrega1GenNHibernate.EN.GrayLine.CategoriaEN), libro.Categoria [i].Id_categoria);
                                libro.Categoria [i].Libro.Add (libro);
                        }
                }

                session.Save (libro);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return libro.Id_libro;
}

public void EliminarLibro (int id_libro
                           )
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), id_libro);
                session.Delete (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void CambiarTitulo (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), libro.Id_libro);
                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void CambiarPortada (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), libro.Id_libro);
                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void CambiarDescripcion (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), libro.Id_libro);
                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<LibroEN> VerLibreria (int first, int size)
{
        System.Collections.Generic.IList<LibroEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LibroEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<LibroEN>();
                else
                        result = session.CreateCriteria (typeof(LibroEN)).List<LibroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: VerLibro
//Con e: LibroEN
public LibroEN VerLibro (int id_libro
                         )
{
        LibroEN libroEN = null;

        try
        {
                SessionInitializeTransaction ();
                libroEN = (LibroEN)session.Get (typeof(LibroEN), id_libro);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return libroEN;
}

public void Publicar (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), libro.Id_libro);
                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<LibroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LibroEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LibroEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<LibroEN>();
                else
                        result = session.CreateCriteria (typeof(LibroEN)).List<LibroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void Denunciar (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), libro.Id_libro);
                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AnyadirCapitulo (int p_Libro_OID, System.Collections.Generic.IList<int> p_capitulo_OIDs)
{
        Entrega1GenNHibernate.EN.GrayLine.LibroEN libroEN = null;
        try
        {
                SessionInitializeTransaction ();
                libroEN = (LibroEN)session.Load (typeof(LibroEN), p_Libro_OID);
                Entrega1GenNHibernate.EN.GrayLine.CapituloEN capituloENAux = null;
                if (libroEN.Capitulo == null) {
                        libroEN.Capitulo = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.CapituloEN>();
                }

                foreach (int item in p_capitulo_OIDs) {
                        capituloENAux = new Entrega1GenNHibernate.EN.GrayLine.CapituloEN ();
                        capituloENAux = (Entrega1GenNHibernate.EN.GrayLine.CapituloEN)session.Load (typeof(Entrega1GenNHibernate.EN.GrayLine.CapituloEN), item);
                        capituloENAux.Libro = libroEN;

                        libroEN.Capitulo.Add (capituloENAux);
                }


                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Valorar (int p_Libro_OID, System.Collections.Generic.IList<int> p_valoracion_OIDs)
{
        Entrega1GenNHibernate.EN.GrayLine.LibroEN libroEN = null;
        try
        {
                SessionInitializeTransaction ();
                libroEN = (LibroEN)session.Load (typeof(LibroEN), p_Libro_OID);
                Entrega1GenNHibernate.EN.GrayLine.ValoracionEN valoracionENAux = null;
                if (libroEN.Valoracion == null) {
                        libroEN.Valoracion = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN>();
                }

                foreach (int item in p_valoracion_OIDs) {
                        valoracionENAux = new Entrega1GenNHibernate.EN.GrayLine.ValoracionEN ();
                        valoracionENAux = (Entrega1GenNHibernate.EN.GrayLine.ValoracionEN)session.Load (typeof(Entrega1GenNHibernate.EN.GrayLine.ValoracionEN), item);
                        valoracionENAux.Libro = libroEN;

                        libroEN.Valoracion.Add (valoracionENAux);
                }


                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Comentar (int p_Libro_OID, System.Collections.Generic.IList<int> p_comentario_OIDs)
{
        Entrega1GenNHibernate.EN.GrayLine.LibroEN libroEN = null;
        try
        {
                SessionInitializeTransaction ();
                libroEN = (LibroEN)session.Load (typeof(LibroEN), p_Libro_OID);
                Entrega1GenNHibernate.EN.GrayLine.ComentarioEN comentarioENAux = null;
                if (libroEN.Comentario == null) {
                        libroEN.Comentario = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN>();
                }

                foreach (int item in p_comentario_OIDs) {
                        comentarioENAux = new Entrega1GenNHibernate.EN.GrayLine.ComentarioEN ();
                        comentarioENAux = (Entrega1GenNHibernate.EN.GrayLine.ComentarioEN)session.Load (typeof(Entrega1GenNHibernate.EN.GrayLine.ComentarioEN), item);
                        comentarioENAux.Libro = libroEN;

                        libroEN.Comentario.Add (comentarioENAux);
                }


                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> BuscarLibro (string nombre)
{
        System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM LibroEN self where FROM LibroEN li WHERE  (li.Titulo= :nombre)";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("LibroENbuscarLibroHQL");
                query.SetParameter ("nombre", nombre);

                result = query.List<Entrega1GenNHibernate.EN.GrayLine.LibroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
