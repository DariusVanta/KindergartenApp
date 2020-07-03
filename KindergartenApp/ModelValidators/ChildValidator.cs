using FluentValidation;
using KindergartenApp.Models;

namespace KindergartenApp.ModelValidators
{
    public class ChildValidator : AbstractValidator<Child>
	{
		public ChildValidator()
		{
			RuleFor(x => x.Age).InclusiveBetween(1, 18);
			RuleFor(x => x.Height).LessThan(160);
			RuleFor(x => x.ChildrenGroup)
				.Equal(Models.ChildrenGroup.Small)
				.When(x => x.Age >= 1 && x.Age <= 3);
			RuleFor(x => x.ChildrenGroup)
				.Equal(Models.ChildrenGroup.Middle)
				.When(x => x.Age > 3 && x.Age <= 6);
			RuleFor(x => x.ChildrenGroup)
			.Equal(Models.ChildrenGroup.Bigger)
			.When(x => x.Age > 6 && x.Age <= 18);
		}
	}
}
