using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Entities;

public partial class ShelterContext : DbContext
{
    public ShelterContext()
    {
    }

    public ShelterContext(DbContextOptions<ShelterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Breed> Breeds { get; set; }

    public virtual DbSet<BreedStatistic> BreedStatistics { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<FoodAttribute> FoodAttributes { get; set; }

    public virtual DbSet<FoodAttribute1> FoodAttributes1 { get; set; }

    public virtual DbSet<FoodPortion> FoodPortions { get; set; }

    public virtual DbSet<FoodPortion1> FoodPortions1 { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<InputFood> InputFoods { get; set; }

    public virtual DbSet<TakingAnimal> TakingAnimals { get; set; }

    public virtual DbSet<Wcfstatus> Wcfstatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HONOR22;database=Shelter;trusted_connection=true;trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.ToTable("Animal");

            entity.Property(e => e.DateOfArrival).HasColumnType("datetime");
            entity.Property(e => e.GenderCode).HasMaxLength(1);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Breed).WithMany(p => p.Animals)
                .HasForeignKey(d => d.BreedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Animal_Breed");

            entity.HasOne(d => d.GenderCodeNavigation).WithMany(p => p.Animals)
                .HasForeignKey(d => d.GenderCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Animal_Gender");
        });

        modelBuilder.Entity<Breed>(entity =>
        {
            entity.ToTable("Breed");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.EnglishName).HasMaxLength(100);
            entity.Property(e => e.Group).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Rcf).HasColumnName("RCF");
            entity.Property(e => e.Section).HasMaxLength(150);
            entity.Property(e => e.StandartFci).HasColumnName("StandartFCI");
            entity.Property(e => e.Synonym).HasMaxLength(100);
            entity.Property(e => e.Urlphoto)
                .HasMaxLength(400)
                .HasColumnName("URLPhoto");
            entity.Property(e => e.Urlwiki)
                .HasMaxLength(400)
                .HasColumnName("URLWiki");
            entity.Property(e => e.Variety).HasMaxLength(100);
            entity.Property(e => e.WfcstatusCode)
                .HasMaxLength(1)
                .HasColumnName("WFCStatusCode");
            entity.Property(e => e.YearOfRecognitionFci).HasColumnName("YearOfRecognitionFCI");

            entity.HasOne(d => d.WfcstatusCodeNavigation).WithMany(p => p.Breeds)
                .HasForeignKey(d => d.WfcstatusCode)
                .HasConstraintName("FK_Breed_WCFStatus");
        });

        modelBuilder.Entity<BreedStatistic>(entity =>
        {
            entity.HasKey(e => e.BreedId);

            entity.ToTable("BreedStatistic");

            entity.Property(e => e.BreedId).ValueGeneratedNever();

            entity.HasOne(d => d.Breed).WithOne(p => p.BreedStatistic)
                .HasForeignKey<BreedStatistic>(d => d.BreedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BreedStatistic_Breed");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.DateOfIssue).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IssuedBy).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.Number)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.OtherContactInfo).HasMaxLength(300);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Phone2).HasMaxLength(15);
            entity.Property(e => e.PostalZip)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Region).HasMaxLength(100);
            entity.Property(e => e.RegistrationAddress).HasMaxLength(100);
            entity.Property(e => e.Serial)
                .HasMaxLength(4)
                .IsFixedLength();

            entity.HasOne(d => d.Country).WithMany(p => p.Clients)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_Country");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.ToTable("Donation");

            entity.Property(e => e.DateOfDonation).HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.Donations)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Donation_Client");

            entity.HasOne(d => d.Food).WithMany(p => p.Donations)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Donation_Food");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.ToTable("Food");

            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.FoodCategory).HasMaxLength(100);
            entity.Property(e => e.FoodClass).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.PublicationDate).HasColumnType("datetime");
            entity.Property(e => e.Scientificname).HasMaxLength(100);
        });

        modelBuilder.Entity<FoodAttribute>(entity =>
        {
            entity.ToTable("FoodAttribute");

            entity.Property(e => e.FoodAttributeId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<FoodAttribute1>(entity =>
        {
            entity.HasKey(e => e.FoodId);

            entity.ToTable("FoodAttributes");

            entity.Property(e => e.FoodId).ValueGeneratedNever();

            entity.HasOne(d => d.FoodAttribute).WithMany(p => p.FoodAttribute1s)
                .HasForeignKey(d => d.FoodAttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FoodAttributes_FoodAttribute");

            entity.HasOne(d => d.Food).WithOne(p => p.FoodAttribute1)
                .HasForeignKey<FoodAttribute1>(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FoodAttributes_Food");
        });

        modelBuilder.Entity<FoodPortion>(entity =>
        {
            entity.ToTable("FoodPortion");

            entity.Property(e => e.FoodPortionId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.GramWeight).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MeasureUnitAbbreviation).HasMaxLength(100);
            entity.Property(e => e.MeasureUnitName).HasMaxLength(100);
            entity.Property(e => e.Modifier).HasMaxLength(100);
        });

        modelBuilder.Entity<FoodPortion1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FoodPortions");

            entity.HasOne(d => d.Food).WithMany()
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FoodPortions_Food");

            entity.HasOne(d => d.FoodPortion).WithMany()
                .HasForeignKey(d => d.FoodPortionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FoodPortions_FoodPortion");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderCode);

            entity.ToTable("Gender");

            entity.Property(e => e.GenderCode).HasMaxLength(1);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<InputFood>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Description).HasMaxLength(300);

            entity.HasOne(d => d.Food).WithMany()
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InputFoods_Food");

            entity.HasOne(d => d.InputFoodNavigation).WithMany()
                .HasForeignKey(d => d.InputFoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InputFoods_Food1");
        });

        modelBuilder.Entity<TakingAnimal>(entity =>
        {
            entity.ToTable("TakingAnimal");

            entity.Property(e => e.DateOfTaking).HasColumnType("datetime");

            entity.HasOne(d => d.Animal).WithMany(p => p.TakingAnimals)
                .HasForeignKey(d => d.AnimalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TakingAnimal_Animal");

            entity.HasOne(d => d.Client).WithMany(p => p.TakingAnimals)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TakingAnimal_Client");
        });

        modelBuilder.Entity<Wcfstatus>(entity =>
        {
            entity.HasKey(e => e.WfcstatusCode);

            entity.ToTable("WCFStatus");

            entity.Property(e => e.WfcstatusCode)
                .HasMaxLength(1)
                .HasColumnName("WFCStatusCode");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
