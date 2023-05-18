using System.ComponentModel.DataAnnotations;

namespace sistemaDeTickets.Models
{
    public class SupportTicket
    { 
        public int TicketNumber { get; set; }
        [Required(ErrorMessage = "El asunto es obligatorio")]
        [MaxLength(25)]
        public string Subject { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatorio")]
        [MaxLength(125)]
        public string Description { get; set; }
        public bool isOpen { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ResolvedDate { get; set; }


        public SupportTicket()
        {
            Random rnd = new Random();
            this.TicketNumber = rnd.Next(1, 1000 + 1);
            isOpen = true;
            CreatedDate = DateTime.Now;
            ResolvedDate = DateTime.MinValue;
        }

        public SupportTicket(int ticketNumber,string subject, string description)
        {

        TicketNumber = ticketNumber;
        Subject = subject;
        Description = description;
        isOpen = true;
        CreatedDate = DateTime.Now;
        ResolvedDate = DateTime.MinValue;

        }

        public void MarkAsResolved()
        {
            isOpen = false;
            ResolvedDate = DateTime.Now;
        }
    }
}
