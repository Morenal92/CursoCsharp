using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// aca declaro la libreria que necesito
using System.Data.SqlClient;

namespace winform_app
{
    class DiscoNegocio
    {
        //Creo los metodos de acceso a datos 
        // Voy a hacer un metodo que lea registros de la base de datos.
        // Este metodo me va a devolver varios discos que los puedo agrupar en una lista:

        public List<Disco> listar()

        {
            List<Disco> lista = new List<Disco>();

            //TENGO QUE AHORA HACER LAS CONFIGURACIONES CON LA BASE DE DATOS:
            //PRIMERO HAGO UN MANEJO DE EXCEPCIONES :
            // declaro un objeto para conectarme:
            SqlConnection conexion = new SqlConnection();
            //  luego una vez creado el objeto tengo que realizar acciones: Para eso creo un objeto:
            SqlCommand comando = new SqlCommand();
            // luego obtengo un set de datos que los voy a albergar aca:
            SqlDataReader lector;
            try
            { // aca voy a poner todo lo que pueda fallar...
                // necesito declarar algunos objetos para conectarme a la base de datos
                // primero debo declarar la libreria (al comienzo del codigo bien arriba)

                // una vez creado los objetos (mas arriba) los tengo que configurar
                conexion.ConnectionString = "server=LAPTOP-C77TFLVM\\SQLEXPRESS01; database = DISCOS_DB; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Titulo , Artista from  Discos";
                comando.Connection = conexion;

                conexion.Open();
                // hago una lectura: creo un objeto SQL
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Numero = (int)lector["Numero"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.Artista = (string)lector["Artista"];

                    lista.Add(aux);
                }
                conexion.Close();



                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }

           

        }

        



    }
}
