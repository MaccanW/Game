using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire.Model
{
    public class Category
    {

        public Category(string category)
        {
            this.Categoryy = category;
        }

        private String category;

        public String Categoryy
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }


    }
}
