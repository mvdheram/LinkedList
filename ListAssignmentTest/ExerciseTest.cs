using System;
using System.Collections.Generic;
using ListAssignment;
using Xunit;

namespace ListAssignmentTest
{
    public class ExerciseTest
    {
        [Fact]
        public void TestAddAtStart()
        {
            TestAddAtStartInternal(new StudentList());
        }


        public static void TestAddAtStartInternal(IStudentList list)
        {
            Student student = new Student("Meher", 23, 7777, 1.0);
            list.AddAtStart(student);
            list.PrintList();
        }




      
          
        }
    }
