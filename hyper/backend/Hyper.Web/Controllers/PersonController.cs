

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hyper.Domain.Entities;
using Hyper.Domain.Interfaces.Repositories;
using Hyper.Infra.Context;
using Hyper.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hyper.Web.Controllers
{
    [ApiController]
    [Route("person")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public IEnumerable<Person> Get([FromServices]AppDataContext context)
        {
            return context.Persons.Include(x => x.Addresses).ToList();
        }

        [HttpGet]
        [Route("{id:int}")]
        public Person Get(int id)
        {
            return _personRepository.GetById(id);
        }

        [HttpPost]
        public async Task<ResultViewModel> Post(
            [FromBody]CreatePersonViewModel personViewModel)
        {
            personViewModel.Validate();

            if (personViewModel.Invalid)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar a pessoa",
                    Data = personViewModel.Notifications
                };
            }

            var person = new Person(
                personViewModel.FirstName,
                personViewModel.LastName,
                personViewModel.Email);


            person.Addresses.Add(personViewModel.Address);

            await _personRepository.Add(person);

            _personRepository.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Cadastrado com sucesso",
                Data = person,
            };
        }

        [HttpPut]
        public Person Put([FromBody]Person person)
        {
            _personRepository.Update(person);
            return person;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            _personRepository.Remove(id);
            _personRepository.SaveChanges();
            return Ok();
        }
    }
}