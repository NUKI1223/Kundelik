using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kundelik.BL.Model
{
    [Serializable]
    public class Posts
    {
        public int ID { get; set; }
        public string Post { get; set; }
        public Posts(string post)
        {
            if (string.IsNullOrWhiteSpace(post))
            {
                throw new ArgumentNullException("Название должности не может быть пустым ", nameof(post));
            }
            Post = post;
        }
        public override string ToString()
        {
            return Post;
        }
    }
}
