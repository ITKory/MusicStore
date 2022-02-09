using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MusicStore.Data
{
    public partial class MusicContext : DbContext
    {
        public MusicContext()
        {
        }

        public MusicContext(DbContextOptions<MusicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TabAdmin> TabAdmins { get; set; }
        public virtual DbSet<TabAuthor> TabAuthors { get; set; }
        public virtual DbSet<TabBonuse> TabBonuses { get; set; }
        public virtual DbSet<TabCountry> TabCountries { get; set; }
        public virtual DbSet<TabGenre> TabGenres { get; set; }
        public virtual DbSet<TabGroup> TabGroups { get; set; }
        public virtual DbSet<TabMusicRecord> TabMusicRecords { get; set; }
        public virtual DbSet<TabPerson> TabPersons { get; set; }
        public virtual DbSet<TabPopular> TabPopulars { get; set; }
        public virtual DbSet<TabPublisher> TabPublishers { get; set; }
        public virtual DbSet<TabPurchaseHistory> TabPurchaseHistories { get; set; }
        public virtual DbSet<TabSale> TabSales { get; set; }
        public virtual DbSet<TabStorage> TabStorages { get; set; }
        public virtual DbSet<TabUser> TabUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseMySQL("Server=localhost;Database=music_store;Uid=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabAdmin>(entity =>
            {
                entity.ToTable("tab_admins");

                entity.HasIndex(e => e.PersonId, "person_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.PersonId)
                    .HasColumnType("int(11)")
                    .HasColumnName("person_id");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("pwd");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TabAdmins)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_admins_ibfk_1");
            });

            modelBuilder.Entity<TabAuthor>(entity =>
            {
                entity.ToTable("tab_authors");

                entity.HasIndex(e => e.GroupId, "group_id");

                entity.HasIndex(e => e.PersonId, "person_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.GroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("group_id");

                entity.Property(e => e.PersonId)
                    .HasColumnType("int(11)")
                    .HasColumnName("person_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TabAuthors)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_authors_ibfk_1");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TabAuthors)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_authors_ibfk_2");
            });

            modelBuilder.Entity<TabBonuse>(entity =>
            {
                entity.ToTable("tab_bonuses");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Count)
                    .HasColumnType("int(11)")
                    .HasColumnName("count");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TabBonuses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_bonuses_ibfk_1");
            });

            modelBuilder.Entity<TabCountry>(entity =>
            {
                entity.ToTable("tab_countries");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TabGenre>(entity =>
            {
                entity.ToTable("tab_genres");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TabGroup>(entity =>
            {
                entity.ToTable("tab_groups");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TabMusicRecord>(entity =>
            {
                entity.ToTable("tab_music_records");

                entity.HasIndex(e => e.AuthorId, "author_id");

                entity.HasIndex(e => e.GenreId, "genre_id");

                entity.HasIndex(e => e.GroupId, "group_id");

                entity.HasIndex(e => e.PublisherId, "publisher_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AuthorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("author_id");

                entity.Property(e => e.Cost)
                    .HasColumnType("int(11)")
                    .HasColumnName("cost");

                entity.Property(e => e.GenreId)
                    .HasColumnType("int(11)")
                    .HasColumnName("genre_id");

                entity.Property(e => e.GroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("group_id");

                entity.Property(e => e.ImgUri)
                    .HasMaxLength(255)
                    .HasColumnName("img_uri");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.ProductionCoasts)
                    .HasColumnType("int(11)")
                    .HasColumnName("production_coasts");

                entity.Property(e => e.PublishDate)
                    .HasColumnType("date")
                    .HasColumnName("publish_date");

                entity.Property(e => e.PublisherId)
                    .HasColumnType("int(11)")
                    .HasColumnName("publisher_id");

                entity.Property(e => e.TrackCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("track_count");

                entity.Property(e => e.Visible).HasColumnName("visible");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.TabMusicRecords)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_music_records_ibfk_1");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.TabMusicRecords)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_music_records_ibfk_2");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TabMusicRecords)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_music_records_ibfk_3");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.TabMusicRecords)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_music_records_ibfk_4");
            });

            modelBuilder.Entity<TabPerson>(entity =>
            {
                entity.ToTable("tab_persons");

                entity.HasIndex(e => e.CountryId, "country_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CountryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("country_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("last_name");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TabPeople)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_persons_ibfk_1");
            });

            modelBuilder.Entity<TabPopular>(entity =>
            {
                entity.ToTable("tab_popular");

                entity.HasIndex(e => e.MusicRecordId, "music_record_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.MusicRecordId)
                    .HasColumnType("int(11)")
                    .HasColumnName("music_record_id");

                entity.HasOne(d => d.MusicRecord)
                    .WithMany(p => p.TabPopulars)
                    .HasForeignKey(d => d.MusicRecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_popular_ibfk_1");
            });

            modelBuilder.Entity<TabPublisher>(entity =>
            {
                entity.ToTable("tab_publishers");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TabPurchaseHistory>(entity =>
            {
                entity.ToTable("tab_purchase_history");

                entity.HasIndex(e => e.MusicRecordId, "music_record_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.MusicRecordId)
                    .HasColumnType("int(11)")
                    .HasColumnName("music_record_id");

                entity.Property(e => e.RecordsCount)
                    .HasColumnType("int(20)")
                    .HasColumnName("records_count");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.MusicRecord)
                    .WithMany(p => p.TabPurchaseHistories)
                    .HasForeignKey(d => d.MusicRecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_purchase_history_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TabPurchaseHistories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_purchase_history_ibfk_2");
            });

            modelBuilder.Entity<TabSale>(entity =>
            {
                entity.ToTable("tab_sales");

                entity.HasIndex(e => e.MusicRecordId, "music_record_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Bonuses)
                    .HasColumnType("int(11)")
                    .HasColumnName("bonuses");

                entity.Property(e => e.Cost)
                    .HasColumnType("int(11)")
                    .HasColumnName("cost");

                entity.Property(e => e.Count)
                    .HasColumnType("int(11)")
                    .HasColumnName("count");

                entity.Property(e => e.MusicRecordId)
                    .HasColumnType("int(11)")
                    .HasColumnName("music_record_id");

                entity.Property(e => e.TotalCost)
                    .HasColumnType("int(11)")
                    .HasColumnName("total_cost");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.MusicRecord)
                    .WithMany(p => p.TabSales)
                    .HasForeignKey(d => d.MusicRecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_sales_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TabSales)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_sales_ibfk_2");
            });

            modelBuilder.Entity<TabStorage>(entity =>
            {
                entity.ToTable("tab_storage");

                entity.HasIndex(e => e.MusicRecordId, "music_record_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Count)
                    .HasColumnType("int(11)")
                    .HasColumnName("count");

                entity.Property(e => e.MusicRecordId)
                    .HasColumnType("int(11)")
                    .HasColumnName("music_record_id");

                entity.HasOne(d => d.MusicRecord)
                    .WithMany(p => p.TabStorages)
                    .HasForeignKey(d => d.MusicRecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_storage_ibfk_1");
            });

            modelBuilder.Entity<TabUser>(entity =>
            {
                entity.ToTable("tab_users");

                entity.HasIndex(e => e.PersonId, "person_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.PersonId)
                    .HasColumnType("int(11)")
                    .HasColumnName("person_id");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("pwd");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TabUsers)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tab_users_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
