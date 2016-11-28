
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
                ILibroCAD _ILibroCAD = new LibroCAD ();
                ICategoriaCAD _ICategoriCAD = new CategoriaCAD ();
                IPagoCAD _IPagoCAD = new PagoCAD ();

                CategoriaEN categoriaEN = new CategoriaEN ();
                CategoriaCEN categoriaCEN = new CategoriaCEN (_ICategoriCAD);

                // LibroEN libro1EN, libro2EN, libro3EN = new LibroEN ();
                // LibroCEN libroCEN = new LibroCEN (_ILibroCAD);



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

                categoria_1EN.Nombre_categoria = Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.aventura;
                categoriaCEN.New_ (categoria_1EN.Nombre_categoria);
                categoria_2EN.Nombre_categoria = Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.fantasia;
                categoriaCEN.New_ (categoria_2EN.Nombre_categoria);
                categoria_3EN.Nombre_categoria = Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.misterio;
                categoriaCEN.New_ (categoria_3EN.Nombre_categoria);
                categoria_4EN.Nombre_categoria = Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.romance;
                categoriaCEN.New_ (categoria_4EN.Nombre_categoria);
                categoria_5EN.Nombre_categoria = Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.terror;
                categoriaCEN.New_ (categoria_5EN.Nombre_categoria);


                #endregion

                #region Libro
                // Libros
                /* Creamos los libros y uno de ellos de pago */
                LibroEN libro1EN = new LibroEN();
                LibroEN libro2EN = new LibroEN();
                PagoEN libro3EN = new PagoEN();

                LibroCEN libroCEN = new LibroCEN(_ILibroCAD);

                //Libro 1 ----PUBLICADO
                libro1EN = new LibroEN();
                libro1EN.Titulo = "El Quijote";
                libro1EN.Portada = @"http://imagenesdeamorlindas.com/wp-content/uploads/2013/10/imagenes-lindas-de-amor.jpg";
                libro1EN.Descripcion = "Novela de Cervantes";
                libro1EN.Fecha = DateTime.Today;
                libro1EN.Publicado = true;
                libro1EN.Baneado = true;
                libro1EN.Num_denuncias = 0;

                /*Libro 2*/
                libro2EN = new LibroEN();
                libro2EN.Titulo = "El Castigo";
                libro2EN.Portada = @"http://imagenesdeamorlindas.com/wp-content/uploads/2013/10/imagenes-lindas-de-amor.jpg";
                libro2EN.Descripcion = "Novela de Pedrito";
                libro2EN.Fecha = DateTime.Today;
                libro2EN.Publicado = true;
                libro2EN.Baneado = false;
                libro2EN.Num_denuncias = 0;

                //Libro 3 ---- De Pago
                libro3EN = new PagoEN();
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
                System.Collections.Generic.List<int> listaCategorias = new List<int>();
                listaUsuarios.Add(usuario1EN.Email);

                int idLibro1 = libroCEN.CrearLibro(libro1EN.Titulo, libro1EN.Portada, libro1EN.Descripcion, libro1EN.Fecha, libro1EN.Publicado, listaUsuarios, listaCategorias, libro1EN.Baneado, libro1EN.Num_denuncias);
                int idLibro2 = libroCEN.CrearLibro(libro2EN.Titulo, libro2EN.Portada, libro2EN.Descripcion, libro2EN.Fecha, libro2EN.Publicado, listaUsuarios, listaCategorias, libro2EN.Baneado, libro2EN.Num_denuncias);
                int idLibro3 = libroCEN.CrearLibro(libro3EN.Titulo, libro3EN.Portada, libro3EN.Descripcion, libro3EN.Fecha, libro3EN.Publicado, listaUsuarios, listaCategorias, libro3EN.Baneado, libro3EN.Num_denuncias);
                #endregion

                #region LibroPago
                //Nuevo libro de Pago
                PagoCEN pagoCEN = new PagoCEN(_IPagoCAD);
                int oidLibroPago = pagoCEN.New_(libro3EN.Titulo, libro3EN.Portada, libro3EN.Descripcion, libro3EN.Fecha, libro3EN.Publicado, listaUsuarios, listaCategorias, libro3EN.Baneado, libro3EN.Num_denuncias, libro3EN.Precio, libro3EN.Pagado);


                #endregion

                #region Capitulo
                // Composicion
                CapituloEN capituloEN = new CapituloEN();
                CapituloCEN capituloCEN = new CapituloCEN();
                /* Al ser una composicion junto con Libro, creamos una lista de capitulos para agregar al libro */
                System.Collections.Generic.List<CapituloEN> capitulo1, capitulo2, capitulo3 = new List<CapituloEN>();


                //Capitulo  1
                capitulo1 = new List<CapituloEN>();
                capituloEN = new CapituloEN();
                capituloEN.Id_capitulo = 1;
                capituloEN.Nombre = "Capitulo 1 - La amenaza Fantasma";
                capituloEN.Numero = 1;
                capituloEN.Contenido = "Este capitulo es el primero del libro 1";
                // capituloEN.Libro = libro1EN;
                capituloEN.Usuario = usuario1EN;
                capituloEN.Editando = false;

                //capitulo1.Add(capituloEN);
                capituloCEN.New_(capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro1, true);


                //capitulo 2
                capitulo2 = new List<CapituloEN>();
                capituloEN = new CapituloEN();
                capituloEN.Id_capitulo = 2;
                capituloEN.Nombre = "Capitulo 2 - Ya vendr�n tiempos mejores";
                capituloEN.Numero = 2;
                capituloEN.Contenido = "Este segundo capitulo es del libro 1";
                //capituloEN.Libro = libro1EN;
                //capituloEN.Usuario = usuario1EN;
                capituloEN.Editando = false;
                capituloCEN.New_(capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro2, true);
                //capitulo2.Add(capituloEN);

                //capitulo 3
                capitulo3 = new List<CapituloEN>();
                capituloEN = new CapituloEN();
                capituloEN.Id_capitulo = 2;
                capituloEN.Nombre = "Capitulo3 - Puta Bida";
                capituloEN.Numero = 3;
                capituloEN.Contenido = "Este capitulo es del libro tercero";
                //capituloEN.Libro = libro3EN;
                //capituloEN.Usuario = usuario1EN;
                capituloEN.Editando = true;
                capituloCEN.New_(capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro3, true);
                // capitulo3.Add(capituloEN);
                #endregion

                #region Comentario

                #endregion

                #region Pruebas

                // llamadas paa comprobar bbdd y metodos custom
                var r = usuarioCEN.ReadAll (0, 10);
                var l = libroCEN.ReadAll (0, 10);
                var mostrarLibros = libroCEN.VerLibreria (0, 10);
                var c = capituloCEN.ReadAll(0,10);
                // System.Console.WriteLine (mostrarLibros);
                // System.Console.WriteLine(usuario2adminEN.Contrasenya);
                // System.Console.WriteLine (usuarioCEN.IniciarSesion (usuario2adminEN.Email, usuario2adminEN.Contrasenya));
                var prueba_filtrolibro = libroCEN.BuscarLibro ("El Quijote");
               
            // comprobar capitulos de libro
            CapituloCP capituloCP = new CapituloCP();
            
             if (idLibro1 > 0)
             {
                    
                 IList<CapituloEN> listCapitulos = capituloCP.LeerCapitulo(idLibro3);

                 
                 if (listCapitulos != null)
                 {
                     // System.Console.WriteLine(listCapitulos);

                     foreach (CapituloEN capitulo in listCapitulos)
                     {
                         System.Console.WriteLine(capitulo.Contenido.ToString());
                     }
                 }
            }
                   
         
                #endregion


            /* Actualizado CapituloCP_LeerLibro --- falla condicion */


                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                
                throw ex;
        }
}
}
}
