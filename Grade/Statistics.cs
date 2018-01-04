using System;

namespace Grades
{
   public class Statistics
    {
        float highestGrade;
        float lowestGrade;
        float averGrade; 
        bool activeStatistics;


        public string LetterGrade
        {
            get 
            {
                string result;
                if (Math.Round(averGrade) >= 90 )
                {
                    result = "A";
                }
                else if (Math.Round(averGrade) >= 80)
                {
                    result = "B";
                }
                else if (Math.Round(averGrade) >=70)
                {
                    result = "C";
                }
                else if (Math.Round(averGrade) >= 60)
                {
                    result = "D";
                }
                else
                {
                    result = "F";
                }
                return result;
            }
        }

           public string Description
        {
            get{
                string result;
                switch(LetterGrade)
                {
                    case "A":
                    result = "Execellent";
                    break;
                    case "B":
                    result = "Good";
                    break;
                    case "C":
                    result = "Average";
                    break;
                    case "D":
                    result = "Below Average";
                    break;
                    default:
                    result = "failing";
                    break;
                }
                return result;
            }
        }

        public Statistics()
        {
            highestGrade = 0;
            lowestGrade = 0;
            averGrade = 0;
            activeStatistics = false; 
        }
       
        public void SetHighestGrade(float high)
        {
            highestGrade = high;
        }

        public float GetHighestGrade()
        {
            return highestGrade;
        }

        public void SetLowestGrade(float low)
        {
           lowestGrade = low; 
        }

        public float GetLowestGrade()
        {
            return lowestGrade;
        }

        public void SetAverGrade(float aver)
        {
            averGrade = aver;
        }
        
        public float GetAverGrade()
        {
            return averGrade;
        }

        public void setActiveStats(bool active)
        {
            activeStatistics = active; 
        }

        public bool GetActiveStats()
        {
            return activeStatistics;
        }

    }

}