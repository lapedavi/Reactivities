using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using Application.Photos;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    public class PhotosController : BaseAPIController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Add.Command command)
        {
            return HandleResults(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return HandleResults(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [HttpPost("{id}/setMain")]
        public async Task<IActionResult> setMain(string id){
            return HandleResults(await Mediator.Send(new SetMain.Command{Id = id}));
        }

    }
}