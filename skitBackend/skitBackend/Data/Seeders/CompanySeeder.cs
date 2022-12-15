using Data;
using Data.Models;
using skitBackend.Data.Enums;

namespace skitBackend.Data.Seeders
{
    public class CompanySeeder
    {
        private readonly ApiDbContext _dbContext;
        public CompanySeeder(ApiDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Companies.Any())
                {
                    var companies = GetCompanies();
                    _dbContext.Companies.AddRange(companies);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Company> GetCompanies()
        {
            var companies = new List<Company>()
            {
                new Company()
                {
                    Name = "SII",
                    WorkLocation = (CompanyWorkLocation)1,
                    Size = (CompanySize)1,
                    Links = "https://sii.pl/",
                    Comments = new List<Comment>(),
                    Addresses = new List<Address>
                    {
                        new Address()
                        {
                            City = "Rzeszow",
                            RegisteredAddress = "Al. Tadeusza Rejtana 20B, 35-310 Rzeszów",
                        },
                        new Address()
                        {
                            City = "Lublin",
                            RegisteredAddress = "ul. Szeligowskiego 6B, 20-883 Lublin",
                        }
                    },
                    Technologies = new List<Technology>
                    {
                        new Technology()
                        {
                            Name = ".Net"
                        },
                        new Technology()
                        {
                            Name = "Java"
                        }
                    }
                },
                new Company()
                {
                    Name = "Comarch",
                    WorkLocation = (CompanyWorkLocation)1,
                    Size = (CompanySize)1,
                    Links = "https://www.comarch.pl/",
                    Comments = new List<Comment>(),
                    Addresses = new List<Address>
                    {
                        new Address()
                        {
                            City = "Rzeszow",
                            RegisteredAddress = "ul. Dąbrowskiego 20, 35-036 Rzeszów",
                        },
                        new Address()
                        {
                            City = "Lublin",
                            RegisteredAddress = "ul. S. Leszczyńskiego 60, 20-068 Lublin",
                        }
                    },
                    Technologies = new List<Technology>
                    {
                        new Technology()
                        {
                            Name = ".Net"
                        },
                        new Technology()
                        {
                            Name = "Java"
                        }
                    }
                }
            };
            return companies;
        }
    }
}
