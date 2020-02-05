using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.ResidentialAreaSystem.RequestViewModel;

namespace ViewModel.ViewValitor.ResidentialAreaSystem
{
    public class AreaAddValitor : AbstractValidator<AreaAddViewModel>
    {
        public AreaAddValitor()
        {
            RuleFor(area => area.Name).NotNull()
            .WithMessage("小区名字不能为空")
            .Matches("[\u4e00-\u9fa5]")
            .WithMessage("角色名称必须为中文");

            RuleFor(area => area.Developers).NotNull()
           .WithMessage("开发商能为空")
           .Matches("[\u4e00-\u9fa5]")
           .WithMessage("开发商必须为中文");

        }
    }
}
