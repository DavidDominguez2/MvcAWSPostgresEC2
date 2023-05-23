using Microsoft.EntityFrameworkCore;
using MvcAWSPostgresEC2.Data;
using MvcAWSPostgresEC2.Models;

namespace MvcAWSPostgresEC2.Repositories {
	public class RepositoryDepartamento {

		private DepartamentoContext context;

		public RepositoryDepartamento(DepartamentoContext context) {
			this.context = context;
		}

		public async Task<List<Departamento>> GetDepartamentosAsync() {
			return await this.context.Departamentos.ToListAsync();
		}

		public async Task<Departamento> FindDepartamento(int id) {
			return await this.context.Departamentos.FirstOrDefaultAsync(x => x.IdDepartamento == id);
		}

		public async Task InsertDepartamento(string nombre, string localidad) {
			int newId = (await this.context.Departamentos.AnyAsync()) ? await this.context.Departamentos.MaxAsync(x => x.IdDepartamento) + 1 : 1;
			Departamento dept = new Departamento {
				IdDepartamento = newId,
				Nombre = nombre,
				Localidad = localidad
			};
			this.context.Departamentos.Add(dept);
			await this.context.SaveChangesAsync();
		}

	}
}
