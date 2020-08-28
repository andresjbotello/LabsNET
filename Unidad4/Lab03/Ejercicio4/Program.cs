using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creo un objeto DataTable llamado Empresas
            DataTable dtEmpresas = new DataTable("Empresas");
            //Al objeto DataTable le agrego dos datacolumns del tipo string
            dtEmpresas.Columns.Add("CustomerID", typeof(string));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));

            /*
            //Creamos un objeto SQLConnection
            SqlConnection myconn = new SqlConnection();
            //Indicamos el Connection String que utilizara
            myconn.ConnectionString = "Server=localhost\\SQLEXPRESS;Database=Northwind; Integrated Security = true;";

            //Creo un objeto SqlCommand
            SqlCommand mycomando = new SqlCommand();
            mycomando.CommandText = "SELECT CustomerID, CompanyName FROM Customers";
            //Le indico el objeto connection que utilizara
            mycomando.Connection = myconn;

            SqlDataAdapter myadap = new SqlDataAdapter("SELECT CustomerID, CompanyName FROM Customers", myconn);

            myconn.Open();
            SqlDataReader mydr = mycomando.ExecuteReader();
            dtEmpresas.Load(mydr);
            myconn.Close();
            */

            //Creamos un objeto SQLConnection
            SqlConnection myconn = new SqlConnection();
            //Indicamos el Connection String que utilizara
            myconn.ConnectionString = "Server=localhost\\SQLEXPRESS;Database=Northwind; Integrated Security = true;";
            SqlDataAdapter myadap = new SqlDataAdapter("SELECT CustomerID, CompanyName FROM Customers", myconn);

            myconn.Open();
            myadap.Fill(dtEmpresas);
            myconn.Close();

            Console.WriteLine("Listado de empresas: ");
            foreach (DataRow rowEmpresa in dtEmpresas.Rows)
            {
                string idempresa = rowEmpresa["CustomerID"].ToString();
                string nombreempresa = rowEmpresa["CompanyName"].ToString();
                Console.WriteLine(idempresa + "-" + nombreempresa);
            }

            //Primero indico el CustomerID que deseo modificar
            Console.Write("Escriba el CustomerID que desea modificar: ");
            string custid = Console.ReadLine();
            DataRow[] rwempresas = dtEmpresas.Select("CustomerID = '" + custid + "'");
            if (rwempresas.Length != 1) //si no encuentro nada entonces salgo
            {
                Console.WriteLine("CustomerID no encontrado");
                Console.ReadLine();
                return;
            }

            //Me traigo el primer datarow de la coleccion 
            DataRow rowMiEmpresa = rwempresas[0];
            string nombreactual = rowMiEmpresa["CompanyName"].ToString();
            //Muestro en consola el nombre del customer id encontrado
            Console.WriteLine("Nombre actual de la empresa: " + nombreactual);
            //Solicito que escriba un nuevo nombre 
            Console.Write("Escriba el nuevo nombre: ");
            string nuevonombre = Console.ReadLine();
            //Llamo al metodo .BeginEdit del datarow para iniciar los cambios
            rowMiEmpresa.BeginEdit();
            //modifico el valor del campo CompanyName
            rowMiEmpresa["CompanyName"] = nuevonombre;
            //Finalizo la edicion llamando al metodo .EndEdit
            rowMiEmpresa.EndEdit();


            SqlCommand updcommand = new SqlCommand();
            updcommand.Connection = myconn;
            updcommand.CommandText = "UPDATE Customers SET CompanyName = @CompanyName WHERE CustomerID = @CustomerID";
            updcommand.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 50, "CompanyName");
            updcommand.Parameters.Add("@CustomerID", SqlDbType.NVarChar, 5, "CustomerID");

            myadap.UpdateCommand = updcommand;
            myadap.Update(dtEmpresas);


            Console.ReadLine();
        }
    }
}
