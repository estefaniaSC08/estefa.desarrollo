namespace PersonaADO.Models;

public class Persona
{
    private int idPersona;
    private string nombre;
    private string documento;
    private DateTime fechaNacimiento;

public Persona(int idPersona,string nombre,string documento,DateTime fechaNacimiento)
    {
        this.idPersona = idPersona;
        this.nombre = nombre;
        this.documento = documento;
        this.fechaNacimiento = fechaNacimiento;
        
    }

public int getIdPersona()
    {
        return this.idPersona;
    }
public void setIdPersona()
    {
        this.idPersona = idPersona;
    }

public string getNombre()
    {
        return this.nombre;
    }
public void setNombre()
    {
        this.nombre = nombre;
    }

public string getDocumento()
    {
        return this.documento;
    }
public void setDocumento()
    {
        this.documento = documento;
    }

public DateTime getFechaNacimiento()
    {
        return this.fechaNacimiento;
    }
public void setFechaNacimiento()
    {
        this.fechaNacimiento = fechaNacimiento;
    }









}

