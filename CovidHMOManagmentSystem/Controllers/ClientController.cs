using DAL.DataAccess;
using DAL.Dto;
using DAL.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CovidHMOManagmentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private IClientsRepository _clientsRepository { get; set; }
        public ClientsController(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetClients()
        {
            try
            {
                var list = await _clientsRepository.GetClients();
                return list;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex}");
            }
        }
        //[Microsoft.AspNetCore.Mvc.HttpGet]
        [HttpGet("{id}")]  
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            try
            {
                var client = await _clientsRepository.GetClient(id);
                if (client == null)
                    return NotFound();
                return Ok(client);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex}");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Client>> AddClient(Client client)
        {
            try
            {
                await _clientsRepository.AddClient(client);
                return Created(new Uri(Request.GetDisplayUrl()), client);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateClient(Client client)
        {
            try
            {
                await _clientsRepository.UpdateClient(client);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex}");
            }
        }
    }
}