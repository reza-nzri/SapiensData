using AutoMapper;
using SapiensDataAPI.Dtos.Income.Request;
using SapiensDataAPI.Models;

namespace SapiensDataAPI.Configs
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<IncomeDto, Income>();
		}
	}
}
