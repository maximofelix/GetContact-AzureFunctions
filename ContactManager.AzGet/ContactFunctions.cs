using ContactManager.AzGet.Data.Domain.Models;
using ContactPersistence.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace ContactManager.AzGet
{
    public class ContactFunctions
    {
        private readonly IContactRepository repo;

        public ContactFunctions(IContactRepository repo)
        {
            this.repo = repo;
        }

        [Function("GetContacts")]
        public async Task<IActionResult> GetAll([HttpTrigger(AuthorizationLevel.Function, "get", Route = "contacts")] HttpRequest req)
        {
            IEnumerable<Contact> contacts = await repo.GetAllAsync();
            return new OkObjectResult(contacts);
        }

        [Function("GetContactById")]
        public async Task<IActionResult> GetById([HttpTrigger(AuthorizationLevel.Function, "get", Route = "contacts/{id}")] HttpRequest req, Guid id)
        {
            Contact contacts = await repo.GetByIdAsync(id);
            return new OkObjectResult(contacts);
        }

        [Function("GetContactByDDD")]
        public async Task<IActionResult> GetByDDD([HttpTrigger(AuthorizationLevel.Function, "get", Route = "contacts/ddd/{ddd}")] HttpRequest req, int ddd)
        {
            IEnumerable<Contact> contacts = await repo.GetByDDDAsync(ddd);
            return new OkObjectResult(contacts);
        }

        [Function("GetContactByPhone")]
        public async Task<IActionResult> GetByPhone([HttpTrigger(AuthorizationLevel.Function, "get", Route = "contacts/phone/{phoneNumber}")] HttpRequest req, string phoneNumber)
        {
            Contact contacts = await repo.GetByPhoneAsync(phoneNumber);
            return new OkObjectResult(contacts);
        }
    }
}

 
// //using CreateContact.Application.Persistence;
////using CreateContact.Domain.Entities;
//using ContactManager.AzGet.Data.Domain.Models;
//using ContactPersistence.Data.Repositories;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure.Functions.Worker;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore.Storage.Json;
//using Microsoft.Extensions.Logging;
//using System.Threading.Tasks;

//namespace ContactManager.AzGet
//{
//    public class ContactFunctions
//    {
//        //private readonly IMediator _dispatcher;
//        private readonly IContactRepository repo;

//        public ContactFunctions(/*IMediator dispatcher, IContactRepository repo*/)
//        {
//    //_dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
//    this.repo = repo;
//}

//[Function("GetContacts")]
//public async Task<IActionResult> GetAll([HttpTrigger(AuthorizationLevel.Function, "get", Route = "contacts")] HttpRequest req)
//{
//    string _connectionString = "Server=localhost;Database=ContactManagerDb;User Id=sa;Password=P@ssw0rd1;Encrypt=False;TrustServerCertificate=True";
//    //_connectionString = "Server=sqlserver-container,1433;Database=ContactManagerDb;User Id=sa;Password=P@ssw0rd1;TrustServerCertificate=True;";

//    var contacts = new List<Contacts>();
//    string query = "SELECT id, name, Region_DddCode, phone, email FROM Contacts";

//    try
//    {
//        using (SqlConnection connection = new SqlConnection(_connectionString))
//        {
//            connection.Open();
//            using (SqlCommand command = new SqlCommand(query, connection))
//            using (SqlDataReader reader = command.ExecuteReader())
//            {
//                while (reader.Read())
//                {
//                    contacts.Add(new Contacts
//                    {
//                        Id = reader.GetGuid(0),
//                        Name = reader.GetString(1),
//                        RegionNumber = reader.GetInt32(2),
//                        Phone = reader.GetString(3),
//                        Email = reader.IsDBNull(4) ? null : reader.GetString(4)
//                    });
//                }
//            }
//        }
//    }
//    catch (Exception ex)
//    {

//    }
//    /*
//        /return new OkObjectResult(contacts);
//      //try
//      //{
//      //    var contacts = await repo.GetAll();
//      //    return new OkObjectResult(contacts);
//      //}
//      //catch (Exception ex)
//      //{
//      //    throw;
//      //}






//      //var retorno = new List<Contacts37.Domain.Entities.Contact>
//      //{
//      //    Contacts37.Domain.Entities.Contact.Create("Contato 1",98, "987654321","contato1@email.com"),
//      //    Contacts37.Domain.Entities.Contact.Create("Contato 2",98, "987654322","contato2@email.com"),
//      //    Contacts37.Domain.Entities.Contact.Create("Contato 3",98, "987654333","contato3@email.com")
//      //};
//       */
//    return new OkObjectResult(contacts);
//}

//        //[Function("GetContactById")]
//        //public IActionResult GetById([HttpTrigger(AuthorizationLevel.Function, "get", /*"post",*/ Route = "contacts/{id}")] HttpRequest req, int id)
//        //{
//        //    _logger.LogInformation("C# HTTP trigger function processed a request. -> GetById");
//        //    var retorno = Contacts37.Domain.Entities.Contact.Create("Contato 1", 98, "987654321", "contato1@email.com");
//        //    return new OkObjectResult(retorno);
//        //}

//        //[Function("GetContactByPhone")]
//        //public IActionResult GetByPhone([HttpTrigger(AuthorizationLevel.Function, "get", /*"post",*/ Route = "contacts/phone/{phoneNumber}")] HttpRequest req, string phoneNumber)
//        //{
//        //    _logger.LogInformation("C# HTTP trigger function processed a request. -> GetContactByPhone");
//        //    var retorno = Contacts37.Domain.Entities.Contact.Create("Contato 1", 98, phoneNumber, "contato1@email.com");
//        //    return new OkObjectResult(retorno);
//        //}
//    }

//    class Contacts
//{
//    public Guid Id { get; set; }
//    public string Name { get; set; }
//    public int RegionNumber { get; set; }
//    public string Phone { get; set; }
//    public string Email { get; set; }
//}
//} 