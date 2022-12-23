using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class WaiterModel
    {
        private int id;
        private string name;
        private string middleName;
        private string lastName;
        private string password;
        private string login;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public string MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
            }
        }

        public WaiterModel(Waiter waiter)
        {
            id = waiter.Id;
            name = waiter.name;
            middleName = waiter.middleName;
            lastName = waiter.lastName;
            password = waiter.password;
            login = waiter.login;
        }
    }
}
