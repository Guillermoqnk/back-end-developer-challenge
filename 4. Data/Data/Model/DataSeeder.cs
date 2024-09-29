using Data.Entities;
using Data.Model.Entities;
using DnDBeyondAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class DataSeeder
    {
        private readonly DnDContext _context;

        public DataSeeder(DnDContext context)
        {
            _context = context;
        }

        public async void Seed()
        {
            if (!_context.Class.Any())
            {
                var classSeed = new List<Class>
                {
                    new Class
                    {
                        
                    }
                };

                await _context.AddRangeAsync(classSeed);

                await _context.SaveChangesAsync();
            }

            if (!_context.Characters.Any())
            {
                await _context.SaveChangesAsync();
            }

            _context.Dispose();
        }
    }
}
