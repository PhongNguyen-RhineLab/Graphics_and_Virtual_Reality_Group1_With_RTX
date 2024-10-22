using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Info
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string Instructor {  get; set; }
        public int ID { get; set; }

        public Info(string name,string category , string authorName, string instructor)
        {
            Category=category;
            Name=name;
            AuthorName=authorName;
            Instructor=instructor;
         
        }
    }
}
