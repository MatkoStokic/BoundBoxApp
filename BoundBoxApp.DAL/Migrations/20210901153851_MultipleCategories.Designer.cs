﻿// <auto-generated />
using System;
using BoundBoxApp.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BoundBoxApp.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210901153851_MultipleCategories")]
    partial class MultipleCategories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BoundBoxApp.Model.Annotation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AnnotatorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsObjectDetection")
                        .HasColumnType("bit");

                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AnnotatorId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Annotation");
                });

            modelBuilder.Entity("BoundBoxApp.Model.Marker", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AnnotationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BoundsId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("XCoords")
                        .HasColumnType("float");

                    b.Property<double>("YCoords")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AnnotationId");

                    b.ToTable("Marker");
                });

            modelBuilder.Entity("BoundBoxApp.Model.Project", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Categories")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsForObjectDetection")
                        .HasColumnType("bit");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Src")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            ConcurrencyStamp = "d8ade769-3363-4c88-8586-ca8d24f6065e",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdb8",
                            ConcurrencyStamp = "4021de59-a1e6-42be-912d-134423a8980a",
                            Name = "Annotator",
                            NormalizedName = "ANNOTATOR"
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdb7",
                            ConcurrencyStamp = "fd04a890-65b7-4a2a-b361-1d864747d556",
                            Name = "ContentOwner",
                            NormalizedName = "CONTENTOWNER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "Role",
                            ClaimValue = "Admin",
                            RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "Role",
                            ClaimValue = "Annotator",
                            RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb8"
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "Role",
                            ClaimValue = "User",
                            RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb7"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "887b7156-4530-4be3-a09d-dbafb273733f",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "Admin",
                            PasswordHash = "AQAAAAEAACcQAAAAEM6Te8kEbySbZxWTnUdum8Msmwo6PXo7RIUxgyI/FNmGqdiqHtvF3NdO/IFw7CL73Q==",
                            PhoneNumber = "",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "46d70bb1-c2dd-4605-bf5b-655d6ea8bd9f",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdb8",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "14250e01-bdcf-4c06-a576-98e7f83fb6ff",
                            Email = "annotator@annotator.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ANNOTATOR@ANNOTATOR.COM",
                            NormalizedUserName = "Annotator",
                            PasswordHash = "AQAAAAEAACcQAAAAELNhClTB2pwCo4nVDixykyEBG3RJf+FfpykflKIx06MG4k7JJ7K5tjZY3LUQbhX+6w==",
                            PhoneNumber = "",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "bb020650-f154-4a55-9d12-be329be21488",
                            TwoFactorEnabled = false,
                            UserName = "Annotator"
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdb7",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "770a22c7-6eb7-4d96-8c72-5d75a81b70c8",
                            Email = "user@user.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@USER.COM",
                            NormalizedUserName = "User",
                            PasswordHash = "AQAAAAEAACcQAAAAEFTKh/ZhL/BiPecbxj4534TEHg24dqMVpmNRqhDPQvNwmkZaMmxoTBagSzc59RSK7w==",
                            PhoneNumber = "",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "06e6e4f9-80b6-4ce0-a3bb-c359c03ab572",
                            TwoFactorEnabled = false,
                            UserName = "User"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdb8",
                            RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb8"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdb7",
                            RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb7"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("BoundBoxApp.Model.Annotation", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Annotator")
                        .WithMany()
                        .HasForeignKey("AnnotatorId");

                    b.HasOne("BoundBoxApp.Model.Project", null)
                        .WithMany("Annotations")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("BoundBoxApp.Model.Marker", b =>
                {
                    b.HasOne("BoundBoxApp.Model.Annotation", null)
                        .WithMany("Markers")
                        .HasForeignKey("AnnotationId");
                });

            modelBuilder.Entity("BoundBoxApp.Model.Project", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
