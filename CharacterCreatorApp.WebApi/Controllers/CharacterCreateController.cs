using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Reflection;
using CharacterCreatorApp.Models.CharacterModels;
using CharacterCreatorApp.Data.Entities;
using CharacterCreatorApp.Data.Entities.CharacterCreationEnums;
using CharacterCreatorApp.Services.CharacterCreationServices;
using CharacterCreatorApp.Models.Responses;

namespace CharacterCreatorApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterCreateController : ControllerBase
    {
        private readonly ICharacterCreationService _characterCreationService;

        public CharacterCreateController(ICharacterCreationService characterCreationService)
        {
            _characterCreationService = characterCreationService;
        }

        [HttpPost("Rogue")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateRogueCharacter([FromBody] CharacterCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = await _characterCreationService.CreateRogueCharacterAsync(request);
            if (response is not null)
                return Ok(response);

            return BadRequest(new TextResponse("Could not create Character, Please Try Again."));
        }

        [HttpPost("Warrior")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateWarriorCharacter([FromBody] CharacterCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = await _characterCreationService.CreateWarriorCharacterAsync(request);
            if (response is not null)
            {
                // var customResponse = new CustomResponse
                // {
                //     OkResponse = response,
                //     TextResponse = new TextResponse("You have successfully created a warrior character.")
                // };

                return Ok(response);
            }

            return BadRequest(new TextResponse("Could not create Character, Please Try Again."));
        }

        [HttpPost("Wizard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateWizardCharacter([FromBody] CharacterCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = await _characterCreationService.CreateWizardCharacterAsync(request);
            if (response is not null)
                return Ok(response);

            return BadRequest(new TextResponse("Could not create Character, Please Try Again."));
        }


    }
}
