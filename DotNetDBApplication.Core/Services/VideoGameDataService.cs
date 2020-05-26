using DotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetDBApplication.Core.Services
{
    class VideoGameDataService
    {
        //private static IEnumerable<VideoGame> AllVideoGamess()
        //{
        //    // The following is order summary data
        //    var videoGames = AllGames();
        //    return videoGames.SelectMany(c => c.Game);
        //}

        private static IEnumerable<VideoGame> AllGames()
        {
            return new List<VideoGame>()
            {
                new VideoGame()
                {
                    Game = new Game()
                    {
                        GameTitle = "The Game 1",
                        GameSubtitle = "Original Content",
                        HoursToComplete = 2.34f,
                        CharacterCast = 
                        {
                            new Character()
                            {
                                CharacterName = "Swain John"
                            }
                        }
                    },
                    Developer = new Developer("The Best Developer"),
                    Publisher = new Publisher("The Best Publisher")
                    
                }
            };
        }
    }
}
