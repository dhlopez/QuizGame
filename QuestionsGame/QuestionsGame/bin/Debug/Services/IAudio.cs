using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionsGame.Services
{
    public interface IAudio
    {
        bool PlayMp3File(string fileName);
    }
}
