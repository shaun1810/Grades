using System;

namespace Grades
{
    
    public class NameChangedEventArgs : EventArgs
    {
       public string CurrentName {get; set;} 
       public string NewName {get; set;}
     }
    
}