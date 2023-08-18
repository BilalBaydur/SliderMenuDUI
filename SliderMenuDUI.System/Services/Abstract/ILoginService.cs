using SliderMenuDUI.Base.Results.Abstract;
using SliderMenuDUI.Base.Token;
using SliderMenuDUI.Systems.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderMenuDUI.Systems.Services.Abstract
{
	public interface ILoginService
	{
        Task<IDataResult<ResultToken>> Login(LoginDto singInDto);
        Task<IResult> Logout();
        Task<IResult> ChangePassword(ChangePasswordDto changePasswordDto);
        Task<IResult> ResetPassword();
    }
}
