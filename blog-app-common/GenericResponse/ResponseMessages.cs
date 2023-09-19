using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_app_common.GenericResponse
{
    public class ResponseMessages
    {
        public static string Success = "Success";
        public static string InvalidCredentials = "Please enter valid password";
        public static string InternalServerError = "Please try after sometime";
        public static string SomethingWentWrong = "Oops! something went wrong!";
        public static string NoDataFound = "No data found";

        public static string BlogAddedSuccess = "Blog added successfully";
        public static string BlogUpdatedSuccess = "Blog updated successfully";
        public static string BlogDeletedSuccess = "Blog deleted successfully";
    }
}
