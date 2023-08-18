using SliderMenuDUI.Base.Results.Abstract;
using SliderMenuDUI.Systems.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderMenuDUI.Systems.Manager.Abstract
{
	public interface ILoginManager
	{
		LoginDto GetNewLoginDto(string userName, string password);
		IResult IsValidation(LoginDto loginDto);
		Task<IResult> Login(LoginDto loginDto);
	}
}
