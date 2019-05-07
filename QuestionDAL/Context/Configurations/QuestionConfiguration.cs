
using RandomQuestionInterview.QuestionDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RandomQuestionInterview.QuestionDAL.Context.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            // Mapping for table
            builder.ToTable("Questions", "QDB");
            // Primary key
            builder.HasKey(p => p.QuestionId);
            // Generate property on Add
            builder.Property(p => p.QuestionId).ValueGeneratedOnAdd();
            // Set mapping for columns
            builder.Property(p => p.QuestionText).HasColumnType("varchar(max)").IsRequired();
        }
    }
}
