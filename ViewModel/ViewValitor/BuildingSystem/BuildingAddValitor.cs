using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BuildingSystem.RequestViewModel;

namespace ViewModel.ViewValitor.BuildingSystem
{
    public class BuildingAddValitor : AbstractValidator<BuildingAddViewModel>
    {
        public BuildingAddValitor()
        {
            RuleFor(area => area.Name).NotNull()
            .WithMessage("小区名字不能为空")
            .Matches("[\u4e00-\u9fa5]")
            .WithMessage("小区名字必须为中文");

           

        }
    }
}
