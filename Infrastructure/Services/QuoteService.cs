using Dapper;
using Npgsql;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class QuoteService
    {
            private string _connectionString = "Server=127.0.0.1; Port=5432;Database=WebApi ; User Id=postgres; Password=233223;";

        public List<Quote> GetQuote()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Quotes";
                var result = connection.Query<Quote>(sql).ToList();
                return result;
            }
        }
        public List<Quote> GetCategoryById(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"SELECT * FROM Quotes where Categoryid = {id}";
                var result = connection.Query<Quote>(sql).ToList();
                return result; 
            }
        }
        public bool AddQuote(Quote quote)
        {

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $" insert into Quotes(id, Author, QuoteText, CategoryId) values ({quote.Id}, '{quote.Author}'," +
                    $"'{quote.QuoteText}', {quote.CategoryId}) ";
                var added = connection.Execute(sql);
                if (added > 0) return true;
                else return false;
            }
        }
        public bool DeleteQuote(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $" delete from Quotes  where id = {id}";
                var deleted = connection.Execute(sql);
                if (deleted > 0) return true;
                else return false;
            }
        }
        public bool UpdateQuote(Quote quote)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $" update Quotes set Author = '{quote.Author}'," +
                    $" QuoteText = '{quote.QuoteText}', CategoryId = {quote.CategoryId} where id = {quote.Id}"; 
                var updated = connection.Execute(sql);
                if (updated > 0) return true; 
                else return false;
            }
        }
    
    }
}

