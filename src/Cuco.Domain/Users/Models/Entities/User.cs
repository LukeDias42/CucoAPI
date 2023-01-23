using Cuco.Commons.Base;
using Cuco.Domain.Roles.Models.Entities;
using Cuco.Domain.Users.Services.Extensions;

namespace Cuco.Domain.Users.Models.Entities;

public class User : Entity
{
    public string Name { get; private set; }
    public string Password { get; private set; }
    public Role Role { get; private set; }
    public long RoleId { get; private set; }

    public User(string name, string password, Role role)
    {
        Name = name;
        Password = password.Hash();
        Role = role;
        RoleId = role.Id;
    }

}