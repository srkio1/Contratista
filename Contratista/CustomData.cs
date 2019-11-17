using System;
using System.Collections.Generic;
using System.Text;

namespace Contratista
{
    public class CustomData
    {
        public CustomData(string image)
        {
            Image = image;
        }
        public string Image
        {
            get;
            set;
        }
        public CustomData()
        {

        }
    }
}
