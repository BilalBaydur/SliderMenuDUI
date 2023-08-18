using SliderMenuDUI.Base.Extensions;
using SliderMenuDUI.Base.RestApi.Abstract;
using SliderMenuDUI.Base.Results;
using SliderMenuDUI.Base.Results.Abstract;
using SliderMenuDUI.Base.Token;
using SliderMenuDUI.Systems.Dto;
using SliderMenuDUI.Systems.Services.Abstract;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace SliderMenuDUI.Systems.Services
{
	/// <summary>
	/// Oturum yönetimi için api ile iletişimi sağlar
	/// </summary>
	public class LoginService : ILoginService
	{
		public IRestApiClient _restApiClient;

		public LoginService(IRestApiClient restApiClient)
		{
			_restApiClient = restApiClient;
		}

		public async Task<IDataResult<ResultToken>> Login(LoginDto singInDto)
		{
			if (singInDto.UserName == "Bilal" && singInDto.Password == "123456")
			{
				return new SuccessDataResult<ResultToken>(
					new ResultToken()
					{
						Token = "123456789123456789",
						Expiration = DateTime.Now.AddDays(1)
					});
			}
			else
			{
				return new ErrorDataResult<ResultToken>(null, "Kullanıcı adı şifrenizi kontrol ediniz.");
			}

			//Servis ile ilgili işlemler
			/*
			var response = await _restApiClient.PostAsync("auth-api/Auth/login", singInDto);
			if (!response.IsSuccessful)
			{
				
				if (response.ResponseStatus == ResponseStatus.Error)
				{
					string errorMessage = (response.ErrorMessage != null)? response.ErrorMessage : "";
					return new ErrorDataResult<ResultToken>(null, errorMessage);
				}
				return new ErrorDataResult<ResultToken>(null, response.Content);
			}
			return new SuccessDataResult<ResultToken>(response.ToObject<ResultToken>());
			*/
		}

		public Task<IResult> Logout()
		{
			throw new NotImplementedException();
		}

		public Task<IResult> ChangePassword(ChangePasswordDto changePasswordDto)
		{
			throw new NotImplementedException();
		}

		public Task<IResult> ResetPassword()
		{
			throw new NotImplementedException();
		}


	}
}
