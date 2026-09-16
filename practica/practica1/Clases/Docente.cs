public class Docente
{
    private string especialidad;
    private string tipoContrato;
    private double sueldo;

    public Docente( string especialidad, string tipoContrato, double sueldo )
    {
        this.especialidad = especialidad;
        this.tipoContrato = tipoContrato;
        this.sueldo = sueldo;

    }
    public string getEspecialidad()
    {
        return this.especialidad;
    }

    public void setEspecialidad(string especialidad)
    {
        this.especialidad = especialidad;
    }

    public string getTipoContrato()
    {
        return this.tipoContrato;
    }

    public void setTipoContrato(string tipoContrato)
    {
        this.tipoContrato = tipoContrato;
    }

    public double getSueldo()
    {
        return this.sueldo;
    }

    public void setSueldo(double sueldo)
    {
        this.sueldo = sueldo;
    }


}