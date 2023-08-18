using SliderMenuDUI.Base.Results;
using SliderMenuDUI.Base.Results.Abstract;
using SliderMenuDUI.Base.Token;
using SliderMenuDUI.Base.Token.Abstract;
using SliderMenuDUI.Systems.Dto;
using SliderMenuDUI.Systems.Globals.Abstract;
using SliderMenuDUI.Systems.Manager.Abstract;
using SliderMenuDUI.Systems.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderMenuDUI.Systems.Manager
{
	/// <summary>
	/// Login işlemlerini gerçekleştirir
	/// </summary>
	public class LoginManager: ILoginManager
	{
		public ILoginService _loginService;
		public IGlobal _global;


		public LoginManager(ILoginService loginService, IGlobal global)
		{
			_loginService = loginService;
			_global = global;

		}

		public LoginDto GetNewLoginDto(string userName, string password)
		{
			return new LoginDto()
			{				
				UserName = userName,
				Password = password
			};

		}

		public IResult IsValidation(LoginDto loginDto)
		{
			if(	string.IsNullOrEmpty(loginDto.UserName) ||
				string.IsNullOrEmpty(loginDto.Password))
			{
				return new ErrorResult("Girdiğiniz bilgileri kontrol ediniz.");
			}

			return new SuccessResult();

		}

		public async Task<IResult> Login(LoginDto loginDto)
		{
			IDataResult<ResultToken> token = await _loginService.Login(loginDto);
			if(!token.Success)
			{
				return new ErrorResult(token.Message);
			}
			
			_global.UserName = loginDto.UserName;
			_global.password = loginDto.Password;
			_global.TokenSetting = token.Data;

			return new SuccessResult();
		}
	}
}
