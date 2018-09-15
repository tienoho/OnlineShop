namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength(50,ErrorMessage ="Tài khoản không được quá 50 ký tự")]
        [Display(Name="Tài khoản")]
        [Required(ErrorMessage = "Bạn chưa nhập danh mục")]
        public string UserName { get; set; }

        [StringLength(32, ErrorMessage = "Mật khẩu không được quá 50 ký tự")]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn chưa nhập danh mục")]
        public string Password { get; set; }

        [StringLength(50, ErrorMessage = "Họ và tên không được quá 50 ký tự")]
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Địa chỉ không được quá 50 ký tự")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập danh mục")]
        [StringLength(50, ErrorMessage = "Số điện thoại không được quá 50 ký tự")]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [StringLength(50, ErrorMessage = "Email không được quá 50 ký tự")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
    }
}
