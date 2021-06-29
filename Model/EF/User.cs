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

        [StringLength(50)]
        [Display (Name = "Tài khoản")]
        public string UserName { get; set; }

        [StringLength(32)]
        [Display(Name ="Mật khẩu")]
        public string Passsword { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(10)]
        [Display(Name = "SĐT")]
        public string Phone { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [Display(Name = "Trạng Thái")]
        public bool Status { get; set; }
    }
}
