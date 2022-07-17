using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vasotoSQLAzure.Models;

namespace vasotoSQLAzure.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class ContactController : Controller
    {
        private ContactsContext contactsContext;

        public ContactController(ContactsContext context)
        {
            contactsContext = context;
        }

        public object ContactContext { get; private set; }

        [HttpGet(Name = "Contacts")]
        public  ActionResult<IEnumerable<Contacts>> Get()
        {
            return contactsContext.ContactSet.ToList();
        }

        [HttpGet ("{id}")]
        public ActionResult<Contacts> Get (int id) 
        {
            var data = contactsContext.ContactSet.FirstOrDefault(x =>x.Identificador == id);
            return data;
        }

        [HttpPost]
        public IActionResult Post ([FromBody] Contacts value) 
        {
            Contacts newContact = value;
            contactsContext.ContactSet.Add(newContact);
            contactsContext.SaveChanges();
            return Ok("Se agregó correctamente");
        }

        [HttpPut ("{id}")]
        public ActionResult<Contacts> Put (int id, [FromBody] Contacts value) 
        {
            var data = contactsContext.ContactSet.Find(id);
            contactsContext.Entry(data).State = EntityState.Modified;
            data.Nombre = value.Nombre;
            data.Email = value.Email;
            data.Telefono = value.Telefono;
            contactsContext.SaveChanges();
            return Ok("Actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public  ActionResult Delete(int id)
        {
            var data =  contactsContext.ContactSet.Find(id);
            contactsContext.Remove(data);
            contactsContext.SaveChanges();
            return Ok("Eliminado correctamente");
        }
    }
}