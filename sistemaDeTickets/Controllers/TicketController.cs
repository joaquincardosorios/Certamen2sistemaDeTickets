using Microsoft.AspNetCore.Mvc;
using sistemaDeTickets.Models;

namespace sistemaDeTickets.Controllers
{
    public class TicketController : Controller
    {
        private static List<SupportTicket> _data = new List<SupportTicket>()
        {
            new SupportTicket{ Subject="Error solicitud en DB", Description="Muestra en pantalla error XLM y no permite acceder a la informacion solicitada, esto ocurre al intentar acceder al listado de pacientes", CreatedDate=DateTime.Now.AddDays(-2)}
        };


        public IActionResult Index()
        {
            List <SupportTicket> ticketsAbiertos = new List<SupportTicket>();
            foreach (SupportTicket ticket in _data)
            {
                if (ticket.isOpen)
                {
                    ticketsAbiertos.Add(ticket);
                }
            }
            return View(ticketsAbiertos);
        }

        public IActionResult NuevoTicket()
        {
            return View();
        }

        public IActionResult Guardar(SupportTicket ticket)
        {

            if (!ModelState.IsValid)
            {
                return View("nuevoTicket");
            }
            _data.Add(ticket);
            return RedirectToAction("Index");
        }

        public IActionResult ticketCerrado()
        {
            List<SupportTicket> ticketsCerrados = new List<SupportTicket>();
            foreach (SupportTicket ticket in _data)
            {
                if (!ticket.isOpen)
                {
                    ticketsCerrados.Add(ticket);
                }
            }
            return View(ticketsCerrados);
        }

        public IActionResult CerrarTicket(int ticketNumber)
        {
            SupportTicket ticket = _data.Find(e => e.TicketNumber == ticketNumber);
            ticket.MarkAsResolved();

            return RedirectToAction("Index");
        }
    }
}
