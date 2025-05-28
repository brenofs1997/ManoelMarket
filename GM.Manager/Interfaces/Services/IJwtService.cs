using GM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Manager.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);

    }
}
