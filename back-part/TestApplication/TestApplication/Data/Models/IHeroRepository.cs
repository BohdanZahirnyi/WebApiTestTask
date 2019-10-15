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
    /// <summary>
    /// repo for main functions 
    /// </summary>
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
        /// <summary>
        /// return all records
        /// </summary>
        /// <returns></returns>
        public List<Hero> GetHeroes()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Hero>("SELECT * FROM Heroes").ToList();
            }
        }
        /// <summary>
        /// return record by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Hero Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Hero>("SELECT * FROM Heroes WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }
        /// <summary>
        /// add new record to db
        /// </summary>
        /// <param name="hero"></param>
        public void Create(Hero hero)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            { 
                if (db.Query<int>("SELECT Id From Heroes").Count()==0)
                {
                    var sql = " DBCC CHECKIDENT ('[Heroes]', RESEED, 0)";
                    db.Execute(sql);
                }
                var sqlQuery = "INSERT INTO Heroes (Name) VALUES(@Name)";
                db.Execute(sqlQuery, hero);

               
            }
        }
        /// <summary>
        /// update existing record
        /// </summary>
        /// <param name="hero"></param>
        public void Update(Hero hero)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Heroes SET Name = @Name WHERE Id = @Id";
                db.Execute(sqlQuery, hero);
            }
        }
        /// <summary>
        /// delete the record
        /// </summary>
        /// <param name="id"></param>
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
