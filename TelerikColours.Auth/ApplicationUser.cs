//using System.Security.Claims;
//using System.Threading.Tasks;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using System.Collections.Generic;
//using Models;

//namespace TelerikColours.Auth
//{
//    public class ApplicationUser : IdentityUser
//    {
//        private ICollection<Flight> flights;

//        public ApplicationUser()
//        {
//            this.flights = new HashSet<Flight>();
//            this.Money = 500;
//        }

//        public int Money { get; set; }

//        public ICollection<Flight> Flights
//        {
//            get
//            {
//                return this.flights;
//            }
//            set
//            {
//                this.flights = value;
//            }
//        }

//        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
//        {
//            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
//            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
//            // Add custom user claims here
//            return userIdentity;
//        }

//        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
//        {
//            return Task.FromResult(GenerateUserIdentity(manager));
//        }
//    }
//}
