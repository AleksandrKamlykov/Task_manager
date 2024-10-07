public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
}

public class Section
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class PromotionalProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SectionId { get; set; }
    public DateTime EndDate { get; set; }
}
