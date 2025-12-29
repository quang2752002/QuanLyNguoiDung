using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UserDto:BaseDto
    {
        /// <summary>
        /// Họ tên 
        /// </summary>
        [Required(ErrorMessage = "Họ tên không được để trống")]
        public string? HoTen { get; set; }
        /// <summary>
        /// Ngày tháng năm sinh
        /// </summary>
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        public DateTime? Dob { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Required(ErrorMessage = "Email không được để trống")]

        public string? Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [RegularExpression(@"^\d{9,11}$", ErrorMessage = "Số điện thoại phải gồm 9–11 chữ số")]
        public string? Sdt { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string? DiaChi { get; set; }
        /// <summary>
        /// thời gian format
        /// </summary>
        public string? DobText { get; set; }
        
    }
}
