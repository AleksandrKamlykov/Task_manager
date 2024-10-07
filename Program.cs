
var repository = new MailingListRepository();

while (true)
{
    Console.WriteLine("1. Insert Customer");
    Console.WriteLine("2. Insert Country");
    Console.WriteLine("3. Insert City");
    Console.WriteLine("4. Insert Section");
    Console.WriteLine("5. Insert Promotional Product");
    Console.WriteLine("6. Update Customer");
    Console.WriteLine("7. Update Country");
    Console.WriteLine("8. Update City");
    Console.WriteLine("9. Update Section");
    Console.WriteLine("10. Update Promotional Product");
    Console.WriteLine("11. Delete Customer");
    Console.WriteLine("12. Delete Country");
    Console.WriteLine("13. Delete City");
    Console.WriteLine("14. Delete Section");
    Console.WriteLine("15. Delete Promotional Product");
    Console.WriteLine("16. Display Cities by Country");
    Console.WriteLine("17. Display Sections by Customer");
    Console.WriteLine("18. Display Promotional Products by Section");
    Console.WriteLine("19. Show Top 3 Popular Sections");
    Console.WriteLine("20. Show Most Popular Section");
    Console.WriteLine("21. Show Top 3 Sections by Promotional Products");
    Console.WriteLine("22. Show Section with Most Promotional Products");
    Console.WriteLine("0. Exit");
    Console.Write("Select an option: ");
    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.Write("Enter customer name: ");
            var customerName = Console.ReadLine();
            Console.Write("Enter customer email: ");
            var customerEmail = Console.ReadLine();
            repository.InsertCustomer(new Customer { Name = customerName, Email = customerEmail });
            break;
        case "2":
            Console.Write("Enter country name: ");
            var countryName = Console.ReadLine();
            repository.InsertCountry(new Country { Name = countryName });
            break;
        case "3":
            Console.Write("Enter city name: ");
            var cityName = Console.ReadLine();
            Console.Write("Enter country ID: ");
            var countryId = int.Parse(Console.ReadLine());
            repository.InsertCity(new City { Name = cityName, CountryId = countryId });
            break;
        case "4":
            Console.Write("Enter section name: ");
            var sectionName = Console.ReadLine();
            repository.InsertSection(new Section { Name = sectionName });
            break;
        case "5":
            Console.Write("Enter product name: ");
            var productName = Console.ReadLine();
            Console.Write("Enter section ID: ");
            var sectionId = int.Parse(Console.ReadLine());
            Console.Write("Enter end date (yyyy-mm-dd): ");
            var endDate = DateTime.Parse(Console.ReadLine());
            repository.InsertPromotionalProduct(new PromotionalProduct { Name = productName, SectionId = sectionId, EndDate = endDate });
            break;
        case "6":
            Console.Write("Enter customer ID: ");
            var customerId = int.Parse(Console.ReadLine());
            Console.Write("Enter new customer name: ");
            customerName = Console.ReadLine();
            Console.Write("Enter new customer email: ");
            customerEmail = Console.ReadLine();
            repository.UpdateCustomer(new Customer { Id = customerId, Name = customerName, Email = customerEmail });
            break;
        case "7":
            Console.Write("Enter country ID: ");
            countryId = int.Parse(Console.ReadLine());
            Console.Write("Enter new country name: ");
            countryName = Console.ReadLine();
            repository.UpdateCountry(new Country { Id = countryId, Name = countryName });
            break;
        case "8":
            Console.Write("Enter city ID: ");
            var cityId = int.Parse(Console.ReadLine());
            Console.Write("Enter new city name: ");
            cityName = Console.ReadLine();
            Console.Write("Enter new country ID: ");
            countryId = int.Parse(Console.ReadLine());
            repository.UpdateCity(new City { Id = cityId, Name = cityName, CountryId = countryId });
            break;
        case "9":
            Console.Write("Enter section ID: ");
            sectionId = int.Parse(Console.ReadLine());
            Console.Write("Enter new section name: ");
            sectionName = Console.ReadLine();
            repository.UpdateSection(new Section { Id = sectionId, Name = sectionName });
            break;
        case "10":
            Console.Write("Enter product ID: ");
            var productId = int.Parse(Console.ReadLine());
            Console.Write("Enter new product name: ");
            productName = Console.ReadLine();
            Console.Write("Enter new section ID: ");
            sectionId = int.Parse(Console.ReadLine());
            Console.Write("Enter new end date (yyyy-mm-dd): ");
            endDate = DateTime.Parse(Console.ReadLine());
            repository.UpdatePromotionalProduct(new PromotionalProduct { Id = productId, Name = productName, SectionId = sectionId, EndDate = endDate });
            break;
        case "11":
            Console.Write("Enter customer ID: ");
            customerId = int.Parse(Console.ReadLine());
            repository.DeleteCustomer(customerId);
            break;
        case "12":
            Console.Write("Enter country ID: ");
            countryId = int.Parse(Console.ReadLine());
            repository.DeleteCountry(countryId);
            break;
        case "13":
            Console.Write("Enter city ID: ");
            cityId = int.Parse(Console.ReadLine());
            repository.DeleteCity(cityId);
            break;
        case "14":
            Console.Write("Enter section ID: ");
            sectionId = int.Parse(Console.ReadLine());
            repository.DeleteSection(sectionId);
            break;
        case "15":
            Console.Write("Enter product ID: ");
            productId = int.Parse(Console.ReadLine());
            repository.DeletePromotionalProduct(productId);
            break;
        case "16":
            Console.Write("Enter country ID: ");
            countryId = int.Parse(Console.ReadLine());
            var cities = repository.GetCitiesByCountry(countryId);
            foreach (var city in cities)
            {
                Console.WriteLine($"City ID: {city.Id}, Name: {city.Name}");
            }
            break;
        case "17":
            Console.Write("Enter customer ID: ");
            customerId = int.Parse(Console.ReadLine());
            var sections = repository.GetSectionsByCustomer(customerId);
            foreach (var section in sections)
            {
                Console.WriteLine($"Section ID: {section.Id}, Name: {section.Name}");
            }
            break;
        case "18":
            Console.Write("Enter section ID: ");
            sectionId = int.Parse(Console.ReadLine());
            var products = repository.GetPromotionalProductsBySection(sectionId);
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, End Date: {product.EndDate}");
            }
            break;
        case "19":
            var top3PopularSections = repository.GetTop3PopularSections();
            foreach (var section in top3PopularSections)
            {
                Console.WriteLine($"Section ID: {section.Id}, Name: {section.Name}");
            }
            break;
        case "20":
            var mostPopularSection = repository.GetMostPopularSection();
            Console.WriteLine($"Section ID: {mostPopularSection.Id}, Name: {mostPopularSection.Name}");
            break;
        case "21":
            var top3SectionsByProducts = repository.GetTop3SectionsByPromotionalProducts();
            foreach (var section in top3SectionsByProducts)
            {
                Console.WriteLine($"Section ID: {section.Id}, Name: {section.Name}");
            }
            break;
        case "22":
            var sectionWithMostProducts = repository.GetSectionWithMostPromotionalProducts();
            Console.WriteLine($"Section ID: {sectionWithMostProducts.Id}, Name: {sectionWithMostProducts.Name}");
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}