using System;
using System.Collections.Generic;
namespace ListAssignment
{
    public class Program
    {

        public static void Main(string[] args)
        {

            Student student1 = new Student("Alexander", 25, 13791, 2.0);
            Student student2 = new Student("Stefanie", 22, 39473, 1.7);
            Student student3 = new Student("Ousmane", 19, 19090, 1.0);
            Student student4 = new Student("Anja", 18, 55701, 3.0);

            IStudentList sa = new StudentList();
            sa.AddAtEnd(student1);
            sa.AddAtStart(student2);
            sa.AddAtEnd(student3);
            sa.ReadFromFile("C:/projectEXP/Data.txt"); 
            sa.RemoveFirst();
            sa.Replace(19090, student4);
            sa.PrintList();
            sa.GetStudentAt(0);
            Console.Read();
        }
     }
}
    
