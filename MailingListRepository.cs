using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

public class MailingListRepository
{
    private readonly string _connectionString = "Server=Oleksandr-PC;" +
        "Database=task_managment;" +
        "Integrated Security=True;" +
        "TrustServerCertificate=true;";
 

    // Insert methods
    public void InsertCustomer(Customer customer)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "INSERT INTO Customers (Name, Email) VALUES (@Name, @Email)";
            connection.Execute(sql, customer);
        }
    }

    public void InsertCountry(Country country)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "INSERT INTO Countries (Name) VALUES (@Name)";
            connection.Execute(sql, country);
        }
    }

    public void InsertCity(City city)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "INSERT INTO Cities (Name, CountryId) VALUES (@Name, @CountryId)";
            connection.Execute(sql, city);
        }
    }

    public void InsertSection(Section section)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "INSERT INTO Sections (Name) VALUES (@Name)";
            connection.Execute(sql, section);
        }
    }

    public void InsertPromotionalProduct(PromotionalProduct product)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "INSERT INTO PromotionalProducts (Name, SectionId, EndDate) VALUES (@Name, @SectionId, @EndDate)";
            connection.Execute(sql, product);
        }
    }

    // Update methods
    public void UpdateCustomer(Customer customer)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "UPDATE Customers SET Name = @Name, Email = @Email WHERE Id = @Id";
            connection.Execute(sql, customer);
        }
    }

    public void UpdateCountry(Country country)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "UPDATE Countries SET Name = @Name WHERE Id = @Id";
            connection.Execute(sql, country);
        }
    }

    public void UpdateCity(City city)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "UPDATE Cities SET Name = @Name, CountryId = @CountryId WHERE Id = @Id";
            connection.Execute(sql, city);
        }
    }

    public void UpdateSection(Section section)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "UPDATE Sections SET Name = @Name WHERE Id = @Id";
            connection.Execute(sql, section);
        }
    }

    public void UpdatePromotionalProduct(PromotionalProduct product)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "UPDATE PromotionalProducts SET Name = @Name, SectionId = @SectionId, EndDate = @EndDate WHERE Id = @Id";
            connection.Execute(sql, product);
        }
    }

    // Delete methods
    public void DeleteCustomer(int customerId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "DELETE FROM Customers WHERE Id = @Id";
            connection.Execute(sql, new { Id = customerId });
        }
    }

    public void DeleteCountry(int countryId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "DELETE FROM Countries WHERE Id = @Id";
            connection.Execute(sql, new { Id = countryId });
        }
    }

    public void DeleteCity(int cityId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "DELETE FROM Cities WHERE Id = @Id";
            connection.Execute(sql, new { Id = cityId });
        }
    }

    public void DeleteSection(int sectionId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "DELETE FROM Sections WHERE Id = @Id";
            connection.Execute(sql, new { Id = sectionId });
        }
    }

    public void DeletePromotionalProduct(int productId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "DELETE FROM PromotionalProducts WHERE Id = @Id";
            connection.Execute(sql, new { Id = productId });
        }
    }

    // Display methods
    public IEnumerable<City> GetCitiesByCountry(int countryId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "SELECT * FROM Cities WHERE CountryId = @CountryId";
            return connection.Query<City>(sql, new { CountryId = countryId });
        }
    }

    public IEnumerable<Section> GetSectionsByCustomer(int customerId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "SELECT s.* FROM Sections s JOIN CustomerSections cs ON s.Id = cs.SectionId WHERE cs.CustomerId = @CustomerId";
            return connection.Query<Section>(sql, new { CustomerId = customerId });
        }
    }

    public IEnumerable<PromotionalProduct> GetPromotionalProductsBySection(int sectionId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "SELECT * FROM PromotionalProducts WHERE SectionId = @SectionId";
            return connection.Query<PromotionalProduct>(sql, new { SectionId = sectionId });
        }
    }
    public IEnumerable<Section> GetTop3PopularSections()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = @"
            SELECT TOP 3 s.Id, s.Name, COUNT(cs.SectionId) AS Popularity
            FROM Sections s
            JOIN CustomerSections cs ON s.Id = cs.SectionId
            GROUP BY s.Id, s.Name
            ORDER BY Popularity DESC";
            return connection.Query<Section>(sql);
        }
    }

    // Get most popular section
    public Section GetMostPopularSection()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = @"
            SELECT TOP 1 s.Id, s.Name, COUNT(cs.SectionId) AS Popularity
            FROM Sections s
            JOIN CustomerSections cs ON s.Id = cs.SectionId
            GROUP BY s.Id, s.Name
            ORDER BY Popularity DESC";
            return connection.QuerySingleOrDefault<Section>(sql);
        }
    }

    // Get top 3 sections by promotional products
    public IEnumerable<Section> GetTop3SectionsByPromotionalProducts()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = @"
            SELECT TOP 3 s.Id, s.Name, COUNT(pp.Id) AS ProductCount
            FROM Sections s
            JOIN PromotionalProducts pp ON s.Id = pp.SectionId
            GROUP BY s.Id, s.Name
            ORDER BY ProductCount DESC";
            return connection.Query<Section>(sql);
        }
    }

    // Get section with most promotional products
    public Section GetSectionWithMostPromotionalProducts()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = @"
            SELECT TOP 1 s.Id, s.Name, COUNT(pp.Id) AS ProductCount
            FROM Sections s
            JOIN PromotionalProducts pp ON s.Id = pp.SectionId
            GROUP BY s.Id, s.Name
            ORDER BY ProductCount DESC";
            return connection.QuerySingleOrDefault<Section>(sql);
        }
    }
