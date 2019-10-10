using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Models;

namespace TestApplication.Data.Models
{
    public interface IHeroRepository
    {
        void Create(Hero hero);
        void Delete(int id);
        Hero Get(int id);
        List<Hero> GetHeroes();
        void Update(Hero hero);
    }
    public class HeroRepository : IHeroRepository
    {
        string connectionString = null;
        public HeroRepository(string conn)
        {
            connectionString = conn;
        }
        public List<Hero> GetHeroes()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Hero>("SELECT * FROM Heroes").ToList();
            }
        }

        public Hero Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Hero>("SELECT * FROM Heroes WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Hero hero)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Heroes (Id, Name) VALUES(@Id, @Name)";
                db.Execute(sqlQuery, hero);

                // если мы хотим получить id добавленного пользователя
                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
            }
        }

        public void Update(Hero hero)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Heroes SET Name = @Name WHERE Id = @Id";
                db.Execute(sqlQuery, hero);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Heroes WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
