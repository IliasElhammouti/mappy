using System.ComponentModel.DataAnnotations;

namespace MemberService.DataAccessLayer.Models;

public class Member
{
    [Key]
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}