using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using System;
using System.Linq;

namespace FundooNotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly InotesBL inotesBL;
        private readonly FundooContext fundooContext;


        public NotesController(InotesBL inotesBL, FundooContext fundooContext)
        {
            this.inotesBL = inotesBL;
            this.fundooContext = fundooContext;
        }
        [Authorize]
        [HttpPost]
        [Route("CreateNotes")]
        public IActionResult CreateNotes(NotesModel notesModel)
        {
            try
            {
                var UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);
                var result = inotesBL.CreateNote(notesModel,UserID);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Notes Created Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "unable to Create Note" });
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpGet]
        [Route("Getnotes")]

        public IActionResult GetNotes ()
        {
            try
            {
                var UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);
                var result = inotesBL.GetNote(UserID);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Got Notes Successfuly", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "unable to get Notes" });
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
