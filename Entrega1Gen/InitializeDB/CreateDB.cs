
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CEN.GrayLine;
using Entrega1GenNHibernate.CAD.GrayLine;

// añado referencia a CP
using Entrega1GenNHibernate.CP.GrayLine;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes

                // creamos las entidades, las Cad y los CEN para realizar operaciones
                IUsuarioCAD _IUsuarioCAD = new UsuarioCAD ();
                


                #region Usuario/administrador

                UsuarioEN usuario1EN, usuario2adminEN = new UsuarioEN ();
                UsuarioCEN usuarioCEN = new UsuarioCEN (_IUsuarioCAD);

                // Usuario ADMINISTRADOR
                IAdministradorCAD _IAdministradorCAD = new AdministradorCAD ();
                AdministradorEN administradorEN = new AdministradorEN ();
                AdministradorCEN administradorCEN = new AdministradorCEN (_IAdministradorCAD);


                // Inicializamos los atributos de las clases
                //Usuario1
                usuario1EN = new UsuarioEN ();
                usuario1EN.Email = "11111111G";
                usuario1EN.Nombre = "Cliente1Nombre";
                usuario1EN.Edad = 18;
                usuario1EN.Fecha_alta = DateTime.Today;
                usuario1EN.Foto = "esta es la foto";
                usuario1EN.Bibliografia = "Soy el primer usuario de esta web y parece que puede molar";
                usuario1EN.Baneado = false;
                usuario1EN.Contrasenya = "12345";

                //Usuario2
                usuario2adminEN = new UsuarioEN ();
                usuario2adminEN.Email = "hasnfsi125";
                usuario2adminEN.Nombre = "Cliente2Nombre";
                usuario2adminEN.Edad = 18;
                usuario2adminEN.Fecha_alta = DateTime.Today;
                usuario2adminEN.Foto = "esta es la foto";
                usuario2adminEN.Bibliografia = "Soy el Admin de esta web y parece que puede molar";
                usuario2adminEN.Baneado = false;
                usuario2adminEN.Contrasenya = "1234";

                // registro de usuarios
                usuarioCEN.Registrarse (usuario1EN.Nombre, usuario1EN.Contrasenya, usuario1EN.Email, usuario1EN.Edad, usuario1EN.Fecha_alta, usuario1EN.Foto, usuario1EN.Bibliografia, usuario1EN.Baneado);
                // administrador
                administradorCEN.New_ (usuario2adminEN.Nombre, usuario2adminEN.Contrasenya, usuario2adminEN.Email, usuario2adminEN.Edad, usuario2adminEN.Fecha_alta, usuario2adminEN.Foto, usuario2adminEN.Bibliografia, usuario2adminEN.Baneado);
                #endregion

                #region Categoria
                // categorias

                ICategoriaCAD _ICategoriaCAD = new CategoriaCAD ();
                CategoriaEN categoria_1EN = new CategoriaEN ();
                CategoriaEN categoria_2EN = new CategoriaEN ();
                CategoriaEN categoria_3EN = new CategoriaEN ();
                CategoriaEN categoria_4EN = new CategoriaEN ();
                CategoriaEN categoria_5EN = new CategoriaEN ();


                CategoriaCEN categoriaCEN = new CategoriaCEN (_ICategoriaCAD);

                categoria_1EN.Nombre_categoria = Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.aventura;
                var cat1 = categoriaCEN.New_ (categoria_1EN.Nombre_categoria);
                categoria_2EN.Nombre_categoria = Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.fantasia;
                var cat2 = categoriaCEN.New_ (categoria_2EN.Nombre_categoria);
                categoria_3EN.Nombre_categoria = Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.misterio;
                var cat3 = categoriaCEN.New_ (categoria_3EN.Nombre_categoria);
                categoria_4EN.Nombre_categoria = Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.romance;
                var cat4 = categoriaCEN.New_ (categoria_4EN.Nombre_categoria);
                categoria_5EN.Nombre_categoria = Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.terror;
                var cat5 = categoriaCEN.New_ (categoria_5EN.Nombre_categoria);

                System.Collections.Generic.List<int> listaCategorias = new List<int>();
                // listaCategorias.Add (cat1);
                // listaCategorias.Add (cat3);

                #endregion

                #region Libro
                // Libros
                /* Creamos los libros y uno de ellos de pago */
                ILibroCAD _ILibroCAD = new LibroCAD();
                IPagoCAD _IPagoCAD = new PagoCAD();
                IGratuitoCAD _IGratuitoCAD = new GratuitoCAD();
                GratuitoEN libro1EN = new GratuitoEN ();
                GratuitoEN libro2EN = new GratuitoEN ();
                PagoEN libro3EN = new PagoEN ();

                GratuitoCEN gratuitoCEN = new GratuitoCEN (_IGratuitoCAD);
                PagoCEN PagoCEN = new PagoCEN (_IPagoCAD);

                LibroCEN libroCEN = new LibroCEN ();

                //Libro 1 ----PUBLICADO
                // libro1EN = new LibroEN();
                libro1EN.Titulo = "El Quijote";
                libro1EN.Portada = @"http://imagenesdeamorlindas.com/wp-content/uploads/2013/10/imagenes-lindas-de-amor.jpg";
                libro1EN.Descripcion = "Novela de Cervantes";
                libro1EN.Fecha = DateTime.Today;
                libro1EN.Publicado = true;
                libro1EN.Baneado = false;
                libro1EN.Num_denuncias = 0;

                /*Libro 2*/
                // libro2EN = new LibroEN();
                libro2EN.Titulo = "El Castigo";
                libro2EN.Portada = @"http://imagenesdeamorlindas.com/wp-content/uploads/2013/10/imagenes-lindas-de-amor.jpg";
                libro2EN.Descripcion = "Novela de Pedrito";
                libro2EN.Fecha = DateTime.Today;
                libro2EN.Publicado = true;
                libro2EN.Baneado = false;
                libro2EN.Num_denuncias = 0;

                //Libro 3 ---- De Pago
                // libro3EN = new PagoEN();
                libro3EN.Titulo = "Libro de Pago";
                libro3EN.Portada = @"http://imagenesdeamorlindas.com/wp-content/uploads/2013/10/imagenes-lindas-de-amor.jpg";
                libro3EN.Descripcion = "Novela de Cervantes de Pago";
                libro3EN.Fecha = DateTime.Today;
                libro3EN.Publicado = true;
                libro3EN.Baneado = false;
                libro3EN.Num_denuncias = 0;
                libro3EN.Precio = 12;
                libro3EN.Pagado = false;

                // lista de usuarios
                // creamos listas de usuarios y categorias para crear los libros
                System.Collections.Generic.List<String> listaUsuarios = new List<string>();
                listaUsuarios.Add (usuario1EN.Email);

                /* Se crean dos libros gratuitos y uno de pago
                 * Se guardan sus OIDS para inicializar la bbdd */
                int idLibro1 = gratuitoCEN.New_ (libro1EN.Titulo, libro1EN.Portada, libro1EN.Descripcion, libro1EN.Fecha, libro1EN.Publicado, listaUsuarios, listaCategorias, libro1EN.Baneado, libro1EN.Num_denuncias);
                int idLibro2 = gratuitoCEN.New_ (libro2EN.Titulo, libro2EN.Portada, libro2EN.Descripcion, libro2EN.Fecha, libro2EN.Publicado, listaUsuarios, listaCategorias, libro2EN.Baneado, libro2EN.Num_denuncias);
                int idLibro3 = PagoCEN.New_ (libro3EN.Titulo, libro3EN.Portada, libro3EN.Descripcion, libro3EN.Fecha, libro3EN.Publicado, listaUsuarios, listaCategorias, libro3EN.Baneado, libro3EN.Num_denuncias, 9, false);
                #endregion


                /* Se crean 4 caputulos, los dos primeros para un libro gratuito
                 * y los dos segundo para un libro de pago */
                #region Capitulo
                // Composicion
                CapituloEN capituloEN = new CapituloEN ();
                CapituloCEN capituloCEN = new CapituloCEN ();

                //Capitulo  1
                capituloEN.Id_capitulo = 1;
                capituloEN.Nombre = "Capitulo 1 - La amenaza Fantasma";
                capituloEN.Numero = 1;
                capituloEN.Contenido = "Este capitulo es el primero del libro 1";
                // capituloEN.Libro = libro1EN;
                // capituloEN.Usuario = usuario1EN;
                capituloEN.Editando = false;

                capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro1, true);


                //capitulo 2
                capituloEN.Id_capitulo = 2;
                capituloEN.Nombre = "Capitulo 2 - Ya vendr�n tiempos mejores";
                capituloEN.Numero = 2;
                capituloEN.Contenido = "Este segundo capitulo es del libro 1";
                // capituloEN.Libro = libro1EN;
                // capituloEN.Usuario = usuario1EN;
                capituloEN.Editando = false;

                capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro1, true);
                

                //capitulo 3
                capituloEN.Id_capitulo = 3;
                capituloEN.Nombre = "Capitulo3 - Puta Bida";
                capituloEN.Numero = 3;
                capituloEN.Contenido = "Este capitulo 3 es del libro pago";
                // capituloEN.Libro = libro3EN;
                // capituloEN.Usuario = usuario1EN;
                capituloEN.Editando = true;
                capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro3, true);

                //capitulo 4
                capituloEN = new CapituloEN ();
                capituloEN.Id_capitulo = 4;
                capituloEN.Nombre = "Capitulo 4 - ararar";
                capituloEN.Numero = 3;
                capituloEN.Contenido = "Este es el segundo capitulo del libro de pago";
                // capituloEN.Libro = libro3EN;
                // capituloEN.Usuario = usuario1EN;
                capituloEN.Editando = true;
                capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro3, true);

                #endregion

                #region Comentario

                IComentarioCAD _IComentarioCAD = new ComentarioCAD ();
                ComentarioEN comentarioEN = new ComentarioEN ();
                ComentarioCEN comentarioCEN = new ComentarioCEN (_IComentarioCAD);


                /* Inicializamos datos de comentarios */
                // Comentario 1
                comentarioEN.Texto_comentario = "Mola mucho este libro!!!";
                comentarioEN.Baneado = true;
                var comentario1 = comentarioCEN.New_ (comentarioEN.Texto_comentario, idLibro1, comentarioEN.Baneado);

                // Comentario 2
                comentarioEN.Texto_comentario = "Mola mucho este libro otra vez!!!";
                comentarioEN.Baneado = true;

                var comentario2 = comentarioCEN.New_ (comentarioEN.Texto_comentario, idLibro1, comentarioEN.Baneado);

                #endregion

                #region Pruebas

                // llamadas paa comprobar bbdd y metodos custom
                var r = usuarioCEN.ReadAll (0, 10);
                var l = gratuitoCEN.ReadAll (0, 10);
                var mostrarLibros = libroCEN.VerLibreria (0, 10);
                var c = capituloCEN.ReadAll (0, 10);
               
                System.Console.WriteLine (usuarioCEN.IniciarSesion (usuario2adminEN.Email, usuario2adminEN.Contrasenya));
                var prueba_filtrolibro = libroCEN.BuscarLibro ("El Quijote");

                // comprobar capitulos de libro
                CapituloCP capituloCP = new CapituloCP ();

                /* Pruebas para ver los comentarios publicados y no baneados */
                IList<ComentarioEN> listaComentarios = comentarioCEN.VerComentarios (idLibro1);
                // Para visualizar el contenido de cada comentario
                if (listaComentarios != null) {
                        foreach (ComentarioEN comentarios in listaComentarios) {
                                System.Console.WriteLine (comentarios.Texto_comentario.ToString ());
                        }
                }

                /* Creamos una lista de capitulos del libro del id pasado por parametro */
                IList<CapituloEN> listCapitulos = capituloCP.LeerCapitulo (idLibro1);

                // Para visualizar el contenido de cada capitulo
                if (listCapitulos != null) {
                        foreach (CapituloEN capitulo in listCapitulos) {
                                // System.Console.WriteLine(capitulo.Contenido.ToString());
                        }
                }

                /* Creamos una lista de categorias del libro del id pasado por parametro */
                IList<CategoriaEN> listCategorias = categoriaCEN.VerCategorias (0, 10);

                // Para visualizar el contenido de cada capitulo
                if (listCategorias != null) {
                        foreach (CategoriaEN categorias in listCategorias) {
                                System.Console.WriteLine (categorias.Nombre_categoria.ToString ());
                        }
                }



                /* Creamos una lista de Libros paar ver su categoria pasada por parametro */

                 IList<LibroEN> listLibros = libroCEN.BuscarCategoria (0,10);
                /* cuando hacemos la consulta, comparamos un entero con una lista ya que en el
                  new libro recibe las categorias como listas 


                // Para visualizar lis libros creados
                 if (listLibros != null) {
                       foreach (LibroEN libros in listLibros) {
                              System.Console.WriteLine (libros.Titulo.ToString ());
                        }
                 }

            */
                #endregion

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
