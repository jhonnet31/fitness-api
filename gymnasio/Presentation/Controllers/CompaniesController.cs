using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public  class CompaniesController:ControllerBase
    {
        private readonly IServiceManager _service;

        public CompaniesController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetCompanies()
        {
            throw new Exception("exception test");
                var companies = _service.CompanyService.GetAllCompanies(trackChanges: false);
                return Ok(companies);
         
        }

        [HttpGet("{id:int}",Name ="CompanyById")]
        public IActionResult GetCompany(int id) {
            var company = _service.CompanyService.GetCompany(id, trackChanges: false);
            return Ok(company);
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody] CompanyForCreationDto company) {
            if (company is null)
                return BadRequest($"{nameof(CompanyForCreationDto)} object is null");
            var companyCreated = _service.CompanyService.CreateCompany(company);
            return CreatedAtRoute("CompanyById", new{Id=companyCreated.Id }, companyCreated);
        }

    }
}
