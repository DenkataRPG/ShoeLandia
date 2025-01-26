namespace ShoeLandia.Web.Areas.Administration.Controllers
{
    using ShoeLandia.Common;
    using ShoeLandia.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
