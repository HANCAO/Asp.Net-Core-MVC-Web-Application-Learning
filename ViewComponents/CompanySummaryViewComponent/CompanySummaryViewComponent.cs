using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.services;

namespace WebApplication1.ViewComponents.CompanySummaryViewComponent
{
    public class CompanySummaryViewComponent:ViewComponent
    {
        private readonly IDepartmentService departmentService;

        public CompanySummaryViewComponent(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string title)
        {
            ViewBag.Title = title;
            var summary = await this.departmentService.GetCompanySummary();
            return View(summary);
        }
    }
}
