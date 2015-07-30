using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class AdministradorController : Controller
    {
        public ActionResult NovoPost()
        {
            return View(new NovoPostViewModel());
        }

        public ActionResult AdicionarTagAoPost(NovoPostViewModel post)
        {
            post.Tags.Add(post.Tag);
            return View("NovoPost", post);
        }
    }
}