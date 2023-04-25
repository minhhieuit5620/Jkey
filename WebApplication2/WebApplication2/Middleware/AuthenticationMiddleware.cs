using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using WebApplication2.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication2.Middleware
{
    public class AuthenticationMiddleware : Attribute, IActionFilter
    {
        private readonly string _actionId;
       
        private readonly string _pageId;
        public JkeyInternalContext _context = new JkeyInternalContext();

        public AuthenticationMiddleware(string actionId = "", string pageId = "")
        {
            this._actionId = actionId;
            this._pageId = pageId;
           
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            try
            {
                // check quyen o day
                //_prefix
                var username = context.HttpContext.User.Identity.Name;
                var userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
              
                if (userId != null)
                {  
                    var pagePermisstion = checkPermission(Guid.Parse(userId));

                    for (int i = 0; i < pagePermisstion.Count; i++)
                    {
                        if (pagePermisstion[i].Id==_pageId&& pagePermisstion[i].ActionId == _actionId)
                        {
                            return;
                        }
                        
                    }
                   
                }
               

            }
            catch{}
            context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "AccessDenied" },
                        { "action", "Index" }
                    });
        }


        public List<Page> checkPermission(Guid userId)
        {
            var roleUsers = _context.UserRoles.Where(x => x.UserId == userId).ToList();

            IDictionary<Guid, List<PageRight>> pageRight = new Dictionary<Guid, List<PageRight>>();

            for (int i = 0; i < roleUsers.Count; i++)
            {
                var pageId = _context.PageRights.Where(x => x.RoleId == roleUsers[i].RoleId).ToList();
                if (pageId != null && pageId.Count > 0)
                {
                    pageRight.Add(roleUsers[i].RoleId, pageId);
                }
            }

            List<Page> page = new List<Page>();
            foreach (var entry in pageRight)

            {
                var check = "";
                for (int i = 0; i < entry.Value.Count; i++)
                {
                    check = entry.Value[i].PageId.ToString();
                    var valuePage = _context.Pages.Where(x => x.Id == check).FirstOrDefault();
                    if (!page.Contains(valuePage))
                    {
                        page.Add(valuePage);
                    }
                    //page.Add(valuePage);
                }
            }

            return page;


        }


        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
