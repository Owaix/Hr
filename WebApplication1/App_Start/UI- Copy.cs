using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace WebApplication1.App_Start
{
    public static class IdentityExtension
    {
        //       private static IUserService _locService = UnityConfig.Resolve<IUserService>();
        public static IList<Claim> GetAllUserClaims(this IIdentity identityUser)
        {
            var userGuid = identityUser.GetUserId();


            //var userLocations = _locService.GetUserLocations(userGuid);
            //var userLocation = JsonConvert.SerializeObject(userLocations);
            //var claimName = Enum.GetName(typeof(UserClaims), UserClaims.Locations);
            //var locClaim = new Claim(claimName, userLocation);

            //// CUrrent User Location Claim 
            //claimName = Enum.GetName(typeof(UserClaims), UserClaims.CurrentLocation);
            //var currUserLoc = userLocations.Where(l => l.IsDefault == true).FirstOrDefault();
            //currUserLoc = (null == currUserLoc) ? userLocations.FirstOrDefault() : currUserLoc;
            //var currUserLocation = new Claim(claimName, JsonConvert.SerializeObject(currUserLoc));

            //            List<Claim> claims = new List<Claim>() { locClaim, currUserLocation };



            //          return claims;
            return null;
        }
    }
}