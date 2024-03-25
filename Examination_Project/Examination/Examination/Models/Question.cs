using System;
using System.Collections.Generic;

namespace Examination.Models;

public partial class Question
{
    public int Id { get; set; }

    public string QuestionBody { get; set; } = null!;

    public bool QuestionType { get; set; }

    public byte QuestionAnswer { get; set; }

    public int TopicId { get; set; }

    public int CourseId { get; set; }

    public virtual ICollection<MultiChoicesQuestionAnswer> MultiChoicesQuestionAnswers { get; set; } = [];
       

    public virtual ICollection<StudentExamAnswer> StudentExamAnswers { get; set; } = new List<StudentExamAnswer>();

    public virtual Topic? Topic { get; set; } = null!;

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
}
