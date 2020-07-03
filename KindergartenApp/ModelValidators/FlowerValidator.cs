using FluentValidation;
using FluentValidation.Results;
using KindergartenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindergartenApp.ModelValidators
{
	public class FlowerValidator : AbstractValidator<Models.Flower>
	{

		// read more: https://www.carlrippon.com/fluentvalidation-in-an-asp-net-core-web-api/
		public FlowerValidator(FlowersDbContext context)
		{

			//RuleFor(x => x.MarketPrice).InclusiveBetween(5, 1000);
			RuleFor(x => x.MarketPrice).InclusiveBetween(5, context.Flowers.Select(f => f.MarketPrice).Max());
			RuleFor(x => x.DateAdded).LessThan(DateTime.Now);
			RuleFor(x => x.FlowerUpkeepDificulty)
				.Equal(Models.FlowerUpkeepDifficulty.Easy)
				.When(x => x.MarketPrice >= 5 && x.MarketPrice <= 10);
			//RuleFor(x => x.Id).Must(x =>
			//{
			//	return true;
			//});
			// RuleForEach(); ValidationResult pentru mai multe chestii
		}
	}
}
