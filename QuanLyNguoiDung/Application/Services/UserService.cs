using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interface;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(UserDto userDto)
        {
            var entity = new User();
            entity.Id = Guid.NewGuid();
            entity.HoTen = userDto.HoTen;
            entity.Dob = userDto.Dob;
            entity.Email = userDto.Email;
            entity.Sdt = userDto.Sdt;
            entity.DiaChi = userDto.DiaChi;
            await _unitOfWork.Users.Add(entity);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(UserDto userDto)
        {
            if (userDto.Id is null) {
                throw new ArgumentException("User Id không hợp lệ", nameof(userDto.Id));
            }
            var entity = await _unitOfWork.Users.GetByIdAsync(userDto.Id.Value);
            if (entity == null) return false;

            entity.HoTen = userDto.HoTen;
            entity.Dob = userDto.Dob;
            entity.Email = userDto.Email;
            entity.Sdt = userDto.Sdt;
            entity.DiaChi = userDto.DiaChi;

            _unitOfWork.Users.Update(entity);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _unitOfWork.Users.GetByIdAsync(id);
            if (entity == null) return false;

            _unitOfWork.Users.Delete(entity);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return users.Select(MapToDto).ToList();
        }

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.Users.GetByIdAsync(id);

            if (entity == null)
                throw new KeyNotFoundException($"User với Id = {id} không tồn tại");

            return MapToDto(entity);
        }


       

        private static UserDto MapToDto(User entity)
        {
            return new UserDto
            {
                Id = entity.Id,
                HoTen = entity.HoTen,
                Dob = entity.Dob,
                Email = entity.Email,
                Sdt = entity.Sdt,
                DiaChi = entity.DiaChi,
                DobText = entity.Dob.HasValue? entity.Dob.Value.ToString("dd/MM/yyyy"): "",
            };
        }
    }
}
