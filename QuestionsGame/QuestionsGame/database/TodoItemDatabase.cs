using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using QuestionsGame.models;

namespace QuestionsGame.database
{
    public class TodoItemDatabase
    {
        string whereType="r1";
        readonly SQLiteAsyncConnection database;

        //if database is null, create it and the tables
        public TodoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TodoItem>().Wait();
            database.CreateTableAsync<User>().Wait();
            database.CreateTableAsync<Questions>().Wait();
        }
        public Task<List<TodoItem>> GetItemsAsync()
        {
            return database.Table<TodoItem>().ToListAsync();
        }

        public Task<List<TodoItem>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<TodoItem> GetItemAsync(int id)
        {
            return database.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(TodoItem item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(TodoItem item)
        {
            return database.DeleteAsync(item);
        }

        //user
        //get users
        public Task<List<User>> GetUsersAsync()
        {
            return database.Table<User>().ToListAsync();
        }
        public Task<User> GetUserAsync(int id)
        {
            return database.Table<User>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveUserAsync(User user)
        {
            if (user.ID != 0)
            {
                return database.UpdateAsync(user);
            }
            else
            {
                return database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return database.DeleteAsync(user);
        }
        
        //questions
        public Task<List<Questions>> GetQuestionsAsync()
        {
            return database.Table<Questions>().ToListAsync();
        }
        public Task<Questions> GetQuestionAsync(int id)
        {
            return database.Table<Questions>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveQuestionAsync(Questions questions)
        {
            if (questions.ID != 0)
            {
                return database.UpdateAsync(questions);
            }
            else
            {
                return database.InsertAsync(questions);
            }
        }

        public Task<int> DeleteQuestionsAsync(Questions questions)
        {
            return database.DeleteAsync(questions);
        }

        public int CheckDBExists()
        {
            try
            {
                var questions = App.Database.GetQuestionsAsync();
                if (questions.Result.Count > 0)
                {
                    return questions.Result.Count;
                }
                return 0;
            }
            catch (Exception e)
            {
                var exception = e;
                return 0;
            }
        }
        public void FillDatabase()
        {
            //original world quiz
            //wrong or right / not answered
            
            var question1 = new Questions { question="What's the biggest country in the world?", opt1="China", opt2="Russia", opt3="Canada", correctAns="Russia", status="not answered" };
            var question2 = new Questions { question = "Aprox. earth's circumference", opt1 = "40,000Km", opt2 = "50,000km", opt3 = "30,000km", correctAns = "40,000Km", status = "not answered" };
            var question3 = new Questions { question = "Nelson Mandela released from prison in", opt1 = "1980", opt2 = "1990", opt3 = "1978", correctAns = "1990", status = "not answered" };
            var question4 = new Questions { question = "What's the biggest ocean in the world?", opt1 = "Atlantic", opt2 = "Pacific", opt3 = "Indian", correctAns = "Pacific", status = "not answered" };
            var question5 = new Questions { question = "William Shakespeare's nationality", opt1 = "British", opt2 = "French", opt3 = "USA", correctAns = "British", status = "not answered" };
            var question6= new Questions { question = "Capital of Norway", opt1 = "Oslo", opt2 = "Lofoten", opt3 = "Amsterdam", correctAns = "Oslo", status = "not answered" };
            var question7 = new Questions { question = "Usain Bold's nationality", opt1 = "Dominican", opt2 = "Jamaican", opt3 = "Bahamas", correctAns = "Jamaican", status = "not answered" };
            var question8 = new Questions { question = "This country has more lakes than any other", opt1 = "Canada", opt2 = "Brazil", opt3 = "Russia", correctAns = "Canada", status = "not answered" };
            var question9 = new Questions { question = "Helped to develop the thermometer and telescope", opt1 = "Isaac Newton", opt2 = "Galileo Galilei", opt3 = "Alba Edison", correctAns = "Galileo Galilei", status = "not answered" };
            var question10 = new Questions { question = "What's the smallest country in the world?", opt1 = "Vatican", opt2 = "Monaco", opt3 = "Maldives", correctAns = "Vatican", status = "not answered" };

            var question11 = new Questions { question = "The Last Supper was painted by", opt1 = "Donatello", opt2 = "Michelangelo", opt3 = "Da Vinci", correctAns = "Da Vinci", status = "not answered" };
            var question12 = new Questions { question = "Diameter of the earth", opt1 = "12,742km", opt2 = "15,942km", opt3 = "10,151km", correctAns = "12,742km", status = "not answered" };
            var question13 = new Questions { question = "First Winter Olympic Games was held in", opt1 = "England", opt2 = "France", opt3 = "USA", correctAns = "France", status = "not answered" };
            var question14 = new Questions { question = "Day of the Dead is celebrated in", opt1 = "Mexico", opt2 = "Peru", opt3 = "Argentina", correctAns = "Mexico", status = "not answered" };
            var question15 = new Questions { question = "Fire extinguisher was invented around", opt1 = "1770", opt2 = "1860", opt3 = "1810", correctAns = "1860", status = "not answered" };
            var question16 = new Questions { question = "One of Alexandre Dumas most known book", opt1 = "Little Prince", opt2 = "The three musketeers", opt3 = "Sherlock Holmes", correctAns = "The three musketeers", status = "not answered" };
            var question17 = new Questions { question = "Birthplace of the Beatles", opt1 = "London", opt2 = "Blackpool", opt3 = "Liverpool", correctAns = "Liverpool", status = "not answered" };
            var question18 = new Questions { question = "Escargot is a meal in", opt1 = "Belgium", opt2 = "France", opt3 = "Holland", correctAns = "France", status = "not answered" };
            var question19 = new Questions { question = "First host of the FIFA Football World Cup?", opt1 = "Paraguay", opt2 = "Argentina", opt3 = "Uruguay", correctAns = "Uruguay", status = "not answered" };

            var question20 = new Questions { question = "Tallest mountain on earth", opt1 = "Aconcagua", opt2 = "Everest", opt3 = "Kilimanjaro", correctAns = "Everest", status = "not answered" };
            var question21 = new Questions { question = "Painted the Sistine Chapel Ceiling", opt1 = "Da Vinci", opt2 = "Michelangelo", opt3 = "Donatello", correctAns = "Michelangelo", status = "not answered" };
            var question22 = new Questions { question = "One of the biggest carnivals", opt1 = "Nice, France", opt2 = "Venice, Italy", opt3 = "Rio de Janeiro, Brazil", correctAns = "Rio de Janeiro, Brazil", status = "not answered" };
            var question23 = new Questions { question = "Lead singer of queen", opt1 = "Freddie Mercury", opt2 = "Steve Tayler", opt3 = "Gene Simmons", correctAns = "Freddie Mercury", status = "not answered" };
            var question24 = new Questions { question = "Superman is a superhero from", opt1 = "Pluto", opt2 = "Krypton", opt3 = "Trypto", correctAns = "Krypton", status = "not answered" };
            var question25 = new Questions { question = "Boxing became legal in ", opt1 = "1950", opt2 = "1932", opt3 = "1901", correctAns = "1901", status = "not answered" };
            var question26 = new Questions { question = "Brazil was a colony of", opt1 = "Spain", opt2 = "Portugal", opt3 = "Italy", correctAns = "Portugal", status = "not answered" };
            var question27 = new Questions { question = "Fidel Castro's year of death", opt1 = "2012", opt2 = "2014", opt3 = "2016", correctAns = "2016", status = "not answered" };
            var question28 = new Questions { question = "Main Character: Around the World in 80 Days", opt1 = "Gulliver", opt2 = "Robert Langdon", opt3 = "Phileas Fogg", correctAns = "Phileas Fogg", status = "not answered" };
            var question29 = new Questions { question = "Mathematician born on a December 25th", opt1 = "Isaac Newton", opt2 = "Da Vinci", opt3 = "Galileo", correctAns = "Isaac Newton", status = "not answered" };

            var question30 = new Questions { question = "Electric refrigerator was invented in", opt1 = "1902", opt2 = "1950", opt3 = "1928", correctAns = "1928", status = "not answered" };
            var question31 = new Questions { question = "Columbus ship where he was traveling", opt1 = "The Girl", opt2 = "The Painted", opt3 = "Santa Maria", correctAns = "Santa Maria", status = "not answered" };
            var question32 = new Questions { question = "The Rolling Stones are from", opt1 = "USA", opt2 = "Canada", opt3 = "England", correctAns = "England", status = "not answered" };
            var question33 = new Questions { question = "What city hosted the 2012 Olympics", opt1 = "London", opt2 = "Paris", opt3 = "Berlin", correctAns = "London", status = "not answered" };
            var question34 = new Questions { question = "Capital of Holland", opt1 = "Amsterdam", opt2 = "Siberia", opt3 = "Berlin", correctAns = "Amsterdam", status = "not answered" };
            var question35 = new Questions { question = "Pozole is a soup from", opt1 = "Peru", opt2 = "Chile", opt3 = "Mexico", correctAns = "Mexico", status = "not answered" };
            var question36 = new Questions { question = "Stanley Cup is a trophy in what sport?", opt1 = "Hockey", opt2 = "Rugby", opt3 = "Tennis", correctAns = "Hockey", status = "not answered" };
            var question37 = new Questions { question = "Year when Queen Elizabeth II was born", opt1 = "1926", opt2 = "1920", opt3 = "1931", correctAns = "1926", status = "not answered" };
            var question38 = new Questions { question = "Muhammad Ali was born in", opt1 = "Argelia", opt2 = "USA", opt3 = "Marroc", correctAns = "USA", status = "not answered" };
            var question39 = new Questions { question = "Oktoberfest was first celebrated in", opt1 = "1820", opt2 = "1810", opt3 = "1800", correctAns = "1810", status = "not answered" };

            var question40 = new Questions { question = "Poutine is a dish from", opt1 = "USA", opt2 = "Canada", opt3 = "Italy", correctAns = "Canada", status = "not answered" };
            var question41 = new Questions { question = "Porsche is a brand of car from", opt1 = "Germany", opt2 = "Poland", opt3 = "England", correctAns = "Germany", status = "not answered" };
            var question42 = new Questions { question = "D in Roman means", opt1 = "500", opt2 = "1000", opt3 = "600", correctAns = "500", status = "not answered" };
            var question43 = new Questions { question = "Creator of Linux", opt1 = "Linus Torvalds", opt2 = "Steve Jobs", opt3 = "Bill Gates", correctAns = "Linus Torvalds", status = "not answered" };
            var question44 = new Questions { question = "ABBA was a pop group from", opt1 = "Sweden", opt2 = "USA", opt3 = "Norway", correctAns = "Sweden", status = "not answered" };
            var question45 = new Questions { question = "Statue of Liberty came from", opt1 = "France", opt2 = "Italy", opt3 = "Germany", correctAns = "France", status = "not answered" };
            var question46 = new Questions { question = "Most populat board game", opt1 = "Monopoly", opt2 = "Chess", opt3 = "Clue", correctAns = "Chess", status = "not answered" };
            var question47 = new Questions { question = "What year did the Titanic sink", opt1 = "1912", opt2 = "1915", opt3 = "1902", correctAns = "1912", status = "not answered" };
            var question48 = new Questions { question = "Capital of China", opt1 = "Hong Kong", opt2 = "Seul", opt3 = "Beijing", correctAns = "Beijing", status = "not answered" };
            var question49 = new Questions { question = "How many hearts in an octopus", opt1 = "1", opt2 = "2", opt3 = "3", correctAns = "3", status = "not answered" };

            var question50 = new Questions { question = "Earth's orbital speed", opt1 = "25.59 km/s", opt2 = "29.78 km/s", opt3 = "34.28 km/s", correctAns = "29.78 km/s", status = "not answered" };
            var question51 = new Questions { question = "Elvis was born in", opt1 = "Mississippi", opt2 = "Alabama", opt3 = "Lousiana", correctAns = "Mississippi", status = "not answered" };
            var question52 = new Questions { question = "What's the meaning of MVP", opt1 = "Most Valuable Person", opt2 = "Most valuable player", opt3 = "More Volume Points", correctAns = "Most valuable player", status = "not answered" };
            var question53 = new Questions { question = "Capital of Canada", opt1 = "Toronto", opt2 = "Ottawa", opt3 = "Montreal", correctAns = "Ottawa", status = "not answered" };
            var question54 = new Questions { question = "Sleepiest animal (up to 22 hours)", opt1 = "Koala", opt2 = "Sloth bear", opt3 = "Hamster", correctAns = "Koala", status = "not answered" };
            var question55 = new Questions { question = "When did Yugoslavia brake up?", opt1 = "2000", opt2 = "2006", opt3 = "1989", correctAns = "2006", status = "not answered" };
            var question56 = new Questions { question = "First Mobile Phone was developed in", opt1 = "1961", opt2 = "1982", opt3 = "1973", correctAns = "1973", status = "not answered" };
            var question57 = new Questions { question = "Highest score in 10 pin bowling", opt1 = "300", opt2 = "200", opt3 = "250", correctAns = "300", status = "not answered" };
            var question58 = new Questions { question = "Capital of Australia", opt1 = "Sydney", opt2 = "Canberra", opt3 = "Braddon", correctAns = "Canberra", status = "not answered" };
            var question59 = new Questions { question = "How many states are in USA", opt1 = "47", opt2 = "49", opt3 = "50", correctAns = "50", status = "not answered" };
            var question60 = new Questions { question = "Main Character: The Da Vinci Code", opt1 = "Robert Langdon", opt2 = "Gulliver", opt3 = "Billy Bunter", correctAns = "Robert Langdon", status = "not answered" };
            /*

            //Canada version
            var question1 = new Questions { question = "Baseball player that hit his first home run in Toronto", opt1 = "Hank Aaron", opt2 = "Babe Ruth", opt3 = "Barry Bonds", correctAns = "Babe Ruth", status = "not answered" };
            var question2 = new Questions { question = "Canada became completely independent in", opt1 = "1982", opt2 = "1953", opt3 = "1974", correctAns = "1982", status = "not answered" };
            var question3 = new Questions { question = "First Tim Hortons was opened in", opt1 = "1955", opt2 = "1964", opt3 = "1970", correctAns = "1964", status = "not answered" };
            var question4 = new Questions { question = "Canada official flag was introduced in", opt1 = "1960", opt2 = "1970", opt3 = "1965", correctAns = "1965", status = "not answered" };
            var question5 = new Questions { question = "The women right to vote in Canada was introduced:", opt1 = "Ontario", opt2 = "Manitoba", opt3 = "British Columbia", correctAns = "Manitoba", status = "not answered" };
            var question6 = new Questions { question = "Second most common sport in Canada", opt1 = "Lacrosse", opt2 = "Hockey", opt3 = "Soccer", correctAns = "Lacrosse", status = "not answered" };
            var question7 = new Questions { question = "YMCA started in", opt1 = "Toronto", opt2 = "Montreal", opt3 = "Vancouver", correctAns = "Montreal", status = "not answered" };
            var question8 = new Questions { question = "Baseball accesory invented in Canada", opt1 = "Bat", opt2 = "Ball", opt3 = "Glove", correctAns = "Glove", status = "not answered" };
            var question9 = new Questions { question = "77 percent of the world's maple syrup is made in", opt1 = "Quebec", opt2 = "Ontario", opt3 = "Alberta", correctAns = "Quebec", status = "not answered" };
            var question10 = new Questions { question = "First area to be explored by Europeans", opt1 = "Ontario", opt2 = "Quebec", opt3 = "Newfoundland", correctAns = "Newfoundland", status = "not answered" };

            var question11 = new Questions { question = "Tim Horton played", opt1 = "Basketball", opt2 = "Hockey", opt3 = "Skater", correctAns = "Hockey", status = "not answered" };
            var question12 = new Questions { question = "Official Canadian Animal", opt1 = "Beaver", opt2 = "Moose", opt3 = "Deer", correctAns = "Beaver", status = "not answered" };
            var question13 = new Questions { question = "How many times zones are in Canada", opt1 = "4", opt2 = "6", opt3 = "3", correctAns = "6", status = "not answered" };
            var question14 = new Questions { question = "Only walled city in North America", opt1 = "Montreal", opt2 = "Quebec", opt3 = "Toronto", correctAns = "Quebec", status = "not answered" };
            var question15 = new Questions { question = "One of the best cities to see the northern lights", opt1 = "Yellowknife", opt2 = "Smithville", opt3 = "Vineland", correctAns = "Yellowknife", status = "not answered" };
            var question16 = new Questions { question = "Second largest French speaking city", opt1 = "Quebec", opt2 = "Montreal", opt3 = "Ottawa", correctAns = "Montreal", status = "not answered" };
            var question17 = new Questions { question = "How many points are in the Canadian flag", opt1 = "9", opt2 = "11", opt3 = "7", correctAns = "9", status = "not answered" };
            var question18 = new Questions { question = "About how many polar bears live in Canada", opt1 = "20000", opt2 = "10000", opt3 = "15000", correctAns = "15000", status = "not answered" };
            var question19 = new Questions { question = "Largest International Film Festival is hosted in", opt1 = "Montreal", opt2 = "Vancouver", opt3 = "Toronto", correctAns = "Toronto", status = "not answered" };

            var question20 = new Questions { question = "Polar Bear Capital of the World", opt1 = "Toronto", opt2 = "Montreal", opt3 = "Manitoba", correctAns = "Manitoba", status = "not answered" };
            var question21 = new Questions { question = "First place to use 911", opt1 = "Winnipeg", opt2 = "Quebec", opt3 = "Vancouver", correctAns = "Winnipeg", status = "not answered" };
            var question22 = new Questions { question = "Coldest temperature registered in Celsius", opt1 = "-63", opt2 = "-52", opt3 = "-70", correctAns = "-63", status = "not answered" };
            var question23 = new Questions { question = "How many oceans border Canada?", opt1 = "2", opt2 = "1", opt3 = "3", correctAns = "3", status = "not answered" };
            var question24 = new Questions { question = "Canada just celebrated its anniversary", opt1 = "120", opt2 = "150", opt3 = "115", correctAns = "150", status = "not answered" };
            var question25 = new Questions { question = "Canadian population in millions", opt1 = "25", opt2 = "40", opt3 = "32", correctAns = "32", status = "not answered" };
            var question26 = new Questions { question = "Where in Canada can you see a whale", opt1 = "British Columbia", opt2 = "Alberta", opt3 = "Manitoba", correctAns = "British Columbia", status = "not answered" };
            var question27 = new Questions { question = "What is CBC", opt1 = "Canadian BroadCasting", opt2 = "A Bank Company", opt3 = "Canadian Services", correctAns = "Canadian BroadCasting", status = "not answered" };
            var question28 = new Questions { question = "Canada Day Celebration", opt1 = "July 4", opt2 = "July 1", opt3 = "July 7", correctAns = "July 4", status = "not answered" };
            var question29 = new Questions { question = "Capital of Ontario", opt1 = "Toronto", opt2 = "Niagara Falls", opt3 = "Ottawa", correctAns = "Ottawa", status = "not answered" };

            var question30 = new Questions { question = "Canadian flag symbol", opt1 = "Oak Leaf", opt2 = "Maple Leaf", opt3 = "None", correctAns = "Maple Leaf", status = "not answered" };
            var question31 = new Questions { question = "What does CRA do", opt1 = "Immigration", opt2 = "Taxes", opt3 = "Utilities", correctAns = "Taxes", status = "not answered" };
            var question32 = new Questions { question = "Victoria is the capital of", opt1 = "Ontario", opt2 = "Manitoba", opt3 = "BC", correctAns = "BC", status = "not answered" };
            var question33 = new Questions { question = "Province more populated", opt1 = "Ontario", opt2 = "BC", opt3 = "Alberta", correctAns = "Ontario", status = "not answered" };
            var question34 = new Questions { question = "Province less populated", opt1 = "Prince Edward Island", opt2 = "Alberta", opt3 = "Manitoba", correctAns = "Prince Edward Island", status = "not answered" };
            var question35 = new Questions { question = "How much is a Toonie?", opt1 = "3", opt2 = "2", opt3 = "1", correctAns = "2", status = "not answered" };
            var question36 = new Questions { question = "What year did Canada became a country?", opt1 = "1810", opt2 = "1867", opt3 = "1853", correctAns = "1867", status = "not answered" };
            var question37 = new Questions { question = "What does CIC do", opt1 = "Immigration", opt2 = "Taxes", opt3 = "Utilities", correctAns = "Immigration", status = "not answered" };
            var question38 = new Questions { question = "How many provinces in Canada?", opt1 = "12", opt2 = "10", opt3 = "13", correctAns = "10", status = "not answered" };
            var question39 = new Questions { question = "How many territories in Canada?", opt1 = "4", opt2 = "3", opt3 = "5", correctAns = "3", status = "not answered" };

            var question40 = new Questions { question = "Where is the highest mountain in Canada?", opt1 = "Yukon", opt2 = "Vancouver", opt3 = "Churchill", correctAns = "Yukon", status = "not answered" };
            var question41 = new Questions { question = "Canada is the ____ largest country", opt1 = "Second", opt2 = "Third", opt3 = "Fourth", correctAns = "Second", status = "not answered" };
            var question42 = new Questions { question = "Capital of Quebec", opt1 = "Montreal", opt2 = "Quebec City", opt3 = "Ottawa", correctAns = "Quebec City", status = "not answered" };
            var question43 = new Questions { question = "Only Country bigger than Canada", opt1 = "China", opt2 = "Russia", opt3 = "Brazil", correctAns = "Russia", status = "not answered" };
            var question44 = new Questions { question = "Head of Canadian government", opt1 = "Monarch", opt2 = "President", opt3 = "Prime Minister", correctAns = "Prime Minister", status = "not answered" };
            var question45 = new Questions { question = "Rank of Canada by population", opt1 = "25", opt2 = "35", opt3 = "56", correctAns = "56", status = "not answered" };
            var question46 = new Questions { question = "Longest river in Canada", opt1 = "Nelson", opt2 = "Fraser", opt3 = "MacKenzie", correctAns = "MacKenzie", status = "not answered" };
            var question47 = new Questions { question = "Michael J. Fox was born in", opt1 = "Edmonton", opt2 = "Montreal", opt3 = "Toronto", correctAns = "Edmonton", status = "not answered" };
            var question48 = new Questions { question = "Pamela Anderson was born in", opt1 = "Ontario", opt2 = "BC", opt3 = "Alberta", correctAns = "BC", status = "not answered" };
            var question49 = new Questions { question = "Where was the first Parliament located?", opt1 = "York", opt2 = "Ottawa", opt3 = "Saint John", correctAns = "York", status = "not answered" };

            var question50 = new Questions { question = "Terry Fox was a known", opt1 = "Hockey Player", opt2 = "Baseball Player", opt3 = "Runner", correctAns = "Runner", status = "not answered" };
            var question51 = new Questions { question = "Percentage of Canadians with a 2nd language", opt1 = "20", opt2 = "30", opt3 = "40", correctAns = "20", status = "not answered" };
            var question52 = new Questions { question = "Sport invented by a Canadian", opt1 = "Baseball", opt2 = "Basketball", opt3 = "Volleyball", correctAns = "Basketball", status = "not answered" };
            var question53 = new Questions { question = "Canadian invent", opt1 = "Telephone", opt2 = "Chair", opt3 = "Television", correctAns = "Telephone", status = "not answered" };
            var question54 = new Questions { question = "Home of the Big Nickel", opt1 = "North Bay", opt2 = "Nickelville", opt3 = "Sudbury", correctAns = "Sudbury", status = "not answered" };
            var question55 = new Questions { question = "Toronto's airport name", opt1 = "Lester B. Pearson", opt2 = "Leonard Cohen", opt3 = "Pierre Trudeau", correctAns = "Lester B. Pearson", status = "not answered" };
            var question56 = new Questions { question = "Blue Jays play", opt1 = "Baseball", opt2 = "Soccer", opt3 = "Hockey", correctAns = "Baseball", status = "not answered" };
            var question57 = new Questions { question = "Country that invaded Canada twice", opt1 = "USA", opt2 = "Russia", opt3 = "China", correctAns = "USA", status = "not answered" };
            var question58 = new Questions { question = "Current prime minister", opt1 = "Justin Parker", opt2 = "Justin Fox", opt3 = "Justin Trudeau", correctAns = "Justin Trudeau", status = "not answered" };
            var question59 = new Questions { question = "Animal on the Canadian nickel", opt1 = "Moose", opt2 = "Deer", opt3 = "Beaver", correctAns = "Beaver", status = "not answered" };
            var question60 = new Questions { question = "Cities that hosted winter games", opt1 = "Toronto, Vancouver", opt2 = "Calgary, Montreal", opt3 = "Calgary, Vancouver", correctAns = "Calgary, Vancouver", status = "not answered" };
            */

            List<Questions> questions = new List<Questions>();
            questions.AddRange(new Questions[] {
                question1, question2, question3, question4, question5, question6, question7, question8, question9, question10
            , question11, question12, question13, question14, question15, question16, question17, question18, question19, question20
            , question21, question22, question23, question24, question25, question26, question27, question28, question29, question30
            , question31, question32, question33, question34, question35, question36, question37, question38, question39, question40
            , question41, question42, question43, question44, question45, question46, question47, question48, question49, question50
            , question51, question52, question53, question54, question55, question56, question57, question58, question59, question60});
            database.InsertAllAsync(questions);

            var user = new User { username = "user", firstName = "first", lastName = "last", points = 0, rank = "1" };
            database.InsertAsync(user);
        }
        //public Questions GetQuestion()
        //{
        //    Questions quest = (Questions)database.Table<Questions>().Where(q => q.status.Equals("not answered")).Take(1);
        //    //Questions question = (Questions)database.ExecuteAsync("SELECT * FROM [Questions] WHERE [status] = 'not answered' limit 1");
        //    return quest;
        //}
        public Questions GetQuest()
        {
            //return database.Table<Questions>().Where(q => q.status.Equals("not answered")).Take(1).ToListAsync();
            //var q = database.Table<Questions>().FirstOrDefaultAsync().Status.Equals("not answered");
            if (App.whereType == "r1")
            {
                var quest = database.QueryAsync<Questions>("SELECT * FROM [Questions] WHERE [status] = 'not answered'").Result;
                if (quest.Count > 0 && whereType == "r1")
                {
                    return quest.First();
                }
                else
                {
                    App.whereType = "r2";
                }
            }
            if(App.whereType == "r2")
            {
                var quest = database.QueryAsync<Questions>("SELECT * FROM [Questions] WHERE [status] = 'wrong'").Result;
                if (quest.Count > 0 && App.whereType == "r2")
                {
                    return quest.First();
                }
                else
                {
                    App.whereType = "r3";
                }
            }
            if (App.whereType == "r3")
            {

                return null;
            }
            return null;
        }
        public User GetUser()
        {
            //return database.Table<Questions>().Where(q => q.status.Equals("not answered")).Take(1).ToListAsync();
            //var q = database.Table<Questions>().FirstOrDefaultAsync().Status.Equals("not answered");
            var user = database.QueryAsync<User>("SELECT * FROM [USER]").Result;
            return user.First();
        }
        public void UpdateStatus(Questions question)
        {
            database.UpdateAsync(question);
        }
        public void UpdateUser(User user)
        {
            database.UpdateAsync(user);
        }
    }
}
