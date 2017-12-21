using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelventDMS.Services.NetworkModelService.TestClient.Tests;

namespace WpfClient.UserSession
{
    public class UserSession
    {
        private static TestGda instance = null;

        public static TestGda Instance()
        {
            if (instance == null)
            {
                instance = new TestGda();
            }
            return instance;

        }
    }
}
