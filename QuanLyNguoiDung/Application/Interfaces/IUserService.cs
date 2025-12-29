using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        
        Task<UserDto> GetByIdAsync(Guid Id);

        Task<bool> Add(UserDto userDto);

        Task<bool> Update(UserDto userDto);

        Task<bool> Delete(Guid Id);
    }
}
