using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        /// <summary>
        /// Họ tên 
        /// </summary>
        public string? HoTen { get; set; }
        /// <summary>
        /// Ngày tháng năm sinh
        /// </summary>
        public DateTime? Dob {  get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string? Sdt {  get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string? DiaChi {  get; set; }

    }
}
