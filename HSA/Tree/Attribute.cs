using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSA.Tree
{
    class Attribute
    {

        // ----------------------------------------------------------------------------------------------------

        // Information name

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Information attributes

        private List<String> attributes;

        public List<String> Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Constructor method

        public Attribute(String name, List<String> attributes)
        {
            Name = name;
            Attributes = attributes;
        }

        // ----------------------------------------------------------------------------------------------------

        // Method get attributes name column

        public static List<String> GetAttributesNameColumn(DataTable data, int columnIndex)
        {
            var differentAttributes = new List<String>();

            for (var i = 0 ; i < data.Rows.Count ; i ++)
            {
                var found = differentAttributes.Any(t => t.ToUpper().Equals(data.Rows[i][columnIndex].ToString().ToUpper()));

                if (!found)
                {
                    differentAttributes.Add(data.Rows[i][columnIndex].ToString());
                }

            }

            return differentAttributes;

        }

        // ----------------------------------------------------------------------------------------------------

    }
}
