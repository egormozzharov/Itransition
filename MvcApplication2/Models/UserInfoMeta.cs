using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public partial class UserInfo
    {

        public String Gender
        {
            get
            {
                if (true == Sex)
                {
                    return "Male";
                }
                else
                {
                    return "Female";
                }
            }
            set
            {
                if ("Male" == value)
                {
                    Sex = true;
                }
                else
                {
                    Sex = false;
                }
            }
        }

    }
}