using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample_DotNetCore_WebAPI.Data;
using Sample_DotNetCore_WebAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_DotNetCore_WebAPI
{
   // Route to define our URL.The default expression '[Controller]' means name of the controller means 'Gadgets'.
   // You can define your custom route name if you wanted.

   [Route("api/[controller]")]
    //Decorated with 'ApiController' attribute indicates that a type and all derived
    //types are used to serve HTTP API responses. Controller decorated
    //with this attribute are configured wth features and behavior target at improving the developer experience for building APIs.
    [ApiController]
    //c# class to become a controller it need to inherit 'Microsoft.AspNetCore.Mvc.ControllerBase'.
    public class GadgetsController : ControllerBase
    {
        //Injected our DbContext into the controller.Line[23-27]
        private readonly Project_DBContext _projectdbcontext;
        public GadgetsController(Project_DBContext projectdbcontext)
        {
            _projectdbcontext = projectdbcontext;
        }
        //Read Operation
        [HttpGet]
        [Route("all")]
        public IActionResult GetAllGadtets()
        {
            var allGadgets = _projectdbcontext.Gadgets.ToList();
            return Ok(allGadgets);
        }
        //Create Operations
        [HttpPost]
        [Route("add")]
        public IActionResult CreateGadget(Gadgets gadgets)
        {
            _projectdbcontext.Gadgets.Add(gadgets);
            _projectdbcontext.SaveChanges();
            return Ok(gadgets.Id);
        }

        //Update Operation
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateGadget(Gadgets gadgets)
        {
            _projectdbcontext.Update(gadgets);
            _projectdbcontext.SaveChanges();
            return NoContent();
        }

        //Delete Operation
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteGadget(int id)
        {
            var gadgetToDelete = _projectdbcontext.Gadgets.Where(_ => _.Id == id).FirstOrDefault();
            if (gadgetToDelete == null)
            {
                return NotFound();
            }

            _projectdbcontext.Gadgets.Remove(gadgetToDelete);
            _projectdbcontext.SaveChanges();
            return NoContent();
        }
    }
}
