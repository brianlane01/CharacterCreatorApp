using System;
using CharacterCreatorApp.Data;
using CharacterCreatorApp.Data.Entities;
using CharacterCreatorApp.Data.Entities.CharacterCreationEnums;
using CharacterCreatorApp.Models.CharacterModels;
using CharacterCreatorApp.Models.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using AutoMapper;

namespace CharacterCreatorApp.Services.CharacterCreationServices
{
    public class CharacterCreationService : ICharacterCreationService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly int _userId;

        // RogueCharacterClassEntity rogue = new RogueCharacterClass();
        // WarriorCharacterClassEntity warrior = new WarriorCharacterClass();
        // WizardCharacterClassEntity wizard = new WizardCharacterClass(); 

        public CharacterCreationService(UserManager<UserEntity> userManager,
                            SignInManager<UserEntity> signInManager,
                            ApplicationDbContext dbContext)
        {
            var currentUser = signInManager.Context.User;
            var userIdClaim = userManager.GetUserId(currentUser);
            var hasValidId = int.TryParse(userIdClaim, out _userId);

            if(hasValidId == false)
            {
                throw new Exception("Attempted to build NoteService without Id Claim.");
            }

            _dbContext = dbContext;
            
        }

        public async Task<RogueCharacterCreateList?> CreateRogueCharacterAsync(CharacterCreate request)
        {
            string hairColorSelection;

            switch (request.HairColor)
            {
                case HairColor.Blonde:
                    hairColorSelection = "Your Character now has Blonde hair.";
                    break;
                case HairColor.Red:
                    hairColorSelection = "Your Character now has Red hair.";
                    break;
                case HairColor.Blue:
                    hairColorSelection = "Your Character now has Blue hair.";
                    break;
                case HairColor.Green:
                    hairColorSelection = "Your Character now has Green hair.";
                    break;
                case HairColor.Pink:
                    hairColorSelection = "Your Character now has Pink hair.";
                    break;
                case HairColor.Aquamarine:
                    hairColorSelection = "Your Character now has Aquamarine hair.";
                    break;
                case HairColor.Platinum:
                    hairColorSelection = "Your Character now has Platinum hair.";
                    break;
                case HairColor.Silver:
                    hairColorSelection = "Your Character now has Silver hair.";
                    break;
                case HairColor.Purple:
                    hairColorSelection = "Your Character now has Purple hair.";
                    break;
                case HairColor.Brown:
                    hairColorSelection = "Your Character now has Brown hair.";
                    break;
                case HairColor.Black:
                    hairColorSelection = "Your Character now has Black hair.";
                    break;
                case HairColor.Orange:
                    hairColorSelection = "Your Character now has Orange hair.";
                    break;
                case HairColor.Teal:
                    hairColorSelection = "Your Character now has Teal hair.";
                    break;
                case HairColor.BurntOrange:
                    hairColorSelection = "Your Character now has BurntOrange hair.";
                    break;
                default:
                    hairColorSelection = "Invalid selection for hair color"; // Handle any other cases
                    break;
            }

            string faceStructureSelection;

            switch (request.FaceStructure)
            {
                case FaceStructure.Oval:
                    faceStructureSelection = "You have selected an Oval face structure for your character";
                    break;

                case FaceStructure.Square:
                    faceStructureSelection = "You have selected an Square face structure for your character";
                    break;

                case FaceStructure.Round:
                    faceStructureSelection = "You have selected an Round face structure for your character";
                    break;

                default:
                    faceStructureSelection = "Invalid selection for hair color"; // Handle any other cases
                    break;
            }

            string characterHeightSelection; 

            switch(request.Height)
            {
                case CharacterHeight.Short:
                    characterHeightSelection = "You have chosen your character to be of short stature. ";
                    break;

                case CharacterHeight.MediumHeight:
                    characterHeightSelection = "You have chosen your character to be of medium height stature. ";
                    break;

                case CharacterHeight.Tall:
                    characterHeightSelection = "You have chosen your character to be of Tall stature. ";
                    break;
                
                case CharacterHeight.ExtraTall:
                    characterHeightSelection = "You have chosen your character to be of Extra Tall stature. ";
                    break;

                default:
                    characterHeightSelection = "You have chosen an invalid height for your character. ";
                    break;
            }

            string bodyTypeSelection;

            switch(request.BodyType)
            {
                case BodyType.Skinny:
                    bodyTypeSelection = "You have chosen your character to have a Slim build. ";
                    break;
                
                case BodyType.Athletic:
                    bodyTypeSelection = "You have chosen your character to have a Athletic build. ";
                    break;

                case BodyType.Muscular:
                    bodyTypeSelection = "You have chosen your character to have a Muscular build. ";
                    break;

                case BodyType.Large:
                    bodyTypeSelection = "You have chosen your character to have a Large build. ";
                    break;

                case BodyType.MediumBuild:
                    bodyTypeSelection = "You have chosen your character to have a Medium build. ";
                    break;

                default:
                    bodyTypeSelection = "You have selected an invalid body type, please try again.";
                    break; 
            }

            RogueCharacterClassEntity entity = new RogueCharacterClassEntity()
            {
                CharacterName = request.CharacterName,
                BodyTypeSelection = bodyTypeSelection,
                HairColorSelection = hairColorSelection,
                FaceStructureSelection = faceStructureSelection,
                HeightSelection = characterHeightSelection,
                UserId = _userId
            };

            _dbContext.Rogues.Add(entity);
            var createdCharacter = await _dbContext.SaveChangesAsync();

            if(createdCharacter != 1)
                return null;

            RogueCharacterCreateList response = new()
            {
                CharacterId = entity.CharacterId,
                CharacterName = entity.CharacterName,
                HairColorSelection = entity.HairColorSelection, 
                FaceStructureSelection = entity.FaceStructureSelection,
                BodyTypeSelection = entity.BodyTypeSelection,
                HeightSelection = entity.HeightSelection,
                SpecialAbility = entity.SpecialAbility,
                SpecialStarterWeapon = entity.SpecialStarterWeapon,
                SneakSkill = entity.SneakSkill
            };

            return response;
        }

