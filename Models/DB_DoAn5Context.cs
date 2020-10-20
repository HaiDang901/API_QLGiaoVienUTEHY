using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DB_DoAn5.Models
{
    public partial class DB_DoAn5Context : DbContext
    {
        public DB_DoAn5Context()
        {
        }

        public DB_DoAn5Context(DbContextOptions<DB_DoAn5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Teacher_Academic> Teacher_Academic { get; set; }
        public virtual DbSet<Teacher_Contract> Teacher_Contract { get; set; }
        public virtual DbSet<Teacher_DiscipRewards> Teacher_DiscipRewards { get; set; }
        public virtual DbSet<Teacher_Faculty> Teacher_Faculty { get; set; }
        public virtual DbSet<Teacher_Position> Teacher_Position { get; set; }
        public virtual DbSet<Teacher_RanksOfficer> Teacher_RanksOfficer { get; set; }
        public virtual DbSet<Teacher_Salary> Teacher_Salary { get; set; }
        public virtual DbSet<Teacher_SalaryRaise> Teacher_SalaryRaise { get; set; }
        public virtual DbSet<Teacher_Scientist> Teacher_Scientist { get; set; }
        public virtual DbSet<Teacher_SignUp> Teacher_SignUp { get; set; }
        public virtual DbSet<Teacher_SubLession> Teacher_SubLession { get; set; }
        public virtual DbSet<Teacher_Subject> Teacher_Subject { get; set; }
        public virtual DbSet<Teacher_Wage> Teacher_Wage { get; set; }
        public virtual DbSet<user2> user2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\;Initial Catalog=DB_DoAn5;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.ID_Teacher)
                    .HasName("PK__Teacher__99ED4E10FF99DCC3");

                entity.Property(e => e.ID_Teacher)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AddressAdmin_Teacher).HasMaxLength(255);

                entity.Property(e => e.Address_Teacher).HasMaxLength(255);

                entity.Property(e => e.CurrentAddress_Teacher).HasMaxLength(255);

                entity.Property(e => e.DP1).HasColumnType("text");

                entity.Property(e => e.DP2).HasColumnType("text");

                entity.Property(e => e.DateBirth_Teacher).HasColumnType("date");

                entity.Property(e => e.DateRange_Teacher).HasColumnType("date");

                entity.Property(e => e.DayAdim_Teacher).HasColumnType("date");

                entity.Property(e => e.Email_Teacher).HasMaxLength(255);

                entity.Property(e => e.Experience_Teacher).HasColumnType("text");

                entity.Property(e => e.First_Name).HasMaxLength(255);

                entity.Property(e => e.IdentityCard_Teacher)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image_Teacher).HasMaxLength(255);

                entity.Property(e => e.IssuedBy_Teacher).HasMaxLength(100);

                entity.Property(e => e.Last_Name).HasMaxLength(255);

                entity.Property(e => e.Level_Teacher).HasMaxLength(255);

                entity.Property(e => e.Name_Teacher).HasMaxLength(255);

                entity.Property(e => e.Nation_Teacher).HasMaxLength(255);

                entity.Property(e => e.Phone__Teacher)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Religion_Teacher).HasMaxLength(255);

                entity.HasOne(d => d.ID_PositionNavigation)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.ID_Position)
                    .HasConstraintName("FK__Teacher__ID_Posi__4316F928");

                entity.HasOne(d => d.ID_RanksNavigation)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.ID_Ranks)
                    .HasConstraintName("FK__Teacher__ID_Rank__440B1D61");

                entity.HasOne(d => d.ID_SubjectNavigation)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.ID_Subject)
                    .HasConstraintName("FK__Teacher__ID_Subj__4222D4EF");

                entity.HasOne(d => d.ID_WageNavigation)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.ID_Wage)
                    .HasConstraintName("FK__Teacher__ID_Wage__44FF419A");
            });

            modelBuilder.Entity<Teacher_Academic>(entity =>
            {
                entity.HasKey(e => e.ID_Academic)
                    .HasName("PK__Teacher___BF66E3554AE1BF62");

                entity.Property(e => e.Certificate_Academic).HasMaxLength(255);

                entity.Property(e => e.DP1).HasColumnType("text");

                entity.Property(e => e.DP2).HasColumnType("text");

                entity.Property(e => e.ID_Teacher)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LevelIT_Academic).HasMaxLength(255);

                entity.Property(e => e.LevelLag_Academic).HasMaxLength(255);

                entity.Property(e => e.Name_Academic).HasMaxLength(255);

                entity.Property(e => e.Specialy__Academic).HasMaxLength(255);

                entity.Property(e => e.UnitWork_Academic).HasMaxLength(255);

                entity.Property(e => e.YearGredu_Academic).HasColumnType("date");

                entity.Property(e => e.YeasTeaching_Academic)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.ID_TeacherNavigation)
                    .WithMany(p => p.Teacher_Academic)
                    .HasForeignKey(d => d.ID_Teacher)
                    .HasConstraintName("FK__Teacher_A__ID_Te__5CD6CB2B");
            });

            modelBuilder.Entity<Teacher_Contract>(entity =>
            {
                entity.HasKey(e => e.ID_Contract)
                    .HasName("PK__Teacher___B16D2ED17FC50D12");

                entity.Property(e => e.Come_Contract).HasColumnType("date");

                entity.Property(e => e.DP1).HasColumnType("text");

                entity.Property(e => e.DP2).HasColumnType("text");

                entity.Property(e => e.ID_Teacher)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Note_Contract).HasColumnType("ntext");

                entity.Property(e => e.Since_Contract).HasColumnType("date");

                entity.Property(e => e.Type_Contract).HasMaxLength(255);

                entity.HasOne(d => d.ID_TeacherNavigation)
                    .WithMany(p => p.Teacher_Contract)
                    .HasForeignKey(d => d.ID_Teacher)
                    .HasConstraintName("FK__Teacher_C__ID_Te__47DBAE45");
            });

            modelBuilder.Entity<Teacher_DiscipRewards>(entity =>
            {
                entity.HasKey(e => e.ID_DisRewards)
                    .HasName("PK__Teacher___855A18E1B70E23B0");

                entity.Property(e => e.DP1).HasColumnType("text");

                entity.Property(e => e.Day_DisRewards).HasColumnType("date");

                entity.Property(e => e.Form_DisRewards).HasMaxLength(255);

                entity.Property(e => e.ID_Teacher)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name_DisRewards).HasMaxLength(255);

                entity.Property(e => e.Note_DisRewards).HasColumnType("ntext");

                entity.Property(e => e.Reason_DisRewards).HasColumnType("ntext");

                entity.HasOne(d => d.ID_TeacherNavigation)
                    .WithMany(p => p.Teacher_DiscipRewards)
                    .HasForeignKey(d => d.ID_Teacher)
                    .HasConstraintName("FK__Teacher_D__ID_Te__4D94879B");
            });

            modelBuilder.Entity<Teacher_Faculty>(entity =>
            {
                entity.HasKey(e => e.ID_Faculty)
                    .HasName("PK__Teacher___F60C0060213CC446");

                entity.Property(e => e.Address_Faculty).HasMaxLength(225);

                entity.Property(e => e.Learder_Faculty).HasMaxLength(255);

                entity.Property(e => e.Name_Faculty).HasMaxLength(225);

                entity.Property(e => e.Website_Facuty)
                    .HasMaxLength(225)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Teacher_Position>(entity =>
            {
                entity.HasKey(e => e.ID_Position)
                    .HasName("PK__Teacher___8F963ECE0AC4D9C8");

                entity.Property(e => e.Name_Position).HasMaxLength(255);

                entity.Property(e => e.Note_Position).HasMaxLength(255);

                entity.Property(e => e.Respon_Position).HasMaxLength(255);

                entity.HasOne(d => d.ID_FacultyNavigation)
                    .WithMany(p => p.Teacher_Position)
                    .HasForeignKey(d => d.ID_Faculty)
                    .HasConstraintName("FK__Teacher_P__ID_Fa__3B75D760");
            });

            modelBuilder.Entity<Teacher_RanksOfficer>(entity =>
            {
                entity.HasKey(e => e.ID_Ranks)
                    .HasName("PK__Teacher___B4DC0623C29C17B7");

                entity.Property(e => e.Code_Ranks)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DP1).HasColumnType("text");

                entity.Property(e => e.DP2).HasColumnType("text");

                entity.Property(e => e.Descript_Ranks).HasMaxLength(255);

                entity.Property(e => e.Name_Ranks).HasMaxLength(255);

                entity.Property(e => e.Note_Ranks).HasColumnType("ntext");
            });

            modelBuilder.Entity<Teacher_Salary>(entity =>
            {
                entity.HasKey(e => e.ID_Salary)
                    .HasName("PK__Teacher___28CBC2C428456BA7");

                entity.Property(e => e.DP1).HasColumnType("text");

                entity.Property(e => e.DateIcre_Salary).HasColumnType("date");

                entity.Property(e => e.Date_Salary).HasMaxLength(255);

                entity.HasOne(d => d.ID_WageNavigation)
                    .WithMany(p => p.Teacher_Salary)
                    .HasForeignKey(d => d.ID_Wage)
                    .HasConstraintName("FK__Teacher_S__ID_Wa__4AB81AF0");
            });

            modelBuilder.Entity<Teacher_SalaryRaise>(entity =>
            {
                entity.HasKey(e => e.ID_Raise)
                    .HasName("PK__Teacher___B31B96E62A2DE5F0");

                entity.HasOne(d => d.ID_SalaryNavigation)
                    .WithMany(p => p.Teacher_SalaryRaise)
                    .HasForeignKey(d => d.ID_Salary)
                    .HasConstraintName("FK__Teacher_S__ID_Sa__5070F446");

                entity.HasOne(d => d.ID_WageNavigation)
                    .WithMany(p => p.Teacher_SalaryRaise)
                    .HasForeignKey(d => d.ID_Wage)
                    .HasConstraintName("FK__Teacher_S__ID_Wa__5165187F");
            });

            modelBuilder.Entity<Teacher_Scientist>(entity =>
            {
                entity.HasKey(e => e.ID_Scientist)
                    .HasName("PK__Teacher___0F6B33E9AE774A04");

                entity.Property(e => e.DP1).HasColumnType("text");

                entity.Property(e => e.DP2).HasColumnType("text");

                entity.Property(e => e.ID_Teacher)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Link_Scientist).HasMaxLength(255);

                entity.Property(e => e.Name_Scientist).HasMaxLength(255);

                entity.Property(e => e.Note_Scientist).HasColumnType("ntext");

                entity.Property(e => e.Type_Scientist).HasColumnType("ntext");

                entity.HasOne(d => d.ID_TeacherNavigation)
                    .WithMany(p => p.Teacher_Scientist)
                    .HasForeignKey(d => d.ID_Teacher)
                    .HasConstraintName("FK__Teacher_S__ID_Te__59FA5E80");
            });

            modelBuilder.Entity<Teacher_SignUp>(entity =>
            {
                entity.HasKey(e => e.ID_SignUp)
                    .HasName("PK__Teacher___AAF06CED74383497");

                entity.Property(e => e.DP1).HasColumnType("text");

                entity.Property(e => e.DP2).HasColumnType("text");

                entity.Property(e => e.Date_SignUp).HasColumnType("datetime");

                entity.Property(e => e.ID_Teacher)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Note_SignUp).HasColumnType("ntext");

                entity.HasOne(d => d.ID_SubNavigation)
                    .WithMany(p => p.Teacher_SignUp)
                    .HasForeignKey(d => d.ID_Sub)
                    .HasConstraintName("FK__Teacher_S__ID_Su__571DF1D5");

                entity.HasOne(d => d.ID_TeacherNavigation)
                    .WithMany(p => p.Teacher_SignUp)
                    .HasForeignKey(d => d.ID_Teacher)
                    .HasConstraintName("FK__Teacher_S__ID_Te__5629CD9C");
            });

            modelBuilder.Entity<Teacher_SubLession>(entity =>
            {
                entity.HasKey(e => e.ID_Sub)
                    .HasName("PK__Teacher___27F89E888C4E4DC4");

                entity.Property(e => e.DP1).HasColumnType("text");

                entity.Property(e => e.Name_Sub).HasMaxLength(255);

                entity.Property(e => e.Type_Sub).HasMaxLength(255);
            });

            modelBuilder.Entity<Teacher_Subject>(entity =>
            {
                entity.HasKey(e => e.ID_Subject)
                    .HasName("PK__Teacher___20028FF457D1F0EE");

                entity.Property(e => e.Address_Subject).HasMaxLength(225);

                entity.Property(e => e.Leader).HasMaxLength(255);

                entity.Property(e => e.Leader_Assis).HasMaxLength(255);

                entity.Property(e => e.Name_Subject).HasMaxLength(225);

                entity.Property(e => e.Phone_Subject)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ID_FacultyNavigation)
                    .WithMany(p => p.Teacher_Subject)
                    .HasForeignKey(d => d.ID_Faculty)
                    .HasConstraintName("FK__Teacher_S__ID_Fa__38996AB5");
            });

            modelBuilder.Entity<Teacher_Wage>(entity =>
            {
                entity.HasKey(e => e.ID_Wage)
                    .HasName("PK__Teacher___B9B9813537235CEE");

                entity.Property(e => e.Group_Wage).HasColumnType("ntext");

                entity.Property(e => e.Name_Wage).HasMaxLength(255);
            });

                modelBuilder.Entity<user2>(entity =>
                {
                entity.HasKey(e => e.user_id)
                .HasName("PK__Teacher__99ED4E10FF99DCC8");

                entity.Property(e => e.user_id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.hoten).HasMaxLength(150);

                entity.Property(e => e.ngaysinh).HasColumnType("date");

                entity.Property(e => e.diachi).HasMaxLength(250);

                entity.Property(e => e.gioitinh).HasMaxLength(30);

                entity.Property(e => e.email).HasMaxLength(150);

                entity.Property(e => e.taikhoan).HasMaxLength(30);

                entity.Property(e => e.matkhau).HasMaxLength(60);

                entity.Property(e => e.role).HasMaxLength(255);


                entity.Property(e => e.image_url).HasMaxLength(300);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
