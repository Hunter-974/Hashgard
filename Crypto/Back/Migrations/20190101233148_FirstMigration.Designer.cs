// <auto-generated />
using System;
using Crypto.Back.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Crypto.Back.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190101233148_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("Crypto.Back.Models.Article", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CategoryId");

                    b.Property<Guid>("CorrelationUid");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.Property<long>("UserId");

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

                    b.Property<long?>("CategoryId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Crypto.Back.Models.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ArticleId");

                    b.Property<long?>("CommentId");

                    b.Property<Guid>("CorrelationUid");

                    b.Property<string>("Text");

                    b.Property<long>("UserId");

                    b.Property<DateTime>("VersionDate");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("CommentId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Crypto.Back.Models.Reaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ArticleId");

                    b.Property<long?>("CommentId");

                    b.Property<string>("ReactionType");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("CommentId");

                    b.HasIndex("UserId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("Crypto.Back.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Location");

                    b.Property<DateTime?>("LogInDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<TimeSpan>("SessionLifetime");

                    b.Property<DateTime>("SignInDate");

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
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                        .HasForeignKey("CategoryId");

                    b.HasOne("Crypto.Back.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Crypto.Back.Models.Comment", b =>
                {
                    b.HasOne("Crypto.Back.Models.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId");

                    b.HasOne("Crypto.Back.Models.Comment", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("CommentId");

                    b.HasOne("Crypto.Back.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Crypto.Back.Models.Reaction", b =>
                {
                    b.HasOne("Crypto.Back.Models.Article", "Article")
                        .WithMany("Reactions")
                        .HasForeignKey("ArticleId");

                    b.HasOne("Crypto.Back.Models.Comment", "Comment")
                        .WithMany("Reactions")
                        .HasForeignKey("CommentId");

                    b.HasOne("Crypto.Back.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
