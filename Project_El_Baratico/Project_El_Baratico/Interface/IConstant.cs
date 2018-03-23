﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_El_Baratico.Interface
{
    public class IConstant
    {
        public const string PASSWORD= "12";
        public const string SERVER = "localhost";
        public const string DATABASE = "reqbase";
        public const string USERNAME = "Admin";
        public const string CONNECTION = "SERVER=" + SERVER + ";" + "DATABASE=" + DATABASE + ";" + "UID=" + USERNAME + ";" + "PASSWORD=" + PASSWORD + ";";
        public const string PROCEDURE_INSERT_CLIENT = "insertClient";

        public const string PROCEDURE_INSERT_ADMINISTRATOR = "insertAdministrator";
    }
}