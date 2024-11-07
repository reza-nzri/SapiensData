using AutoMapper;
using SapiensDataAPI.Dtos.Expense.Request;
using SapiensDataAPI.Dtos.Income.Request;
using SapiensDataAPI.Models;

namespace SapiensDataAPI.Configs
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<IncomeDto, Income>();
			CreateMap<ExpenseDto, Expense>();
		}
	}
}