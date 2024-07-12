﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
using System.Net.Http.Headers;
using System.Text;
using WebApplicationForMilitaria.Domain.Entities.JsonFIle;
using WebApplicationForMilitaria.Domain.Interfaces;
using WebApplicationForMilitaria.Domain.JsonList;
using WebApplicationForMilitaria.Infrastructure.Persistance;

namespace WebApplicationForMilitaria.Infrastructure.Repositories
{
    public class JsonFileRepository : IJsonFileRepository
    {
        private readonly WebAppDbContext _dbContext;

        public JsonFileRepository(WebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        => await _dbContext.SaveChangesAsync();

        public async Task Create(BillingEntry billingEntry)
        {
            _dbContext.BillingEntries.Add(billingEntry);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(BillingEntry deletedRecord)
        {
            _dbContext.BillingEntries.Remove(deletedRecord);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BillingEntry>> GetAll()
        => await _dbContext.BillingEntries
            .Include(t => t.Type).ToListAsync();

        public async Task<string> GetAllAPIAllegro(StringBuilder token)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files/JsonFilesFromAllegroAPI.txt");
            string results = "";
            
            if (System.IO.File.Exists(filePath))
            {
                 results = System.IO.File.ReadAllText(filePath);
                return results;
            }
            

            try
            {
                HttpClient client = new HttpClient();

                string url = "https://api.allegro.pl.allegrosandbox.pl/billing/billing-entries";

                int first = token.Length/2;
                int second = first+1;

                string str1 = token.ToString().Substring(0, first);
                string str2 = token.ToString().Substring(second-1);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.allegro.public.v1+json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", str1 + str2);

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                System.IO.File.WriteAllText("Files/JsonFilesFromAllegroAPI.txt", json);

                results = json;
                return results;

            }
            catch (Exception ex)
            {
            }

            return "Something wrong";
        }

        public async Task<BillingEntry> GetRecordById(int id)
        => await _dbContext.BillingEntries
            .Include(t => t.Tax)
            .Include(t => t.Balance)
            .Include(t => t.Offer)
            .Include(t => t.Order)
            .Include(t => t.Type)
            .Include(t => t.Value)
            .FirstAsync(t => t.Id == id);

        public async Task SaveToDatabase(BillingEntriesWrapper billingEntriesWrapper)
        {
            foreach (var entry in billingEntriesWrapper.BillingEntries)
            {

                if (entry.Type == null) entry.Type = new Domain.JsonFileToObject.Type();
                if (entry.Offer == null) entry.Offer = new Domain.JsonFileToObject.Offer();
                if (entry.Value == null) entry.Value = new Domain.JsonFileToObject.Value();
                if (entry.Tax == null) entry.Tax = new Domain.JsonFileToObject.Tax();
                if (entry.Balance == null) entry.Balance = new Domain.JsonFileToObject.Balance();
                if (entry.Order == null) entry.Order = new Domain.JsonFileToObject.Order();

                if (string.IsNullOrEmpty(entry.Id)) entry.Id = "";
                if (entry.OccurredAt == null) entry.OccurredAt = default!;
                if (string.IsNullOrEmpty(entry.Type.Id)) entry.Type.Id = "";
                if (string.IsNullOrEmpty(entry.Type.Name)) entry.Type.Name = "";
                if (string.IsNullOrEmpty(entry.Offer.Id)) entry.Offer.Id = "";
                if (string.IsNullOrEmpty(entry.Offer.Name)) entry.Offer.Name = "";
                if (string.IsNullOrEmpty(entry.Order.Id)) entry.Order.Id = "";

                BillingEntry billingEntry = new BillingEntry()
                {
                    BillingEntryIdJson = entry.Id,
                    OccurredAt = entry.OccurredAt,
                    Type = new Domain.Entities.JsonFIle.Type() { TypeIdJson = entry.Type.Id, Name = entry.Type.Name },
                    Offer = new Offer() { OfferIdJson = entry.Offer.Id, Name = entry.Offer.Name},
                    Value = new Value() { Amount = entry.Value.Amount, Currency = entry.Value.Currency },
                    Tax = new Tax() { Percentage = entry.Tax.Percentage },
                    Balance = new Balance() { Amount = entry.Balance.Amount, Currency = entry.Balance.Currency },
                    Order = new Order() { OrderIdJson = entry.Order.Id }

                };
              await _dbContext.BillingEntries.AddAsync(billingEntry);
            }

            await _dbContext.SaveChangesAsync();
            Console.WriteLine("Billing entries have been successfully saved to the database.");
        }

        
    }


}