        public async Task<WarriorCharacterCreateList?> CreateWarriorCharacterAsync(CharacterCreate request)
        {
            string hairColorSelection;

            switch (request.HairColor)
            {
                case HairColor.Blonde:
                    hairColorSelection = "Your Character now has Blonde hair.";
                    break;
                case HairColor.Red:
                    hairColorSelection = "Your Character now has Red hair.";
                    break;
                case HairColor.Blue:
                    hairColorSelection = "Your Character now has Blue hair.";
                    break;
                case HairColor.Green:
                    hairColorSelection = "Your Character now has Green hair.";
                    break;
                case HairColor.Pink:
                    hairColorSelection = "Your Character now has Pink hair.";
                    break;
                case HairColor.Aquamarine:
                    hairColorSelection = "Your Character now has Aquamarine hair.";
                    break;
                case HairColor.Platinum:
                    hairColorSelection = "Your Character now has Platinum hair.";
                    break;
                case HairColor.Silver:
                    hairColorSelection = "Your Character now has Silver hair.";
                    break;
                case HairColor.Purple:
                    hairColorSelection = "Your Character now has Purple hair.";
                    break;
                case HairColor.Brown:
                    hairColorSelection = "Your Character now has Brown hair.";
                    break;
                case HairColor.Black:
                    hairColorSelection = "Your Character now has Black hair.";
                    break;
                case HairColor.Orange:
                    hairColorSelection = "Your Character now has Orange hair.";
                    break;
                case HairColor.Teal:
                    hairColorSelection = "Your Character now has Teal hair.";
                    break;
                case HairColor.BurntOrange:
                    hairColorSelection = "Your Character now has BurntOrange hair.";
                    break;
                default:
                    hairColorSelection = "Invalid selection for hair color"; // Handle any other cases
                    break;
            }

            string faceStructureSelection;

            switch (request.FaceStructure)
            {
                case FaceStructure.Oval:
                    faceStructureSelection = "You have selected an Oval face structure for your character";
                    break;

                case FaceStructure.Square:
                    faceStructureSelection = "You have selected an Square face structure for your character";
                    break;

                case FaceStructure.Round:
                    faceStructureSelection = "You have selected an Round face structure for your character";
                    break;

                default:
                    faceStructureSelection = "Invalid selection for hair color"; // Handle any other cases
                    break;
            }

            string characterHeightSelection; 

            switch(request.Height)
            {
                case CharacterHeight.Short:
                    characterHeightSelection = "You have chosen your character to be of short stature. ";
                    break;

                case CharacterHeight.MediumHeight:
                    characterHeightSelection = "You have chosen your character to be of medium height stature. ";
                    break;

                case CharacterHeight.Tall:
                    characterHeightSelection = "You have chosen your character to be of Tall stature. ";
                    break;
                
                case CharacterHeight.ExtraTall:
                    characterHeightSelection = "You have chosen your character to be of Extra Tall stature. ";
                    break;

                default:
                    characterHeightSelection = "You have chosen an invalid height for your character. ";
                    break;
            }

            string bodyTypeSelection;

            switch(request.BodyType)
            {
                case BodyType.Skinny:
                    bodyTypeSelection = "You have chosen your character to have a Slim build. ";
                    break;
                
                case BodyType.Athletic:
                    bodyTypeSelection = "You have chosen your character to have a Athletic build. ";
                    break;

                case BodyType.Muscular:
                    bodyTypeSelection = "You have chosen your character to have a Muscular build. ";
                    break;

                case BodyType.Large:
                    bodyTypeSelection = "You have chosen your character to have a Large build. ";
                    break;

                case BodyType.MediumBuild:
                    bodyTypeSelection = "You have chosen your character to have a Medium build. ";
                    break;

                default:
                    bodyTypeSelection = "You have selected an invalid body type, please try again.";
                    break; 
            }

            WarriorCharacterClassEntity entity = new WarriorCharacterClassEntity()
            {
                CharacterName = request.CharacterName,
                UserId = _userId,
                BodyTypeSelection = bodyTypeSelection,
                HairColorSelection = hairColorSelection,
                FaceStructureSelection = faceStructureSelection,
                HeightSelection = characterHeightSelection
            };

            _dbContext.Warriors.Add(entity);
            var createdCharacter = await _dbContext.SaveChangesAsync();

            if(createdCharacter != 1)
                return null;

            WarriorCharacterCreateList response = new()
            {
                CharacterId = entity.CharacterId,
                CharacterName = entity.CharacterName,
                HairColorSelection = entity.HairColorSelection, 
                FaceStructureSelection = entity.FaceStructureSelection,
                BodyTypeSelection = entity.BodyTypeSelection,
                HeightSelection = entity.HeightSelection,
                SpecialAbility = entity.SpecialAbility,
                SpecialStarterWeapon = entity.SpecialStarterWeapon,
                WeaponSkill = entity.WeaponSkill
            };

            return response;
        }

