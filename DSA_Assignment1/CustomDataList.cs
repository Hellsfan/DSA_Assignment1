using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Assignment1
{
    internal class CustomDataList
    {
        private string[] firstNames = new string[7] { "Ivan", "Georgi", "Ronaldo", "Donald", "Mickey", "Goofy", "Zoro" };
        private string[] lastNames = new string[7] { "Petrov", "Mouse", "Duck", "Messi", "Roger", "Ibrahimovic", "Uzumaki" };
        Random random = new Random();
        public Student[] arrayOfStudents;

        public int Length = 0;
       
        public Student firstStudent { get; set; }
        public Student lastStudent { get; set; }


        public CustomDataList(int _length)
        {
            arrayOfStudents = new Student[_length];
            
        }






        public void PopulateData()
        {
            int filledSpots = Length;
            for (int i = 0; i < arrayOfStudents.Length-filledSpots; i++)
            {

                arrayOfStudents[i+filledSpots] = new Student()
                {
                    firstName = firstNames[random.Next(0, 7)],
                    lastName = lastNames[random.Next(0, 7)],
                    studentNumber = i + 1,
                    studentScore = (float)random.Next(0, 100)
                };

                Length++;
            }
            firstStudent = arrayOfStudents[0];
            lastStudent = arrayOfStudents[arrayOfStudents.Length-1];
        }           //Done

        public void AddStudent(Student student)
        {
            if (arrayOfStudents.Length == Length)
            {
                Student[] resizedArray = new Student[arrayOfStudents.Length + 1];

                Array.Copy(arrayOfStudents, 0, resizedArray, 0, arrayOfStudents.Length);

                arrayOfStudents = resizedArray;
            }

            arrayOfStudents[Length] = student;
            Length++;

            firstStudent = arrayOfStudents[0];
            lastStudent = arrayOfStudents[arrayOfStudents.Length - 1];
        }       //Done

        public Student GetStudentByIndex(int index)
        {
            if (index < 0 || index > arrayOfStudents.Length)
            {
                Console.WriteLine("Returned null, because given input is out of range");
                return null;
            }
            else
            {
                return arrayOfStudents[index];
            }


        }           //Done

        public void RemoveByIndex(int index)
        {
            if (index < 0 || index > arrayOfStudents.Length)
            {
                Console.WriteLine("Student Index is out of range");
            }
            else if (arrayOfStudents[index] == null)
            {
                Console.WriteLine("Student Index is empty already");
            }
            else
            {
                arrayOfStudents[index] = null;
                rearangeAndTrim();
                Length--;

                if (arrayOfStudents.Length == 0)
                {
                    firstStudent = null;
                    lastStudent = null;
                }
                else
                {
                    firstStudent = arrayOfStudents[0];
                    lastStudent = arrayOfStudents[arrayOfStudents.Length - 1];
                }
            }



        }           //Done

        public void RemoveFirst()
        {
            arrayOfStudents[0] = null;
            rearangeAndTrim();
            Length--;

            if (arrayOfStudents.Length == 0)
            {
                firstStudent = null;
                lastStudent = null;
            }
            else
            {
                firstStudent = arrayOfStudents[0];
                lastStudent = arrayOfStudents[arrayOfStudents.Length - 1];
            }
        }               //Done
        public void RemoveLast()
        {
            arrayOfStudents[Length - 1] = null;
            rearangeAndTrim();
            Length--;

            if (arrayOfStudents.Length == 0)
            {
                firstStudent = null;
                lastStudent = null;
            }
            else
            {
                firstStudent = arrayOfStudents[0];
                lastStudent = arrayOfStudents[arrayOfStudents.Length - 1];
            }
        }               //Done

        public void DisplayList()
        {
            int counter = 1;
            Console.WriteLine($"Current Length of list is:{Length}");
            foreach (Student student in arrayOfStudents)
            {
                if (student != null)
                {
                    Console.WriteLine($"Student {counter}: {student.firstName} {student.lastName}, student number: {student.studentNumber}, Average score: {student.studentScore}");
                    counter++;
                }
            }

        }       //Done

        private void rearangeAndTrim()
        {
            Student[] fixedArray = new Student[arrayOfStudents.Length];

            int counter = 0;

            foreach (Student student in arrayOfStudents)
            {
                if (student != null)
                {
                    fixedArray[counter] = student;
                    counter++;
                }
            }

            Student[] trimmedArray = new Student[counter];

            Array.Copy(fixedArray, trimmedArray, counter);

            arrayOfStudents = trimmedArray;


        }       //Secret method, no need for implement
    }
}
