﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace WebApi.Migrations
{
    [DbContext(typeof(ConfigurationContext))]
    partial class ConfigurationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppSettings", b =>
                {
                    b.Property<int>("AppSettingsId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("DefaultPrice");

                    b.Property<string>("DefaultUrl");

                    b.Property<bool>("IsFromLocalStorage");

                    b.HasKey("AppSettingsId");

                    b.ToTable("AppSettings");
                });
#pragma warning restore 612, 618
        }
    }
}
