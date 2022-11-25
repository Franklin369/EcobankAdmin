using System;
using System.Collections.Generic;
using System.Text;

namespace EcobankAdmin.Services
{
    public interface IGoogleAuthService
    {
        void Autheticate(IGoogleAuthenticationDelegate googleAuthenticationDelegate);

    }
}
