using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea03.Model
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
