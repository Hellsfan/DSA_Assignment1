using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Assignment1
{
    internal class CustomDataList : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.firstName.CompareTo(y.firstName);
        }
        
        public int CompareLName(Student x, Student y)
        {
            return x.lastName.CompareTo(y.lastName);
        }


        private string[] firstNames = new string[7] { "Ivan", "Georgi", "Ronaldo", "Donald", "Mickey", "Goofy", "Zoro" };
        private string[] lastNames = new string[7] { "Petrov", "Mouse", "Duck", "Messi", "Roger", "Ibrahimovic", "Uzumaki" };
        Random random = new Random();
        public Student[] arrayOfStudents;

        public int LastStudentIndex = 0;

        public Student firstStudent { get; set; }
        public Student lastStudent { get; set; }
        public Student bestScore  { get; set; }
        public Student worstScore { get; set; }


        public CustomDataList(int _length)
        {
            arrayOfStudents = new Student[_length];

        }






        public void PopulateData()
        {
            int filledSpots = LastStudentIndex;
            for (int i = 0; i < arrayOfStudents.Length - filledSpots; i++)
            {

                arrayOfStudents[i + filledSpots] = new Student()
                {
                    firstName = firstNames[random.Next(0, 7)],
                    lastName = lastNames[random.Next(0, 7)],
                    studentNumber = i + 1,
                    studentScore = (int)random.Next(0, 100)
                };

                LastStudentIndex++;
            }
            firstStudent = arrayOfStudents[0];
            lastStudent = arrayOfStudents[arrayOfStudents.Length - 1];
        }           //Done

        public void AddStudent(Student student)
        {
            if (arrayOfStudents.Length == LastStudentIndex)
            {
                Student[] resizedArray = new Student[arrayOfStudents.Length + 1];

                Array.Copy(arrayOfStudents, 0, resizedArray, 0, arrayOfStudents.Length);

                arrayOfStudents = resizedArray;
            }

            arrayOfStudents[LastStudentIndex] = student;
            LastStudentIndex++;

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
                LastStudentIndex--;

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
            LastStudentIndex--;

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

            arrayOfStudents[arrayOfStudents.Length - 1] = null;
            rearangeAndTrim();
            LastStudentIndex--;

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
            Console.WriteLine($"Current Length of list is:{LastStudentIndex}");
            foreach (Student student in arrayOfStudents)
            {
                if (student != null)
                {
                    Console.WriteLine($"Student {counter}: {student.firstName} {student.lastName}, student number: {student.studentNumber}, Average score: {student.studentScore}");
                    counter++;
                }
            }

        }       //Done

        public void BubbleSortScore()
        {
            int n = LastStudentIndex;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arrayOfStudents[j] != null || arrayOfStudents[j + 1] != null)
                    {
                        if (arrayOfStudents[j].studentScore > arrayOfStudents[j + 1].studentScore)
                        {
                            // swap temp and arr[i] 
                            Student temp = arrayOfStudents[j];
                            arrayOfStudents[j] = arrayOfStudents[j + 1];
                            arrayOfStudents[j + 1] = temp;
                        }
                    }
                }
            }

        }
        
        public void BubbleSortName()
        {
            int n = LastStudentIndex;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arrayOfStudents[j]!=null||arrayOfStudents[j+1]!=null) {
                        if (Compare(arrayOfStudents[j], arrayOfStudents[j + 1]) == 1)
                        {
                            // swap temp and arr[i] 


                            Student temp = arrayOfStudents[j];
                            arrayOfStudents[j] = arrayOfStudents[j + 1];
                            arrayOfStudents[j + 1] = temp;
                        }
                        else if (Compare(arrayOfStudents[j], arrayOfStudents[j + 1]) == 0)
                        {
                            if (CompareLName(arrayOfStudents[j], arrayOfStudents[j + 1]) == 1)
                            {
                                Student temp = arrayOfStudents[j];
                                arrayOfStudents[j] = arrayOfStudents[j + 1];
                                arrayOfStudents[j + 1] = temp;
                            }
                        }
                    }
                }
            }
        }

        public void getFirstScore()
        {
            int currentBestScore = 0;
            for (int i = 0; i < LastStudentIndex; i++)
            {
                if (arrayOfStudents[i] != null)
                {
                    if (arrayOfStudents[i].studentScore > currentBestScore)
                    {
                        currentBestScore = arrayOfStudents[i].studentScore;
                        bestScore = arrayOfStudents[i];
                    }
                }
            }   
        }
        public void getLastScore()
        {
            int currentWorstScore = int.MaxValue;
            for (int i = 0; i < LastStudentIndex; i++)
            {
                if (arrayOfStudents[i] != null)
                {
                    if (arrayOfStudents[i].studentScore < currentWorstScore)
                    {
                        currentWorstScore = arrayOfStudents[i].studentScore;
                        worstScore = arrayOfStudents[i];
                    }
                }
            }
            
        }



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

        public bool checkIfStudentsExist()
        {
            bool studentsExist = false;


            if (arrayOfStudents.Length == 0)
            {

            }
            else
            {
                for (int i = 0; i < arrayOfStudents.Length; i++)
                {
                    if (arrayOfStudents[i] != null)
                    {
                        studentsExist = true;
                    }
                }
            }

            return studentsExist;
        }
    }
}
