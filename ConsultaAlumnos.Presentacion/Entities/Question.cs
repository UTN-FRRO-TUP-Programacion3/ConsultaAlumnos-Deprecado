﻿using ConsultaAlumnos.Presentacion.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaAlumnos.API.Entities
{
    public class Question
    {
        public Question()
        {
            CreationDate = DateTime.Now;
            LastModificationDate = DateTime.Now;
            QuestionState = QuestionState.WaitingProfessorAnwser;
        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey("ProfessorId")]
        public Professor AssignedProfessor { get; set; }
        public int ProfessorId { get; set; }
        [ForeignKey("CreatorStudentId")]
        public Student Student { get; set; }
        public int CreatorStudentId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
        //public ICollection<Alumno> Seguidores { get; set; } = new List<Alumno>();
        public ICollection<Response> Responses { get; set; } = new List<Response>();
        public QuestionState QuestionState { get; set; }
        public DateTime CreationDate { get; }
        public DateTime? EndDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
    }
}
