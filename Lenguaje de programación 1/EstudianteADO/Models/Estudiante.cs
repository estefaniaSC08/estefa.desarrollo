using System;
using System.Collections.Generic;
using System.Text;



namespace EstudianteADO.Models
{
    
}

Public class Estudiante
{
    private int idEstudiante;
    private  string nombre;
    private string carrera;
    private DateTime fechaIngreso;
}



public Estudiante(int idEstudiante, string nombre, string carrera, DateTime fechaIngreso)
    {
        this.idEstudiante = idEstudiante;
        this.nombre = nombre;
        this.carrera = carrera;
        this.fechaIngreso = fechaIngreso;

    }

    public int getIdEstudiante()
    {
        return this.idEstudiante;
    }
    public void setIdEstudiante(int idEstudiante)
    {
        this.idEstudiante = idEstudiante;
    }

    public string getNombre()
    {
        return this.nombre;
    }
    public void setNombre(string nombre)
    {
        this.nombre = nombre;
    }

    public string getcarrera()
    {
        return this.carrera;
    }
    public void setcarrera(string carrera)
    {
        this.carrera = carrera;
    }

    public DateTime getfechaIngreso()
    {
        return this.fechaIngreso;
    }
    public void setfechaIngreso(DateTime fechaIngreso)
    {
        this.fechaIngreso = fechaIngreso;
    }