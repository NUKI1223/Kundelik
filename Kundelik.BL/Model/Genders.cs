using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kundelik.BL.Model
{  /// <summary>
   /// Пол
   /// </summary>
    [Serializable]
    public class Genders
    {
        public int ID { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Создать новый пол
        /// </summary>
        /// <param name="name"> Имя пола</param>
        public Genders(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым ", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
