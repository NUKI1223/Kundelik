using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kundelik.BL.Model
{
    [Serializable]
    public class User
    {
        public int ID { get; set; }
        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        
        public Genders Gender { get; set; }
        

        public DateTime BirthDate { get; set; }

        public Posts Post { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        
        public override string ToString()
        {
            return Name + " "+ Age;
        }
        
    }
}
