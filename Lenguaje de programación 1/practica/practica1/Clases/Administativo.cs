public class Administrativo
{

    private string cargo;
    private string departamento;
    private double salario;


    public Administrativo( string cargoRecibido, string departamentoRecibido, double salarioRecibido )
    {
        this.cargo = cargoRecibido;
        this.departamento = departamentoRecibido;
        this.salario = salarioRecibido;
    }

	public string getCargo() {
		return this.cargo;
	}

	public void setCargo(string cargo) {
		this.cargo = cargo;
	}

	public string getDepartamento() {
		return this.departamento;
	}

	public void setDepartamento(string departamento) {
		this.departamento = departamento;
	}

	public double getSalario() {
		return this.salario;
	}

	public void setSalario(double salario) {
		this.salario = salario;
	}


    

}

