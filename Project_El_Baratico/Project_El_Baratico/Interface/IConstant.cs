using System;
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
        public const string DATABASE = "proyecto";
        public const string USERNAME = "Admin";
        public const string CONNECTION = "SERVER=" + SERVER + ";" + "DATABASE=" + DATABASE + ";" + "UID=" + USERNAME + ";" + "PASSWORD=" + PASSWORD + ";";
        public const string PROCEDURE_INSERT_CLIENT = "insertClient";
        public const string PROCEDURE_INSERT_ADMINISTRATOR = "insertAdmi";
        public const string PROCEDURE_GET_PRODUCT = "getProduct";
        public const string PROCEDURE_GET_OFFER = "getOffer";
        public const string PROCEDURE_GET_CATEGORY = "getCategory";
        public const string PROCEDURE_GET_OFFER_BY_ID = "getOfferById";
        public const string PROCEDURE_GET_PRODUCT_BY_ID = "getProductById";
        public const string PROCEDURE_GET_PRODUCT_BY_CATEGORY = "getProductByCategory";
        public const string PROCEDURE_GET_PRODUCT_BY_NAME = "searchProduct";


        public const string PROCEDURE_GET_MESSAGE_BY_CLIENT = "getMessageByClient";
        public const string PROCEDURE_INSERT_MESSAGE = "insertMessage";


        public const string PROCEDURE_INSERT_CART = "insertCart";
        public const string PROCEDURE_INSERT_PURCHASE = "purchase";
        public const string PROCEDURE_GET_PURCHASE_BY_CLIENT = "getPurchaseByClient";


    }
}
