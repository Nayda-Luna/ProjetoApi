using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoApi.Models;
using ProjetoApi.Models.Enuns;
using ProjetoApi.Utils;


namespace ProjetoApi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Tarefa> TB_TAREFAS {get; set; }
        public DbSet<Usuario> TB_USUARIOS { get; set; }
       // public DbSet<Categoria> TB_CATEGORIA { get; set; }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>().ToTable("TB_TAREFAS");
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
           /* modelBuilder.Entity<Categoria>().ToTable("TB_CATEGORIA");*/
           
            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Tarefas)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId)
                .IsRequired(false);

             
          /*  modelBuilder.Entity<Tarefa>()
                .HasOne(e => e.Categoria)
                .WithOne(e => e.Tarefa)
                .HasForeignKey<Categoria>(e => e.TarefaId)
                .IsRequired();

             modelBuilder.Entity<Tarefa>()
                .HasOne(l => l.Lembrete)
                .WithOne(l => l.Tarefa)
                .HasForeignKey<Lembrete>(l => l.TarefaId)
                .IsRequired(); 
*/
            modelBuilder.Entity<Tarefa>().HasData
            (

                new Tarefa() {Id=1, Título = "Estudar", Descricao = "Estudar para á prova", Observacao = "Andamento",  Classe= ClasseEnum.Comum, UsuarioId=1 },
                new Tarefa() {Id= 2, Título ="Viagem", Descricao="Viagem para pesquisa/trabalho da universidade", Observacao="Não iniciado",  Classe= ClasseEnum.Especial, UsuarioId=1 },
                new Tarefa() {Id = 3, Título = "Trablho em grupo", Descricao="Fazer atividade em grupo na casa da Mariana", Observacao="Concluido",  Classe= ClasseEnum.Urgente, UsuarioId=1 },
                new Tarefa() {Id = 4, Título="Compromisso", Descricao="Aniversario de uma amiga", Observacao= "nao iniciada",  Classe=ClasseEnum.Especial, UsuarioId=1  }
            
            );

        /*    modelBuilder.Entity<Lembrete>().HasData
            (
              new Lembrete() { Id = 1, Mensagem = "Amanhã você tem um compromisso...", TarefaId =4 },
              new Lembrete() { Id = 2, Mensagem = "Objetivo concluido", TarefaId = 3},
              new Lembrete() { Id = 3, Mensagem = "Hoje você deve estudar biologia", TarefaId = 1},
              new Lembrete() { Id = 4, Mensagem = "Faltam 5 dias para sua viagem...", TarefaId = 2}
              
            );

            modelBuilder.Entity<Categoria>().HasData
            (
              new Categoria() { Id = 1, Cor = "Vermelho", TarefaId =4 },
              new Categoria() { Id = 2, Cor = "Azul", TarefaId = 3},
              new Categoria() { Id = 3, Cor = "Azul", TarefaId = 1},
              new Categoria() { Id = 4, Cor = "Roxo", TarefaId = 2}
              
            );
*/
            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
            user.Id = 1;
            user.Username = "UsuarioAdmin";
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.Perfil = "Admin";
            user.Email = "seuEmail@gmail.com";
            user.Latitude = -23.5200241;
            user.Longitude = -46.596498;

            modelBuilder.Entity<Usuario>().HasData(user);

            modelBuilder.Entity<Usuario>().Property(u => u.Perfil).HasDefaultValue("Usuário");

            
            


            
        }

     /*   protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(200);
            base.ConfigureConventions(configurationBuilder);
        }
        }

    internal class Criptografia
    {
        internal static void CriarPasswordHash(string v, out byte[] hash, out byte[] salt)
        {
            throw new NotImplementedException();
        }*/
    }
}
