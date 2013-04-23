using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeTrax.BLL
{
    public class Validator
    {
        public const string EmailPattern = "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
        public const string URLPattern = "^(http[s]?://|ftp://)?(www\\.)?[a-zA-Z0-9-\\.]+\\.(com|org|net|mil|edu|ca|co.uk|com.au|gov)$";
        public const string TwoDecimalPattern = "^\\d*[0-9](\\.\\d{1}[0-9])?$";
        public const string DecimalPattern = "^\\d*[0-9](\\.\\d*[0-9])?$";
        public const string ExtendedPhonePattern = "^(([0-9]{1})*[- .(]*([0-9a-zA-Z]{3})*[- .)]*[0-9a-zA-Z]{3}[- .]*[0-9a-zA-Z]{4})+$";
        public const string PhonePattern = "^[2-9]\\d{2}-\\d{3}-\\d{4}$";
        public const string DatePattern = "^([\\d]|1[0,1,2])/([0-9]|[0,1,2][0-9]|3[0,1])/\\d{4}$";
        public const string DocFilePattern = "^[a-zA-Z0-9-_\\.]+\\.(pdf|txt|doc|csv)$";
        public const string ImageFilePattern = "^[a-zA-Z0-9-_\\.]+\\.(jpg|gif|png)$";
        public const string IPAddressPattern = " ^((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\\.){3}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})$ ";
        public const string MediaFilePattern = "^[a-zA-Z0-9-_\\.]+\\.(swf|mov|wma|mpg|mp3|wav)$";
        public const string ZipCodePattern = "^(\\d{5}-\\d{4}|\\d{5}|\\d{9})$|^([a-zA-Z]\\d[a-zA-Z] \\d[a-zA-Z]\\d)$";
        public const string StrongPasswordPattern = "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$";
        public const string NumberPattern = "^(\\d|,)*\\d*$";
    }
}
