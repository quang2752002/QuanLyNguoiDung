using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Xml.Linq;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _userService.GetAllAsync();
                return Json(new { data = users });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = ex.Message
                });
            }
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserDto userDto)
        {
            try
            {
                var isCheck= await _userService.Add(userDto);
                if (!isCheck)
                {
                    return BadRequest(new { message = "Thêm người dùng thất bại" });
                }
               
                return Ok(new { message = "Thêm người dùng thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Thêm người dùng thất bại" });
            }
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            return View(user);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var isSuccess = await _userService.Update(userDto);

                if (!isSuccess)
                {
                    return BadRequest(new { message = "Cập nhật người dùng thất bại" });
                }

                return Ok(new { message = "Cập nhật người dùng thành công" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest(new { message = "Id không hợp lệ" });

            var isSuccess = await _userService.Delete(id);

            if (!isSuccess)
                return BadRequest(new { message = "Xóa người dùng thất bại" });

            return Ok(new { message = "Xóa người dùng thành công" });
        }




    }
}
