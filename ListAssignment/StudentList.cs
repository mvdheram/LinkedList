using System;
using System.IO;
using System.Text;

namespace ListAssignment
{

    // Creates a new Node with data of type student and next of type Node
    public class Node
    {
        public Student data;
        public Node next;
        public Node(Student d)
        {
            data = d;
            next = null;
        }

    }

    public class StudentList : IStudentList

    {

        public Node head;
        int count = 0;

        // Creates a New node of type student at the end of the list
        public void AddAtEnd(Student student)

        {

            Node temp = head;

            if (head == null)  // Check if the first node is null, if true create new head node of student 
            {
                head = new Node(student);
            }

            else // Iterate over list till the end, then add new node 
            {
                while (temp.next != null)
                {
                    temp = temp.next;
                }

                temp.next = new Node(student);

            }
            count++;
        }


        // Creates a new Node of student and adds at the start of the list
        public void AddAtStart(Student student)
        {

            if (head == null) // Check if the first node is null, if true create new head node of student 
            {
                head = new Node(student);

            }
            else // Create a new Node of student and add at the start of the list which becomes head node
            {
                Node temp = new Node(student);
                temp.next = head;
                head = temp;

            }
            count++;
        }


        // Remove the first Node of the list and returnes to the caller. If no element is present, will throw an Exception 
        public Student RemoveFirst()
        {

            if (head != null)
            {
                Node temp = head;
                head = head.next;
                count--;
                return temp.data;

            }


            else
            {

                throw new System.InvalidOperationException("Null list exception");
            }
            
        }



        // Prints the list of Nodes iterating over the head node
        public void PrintList()
        {
            Node temp = head;
            while (temp != null)
            {
                {
                    if (temp.data.Name != null) { Console.Write(" |Name" + "|->" + temp.data.Name + "   |Age" + " |->" + temp.data.Age + "    |Matriculation Number" + " |->" + temp.data.MatriculationNumber + "    |Grade" + " |->" + String.Format("{0:0.0}", temp.data.Grade)); }
                    Console.WriteLine();
                    temp = temp.next;

                }
            }

        }

        /// <summary>
        /// Replace the student having Identifier i.e (Matriculation Number) with new student. If Node to be replaced is the first Node then new student next Node is made 
        /// to point next node of head. The head is updated with the new student node. If the node to be replaced is in the middle, the  previous node and temp node to be 
        /// replaced are found through iteration. New student node next node will point to temp next and previous node next will point to new student node. If the list is 
        /// empty null is returned.
        /// </summary>
        /// <param name="studentIdentifier">MatriculationNumber</param>
        /// <param name="newStudent">newStud</param>
        public void Replace(object studentIdentifier, Student newStudent)
        {
            Node newStud = new Node(newStudent);
            Node temp = head;
            Node prev = null;

            if (temp != null && temp.data.Identifier.Equals(studentIdentifier)) // checks if the node to be replaced is the first node
            {
                newStud.next = temp.next;
                temp = newStud;
                head = temp;
                return;

            }
            while (temp != null && !temp.data.Identifier.Equals(studentIdentifier)) //  if node is in the middle iterate to find the previous node and temp node to be replaced
            {
                prev = temp;
                temp = temp.next;
            }
            if (temp == null)
            {
                return;
            }
            newStud.next = temp.next;
            prev.next = newStud;

        }
        /// <summary>
        /// Reads the file path as string line by line. Each part of the line is read by splitting the line with whitespace as delimiter and using RemoveEmptyEntries
        /// to get each string as array of parts. As the text file given contains 4 fields in a line, each part in the line is read as a new student. The input read as string 
        /// are converted into int and double as defined in the constructor of student class. Each student is now added at the end of the list
        /// </summary>
        /// <param name="file">filepath</param>
        public void ReadFromFile(string file)
        {
            string text = System.IO.File.ReadAllText(file);
            string[] lines = System.IO.File.ReadAllLines(file);
            Console.WriteLine("Contents after adding to the end of list = ");
            char[] charSeparators = new char[] { ' ' };
            while(head!=null)
            {
                RemoveFirst();
            }
            count = 0;
            foreach (String line in lines)

            {
                String[] parts = line.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                Student s = new Student(parts[0], Int32.Parse(parts[1]), Int32.Parse(parts[2]), Convert.ToDouble(parts[3]));

                AddAtEnd(s);
            }

        }
        // returns the student at the perticular index
        public Student GetStudentAt(int index)
        {
            try
            {
                Node temp = head;

                if (index < Length())
                {
                    for (int i = 1; i <= index; i++)
                    {
                        {

                            temp = temp.next;
                        }
                    }
                    Console.WriteLine("student at index  " + index + " : " + temp.data.Name);
                    return temp.data;
                }

                else { return null; }

            }
            catch (Exception e)
            {

                Console.WriteLine("Argument not found exception" + e);
                return null;

            }

        }
        // returns the length of the list
        public int Length()
        {
            return count;


        }

    }
}

