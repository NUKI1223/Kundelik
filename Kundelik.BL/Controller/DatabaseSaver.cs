using Kundelik.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Kundelik.BL.Controller
{
    class DatabaseSaver
    {
        
        public void Save(string filename, object item)
        {
            using (var db = new KundelikContex())
            {
                var type = item.GetType();
                switch (item.GetType().Name)
                {

                    case nameof(Student):
                        db.DBStudent.Add(item as Student);
                        break;
                    case nameof(Teacher):
                        db.DBTeacher.Add(item as Teacher);
                        break;
                    case nameof(Genders):
                        db.DBGender.Add(item as Genders);
                        break;
                    case nameof(Posts):
                        db.DBPost.Add(item as Posts);
                        break;
                    default:
                        break;
                }
                db.SaveChanges();
            }
        }
    }
}
