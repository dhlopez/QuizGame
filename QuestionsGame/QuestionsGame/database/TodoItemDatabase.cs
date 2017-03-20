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
            //wrong or right / not answered
            var question1 = new Questions { question="Some question1", opt1="option1", opt2="option2", opt3="option3", correctAns="option2", status="not answered" };
            var question2 = new Questions { question = "Some question2", opt1 = "option1", opt2 = "option2", opt3 = "option3", correctAns = "option3", status = "wrong" };
            List<Questions> questions = new List<Questions>();
            questions.AddRange(new Questions[] { question1, question2});
            database.InsertAllAsync(questions);

        }
    }
}
