using System;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DL
{
    public partial class ApartmentBrokerageContext : DbContext
    {
        public ApartmentBrokerageContext()
        {
        }

        public ApartmentBrokerageContext(DbContextOptions<ApartmentBrokerageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<AreaPerCity> AreaPerCities { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<IdentityType> IdentityTypes { get; set; }
        public virtual DbSet<Neighborhood> Neighborhoods { get; set; }
        public virtual DbSet<PaymentOption> PaymentOptions { get; set; }
        public virtual DbSet<PaymentPerProperty> PaymentPerProperties { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PropertyDetail> PropertyDetails { get; set; }
        public virtual DbSet<PropertyType> PropertyTypes { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<SubscriberPropertyDetail> SubscriberPropertyDetails { get; set; }
        public virtual DbSet<SubscriptionPerUser> SubscriptionPerUsers { get; set; }
        public virtual DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        //add on declaration part
        public virtual DbSet<Rating> Rating { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=ApartmentBrokerage;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("area");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<AreaPerCity>(entity =>
            {
                entity.ToTable("area_per_city");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AreaId).HasColumnName("area_id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.AreaPerCities)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_area_per_city_area");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.AreaPerCities)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_area_per_city_city");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<IdentityType>(entity =>
            {
                entity.ToTable("identity_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Neighborhood>(entity =>
            {
                entity.ToTable("neighborhood");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Neighborhoods)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_neighborhood_city");
            });

            modelBuilder.Entity<PaymentOption>(entity =>
            {
                entity.ToTable("payment_option");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<PaymentPerProperty>(entity =>
            {
                entity.ToTable("payment_per_property");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApartmentId).HasColumnName("apartment_id");

                entity.Property(e => e.PaymentOptionsId).HasColumnName("payment_option_id");

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.PaymentPerProperties)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_payment_per_property_property_details");

                entity.HasOne(d => d.PaymentOptions)
                    .WithMany(p => p.PaymentPerProperties)
                    .HasForeignKey(d => d.PaymentOptionsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_payment_per_property_payment_option");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildingNumber).HasColumnName("building_number");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("email");

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("fax");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("first_name");

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.IdentityId).HasColumnName("identity_id");

                entity.Property(e => e.IdentityNumber).HasColumnName("identity_number");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Phone1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("phone_1");

                entity.Property(e => e.Phone2)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("phone_2");

                entity.Property(e => e.Phone3)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("phone_3");

                entity.Property(e => e.StreetId).HasColumnName("street_id");

                entity.HasOne(d => d.Identity)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.IdentityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_person_identity_type");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.StreetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_person_street");

                entity.Property(e => e.Salt)
                    //.IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("salt");

            });

            modelBuilder.Entity<PropertyDetail>(entity =>
            {
                entity.ToTable("property_details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccessForDisabled).HasColumnName("access_for_disabled");

                entity.Property(e => e.AirConditioning).HasColumnName("air_conditioning");

                entity.Property(e => e.Available).HasColumnName("available");

                entity.Property(e => e.BuildingNumber).HasColumnName("building_number");

                entity.Property(e => e.Elevators).HasColumnName("elevators");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("entry_date");

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.FreeDescription)
                    .HasMaxLength(200)
                    .HasColumnName("free_description");

                entity.Property(e => e.Furnished).HasColumnName("furnished");

                entity.Property(e => e.NumberRoom).HasColumnName("number_room");

                entity.Property(e => e.Parking).HasColumnName("parking");

                entity.Property(e => e.Porch).HasColumnName("porch");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.PropertyNumber).HasColumnName("property_number");

                entity.Property(e => e.PropertyTaxPrice).HasColumnName("property_tax_price");

                entity.Property(e => e.PropertyTypeId).HasColumnName("property_type_id");

                entity.Property(e => e.Renovated).HasColumnName("renovated");

                entity.Property(e => e.SeveralDirectionsOfAir).HasColumnName("several_directions_of_air");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("sku");

                entity.Property(e => e.SquareMeter).HasColumnName("square_meter");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Storage).HasColumnName("storage");

                entity.Property(e => e.StreetId).HasColumnName("street_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserPropertyNumber).HasColumnName("user_property_number");

                entity.Property(e => e.Yard).HasColumnName("yard");

                entity.HasOne(d => d.PropertyType)
                    .WithMany(p => p.PropertyDetails)
                    .HasForeignKey(d => d.PropertyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_property_details_property_type");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.PropertyDetails)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_property_details_status");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.PropertyDetails)
                    .HasForeignKey(d => d.StreetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_property_details_street");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PropertyDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_property_details_user");
            });

            modelBuilder.Entity<PropertyType>(entity =>
            {
                entity.ToTable("property_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.ToTable("street");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.NeighborhoodId).HasColumnName("neighborhood_id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Streets)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_street_city");

                entity.HasOne(d => d.Neighborhood)
                    .WithMany(p => p.Streets)
                    .HasForeignKey(d => d.NeighborhoodId)
                    .HasConstraintName("FK_street_neighborhood");
            });

            modelBuilder.Entity<SubscriberPropertyDetail>(entity =>
            {
                entity.ToTable("subscriber_property_details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccessForDisabled).HasColumnName("access_for_disabled");

                entity.Property(e => e.AirConditioning).HasColumnName("air_conditioning");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Distance).HasColumnName("distance");

                entity.Property(e => e.Elevators).HasColumnName("elevators");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("entry_date");

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.Furnished).HasColumnName("furnished");

                entity.Property(e => e.MaximumPrice).HasColumnName("maximum_price");

                entity.Property(e => e.NeighborhoodId).HasColumnName("neighborhood_id");

                entity.Property(e => e.Parking).HasColumnName("parking");

                entity.Property(e => e.Porch).HasColumnName("porch");

                entity.Property(e => e.PropertyTypeId).HasColumnName("property_type_id");

                entity.Property(e => e.Renovated).HasColumnName("renovated");

                entity.Property(e => e.RoomNumber).HasColumnName("room_number");

                entity.Property(e => e.SeveralDirectionsOfAir).HasColumnName("several_directions_of_air");

                entity.Property(e => e.SquareMeter).HasColumnName("square_meter");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Storage).HasColumnName("storage");

                entity.Property(e => e.SubscriptionPerUserId).HasColumnName("subscription_per_user_id");

                entity.Property(e => e.Yard).HasColumnName("yard");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.SubscriberPropertyDetails)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_subscriber_property_details_city");

                entity.HasOne(d => d.Neighborhood)
                    .WithMany(p => p.SubscriberPropertyDetails)
                    .HasForeignKey(d => d.NeighborhoodId)
                    .HasConstraintName("FK_subscriber_property_details_neighborhood");

                entity.HasOne(d => d.PropertyType)
                    .WithMany(p => p.SubscriberPropertyDetails)
                    .HasForeignKey(d => d.PropertyTypeId)
                    .HasConstraintName("FK_subscriber_property_details_property_type");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.SubscriberPropertyDetails)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_subscriber_property_details_status");

                entity.HasOne(d => d.SubscriptionPerUser)
                    .WithMany(p => p.SubscriberPropertyDetails)
                    .HasForeignKey(d => d.SubscriptionPerUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_subscriber_property_details_subscription_per_user");
            });

            modelBuilder.Entity<SubscriptionPerUser>(entity =>
            {
                entity.ToTable("subscription_per_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AreaId).HasColumnName("area_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.Property(e => e.SubscriptionTypeId).HasColumnName("subscription_type_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.SubscriptionPerUsers)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_subscription_per_user_area");

                entity.HasOne(d => d.SubscriptionType)
                    .WithMany(p => p.SubscriptionPerUsers)
                    .HasForeignKey(d => d.SubscriptionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_subscription_per_user_subscription_type");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SubscriptionPerUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_subscription_per_user_user");
            });

            modelBuilder.Entity<SubscriptionType>(entity =>
            {
                entity.ToTable("subscription_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DaysNumber).HasColumnName("days_number");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_person");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_user_type");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("user_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("description");
            });





            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("RATING");

                entity.Property(e => e.RatingId).HasColumnName("RATING_ID");

                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasMaxLength(50);

                entity.Property(e => e.Method)
                    .HasColumnName("METHOD")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Path)
                    .HasColumnName("PATH")
                    .HasMaxLength(50);

                entity.Property(e => e.RecordDate)
                 .HasColumnName("Record_Date")
                 .HasColumnType("datetime");

                entity.Property(e => e.Referer)
                    .HasColumnName("REFERER")
                    .HasMaxLength(100);

                entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
            });


        OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
