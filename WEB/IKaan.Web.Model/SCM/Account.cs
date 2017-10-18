using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;


namespace IKaan.Web.Model.SCM
{
    public class LoginModel
    {
        [Required(ErrorMessage = "아이디를 입력 해 주세요.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "20자까지 가능합니다.")]
        public string LoginID { get; set; }

        [Required(ErrorMessage = "비밀번호를 입력 해 주세요.")]
        [Display(Name = "비밀번호")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "최대 20자까지 가능합니다.")]
        public string LoginPW { get; set; }
    }

    public class ErrResultModel
    {
        public string STATUS { get; set; }

        public string RESULT { get; set; }
    }
}