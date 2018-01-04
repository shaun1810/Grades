using System;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
   public class GradeBook
    {
       public event NameChangeDelegate NameChange;
       private List<float> currentGrades;
       private string _name;
       public string Name
       {
           get{

               return _name;
           }
           set{
               
           if(_name != value)
                {

                      NameChangedEventArgs args = new NameChangedEventArgs();  
                      args.CurrentName = _name;
                      args.NewName = value;
                      NameChange(this, args);
                }
                    _name = value;
               }
        }
        
        internal void WriteGradesWhileLoop(TextWriter destination)
        {
            int i = currentGrades.Count -1;
            destination.WriteLine("while loop");
            while(i>=0)
            {
                destination.WriteLine(currentGrades[i]);
                i--;
            }
        }

        internal void WriteGradesForEachLoop(TextWriter destination)
        {
            destination.WriteLine("for Ea loop");
            foreach (float grade in currentGrades)
            {
                destination.WriteLine(grade);
            } 
        }

        public void WriteGradesForLoop(TextWriter destination)
        {
            Console.WriteLine("for Loop");
            for (int i=currentGrades.Count; i>0; i--)
            {
                destination.WriteLine(currentGrades[i-1]);
            }
        }

        public void WriteGradesToFile(StreamWriter outputFile)
        {
              outputFile.WriteLine(_name);
              outputFile.WriteLine("Grades From the GradeBook Program.");
            for (int i=currentGrades.Count; i>0; i--)
            {
                outputFile.WriteLine(currentGrades[i-1]);
            }
        }

        public GradeBook()
        {
            currentGrades = new List<float>();
            _name = "empty";
        }
        public void AddGrade (float grade)
        {
            currentGrades.Add(grade);
        }

        public Statistics ComputeStatistics()
        {
          Statistics stats = new Statistics();
          if (currentGrades.Count != 0)
          {
              stats.setActiveStats(true);
          float highestGrade = 0f;
          float lowestGrade =100f;
          float averGrade = 0f;
          float gradeTotal = 0f;

          for(int i = 0; i<currentGrades.Count;i++)
          {
              
                  highestGrade = Math.Max(currentGrades[i], highestGrade);
             
              if (currentGrades[i] < lowestGrade)
              {
                  lowestGrade = Math.Min(currentGrades[i], lowestGrade);
              }
              gradeTotal += currentGrades[i];
          }
            
        averGrade = gradeTotal/currentGrades.Count;
        stats.SetHighestGrade(highestGrade);
        stats.SetLowestGrade(lowestGrade);
        stats.SetAverGrade(averGrade);
        
          return stats;
        }
        else
        {
            return stats; 
        }
        }
    }
}