using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Assignment1
{
    // Known bugs:
    //  1.Name for students can be left blank a.k.a null or a number can be given
    //  2.Student score and student number can be input as negative number
    //  3.Achieving complete unbreakability of the code is slowly destroying my sanity
    internal class Program
    {
        static void Main(string[] args)
        {
            bool listHasSlots = false;
            bool loop = true;
            bool populated = false;

            Console.WriteLine("Before we start, please choose the length of the list of students:");

            int length = 0;

            bool lengthIsNatural = false;
            while (lengthIsNatural == false)
            {
                length = validateInput(length, "Given length is not valid. Please input again.");
                if (length >= 0)
                {
                    lengthIsNatural= true;
                }
                else
                {
                    Console.WriteLine("Length must be a natural number. Please try again");
                }
            }
            CustomDataList list = new CustomDataList(length);
            list.firstStudent = null;
            list.lastStudent=null;

            if (length > 0)
            {
                listHasSlots = true;
            }
            while (loop)
            {
                int input = 0;
                Console.Clear();
                Console.WriteLine(
                    "Welcome to my assignment 1 for DSA made by yours truly Filip Petkov\n\n" +
                    "Please choose a program:\n\n" +
                    "1. Populate list with randomized stats.\n" +
                    "2. Display the list of students.\n" +
                    "3. Add a new student.\n" +
                    "4. Get student by index.\n" +
                    "5. Remove student by index.\n" +
                    "6. Remove first student in list.\n" +
                    "7. Remove last student in list.\n" +
                    "8. Sort the list of students.\n" +
                    "9. Display the student with best score.\n" +
                    "10. Display the student with worst score.\n" + 
                    "0. Exit program.\n\n"
                    );

                input = validateInput(input, "Given command is invalid. Please try again.");



                switch (input)
                {
                    
                    case 1:

                        if (listHasSlots == false)
                        {
                            Console.Clear();
                            Console.WriteLine("There are no slots in the list, therefore randomizer cannot fill it. Press enter to continue.");
                            Console.ReadLine();
                        }
                        else
                        {
                            if (populated == false)
                            {
                                list.PopulateData();
                                populated = true;
                                Console.Clear();
                                Console.WriteLine("Data populated successfuly. Press enter to continue.");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Data already populated. No need to populate it again. Press enter to continue");
                                Console.ReadLine();
                            }
                        }
                        break;


                    case 2:
                        Console.Clear();
                        list.DisplayList();
                        Console.WriteLine("\n\nPress enter to continue.");
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.Clear();
                        Student studentCase3 = new Student();
                        int inputStudentNumber = 0;
                        int inputstudentScore = 0;
                        Console.WriteLine("Please enter students first name:");
                        studentCase3.firstName = Console.ReadLine();
                        Console.WriteLine("Please enter students last name:");
                        studentCase3.lastName = Console.ReadLine();
                        Console.WriteLine("Please enter the students number:");
                        studentCase3.studentNumber = validateInput(inputStudentNumber, "Student number must be an integer. Please try again.");
                        Console.WriteLine("Please enter the students score:");
                        studentCase3.studentScore = validateInput(inputstudentScore, "Student score must be an integer. Please try again.");
                        list.AddStudent(studentCase3);
                        listHasSlots = true;
                        Console.WriteLine("\nStudent added successfuly. Press enter to continue");
                        Console.ReadLine();

                        break;

                    case 4:
                        if (list.checkIfStudentsExist()==false)
                        {
                            Console.Clear();
                            Console.WriteLine("There are no students available. Please add students first.");
                            Console.ReadLine();
                            break;
                        }

                        bool isInRangeCase4 = false;
                        int indexGet = 0;
                        int indexCase4 = 0;
                        Console.Clear();
                        if (listHasSlots == false)
                        {
                            Console.Clear();
                            Console.WriteLine("There are no slots in the list, therefore no students to get. Press enter to continue.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Student studentCase4 = new Student();
                            Console.WriteLine($"Please enter the wanted students index. (current possible index range is: 1 - {list.LastStudentIndex}");
                            while (isInRangeCase4 == false)
                            {
                                indexCase4 = validateInput(indexGet, "given Index is not an integer. Please try again.");
                                if (indexCase4 > 0 && indexCase4 <= list.LastStudentIndex)
                                {
                                    isInRangeCase4 = true;
                                }
                                else
                                {
                                    Console.WriteLine($"Given index is not between the possible range: 1 - {list.LastStudentIndex}");
                                }
                            }

                            studentCase4 = list.GetStudentByIndex(indexCase4 - 1);
                            Console.WriteLine($"Got the Student: {studentCase4.firstName} {studentCase4.lastName}, student number: {studentCase4.studentNumber}, Average score: {studentCase4.studentScore}");
                            Console.WriteLine("\nPress enter to continue.");
                            Console.ReadLine();
                        }
                        break;

                    case 5:
                        if (list.checkIfStudentsExist() == false)
                        {
                            Console.Clear();
                            Console.WriteLine("There are no students available. Please add students first.");
                            Console.ReadLine();
                            break;
                        }

                        if (listHasSlots == false)
                        {
                            Console.Clear();
                            Console.WriteLine("There are no slots in the list, therefore no students to remove. Press enter to continue.");
                            Console.ReadLine();
                        }
                        else
                        {
                            bool isInRangeCase5 = false;
                            int indexRemove = 0;
                            int indexCase5 = 0;
                            Console.Clear();
                            Console.WriteLine($"Please enter students index that must be removed. (current possible index range is: 1 - {list.LastStudentIndex}");

                            while (isInRangeCase5 == false)
                            {
                                indexCase5 = validateInput(indexRemove, "given Index is not an integer. Please try again.");
                                if (indexCase5 > 0 && indexCase5 <= list.LastStudentIndex)
                                {
                                    isInRangeCase5 = true;
                                }
                                else
                                {
                                    Console.WriteLine($"Given index is not between the possible range: 1 - {list.LastStudentIndex}");
                                }
                            }

                            list.RemoveByIndex(indexCase5 - 1);
                            Console.WriteLine("Student terminated successfuly...   (Press enter to continue)");
                            if(list.LastStudentIndex == 0)
                            {
                                listHasSlots = false;
                            }
                            Console.ReadLine();
                        }
                        break;

                    case 6:
                        if (list.checkIfStudentsExist() == false)
                        {
                            Console.Clear();
                            Console.WriteLine("There are no students available. Please add students first.");
                            Console.ReadLine();
                            break;
                        }

                        if (listHasSlots == false)
                        {
                            Console.Clear();
                            Console.WriteLine("There are no slots in the list, therefore no first student exists. Press enter to continue.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Removed first student: {list.firstStudent.firstName} {list.firstStudent.lastName}");
                            list.RemoveFirst();
                            if (list.LastStudentIndex == 0)
                            {
                                listHasSlots = false;
                            }
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                        }
                        break;

                    case 7:
                        if (list.checkIfStudentsExist() == false)
                        {
                            Console.Clear();
                            Console.WriteLine("There are no students available. Please add students first.");
                            Console.ReadLine();
                            break;
                        }

                        if (list.lastStudent == null)
                        {
                            Console.Clear();
                            Console.WriteLine("There is no last student available.");
                            Console.ReadLine();
                            break;
                        }

                        if (listHasSlots == false)
                        {
                            Console.Clear();
                            Console.WriteLine("There are no slots in the list, therefore no last student exists. Press enter to continue.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Removed last student: {list.lastStudent.firstName} {list.lastStudent.lastName}");
                            list.RemoveLast();
                            if (list.LastStudentIndex == 0)
                            {
                                listHasSlots = false;
                            }
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                        }
                        break;

                    case 8:

                        if (list.LastStudentIndex<2)
                        {
                            Console.Clear();
                            Console.WriteLine("Not enough students to sort.");
                            Console.ReadLine();
                            break;
                        }

                        int inputSort=0; 
                        bool validInput=false;

                        Console.Clear();
                        Console.WriteLine("Please choose sorting method:\n" +
                            "1. Sort by name alphabetically.\n" +
                            "2. Sort by average score.\n");

                        while (validInput == false)
                        {
                            inputSort = validateInput(inputSort, "Please enter either 1 or 2.");
                            
                            if (inputSort == 1)
                            {
                                list.BubbleSortName();
                                validInput = true;
                            }
                            else if(inputSort == 2)
                            {
                                validInput = true;
                                list.BubbleSortScore();
                            }
                            else
                            {
                                Console.WriteLine("Please enter 1 or 2.");
                            }
                        }

                        Console.WriteLine("List of students is sorted.");
                        Console.ReadLine();
                        break;

                    case 9:
                        list.getFirstScore();
                        if (list.bestScore == null)
                        {
                            Console.Clear();
                            Console.WriteLine("There are no students in the list.");
                            Console.ReadLine();
                            break;
                        }
                        Console.Clear();
                        Console.WriteLine($"The student with best score is: {list.bestScore.firstName} {list.bestScore.lastName} with score: {list.bestScore.studentScore}.");
                        Console.ReadLine();
                        break;

                    case 10:
                        list.getLastScore();
                        if(list.worstScore == null)
                        {
                            Console.Clear();
                            Console.WriteLine("There are no students in the list.");
                            Console.ReadLine();
                            break;
                        }
                        Console.Clear();
                        Console.WriteLine($"The student with worst score is: {list.worstScore.firstName} {list.worstScore.lastName} with score: {list.worstScore.studentScore}.");
                        Console.ReadLine();
                        break;

                    case 0:
                        loop = false;
                        Console.WriteLine("Thank you for testing. Press enter to exit.");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Input command is invalid. Press enter to continue");
                        Console.ReadLine();
                        break;

                }
            }


        }

        private static int validateInput(int input, string message)
        {
            bool inputValid = false;
            while (inputValid == false)
            {

                try
                {
                    input = int.Parse(Console.ReadLine());
                    inputValid = true;
                }
                catch
                {
                    Console.WriteLine(message);
                }

            }
            return input;
        }

        
       
    }


}
