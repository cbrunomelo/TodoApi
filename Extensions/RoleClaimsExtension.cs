using System.Linq;
using System.Security.Claims;
using TodoAPi.Models;

namespace TodoAPi.Externsions;
public static class RoleClaimsExtension
{
    public static IEnumerable<Claim> GetClaims(this User user)
    {
        var result = new List<Claim>
        {
            new(ClaimTypes.Name, user.Email.ToString())
        };
        result.AddRange(
            
            user.UserRoles.Select(role =>new Claim(ClaimTypes.Role, role.RoleName.ToString()) )
        );
        return result;
    }
}

