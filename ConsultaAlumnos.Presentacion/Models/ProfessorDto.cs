﻿namespace ConsultaAlumnos.Presentacion.Models
{
    public class ProfessorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CompleteName { get => Name + " " + LastName; }
    }
}