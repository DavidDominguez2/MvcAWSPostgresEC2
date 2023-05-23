using Microsoft.EntityFrameworkCore;
using MvcAWSPostgresEC2.Models;

namespace MvcAWSPostgresEC2.Data {
	public class DepartamentoContext : DbContext {
		public DepartamentoContext(DbContextOptions<DepartamentoContext> options) : base(options) { }

		public DbSet<Departamento> Departamentos { get; set; }
	}
}
