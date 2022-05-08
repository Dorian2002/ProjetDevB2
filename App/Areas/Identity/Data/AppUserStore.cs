//using Microsoft.AspNetCore.Identity;
//
//namespace App.Areas.Identity.Data;
//public class AppUserStore : UserStore<AppUser, AppRole, ApplicationDbContext, int, AppUserClaim, AppUserRole, AppUserLogin, AppUserToken, AppRoleClaim>
//{
//    public AppUserStore(ApplicationDbContext dbContext)
//        : base(dbContext)
//    {
//    }
//
//    protected override AppUserToken CreateUserToken(AppUser user, string loginProvider, string name, string value)
//    {
//        throw new NotImplementedException();
//    }
//
//    protected override AppUserLogin CreateUserLogin(AppUser user, UserLoginInfo login)
//    {
//        throw new NotImplementedException();
//    }
//
//    protected override AppUserRole CreateUserRole(AppUser user, AppRole role)
//    {
//        throw new NotImplementedException();
//    }
//
//    protected override AppUserClaim CreateUserClaim(AppUser user, Claim claim)
//    {
//        throw new NotImplementedException();
//    }
//}