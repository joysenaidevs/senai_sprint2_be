using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_spmedical_be_webApi.Domains;

#nullable disable
//   Comando DataBase
//          Scaffold-DbContext "Data Source=; initial catalog=; user Id=sa; pwd="adm@132;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Domains -Contexts -Context MedicalContext (MedicalContext.cs)
// Comando:                     string de conexão                                           Provedor              nome da pasta onde ficarão os domains          Nome da classe MedicalContext
// 
// Documentação EF Core
// https://docs.microsoft.com/pt-br/ef/core/managing-schemas/scaffolding

/*
    Dependências do EF Core
    Microsoft.EntityFrameworkCore.SqlServer
    Microsoft.EntityFrameworkCore.SqlServer.Design
    Microsoft.EntityFrameworkCore.Tools
*/

// Scaffold-DbContext "Data Source=DESKTOP-SP7RV1S\SQLEXPRESS; initial catalog=Gufi_manha; user Id=sa; pwd=senai@132;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Domains -ContextDir Contexts -Context GufiContext

// Comando:                                 Scaffold-DbContext
// String de conexão:                       "Data Source=DESKTOP-SP7RV1S\SQLEXPRESS; initial catalog=Gufi_manha; user Id=sa; pwd=senai@132;"
// Provedor utilizado:                      Microsoft.EntityFrameworkCore.SqlServer
// Nome da pasta onde ficarão os domínios:  -OutputDir Domains
// Nome da pasta onde ficarão os contextos: -ContextDir Contexts
// Nome do arquivo/classe de contexto:      -Context GufiContext


namespace senai_spmedical_be_webApi.Contexts
{
    public partial class MedicalContext : DbContext
    {
        public MedicalContext()
        {
        }

        public MedicalContext(DbContextOptions<MedicalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consulta> Consultas { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Prontuario> Prontuarios { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                //string de conexao Joyce
                //optionsBuilder.UseSqlServer("Data Source=WINDOWS\\SQLEXPRESS; initial catalog=medicalGroup; user Id=sa; pwd=adm@132;");


                //string de conexao do senai
                optionsBuilder.UseSqlServer("Data Source=LAB08DESK2601\\SQLEXPRESS01; initial catalog=medicalGroup; integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__clinicas__C73A6055CFCE875F");

                entity.ToTable("clinicas");

                entity.HasIndex(e => e.Cnpj, "UQ__clinicas__35BD3E48AA99F52F")
                    .IsUnique();

                entity.HasIndex(e => e.Endereco, "UQ__clinicas__9456D40621F47D3D")
                    .IsUnique();

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("cnpj")
                    .IsFixedLength(true);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.HorarioFuncionamento).HasColumnName("horarioFuncionamento");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeFantasia");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocial");
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__consulta__CA9C61F5ADA335F4");

                entity.ToTable("consultas");

                entity.HasIndex(e => e.DataConsulta, "UQ__consulta__966AA07407ABE841")
                    .IsUnique();

                entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");

                entity.Property(e => e.DataConsulta)
                    .HasColumnType("date")
                    .HasColumnName("dataConsulta");

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.IdProntuario).HasColumnName("idProntuario");

                entity.Property(e => e.Situacao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("situacao");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__consultas__idMed__5070F446");

                entity.HasOne(d => d.IdProntuarioNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdProntuario)
                    .HasConstraintName("FK__consultas__idPro__4F7CD00D");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade)
                    .HasName("PK__especial__4096980599CE212E");

                entity.ToTable("especialidades");

                entity.HasIndex(e => e.NomeEspecialidade, "UQ__especial__EF876A54717CE94F")
                    .IsUnique();

                entity.Property(e => e.IdEspecialidade).HasColumnName("idEspecialidade");

                entity.Property(e => e.NomeEspecialidade)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeEspecialidade");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__medicos__4E03DEBA963B9A79");

                entity.ToTable("medicos");

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.IdEspecialidade).HasColumnName("idEspecialidade");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeMedico)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeMedico");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__medicos__idClini__4AB81AF0");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .HasConstraintName("FK__medicos__idEspec__49C3F6B7");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__medicos__idUsuar__4BAC3F29");
            });

            modelBuilder.Entity<Prontuario>(entity =>
            {
                entity.HasKey(e => e.IdProntuario)
                    .HasName("PK__prontuar__41651E52EB334B7A");

                entity.ToTable("prontuarios");

                entity.HasIndex(e => e.Rg, "UQ__prontuar__3214331044D3AC67")
                    .IsUnique();

                entity.HasIndex(e => e.Endereco, "UQ__prontuar__9456D40604B5BCD8")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__prontuar__D836E71F40408E68")
                    .IsUnique();

                entity.Property(e => e.IdProntuario).HasColumnName("idProntuario");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cpf")
                    .IsFixedLength(true);

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("dataNascimento");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeProntuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeProntuario");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("rg")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefone).HasColumnName("telefone");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Prontuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__prontuari__idUsu__440B1D61");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF3A889E70");

                entity.ToTable("tipoUsuarios");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__tipoUsua__A017BD9F8E276E22")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuarios__645723A6BAB0F333");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Email, "UQ__usuarios__AB6E6164EC9C88C3")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuarios__idTipo__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
