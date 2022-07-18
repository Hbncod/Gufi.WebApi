﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senai.Gufi.WebApi.Manha.Domains;

namespace Senai.Gufi.WebApi.Manha.Migrations
{
    [DbContext(typeof(GufiContext))]
    [Migration("20220718031812_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Senai.Gufi.WebApi.Manha.Domains.Evento", b =>
                {
                    b.Property<int>("IdEvento")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("AcessoLivre")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<DateTime>("DataEvento");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int?>("IdInstituicao");

                    b.Property<int?>("IdTipoEvento");

                    b.Property<string>("NomeEvento")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdEvento");

                    b.HasIndex("IdInstituicao");

                    b.HasIndex("IdTipoEvento");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("Senai.Gufi.WebApi.Manha.Domains.Filmes", b =>
                {
                    b.Property<int>("IdFilme")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdGenero");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdFilme");

                    b.HasIndex("IdGenero");

                    b.HasIndex("Titulo")
                        .IsUnique()
                        .HasName("UQ__Filmes__7B406B563051A64A");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("Senai.Gufi.WebApi.Manha.Domains.Generos", b =>
                {
                    b.Property<int>("IdGenero")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdGenero");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasName("UQ__Generos__7D8FE3B27DA425AE");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("Senai.Gufi.WebApi.Manha.Domains.Instituicao", b =>
                {
                    b.Property<int>("IdInstituicao")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnName("CNPJ")
                        .HasMaxLength(14)
                        .IsUnicode(false);

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdInstituicao");

                    b.HasIndex("Cnpj")
                        .IsUnique()
                        .HasName("UQ__Institui__AA57D6B4A0D8C4A9");

                    b.HasIndex("Endereco")
                        .IsUnique()
                        .HasName("UQ__Institui__4DF3E1FFEB31E649");

                    b.HasIndex("NomeFantasia")
                        .IsUnique()
                        .HasName("UQ__Institui__F5389F316511E1BD");

                    b.ToTable("Instituicao");
                });

            modelBuilder.Entity("Senai.Gufi.WebApi.Manha.Domains.Presenca", b =>
                {
                    b.Property<int>("IdPresenca")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdEvento");

                    b.Property<int?>("IdUsuario");

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdPresenca");

                    b.HasIndex("IdEvento");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Presenca");
                });

            modelBuilder.Entity("Senai.Gufi.WebApi.Manha.Domains.TipoEvento", b =>
                {
                    b.Property<int>("IdTipoEvento")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TituloTipoEvento")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdTipoEvento");

                    b.HasIndex("TituloTipoEvento")
                        .IsUnique()
                        .HasName("UQ__TipoEven__40023AD22E845A9E");

                    b.ToTable("TipoEvento");
                });

            modelBuilder.Entity("Senai.Gufi.WebApi.Manha.Domains.TipoUsuario", b =>
                {
                    b.Property<int>("IdTipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TituloTipoUsuario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdTipoUsuario");

                    b.HasIndex("TituloTipoUsuario")
                        .IsUnique()
                        .HasName("UQ__TipoUsua__37BBE07EE206D0FA");

                    b.ToTable("TipoUsuario");
                });

            modelBuilder.Entity("Senai.Gufi.WebApi.Manha.Domains.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataCadastro");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Genero")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int?>("IdTipousuario");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdUsuario");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UQ__Usuario__A9D105340E1BBF9E");

                    b.HasIndex("IdTipousuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Senai.Gufi.WebApi.Manha.Domains.Evento", b =>
                {
                    b.HasOne("Senai.Gufi.WebApi.Manha.Domains.Instituicao", "IdInstituicaoNavigation")
                        .WithMany("Evento")
                        .HasForeignKey("IdInstituicao")
                        .HasConstraintName("FK__Evento__IdInstit__693CA210");

                    b.HasOne("Senai.Gufi.WebApi.Manha.Domains.TipoEvento", "IdTipoEventoNavigation")
                        .WithMany("Evento")
                        .HasForeignKey("IdTipoEvento")
                        .HasConstraintName("FK__Evento__IdTipoEv__6A30C649");
                });

            modelBuilder.Entity("Senai.Gufi.WebApi.Manha.Domains.Filmes", b =>
                {
                    b.HasOne("Senai.Gufi.WebApi.Manha.Domains.Generos", "IdGeneroNavigation")
                        .WithMany("Filmes")
                        .HasForeignKey("IdGenero")
                        .HasConstraintName("FK__Filmes__IdGenero__19DFD96B");
                });

            modelBuilder.Entity("Senai.Gufi.WebApi.Manha.Domains.Presenca", b =>
                {
                    b.HasOne("Senai.Gufi.WebApi.Manha.Domains.Evento", "IdEventoNavigation")
                        .WithMany("Presenca")
                        .HasForeignKey("IdEvento")
                        .HasConstraintName("FK__Presenca__IdEven__6E01572D");

                    b.HasOne("Senai.Gufi.WebApi.Manha.Domains.Usuario", "IdUsuarioNavigation")
                        .WithMany("Presenca")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__Presenca__IdUsua__6D0D32F4");
                });

            modelBuilder.Entity("Senai.Gufi.WebApi.Manha.Domains.Usuario", b =>
                {
                    b.HasOne("Senai.Gufi.WebApi.Manha.Domains.TipoUsuario", "IdTipousuarioNavigation")
                        .WithMany("Usuario")
                        .HasForeignKey("IdTipousuario")
                        .HasConstraintName("FK__Usuario__IdTipou__4316F928");
                });
#pragma warning restore 612, 618
        }
    }
}