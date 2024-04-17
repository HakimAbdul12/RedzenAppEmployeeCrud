using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using Employess.Data;

namespace Employess.Controllers
{
    public partial class ExportBlazorController : ExportController
    {
        private readonly BlazorContext context;
        private readonly BlazorService service;

        public ExportBlazorController(BlazorContext context, BlazorService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/Blazor/contacts/csv")]
        [HttpGet("/export/Blazor/contacts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportContactsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetContacts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Blazor/contacts/excel")]
        [HttpGet("/export/Blazor/contacts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportContactsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetContacts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Blazor/employees/csv")]
        [HttpGet("/export/Blazor/employees/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEmployeesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEmployees(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Blazor/employees/excel")]
        [HttpGet("/export/Blazor/employees/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEmployeesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEmployees(), Request.Query, false), fileName);
        }
    }
}
