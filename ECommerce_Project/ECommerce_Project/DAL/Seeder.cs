﻿using ECommerce_Project.DAL.Entities;
using ECommerce_Project.Enum;
using ECommerce_Project.Helpers;

namespace ECommerce_Project.DAL
{
    public class Seeder
    {
        private readonly DataBaseContext _context;
        private readonly IUserHelper _userHelper;

        public Seeder(DataBaseContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await PopulateCategoriesAsync();
            await PopulateCountriesStatesCitiesAsync();
            await PopulateRolesAsync();
            await PopulateUserAsync("First Name Admin", "Last Name Role", "adminrole@yopmail.com", "Phone 3002323232", "Add Street Fighter", "Doc 102030", UserType.Admin);
            await PopulateUserAsync("First Name User", "Last Name Role", "userrole@yopmail.com", "Phone 3502323232", "Address Street Fighter 2", "Doc 405060", UserType.User);

            await _context.SaveChangesAsync();
        }

        private async Task PopulateCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Tecnología", Description = "Elementos tech", CreateDate = DateTime.Now });
                _context.Categories.Add(new Category { Name = "Implementos de Aseo", Description = "Detergente, jabón, etc.", CreateDate = DateTime.Now });
                _context.Categories.Add(new Category { Name = "Ropa interior", Description = "Tanguitas, narizonas", CreateDate = DateTime.Now });
                _context.Categories.Add(new Category { Name = "Gamers", Description = "PS5, XBOX SERIES", CreateDate = DateTime.Now });
                _context.Categories.Add(new Category { Name = "Mascotas", Description = "Concentrado, jabón para pulgas.", CreateDate = DateTime.Now });
            }
        }

        private async Task PopulateCountriesStatesCitiesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(
                new Country
                {
                    Name = "Colombia",
                    CreateDate = DateTime.Now,
                    States = new List<State>()
                    {
                        new State
                        {
                            Name = "Antioquia",
                            CreateDate = DateTime.Now,
                            Cities = new List<City>()
                            {
                                new City { Name = "Medellín", CreateDate= DateTime.Now },
                                new City { Name = "Bello", CreateDate= DateTime.Now },
                                new City { Name = "Itagüí", CreateDate= DateTime.Now },
                                new City { Name = "Sabaneta", CreateDate= DateTime.Now },
                                new City { Name = "Envigado", CreateDate= DateTime.Now },
                            }
                        },

                        new State
                        {
                            Name = "Cundinamarca",
                            CreateDate = DateTime.Now,
                            Cities = new List<City>()
                            {
                                new City { Name = "Bogotá", CreateDate= DateTime.Now },
                                new City { Name = "Fusagasugá", CreateDate= DateTime.Now },
                                new City { Name = "Funza", CreateDate= DateTime.Now },
                                new City { Name = "Sopó", CreateDate= DateTime.Now },
                                new City { Name = "Chía", CreateDate= DateTime.Now },
                            }
                        },

                        new State
                        {
                            Name = "Atlántico",
                            CreateDate = DateTime.Now,
                            Cities = new List<City>()
                            {
                                new City { Name = "Barranquilla", CreateDate= DateTime.Now },
                                new City { Name = "La Chinita", CreateDate= DateTime.Now },
                            }
                        },
                    }
                });

                _context.Countries.Add(
                new Country
                {
                    Name = "Argentina",
                    CreateDate = DateTime.Now,
                    States = new List<State>()
                    {
                        new State
                        {
                            Name = "Buenos Aires",
                            CreateDate = DateTime.Now,
                            Cities = new List<City>()
                            {
                                new City { Name = "Avellaneda", CreateDate= DateTime.Now },
                                new City { Name = "Ezeiza", CreateDate= DateTime.Now },
                                new City { Name = "La Boca", CreateDate= DateTime.Now },
                                new City { Name = "Río de la Plata", CreateDate= DateTime.Now },
                            }
                        },

                        new State
                        {
                            Name = "La Pampa",
                            CreateDate = DateTime.Now,
                            Cities = new List<City>()
                            {
                                new City { Name = "Santa María", CreateDate= DateTime.Now },
                                new City { Name = "Obrero", CreateDate= DateTime.Now },
                                new City { Name = "Rosario", CreateDate= DateTime.Now }
                            }
                        }
                    }
                });
            }
        }


        private async Task PopulateRolesAsync()
        {
            await _userHelper.AddRoleAsync(UserType.Admin.ToString());
            await _userHelper.AddRoleAsync(UserType.User.ToString());
        }

        private async Task PopulateUserAsync(string firstName, string lastName, string email, string phone, string address, string document, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);

            if (user == null)
            {
                user = new User
                {
                    CreatedDate = DateTime.Now,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    City = _context.Cities.FirstOrDefault(),
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
        }
    }
}
