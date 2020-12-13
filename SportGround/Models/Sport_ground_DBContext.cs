using System;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace SportGround.Models
{
    public partial class Sport_ground_DBContext : DbContext
    {
        public Sport_ground_DBContext()
        {
        }

        public Sport_ground_DBContext(DbContextOptions<Sport_ground_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<CompParticipant> CompParticipants { get; set; }
        public virtual DbSet<CompTeamParticipant> CompTeamParticipants { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }
        public virtual DbSet<IndividualTraining> IndividualTrainings { get; set; }
        public virtual DbSet<SectionVisitor> SectionVisitors { get; set; }
        public virtual DbSet<SportSection> SportSections { get; set; }
        public virtual DbSet<SportTeam> SportTeams { get; set; }
        public virtual DbSet<SportType> SportTypes { get; set; }
        public virtual DbSet<TeamPlayer> TeamPlayers { get; set; }
        public virtual DbSet<TeamTraining> TeamTrainings { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=127.0.0.1,8080;Initial Catalog=Sport_ground_DB;Persist Security Info=True;User ID=sa;Password=Qwerty123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Coach>(entity =>
            {
                entity.HasIndex(e => new { e.FirstName, e.SecondName }, "Coach_name_IX");

                entity.HasIndex(e => e.PhoneNumber, "Coach_phone_UK")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Age).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Experience).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("First_name");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("Phone_number");

                entity.Property(e => e.Salary).HasColumnType("numeric(10, 3)");

                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Second_name");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.SportSectionId).HasColumnName("Sport_section_ID");

                entity.HasOne(d => d.SportSection)
                    .WithMany(p => p.Coaches)
                    .HasForeignKey(d => d.SportSectionId)
                    .HasConstraintName("Coach_section_FK");
            });

            modelBuilder.Entity<CompParticipant>(entity =>
            {
                entity.ToTable("Comp_participants");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompetitionId).HasColumnName("Competition_ID");

                entity.Property(e => e.ParticipantCategory)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("Participant_category");

                entity.Property(e => e.ParticipantNumber)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("Participant_number");

                entity.Property(e => e.Result).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.VisitorId).HasColumnName("Visitor_ID");

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.CompParticipants)
                    .HasForeignKey(d => d.CompetitionId)
                    .HasConstraintName("I_competition_FK");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.CompParticipants)
                    .HasForeignKey(d => d.VisitorId)
                    .HasConstraintName("Competition_participant_FK");
            });

            modelBuilder.Entity<CompTeamParticipant>(entity =>
            {
                entity.ToTable("Comp_team_participants");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompetitionId).HasColumnName("Competition_ID");

                entity.Property(e => e.ParticipantCategory)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("Participant_category");

                entity.Property(e => e.ParticipantNumber)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("Participant_number");

                entity.Property(e => e.Result).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.SportTeamId).HasColumnName("Sport_team_ID");

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.CompTeamParticipants)
                    .HasForeignKey(d => d.CompetitionId)
                    .HasConstraintName("T_competition_FK");

                entity.HasOne(d => d.SportTeam)
                    .WithMany(p => p.CompTeamParticipants)
                    .HasForeignKey(d => d.SportTeamId)
                    .HasConstraintName("Competition_team_FK");
            });

            modelBuilder.Entity<Competition>(entity =>
            {
                entity.HasIndex(e => e.Name, "Competition_name_IX");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompetitionDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Competition_date_time");

                entity.Property(e => e.CompetitionType)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("Competition_type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.ParticipantsMaxNumber)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("Participants_max_number");

                entity.Property(e => e.ParticipantsNumber)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("Participants_number");

                entity.Property(e => e.Reward).HasMaxLength(50);

                entity.Property(e => e.SportTypeId).HasColumnName("Sport_type_ID");

                entity.HasOne(d => d.SportType)
                    .WithMany(p => p.Competitions)
                    .HasForeignKey(d => d.SportTypeId)
                    .HasConstraintName("Competition_type_FK");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasIndex(e => e.Name, "Equipment_name_IX");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateOfPurchase)
                    .HasColumnType("date")
                    .HasColumnName("Date_of_purchase");

                entity.Property(e => e.GenralPrice)
                    .HasColumnType("numeric(4, 3)")
                    .HasColumnName("Genral_price");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.NumberOfUnits)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("Number_of_units");

                entity.Property(e => e.PriceOfUnit)
                    .HasColumnType("numeric(4, 3)")
                    .HasColumnName("Price_of_unit");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<EquipmentType>(entity =>
            {
                entity.ToTable("Equipment_types");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EquipmentId).HasColumnName("Equipment_ID");

                entity.Property(e => e.SportTypeId).HasColumnName("Sport_type_ID");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentTypes)
                    .HasForeignKey(d => d.EquipmentId)
                    .HasConstraintName("Equipment_FK");

                entity.HasOne(d => d.SportType)
                    .WithMany(p => p.EquipmentTypes)
                    .HasForeignKey(d => d.SportTypeId)
                    .HasConstraintName("Equipment_type_FK");
            });

            modelBuilder.Entity<IndividualTraining>(entity =>
            {
                entity.ToTable("Individual_trainings");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CoachId).HasColumnName("Coach_ID");

                entity.Property(e => e.IsCanseled)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("Is_canseled");

                entity.Property(e => e.TrainingDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Training_date_time");

                entity.Property(e => e.TrainingDuration)
                    .HasColumnType("numeric(5, 3)")
                    .HasColumnName("Training_duration");

                entity.Property(e => e.TrainingType)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("Training_type");

                entity.Property(e => e.VisitorId).HasColumnName("Visitor_ID");

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.IndividualTrainings)
                    .HasForeignKey(d => d.CoachId)
                    .HasConstraintName("I_training_coach_FK");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.IndividualTrainings)
                    .HasForeignKey(d => d.VisitorId)
                    .HasConstraintName("Training_visitor_FK");
            });

            modelBuilder.Entity<SectionVisitor>(entity =>
            {
                entity.ToTable("Section_visitors");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SportSectionId).HasColumnName("Sport_section_ID");

                entity.Property(e => e.VisitorId).HasColumnName("Visitor_ID");

                entity.HasOne(d => d.SportSection)
                    .WithMany(p => p.SectionVisitors)
                    .HasForeignKey(d => d.SportSectionId)
                    .HasConstraintName("Sport_section_FK");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.SectionVisitors)
                    .HasForeignKey(d => d.VisitorId)
                    .HasConstraintName("Section_visitor_FK");
            });

            modelBuilder.Entity<SportSection>(entity =>
            {
                entity.ToTable("Sport_sections");

                entity.HasIndex(e => e.Name, "Section_name_UK")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "Sport_section_name_IX");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CoachesNumber)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("Coaches_number");

                entity.Property(e => e.DateOfCreation)
                    .HasColumnType("date")
                    .HasColumnName("Date_of_creation");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SportTypeId).HasColumnName("Sport_type_ID");

                entity.Property(e => e.VisitorsMaxNumber)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("Visitors_max_number");

                entity.Property(e => e.VisitorsNumber)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("Visitors_number");

                entity.HasOne(d => d.SportType)
                    .WithMany(p => p.SportSections)
                    .HasForeignKey(d => d.SportTypeId)
                    .HasConstraintName("Section_type_FK");
            });

            modelBuilder.Entity<SportTeam>(entity =>
            {
                entity.ToTable("Sport_teams");

                entity.HasIndex(e => e.Name, "Sport_team_name_IX");

                entity.HasIndex(e => e.Name, "Team_name_UK")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateOfCreation)
                    .HasColumnType("date")
                    .HasColumnName("Date_of_creation");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PlayersNumber)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("Players_number");

                entity.Property(e => e.RewardNumber)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("Reward_number");

                entity.Property(e => e.SportSectionId).HasColumnName("Sport_section_ID");

                entity.HasOne(d => d.SportSection)
                    .WithMany(p => p.SportTeams)
                    .HasForeignKey(d => d.SportSectionId)
                    .HasConstraintName("Team_sport_section_FK");
            });

            modelBuilder.Entity<SportType>(entity =>
            {
                entity.ToTable("Sport_types");

                entity.HasIndex(e => e.Name, "Sport_type_name_IX");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsTeamplay)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("Is_teamplay");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TeamPlayer>(entity =>
            {
                entity.ToTable("Team_players");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PlayerRole)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Player_role");

                entity.Property(e => e.SportTeamId).HasColumnName("Sport_team_ID");

                entity.Property(e => e.TeamNumber)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("Team_number");

                entity.Property(e => e.VisitorId).HasColumnName("Visitor_ID");

                entity.HasOne(d => d.SportTeam)
                    .WithMany(p => p.TeamPlayers)
                    .HasForeignKey(d => d.SportTeamId)
                    .HasConstraintName("Sport_team_FK");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.TeamPlayers)
                    .HasForeignKey(d => d.VisitorId)
                    .HasConstraintName("Player_FK");
            });

            modelBuilder.Entity<TeamTraining>(entity =>
            {
                entity.ToTable("Team_trainings");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CoachId).HasColumnName("Coach_ID");

                entity.Property(e => e.IsCanseled)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("Is_canseled");

                entity.Property(e => e.SportTeamId).HasColumnName("Sport_team_ID");

                entity.Property(e => e.TrainingDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Training_date_time");

                entity.Property(e => e.TrainingDuration)
                    .HasColumnType("numeric(5, 3)")
                    .HasColumnName("Training_duration");

                entity.Property(e => e.TrainingType)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("Training_type");

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.TeamTrainings)
                    .HasForeignKey(d => d.CoachId)
                    .HasConstraintName("Training_coach_FK");

                entity.HasOne(d => d.SportTeam)
                    .WithMany(p => p.TeamTrainings)
                    .HasForeignKey(d => d.SportTeamId)
                    .HasConstraintName("T_training_team_FK");
            });

            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.HasIndex(e => new { e.FirstName, e.SecondName }, "Visitor_name_IX");

                entity.HasIndex(e => e.PhoneNumber, "Visitor_phone_UK")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Age).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("First_name");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("Phone_number");

                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Second_name");

                entity.Property(e => e.Sex).HasMaxLength(1);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
