using System;

public class MailRepository 
{
    public MailRepository()
    {


    private readonly AppDbContext _context;

    public MailRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Mail>> GetAllMailsAsync()
    {
        return await _context.Mails.ToListAsync();
    }

    public async Task<Mail> GetMailByIdAsync(int id)
    {
        return await _context.Mails.FindAsync(id);
    }

    public async Task AddMailAsync(Mail mail)
    {
        await _context.Mails.AddAsync(mail);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMailAsync(Mail mail)
    {
        _context.Mails.Update(mail);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMailAsync(int id)
    {
        var mail = await _context.Mails.FindAsync(id);
        if (mail != null)
        {
            _context.Mails.Remove(mail);
            await _context.SaveChangesAsync();
        }
    }
}
    }
}

