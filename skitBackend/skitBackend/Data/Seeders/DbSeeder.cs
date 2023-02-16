using Data;
using Data.Models;
using skitBackend.Data.Enums;
using skitBackend.Data.Models;
using System.Text.Json;

namespace skitBackend.Data.Seeders
{
    public class DbSeeder
    {
        private readonly ApiDbContext _dbContext;
        public DbSeeder(ApiDbContext dbContext)
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
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Id= 1,
                    Name = "BusinessUser"
                },
                new Role()
                {
                    Id= 2,
                    Name = "Moderator"
                },
                new Role()
                {
                    Id= 3,
                    Name = "Admin"
                }
            };

            return roles;
        }

        private IEnumerable<Company> GetCompanies()
        {
            var companies = new List<Company>()
            {
                new Company()
                {
                    Name = "SII",
                    WorkLocation = CompanyWorkLocation.Hybrid,
                    Size = (CompanySize)1,
                    Links = new List<string>()
                    {
                        "https://sii.pl/",
                        "https://sii.com/"
                    },
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
                    Links = new List<string>()
                    {
                        "https://www.comarch.pl/"
                    },
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
