using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;
using FileData;
using Microsoft.AspNetCore.Components.Rendering;

namespace WebAPI.Data.Impl
{
    public class PersistenceAdapter : IAdultService
    {

        private FileContext file;

        public PersistenceAdapter()
        {
            file = new FileContext();
        }

        public void AddAdult(Adult adultToAdd)
        {
            Console.WriteLine("I am here.....");
            try
            {
                int max = 0;
                if (file.Adults.Count>0)
                  max = file.Adults.Max(a => a.Id);
                adultToAdd.Id = (++max);
                file.Adults.Add(adultToAdd);
                file.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        public IList<Adult> ReadAllAdults()
        {
            return file.Adults;
        }

        public void UpdateAdult(Adult adultToUpdate)
        {
            foreach (var adult in file.Adults)
            {
                if (adult.Id == adultToUpdate.Id)
                {
                    adult.Update(adultToUpdate);
                    file.SaveChanges();
                    return;
                }
            }
        }

        public void DeleteAdult(Adult adultToDelete)
        {
            foreach (var adult in file.Adults)
            {
                if (adult.Id == adultToDelete.Id)
                {
                    file.Adults.Remove(adult);
                    file.SaveChanges();
                    return;
                }
            }
        }
    }
}