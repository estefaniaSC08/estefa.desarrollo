using Microsoft.Data.SqlClient;
using ProductoADO.Data;
using ProductoADO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ProductoXML.Repositories;

public class ProductoRepository
{
    private readonly string _rutaArchivo;


    public ProductoRepository()
    {
        _rutaArchivo = Path.Combine(
            AppContext.BaseDirectory,
            "Producto.xml"
        );
    }

    // Cargar los datos desde el archivo XML
    private DataSet CargarDatos()
    {
        DataSet dataSet = new DataSet("RegistroProductos");

        if (File.Exists(_rutaArchivo))
        {
            dataSet.ReadXml(
                _rutaArchivo,
                XmlReadMode.ReadSchema
            );
        }

        if (!dataSet.Tables.Contains("Producto"))
        {
            DataTable tabla = new DataTable("Producto");

            DataColumn columnaId = tabla.Columns.Add(
                "IdProducto",
                typeof(int)
            );

            columnaId.AllowDBNull = false;
            columnaId.Unique = true;

            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Descripcion", typeof(string));
            tabla.Columns.Add("FechaVencimiento", typeof(DateTime));

            tabla.PrimaryKey = new[] { columnaId };

            dataSet.Tables.Add(tabla);
        }

        return dataSet;
    }

    // Obtener la tabla Producto
    private DataTable ObtenerTabla(DataSet dataSet)
    {
        return dataSet.Tables["Producto"]
            ?? throw new InvalidOperationException(
                "No existe la tabla Producto."
            );
    }

    // Guardar los datos en el archivo XML
    private void GuardarDatos(DataSet dataSet)
    {
        dataSet.WriteXml(
            _rutaArchivo,
            XmlWriteMode.WriteSchema
        );
    }

    // CREATE: registrar una Producto
    public void Crear(Producto Producto)
    {
        DataSet dataSet = CargarDatos();
        DataTable tabla = ObtenerTabla(dataSet);

        int nuevoId = tabla.Rows.Count == 0
            ? 1
            : tabla.AsEnumerable()
                .Max(fila => fila.Field<int>("IdProducto")) + 1;

        DataRow fila = tabla.NewRow();

        fila["IdProducto"] = nuevoId;
        fila["Nombre"] = Producto.GetNombre();
        fila["Descripcion"] = Producto.GetDescripcion();
        fila["FechaVencimiento"] = Producto.GetFechaVencimiento();

        tabla.Rows.Add(fila);

        GuardarDatos(dataSet);

        Producto.SetIdProducto(nuevoId);
    }

    // READ: consultar todas las Productos
    public List<Producto> ObtenerTodos()
    {
        DataSet dataSet = CargarDatos();
        DataTable tabla = ObtenerTabla(dataSet);

        List<Producto> Productos = new List<Producto>();

        foreach (DataRow fila in tabla.Rows)
        {
            Productos.Add(new Producto
            {
                IdProducto = fila.Field<int>("IdProducto"),
                Nombre = fila.Field<string>("Nombre") ?? "",
                Descripcion = fila.Field<string>("Descripcion") ?? "",
                FechaVencimiento =
                    fila.Field<DateTime>("FechaVencimiento")
            });
        }

        return Productos;
    }

    // READ: consultar por IdProducto
    public Producto? ObtenerPorId(int idProducto)
    {
        DataSet dataSet = CargarDatos();
        DataTable tabla = ObtenerTabla(dataSet);

        DataRow? fila = tabla.Rows.Find(idProducto);

        if (fila == null)
        {
            return null;
        }

        return new Producto
        {
            IdProducto = fila.Field<int>("IdProducto"),
            Nombre = fila.Field<string>("Nombre") ?? "",
            Descripcion = fila.Field<string>("Descripcion") ?? "",
            FechaVencimiento =
                fila.Field<DateTime>("FechaVencimiento")
        };
    }

    // UPDATE: actualizar una Producto
    public bool Actualizar(Producto Producto)
    {
        DataSet dataSet = CargarDatos();
        DataTable tabla = ObtenerTabla(dataSet);

        DataRow? fila = tabla.Rows.Find(Producto.IdProducto);

        if (fila == null)
        {
            return false;
        }

        fila["Nombre"] = Producto.GetNombre();
        fila["Descripcion"] = Producto.GetDescripcion();
        fila["FechaVencimiento"] = Producto.GetFechaVencimiento();

        GuardarDatos(dataSet);

        return true;
    }

    // DELETE: eliminar una Producto
    public bool Eliminar(int idProducto)
    {
        DataSet dataSet = CargarDatos();
        DataTable tabla = ObtenerTabla(dataSet);

        DataRow? fila = tabla.Rows.Find(idProducto);

        if (fila == null)
        {
            return false;
        }

        tabla.Rows.Remove(fila);

        GuardarDatos(dataSet);

        return true;
    }

}