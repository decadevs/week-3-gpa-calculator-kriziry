using System;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
namespace Testquestions
{
    internal class Program
    {
        static void Main()
        {


            // Display table header
            Console.WriteLine("|----------------------------|-----------------------|------------|---------------------|");
            Console.WriteLine("| COURSE & CODE              | COURSE UNIT           | GRADE      | GRADE-UNIT          |");
            Console.WriteLine("|----------------------------|-----------------------|------------|---------------------|");

            double totalQualityPoints = 0;
            int totalGradeUnits = 0;

            while (true)
            {
                // Get user input for course details
                Console.Write("Enter Course Name and Code (or 'exit' to finish): ");
                string courseNameAndCode = Console.ReadLine();

                if (courseNameAndCode.ToLower() == "exit")
                    break;

                Console.Write("Enter Course Unit: ");
                int courseUnit = int.Parse(Console.ReadLine());

                Console.Write("Enter Course Score: ");
                int courseScore = int.Parse(Console.ReadLine());

                // Calculate grade and grade unit
                string grade = CalculateGrade(courseScore);
                int gradeUnit = CalculateGradeUnit(grade);

                // Calculate quality point
                double qualityPoint = courseUnit * gradeUnit;

                // Display course details in tabular form
                Console.WriteLine($"| {courseNameAndCode,-27} | {courseUnit,-21} | {grade,-10} | {gradeUnit,-21} |");

                // Accumulate total quality points and grade units
                totalQualityPoints += qualityPoint;
                totalGradeUnits += courseUnit;
            }

            // Display table footer
            Console.WriteLine("|---------------------------------------------------------------------------------------|");

            // Calculate GPA
            double gpa = totalQualityPoints / totalGradeUnits;

            // Display GPA
            Console.WriteLine($"Your GPA is = {gpa:F2} to 2 decimal places.");
        }

        // Function to calculate the grade based on the given grading system
        static string CalculateGrade(int score)
        {
            if (score >= 70 && score <= 100)
                return "A";
            else if (score >= 60 && score <= 69)
                return "B";
            else if (score >= 50 && score <= 59)
                return "C";
            else if (score >= 45 && score <= 49)
                return "D";
            else if (score >= 40 && score <= 44)
                return "E";
            else
                return "F";
        }

        // Function to calculate the grade unit based on the given grading system
        static int CalculateGradeUnit(string grade)
        {
            switch (grade)
            {
                case "A":
                    return 5;
                case "B":
                    return 4;
                case "C":
                    return 3;
                case "D":
                    return 2;
                case "E":
                    return 1;
                default:
                    return 0;
            }
        }
    }

}
