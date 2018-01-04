using System;
using System.Collections.Generic;
using System.IO;
namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook();
            
            GetBookName(book);
            addGradesToBook(book);
            SaveBook(book);
            GenerateResults(book);
            //Just tests; uncomment to use. Look in Gradebook to see funtions. 
            /*book.WriteGradesForLoop(Console.Out);
              book.WriteGradesForEachLoop(Console.Out);
              book.WriteGradesWhileLoop(Console.Out);*/
        }

        private static void GenerateResults(GradeBook book)
        {
            Statistics stats = book.ComputeStatistics();
            if (stats.GetActiveStats() == true)
            {
                writeResult("Highest Grade", stats.GetHighestGrade());
                writeResult("Lowest Grade", stats.GetLowestGrade());
                writeResult("Average Grade", stats.GetAverGrade());
                writeResult(stats.Description, stats.LetterGrade);
            }
            else
            {
                Console.WriteLine("There are no grades to compute!");
            }
        }

        private static void SaveBook(GradeBook book)
        {
            using (StreamWriter outputFile = File.CreateText("Grades.txt"))
            {
                book.WriteGradesToFile(outputFile);
            }
        }

        private static void addGradesToBook(GradeBook book)
        {

            book.AddGrade(78);
            book.AddGrade(99.444f);
            book.AddGrade(80);
        }

        static void GetBookName(GradeBook book)
        {
            book.NameChange += OnNameChanged;
            bool validName = false;
            string bookName;
            while (validName == false)
            {
                try
                {
                    Console.WriteLine("Please Enter a Name for your gradebook: ");
                    bookName = Console.ReadLine();
                    if (bookName != null && bookName != "" && bookName != " ")
                    {
                        book.Name = bookName;
                        validName = true;
                    }
                    else
                    {
                        throw new ArgumentException("Name cannot be null or empty");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Thank you choosing a valid name!");
                }
            }
        }

        static void writeResult(string message, float gradeResult)
        {
                Console.WriteLine($"{message}: {gradeResult:f2}", message, gradeResult);
        }

          static void writeResult(string message, string gradeResult)
        {
                Console.WriteLine($"{message}: {gradeResult}", message, gradeResult);
        }

       /*  static void writeGrades(string message, int gradeResult)
        {
                Console.WriteLine("{0}: {1:f2}", message , gradeResult);
        }*/

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Name of book changing from {args.CurrentName} to {args.NewName}");
        }
    }
}