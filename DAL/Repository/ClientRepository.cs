using DAL.DataAccess;
using DAL.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IClientsRepository
    {
        Task<List<Client>> GetClients();
        Task<Client> AddClient(Client client);
        Task UpdateClient(Client client);
        Task<Client> GetClient(int Id);

        Task DeleteClient(int id);
    }

    public class ClientsRepository : IClientsRepository
    {
        private CovidContext _context { get; set; }
        public ClientsRepository(CovidContext context)
        {
            _context = context;
        }
        public async Task<List<Client>> GetClients()
        {
            var list = await _context.Clients.ToListAsync();
            return list;
        }
        public async Task<Client> GetClient(int id)
        {
            Client client = await _context.Clients.Where(x => x.ClientId == id)
                .Include(x => x.VaccinationsClients).ThenInclude(x => x.Creator)
                .FirstOrDefaultAsync();
            return client;
        }

        public async Task<Client> AddClient(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task UpdateClient(Client client)
        {
            Client clientFromDb = await GetClient(client.ClientId ?? 0);
            clientFromDb.FirstName = client.FirstName;
            clientFromDb.PositiveResultDate = client.PositiveResultDate;
            //TODO
            _context.Clients.Update(clientFromDb);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClient(int id)
        {
            var client = await _context.Clients.Where(x => x.ClientId == id).FirstAsync();
            if (client != null)
                _context.Clients.Remove((Client)client);
            await _context.SaveChangesAsync();
        }
    }

}