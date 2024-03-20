using System;
using System.Collections.Generic;
using Examination.Models;
using Microsoft.EntityFrameworkCore;

namespace Examination.data;

public partial class ExamContext : DbContext
{
    public ExamContext()
    {
    }

    public ExamContext(DbContextOptions<ExamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<InstructorTrackCourse> InstructorTrackCourses { get; set; }

    public virtual DbSet<MultiChoicesQuestionAnswer> MultiChoicesQuestionAnswers { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentExam> StudentExams { get; set; }

    public virtual DbSet<StudentExamAnswer> StudentExamAnswers { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    public virtual DbSet<TrackBranch> TrackBranches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Examination_System_DataBase;Integrated Security=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Branch__3214EC2778E6DE22");

            entity.ToTable("Branch");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BuildingNumber).HasColumnName("Building_Number");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Street).HasMaxLength(100);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__course__3214EC27041F7381");

            entity.ToTable("course");

            entity.HasIndex(e => e.Name, "UQ__course__737584F656F6F26F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Exam__3214EC2768D245CD");

            entity.ToTable("Exam");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Duration).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Course).WithMany(p => p.Exams)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Exam__Course_ID__5070F446");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Instruct__3214EC27F54B2735");

            entity.ToTable("Instructor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BranchId).HasColumnName("Branch_ID");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.DateOfBirth).HasColumnName("Date_of_birth");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fname)
                .HasMaxLength(20)
                .HasColumnName("FName");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Lname)
                .HasMaxLength(20)
                .HasColumnName("LName");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Street).HasMaxLength(50);

            entity.HasOne(d => d.Branch).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__Instructo__Branc__398D8EEE");
        });

        modelBuilder.Entity<InstructorTrackCourse>(entity =>
        {
            entity.HasKey(e => new { e.InstructorId, e.TrackId, e.CourseId }).HasName("PK__Instruct__D2A6B8E730C5CB92");

            entity.ToTable("Instructor_Track_Course");

            entity.Property(e => e.InstructorId).HasColumnName("Instructor_ID");
            entity.Property(e => e.TrackId).HasColumnName("Track_ID");
            entity.Property(e => e.CourseId).HasColumnName("Course_ID");

            entity.HasOne(d => d.Course).WithMany(p => p.InstructorTrackCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Instructo__Cours__5FB337D6");

            entity.HasOne(d => d.Instructor).WithMany(p => p.InstructorTrackCourses)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK__Instructo__Instr__60A75C0F");

            entity.HasOne(d => d.Track).WithMany(p => p.InstructorTrackCourses)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("FK__Instructo__Track__619B8048");
        });

        modelBuilder.Entity<MultiChoicesQuestionAnswer>(entity =>
        {
            entity.HasKey(e => new { e.QuestionId, e.NumberOfChoice }).HasName("PK__Multi_Ch__90D0E1113D9DF090");

            entity.ToTable("Multi_Choices_Question_Answers");

            entity.Property(e => e.QuestionId).HasColumnName("Question_ID");
            entity.Property(e => e.NumberOfChoice).HasColumnName("Number_OF_Choice");
            entity.Property(e => e.BodyOfChoice)
                .HasMaxLength(200)
                .HasColumnName("Body_OF_Choice");

            entity.HasOne(d => d.Question).WithMany(p => p.MultiChoicesQuestionAnswers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__Multi_Cho__Quest__4D94879B");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC2758D06400");

            entity.ToTable("Question");

            entity.HasIndex(e => e.QuestionBody, "UQ__Question__187959AE2782B8A0").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CourseId).HasColumnName("course_ID");
            entity.Property(e => e.QuestionAnswer).HasColumnName("Question_Answer");
            entity.Property(e => e.QuestionBody)
                .HasMaxLength(200)
                .HasColumnName("Question_Body");
            entity.Property(e => e.QuestionType).HasColumnName("Question_Type");
            entity.Property(e => e.TopicId).HasColumnName("Topic_ID");

            entity.HasOne(d => d.Topic).WithMany(p => p.Questions)
                .HasForeignKey(d => new { d.TopicId, d.CourseId })
                .HasConstraintName("FK__Question__4AB81AF0");

            entity.HasMany(d => d.Exams).WithMany(p => p.Questions)
                .UsingEntity<Dictionary<string, object>>(
                    "ExamQuestion",
                    r => r.HasOne<Exam>().WithMany()
                        .HasForeignKey("ExamId")
                        .HasConstraintName("FK__Exam_Ques__Exam___5CD6CB2B"),
                    l => l.HasOne<Question>().WithMany()
                        .HasForeignKey("QuestionId")
                        .HasConstraintName("FK__Exam_Ques__Quest__5BE2A6F2"),
                    j =>
                    {
                        j.HasKey("QuestionId", "ExamId").HasName("PK__Exam_Que__3CCAC8612BE87766");
                        j.ToTable("Exam_Question");
                        j.IndexerProperty<int>("QuestionId").HasColumnName("Question_ID");
                        j.IndexerProperty<int>("ExamId").HasColumnName("Exam_ID");
                    });
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC2788E2EAFF");

            entity.ToTable("Student");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BranchId).HasColumnName("Branch_ID");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.DateOfBirth).HasColumnName("Date_of_birth");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fname)
                .HasMaxLength(20)
                .HasColumnName("FName");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Lname)
                .HasMaxLength(20)
                .HasColumnName("LName");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.TrackId).HasColumnName("Track_ID");

            entity.HasOne(d => d.Branch).WithMany(p => p.Students)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__Student__Track_I__4222D4EF");

            entity.HasOne(d => d.Track).WithMany(p => p.Students)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("FK__Student__Track_I__4316F928");
        });

        modelBuilder.Entity<StudentExam>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ExamId }).HasName("PK__Student___2E8CC50BA1E06D21");

            entity.ToTable("Student_Exam");

            entity.Property(e => e.StudentId).HasColumnName("Student_ID");
            entity.Property(e => e.ExamId).HasColumnName("Exam_ID");

            entity.HasOne(d => d.Exam).WithMany(p => p.StudentExams)
                .HasForeignKey(d => d.ExamId)
                .HasConstraintName("FK__Student_E__Exam___59063A47");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentExams)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Student_E__Stude__5812160E");
        });

        modelBuilder.Entity<StudentExamAnswer>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ExamId, e.QuestionId }).HasName("PK__Student___E93C77EF9B09EB58");

            entity.ToTable("Student_Exam_Answers");

            entity.Property(e => e.StudentId).HasColumnName("Student_ID");
            entity.Property(e => e.ExamId).HasColumnName("Exam_ID");
            entity.Property(e => e.QuestionId).HasColumnName("Question_ID");
            entity.Property(e => e.StudentAnswer).HasColumnName("Student_Answer");

            entity.HasOne(d => d.Exam).WithMany(p => p.StudentExamAnswers)
                .HasForeignKey(d => d.ExamId)
                .HasConstraintName("FK__Student_E__Exam___656C112C");

            entity.HasOne(d => d.Question).WithMany(p => p.StudentExamAnswers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__Student_E__Quest__66603565");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentExamAnswers)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Student_E__Stude__6477ECF3");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.CourseId }).HasName("PK__topic__4AE5131DDAB2CAD2");

            entity.ToTable("topic");

            entity.HasIndex(e => e.Name, "UQ__topic__737584F698C831B7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CourseId).HasColumnName("course_ID");
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.Course).WithMany(p => p.Topics)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__topic__course_ID__46E78A0C");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Track__3214EC27FB549E1A");

            entity.ToTable("Track");

            entity.HasIndex(e => e.Name, "UQ__Track__737584F6D0122AB4").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<TrackBranch>(entity =>
        {
            entity.HasKey(e => new { e.BranchId, e.TrackId }).HasName("PK__Track_Br__E71472299BE36960");

            entity.ToTable("Track_Branch");

            entity.Property(e => e.BranchId).HasColumnName("Branch_ID");
            entity.Property(e => e.TrackId).HasColumnName("Track_ID");
            entity.Property(e => e.SupervisorId).HasColumnName("Supervisor_ID");

            entity.HasOne(d => d.Branch).WithMany(p => p.TrackBranches)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__Track_Bra__Branc__534D60F1");

            entity.HasOne(d => d.Supervisor).WithMany(p => p.TrackBranches)
                .HasForeignKey(d => d.SupervisorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Track_Bra__Super__5535A963");

            entity.HasOne(d => d.Track).WithMany(p => p.TrackBranches)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("FK__Track_Bra__Track__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
