namespace RestfulApi.Models
{
    public class GameLibrary
    {
        public static List<Game> gameList = new List<Game>()
        {
            new Game()
            {
                Id = 1,
                Name = "The Witcher 3: Wild Hunt",
                Description = "The Witcher 3: Wild Hunt is a 2015 action role-playing game developed and published by Polish developer CD Projekt Red and is based on The Witcher series of fantasy novels by Andrzej Sapkowski. It is the sequel to the 2011 game The Witcher 2: Assassins of Kings and the third main installment in the The Witcher's video game series, played in an open world with a third-person perspective.",
                Genre = "Action role-playing",
                Developer = "CD Projekt Red",
                Publisher = "CD Projekt",
                ReleaseDate = new System.DateTime(2015, 5, 19),
                Platform = "Microsoft Windows, PlayStation 4, Xbox One, Nintendo Switch",
                Price = 59.99
            },
            new Game()
            {
                Id = 2,
                Name = "The Elder Scrolls V: Skyrim",
                Description = "The Elder Scrolls V: Skyrim is an action role-playing video game developed by Bethesda Game Studios and published by Bethesda Softworks. It is the fifth main installment in The Elder Scrolls series, following The Elder Scrolls IV: Oblivion, and was released worldwide for Microsoft Windows, PlayStation 3, and Xbox 360 on November 11, 2011.",
                Genre = "Action role-playing",
                Developer = "Bethesda Game Studios",
                Publisher = "Bethesda Softworks",
                ReleaseDate = new System.DateTime(2011, 11, 11),
                Platform = "Microsoft Windows, PlayStation 3, Xbox 360, PlayStation 4, Xbox One, Nintendo Switch",
                Price = 39.99
            },
            new Game()
            {
                Id = 3,
                Name = "Grand Theft Auto V",
                Description = "Grand Theft Auto V is a 2013 action-adventure game developed by Rockstar North and published by Rockstar Games. It is the first main entry in the Grand Theft Auto series since 2008's Grand Theft Auto IV.",
                Genre = "Action-adventure",
                Developer = "Rockstar North",
                Publisher = "Rockstar Games",
                ReleaseDate = new System.DateTime(2013, 9, 17),
                Platform = "PlayStation 3, Xbox 360, PlayStation 4, Xbox One, Microsoft Windows",
            }
        };
    }
}