        public async Task<WizardCharacterCreateList?> CreateWizardCharacterAsync(CharacterCreate request)
        {
            string hairColorSelection;

            switch (request.HairColor)
            {
                case HairColor.Blonde:
                    hairColorSelection = "Your Character now has Blonde hair.";
                    break;
                case HairColor.Red:
                    hairColorSelection = "Your Character now has Red hair.";
                    break;
                case HairColor.Blue:
                    hairColorSelection = "Your Character now has Blue hair.";
                    break;
                case HairColor.Green:
                    hairColorSelection = "Your Character now has Green hair.";
                    break;
                case HairColor.Pink:
                    hairColorSelection = "Your Character now has Pink hair.";
                    break;
                case HairColor.Aquamarine:
                    hairColorSelection = "Your Character now has Aquamarine hair.";
                    break;
                case HairColor.Platinum:
                    hairColorSelection = "Your Character now has Platinum hair.";
                    break;
                case HairColor.Silver:
                    hairColorSelection = "Your Character now has Silver hair.";
                    break;
                case HairColor.Purple:
                    hairColorSelection = "Your Character now has Purple hair.";
                    break;
                case HairColor.Brown:
                    hairColorSelection = "Your Character now has Brown hair.";
                    break;
                case HairColor.Black:
                    hairColorSelection = "Your Character now has Black hair.";
                    break;
                case HairColor.Orange:
                    hairColorSelection = "Your Character now has Orange hair.";
                    break;
                case HairColor.Teal:
                    hairColorSelection = "Your Character now has Teal hair.";
                    break;
                case HairColor.BurntOrange:
                    hairColorSelection = "Your Character now has BurntOrange hair.";
                    break;
                default:
                    hairColorSelection = "Invalid selection for hair color"; // Handle any other cases
                    break;
            }

            string faceStructureSelection;

            switch (request.FaceStructure)
            {
                case FaceStructure.Oval:
                    faceStructureSelection = "You have selected an Oval face structure for your character";
                    break;

                case FaceStructure.Square:
                    faceStructureSelection = "You have selected an Square face structure for your character";
                    break;

                case FaceStructure.Round:
                    faceStructureSelection = "You have selected an Round face structure for your character";
                    break;

                default:
                    faceStructureSelection = "Invalid selection for hair color"; // Handle any other cases
                    break;
            }

            string characterHeightSelection; 

            switch(request.Height)
            {
                case CharacterHeight.Short:
                    characterHeightSelection = "You have chosen your character to be of short stature. ";
                    break;

                case CharacterHeight.MediumHeight:
                    characterHeightSelection = "You have chosen your character to be of medium height stature. ";
                    break;

                case CharacterHeight.Tall:
                    characterHeightSelection = "You have chosen your character to be of Tall stature. ";
                    break;
                
                case CharacterHeight.ExtraTall:
                    characterHeightSelection = "You have chosen your character to be of Extra Tall stature. ";
                    break;

                default:
                    characterHeightSelection = "You have chosen an invalid height for your character. ";
                    break;
            }

            string bodyTypeSelection;

            switch(request.BodyType)
            {
                case BodyType.Skinny:
                    bodyTypeSelection = "You have chosen your character to have a Slim build. ";
                    break;
                
                case BodyType.Athletic:
                    bodyTypeSelection = "You have chosen your character to have a Athletic build. ";
                    break;

                case BodyType.Muscular:
                    bodyTypeSelection = "You have chosen your character to have a Muscular build. ";
                    break;

                case BodyType.Large:
                    bodyTypeSelection = "You have chosen your character to have a Large build. ";
                    break;

                case BodyType.MediumBuild:
                    bodyTypeSelection = "You have chosen your character to have a Medium build. ";
                    break;

                default:
                    bodyTypeSelection = "You have selected an invalid body type, please try again.";
                    break; 
            }

            WizardCharacterClassEntity entity = new WizardCharacterClassEntity()
            {
                CharacterName = request.CharacterName,
                BodyTypeSelection = bodyTypeSelection,
                HairColorSelection = hairColorSelection,
                FaceStructureSelection = faceStructureSelection,
                HeightSelection = characterHeightSelection
            };

            _dbContext.Wizards.Add(entity);
            var createdCharacter = await _dbContext.SaveChangesAsync();

            if(createdCharacter != 1)
                return null;

            WizardCharacterCreateList response = new()
            {
                CharacterId = entity.CharacterId,
                CharacterName = entity.CharacterName,
                HairColorSelection = entity.HairColorSelection, 
                FaceStructureSelection = entity.FaceStructureSelection,
                BodyTypeSelection = entity.BodyTypeSelection,
                HeightSelection = entity.HeightSelection,
                SpecialAbility = entity.SpecialAbility,
                SpecialStarterWeapon = entity.SpecialStarterWeapon,
                MagicSkill = entity.MagicSkill
            };

            return response;
        }
    }
}