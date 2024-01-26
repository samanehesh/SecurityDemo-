﻿using Microsoft.Data.Sqlite;
using SecurityDemo.Data;
using SecurityDemo.Models;
using System.Data.SQLite;

namespace SecurityDemo.Repositories
{
    public class SqlDbRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public SqlDbRepository(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        public List<string> GetCities(out string message)
        {
            message = string.Empty;
            List<string> cities = new List<string>();


            try
            {
                cities = _context.Cities.Select(c => c.cityId + "," + c.cityName).ToList();

            }
            catch (Exception e)
            {
                message = $"Error retrieving cities: {e.Message}";
            }
            if (cities.Count() == 0)
            {
                message = $"No cities";
            }
            return cities;
        }
        public string GetCityName(string cityId)
        {
            string cityName = string.Empty;

            try
            {
                int id = int.Parse(cityId);
                City city = _context.Cities.FirstOrDefault(c => c.cityId == id);
                if (city != null)
                {
                    cityName = city.cityName;
                }
            }
            catch (Exception e)
            {
                string message = $"Error executing QL statement: {e.Message}";
            }
            return cityName;
        }

        public List<string> GetBuildingsInCity(string cityId)
        {
            int id = int.Parse(cityId);

            List<string> list = new List<string>();

            try
            {

                var query = from building in _context.Buildings
                            where building.cityId == id
                            join room in _context.Rooms on building.buildingId equals room.buildingId
                           
                            select new
                            {
                                BuildingId=building.buildingId,
                                BuildingName=building.name,
                                RoomName = room.name ,
                                Capacity=room.capacity
                            };

                foreach (var result in query)
                {
                    list.Add($"{result.BuildingId},{result.BuildingName},{result.RoomName},{result.Capacity}");
                }

            }
            catch (Exception e)
            {
                string message = $"Error retrieving city name: {e.Message}";
            }
            return list;
        }
        public List<string> GetRegisteredUsers()
        {
            List<string> list = new List<string>();
            string cityName = string.Empty;

            try
            {
                var query = from user in _context.Users
                            join userRole in _context.UserRoles on user.Id equals userRole.UserId
                            join role in _context.Roles on userRole.RoleId equals role.Id
                            select new
                            {
                                UserId = user.Id,
                                UserName = user.UserName,
                                RoleId = role.Id
                            };

                foreach (var result in query)
                {
                    list.Add($"{result.UserId},{result.UserName},{result.RoleId}");
                }
                //string connectionString = "Data Source=.\\wwwroot\\sql.db";

                //using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                //{
                //    connection.Open();

                //    string sql = $"SELECT AspNetUsers.Id, AspNetUsers.UserName, " +
                //                    $"AspNetUserRoles.RoleId FROM AspNetUsers INNER " +
                //                    $"JOIN AspNetUserRoles ON AspNetUsers.Id = " +
                //                    $"AspNetUserRoles.UserId INNER JOIN AspNetRoles " +
                //                    $"ON AspNetUserRoles.RoleId = AspNetRoles.Id;";

                //    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                //    {
                //        using (SQLiteDataReader reader = cmd.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                list.Add($"{reader.GetString(0)},{reader.GetString(1)}," +
                //                            $"{reader.GetString(2)}");
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception e)
            {
                string message = $"Error retrieving city name: {e.Message}";
            }
            return list;
        }


        public List<ProductVM> GetProducts()
        {
            List<ProductVM> products = new List<ProductVM>();

            try
            {
                 products = _context.Products
                    .Select(p => new ProductVM
                     {
                         ProdID = p.ProdID,
                         ProdName = p.ProdName,
                         Price = p.Price,
        // Include other properties from ProductVM based on your needs
                      }).ToList();

                //string connectionString = "Data Source=.\\wwwroot\\sql.db";

                //using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                //{
                //    connection.Open();

                //    string sql = $"SELECT * FROM Products";

                //    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                //    {
                //        using (SQLiteDataReader reader = cmd.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                products.Add(new ProductVM
                //                {
                //                    ProdName = (string)reader["prodName"],
                //                    ProdID = (string)reader["prodID"],
                //                    Price = (decimal)reader["price"]
                //                });
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception e)
            {
                string message = $"Error retrieving product name: {e.Message}";
            }
            return products;
        }

        public ProductVM GetProduct(string productID)
        {
            ProductVM productVM = new ProductVM();

            try
            {
                productVM = _context.Products.FirstOrDefault(p => p.ProdID == productID);

                //string connectionString = "Data Source=.\\wwwroot\\sql.db";

                //using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                //{
                //    connection.Open();

                //    string sql = $"SELECT * FROM products WHERE prodID= {productID}";

                //    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                //    {
                //        using (SQLiteDataReader reader = cmd.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {

                //                productVM = new ProductVM
                //                {
                //                    ProdName = (string)reader["prodName"],
                //                    ProdID = (string)reader["prodID"],
                //                    Price = (decimal)reader["price"]
                //                };
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception e)
            {
                string message = $"Error retrieving product name: {e.Message}";
            }

            return productVM;
        }


    }
}
