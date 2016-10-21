using Millionaire.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire.View
{
    class Controller
    {
        DAL1 dal = new DAL1();

        private bool createUser(string userName, string password, string userType)
        {
            return dal.CreateUser(userName, password, userType);
        }
        private void updateUser(string userName, string password, string userType)
        {
        }
        private void deleteUser(string userName, string password, string userType)
        {
        }
    }
}
