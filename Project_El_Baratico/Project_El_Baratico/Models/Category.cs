using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_El_Baratico.Models
{
    public class Category
    {
        // Attributes

        string url;
        string name;

        // Constructor

        public Category(string pUrl, string pName)
        {
            setUrl(pUrl);
            setName(pName);
        }

        // Getter and setter

        public string getUrl()
        {
            return this.url;
        }

        public string getName()
        {
            return this.name;
        }

        public void setUrl(string pUrl)
        {
            this.url = pUrl;
        }

        public void setName(string pName)
        {
            this.name = pName;
        }
    }
}