using System;
using System.Collections.Generic;
using System.Text;

namespace Завдання_6
{
    partial class Student
    {
        public int History;
        public int Math;
        public int Ukrainian;
        public int English;

        public Student(string surname, string name, int course, int age, int History, int Math, int Ukrainian, int English)
        {
            this.surname = surname;
            this.name = name;
            this.course = course;
            this.age = age;
            this.History = History;
            this.Math = Math;
            this.Ukrainian = Ukrainian;
            this.English = English;
        }
    }
}