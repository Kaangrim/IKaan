using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace IKaan.Web.Model.SCM.Biz
{
    public class ContactModel 
    {
        [Display(Name = "이름")]
        public string Name { get; set; }

        [Display(Name = "타입")]
        public string ContactType { get; set; }

        [Display(Name = "이메일")]
        public string Email { get; set; }

        [Display(Name = "전화번호")]
        public string PhoneNo { get; set; }

        [Display(Name = "휴대전화")]
        public string MobileNo { get; set; }

        [Display(Name = "팩스번호")]
        public string FaxNo { get; set; }

        [Display(Name = "사용여부")]
        public string UseYn { get; set; }

        [Display(Name = "설명")]
        public string Description { get; set; }

        [Required(ErrorMessage = "아이디를 입력 하세요.")]
        [Display(Name = "로그인 아이디")]
        public string LoginID { get; set; }
        
        [Required(ErrorMessage = "비밀번호를 입력 하세요.")]
        [DataType(DataType.Password)]
        [Display(Name = "비밀번호")]
        public string LoginPW { get; set; }

        [Display(Name = "관리자 권한")]
        public string AuthGroup { get; set; }

        [Display(Name = "ERROR 코드")]
        public string ResultCode { get; set; }

        [Display(Name = "ERROR 메세지")]
        public string ResultMassege { get; set; }
    }
}