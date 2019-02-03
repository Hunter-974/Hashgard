﻿// <auto-generated />
using System;
using Crypto.Back.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Crypto.Back.Db.Migrations
{
    [DbContext(typeof(CryptoDbContext))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("Crypto.Back.Models.Article", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CategoryId");

                    b.Property<Guid>("CorrelationUid");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.Property<long?>("UserId");

                    b.Property<DateTime>("VersionDate");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Crypto.Back.Models.Attachment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ArticleId");

                    b.Property<long?>("CommentId");

                    b.Property<string>("Data");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("CommentId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Crypto.Back.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long?>("ParentId")
                        .HasColumnName("CategoryId");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Crypto.Back.Models.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ArticleId");

                    b.Property<Guid>("CorrelationUid");

                    b.Property<long?>("ParentId")
                        .HasColumnName("CommentId");

                    b.Property<string>("Text");

                    b.Property<long?>("UserId");

                    b.Property<DateTime>("VersionDate");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Crypto.Back.Models.Reaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ReactionTypeId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ReactionTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("Crypto.Back.Models.ReactionType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ArticleId");

                    b.Property<long?>("CommentId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("CommentId");

                    b.ToTable("ReactionTypes");
                });

            modelBuilder.Entity("Crypto.Back.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("LogInDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<TimeSpan>("SessionLifetime");

                    b.Property<DateTime>("SignUpDate");

                    b.Property<Guid?>("Token");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Crypto.Back.Models.Article", b =>
                {
                    b.HasOne("Crypto.Back.Models.Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Crypto.Back.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Crypto.Back.Models.Attachment", b =>
                {
                    b.HasOne("Crypto.Back.Models.Article", "Article")
                        .WithMany("Attachments")
                        .HasForeignKey("ArticleId");

                    b.HasOne("Crypto.Back.Models.Comment", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId");
                });

            modelBuilder.Entity("Crypto.Back.Models.Category", b =>
                {
                    b.HasOne("Crypto.Back.Models.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.HasOne("Crypto.Back.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Crypto.Back.Models.Comment", b =>
                {
                    b.HasOne("Crypto.Back.Models.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId");

                    b.HasOne("Crypto.Back.Models.Comment", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.HasOne("Crypto.Back.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Crypto.Back.Models.Reaction", b =>
                {
                    b.HasOne("Crypto.Back.Models.ReactionType", "ReactionType")
                        .WithMany("Reactions")
                        .HasForeignKey("ReactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Crypto.Back.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Crypto.Back.Models.ReactionType", b =>
                {
                    b.HasOne("Crypto.Back.Models.Article", "Article")
                        .WithMany("ReactionTypes")
                        .HasForeignKey("ArticleId");

                    b.HasOne("Crypto.Back.Models.Comment", "Comment")
                        .WithMany("ReactionTypes")
                        .HasForeignKey("CommentId");
                });
#pragma warning restore 612, 618
        }
    }
}
