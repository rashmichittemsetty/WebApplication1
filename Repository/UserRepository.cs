using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class UserRepository : IRepository
    {
        private List<UserDetails> _userList;

        public UserRepository()
        {
            _userList = new List<UserDetails>()
            {
                new UserDetails(){Id =1, Name="Rashmi", Email="rashmi@email.com", ContactNo=1234567890 },
                new UserDetails() {Id=2, Name="Karthik", Email="karthik@email.com", ContactNo=1234567890 },
                new UserDetails() {Id=3, Name="Kalavathi", Email="kalavathi@email.com", ContactNo=1234567890 },
                new UserDetails() {Id=4, Name="Ramamoorthy", Email="ram@email.com", ContactNo=1234567890 }
            };
        }
        public UserDetails Add(UserDetails userDetails)
        {
            userDetails.Id = _userList.Max(u => u.Id) + 1;
            _userList.Add(userDetails);
            return userDetails;
        }
    }
}
