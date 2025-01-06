using System;

[ApiController]
[Route("api/[controller]")]
public class MailsController : ControllerBase
{
    private readonly IMailRepository _mailRepository;
    private readonly IEmailService _emailService;

    public ProductsController(IMailRepository mailRepository, IEmailService emailService)
    {
        _mailRepository = mailRepository;
        _emailService = emailService;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(Mail mail)
    {
        await _MailRepository.AddMailAsync(mail);
        await _emailService.SendEmailAsync("recipient@example.com", "New Product Added", $"Product {Mail.Name} has been added.");
        return CreatedAtAction(nameof(GetMailById), new { id = Mail.Id }, mail);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMailById(int id)
    {
        var mail = await _mailRepository.GetMailByIdAsync(id);
        if (mail == null)
        {
            return NotFound();
        }
        return Ok(mail);
    }
}
