using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web;

namespace Heaton_TriviaApp
{
    class Trivia
    {
        public int response_code;
        public List<TriviaResult> results;
    }

    class TriviaResult
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public List<string> incorrect_answers;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string url = null;
            string s = null;

            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader reader;

            url = " https://opentdb.com/api.php?amount=1&type=multiple";

            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());

            s = reader.ReadToEnd();
            reader.Close();

            Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);

            trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);
            trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);

            for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
            {
                trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
            }

            // Pop the question
            Console.WriteLine(trivia.results[0].question);

            // Random instance will be correct answer
            Random rnd = new Random();
            int rand = rnd.Next(4);
            bool hasCorrectHappened = false;
            
            for (int i = 0; i < 4; ++i)
            {
                string choice = "";

                // If this answer is the randomly correct one
                if (i == rand)
                {
                    choice = trivia.results[0].correct_answer;
                    hasCorrectHappened |= true;
                }
                else
                {
                    // If correct answer has been printed, need to shift the index back by one
                    if (hasCorrectHappened)
                    {
                        choice = trivia.results[0].incorrect_answers[i - 1];
                    }
                    else
                    {
                        choice = trivia.results[0].incorrect_answers[i];
                    }
                }

                Console.WriteLine(i.ToString() + ". " + choice);
            }

            // Get input
            Console.Write("Your Answer: ");
            string userAnswer = Console.ReadLine();

            if (userAnswer.ToUpper() == trivia.results[0].correct_answer.ToUpper())
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect. The answer was " + trivia.results[0].correct_answer);
            }
        }

    }
}
