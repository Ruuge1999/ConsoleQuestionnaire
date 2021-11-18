using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleQuestionnaire
{
    class Program
    {
        static Dictionary<string, string[]> qAndA = new Dictionary<string, string[]>();

        static void Main(string[] args)
        {
            // Read each argument as a path to a JSON file
            foreach (string path in args)
            {
                // Make sure the dictinary is empty so old questions and answers aren't displayed again
                qAndA = new Dictionary<string, string[]>();

                ConsoleHelper.WriteLineAsColour(path, ConsoleColor.Yellow);
                ReadQuestionsAndAnswers(path);

                // Print the questions and answers
                foreach (var pair in qAndA)
                {
                    ConsoleHelper.WriteLineAsColour(pair.Key, ConsoleColor.Magenta);

                    string input = Console.ReadLine();

                    foreach (string item in pair.Value)
                    {
                        if (input == item)
                            ConsoleHelper.WriteLineAsColour($"    {item}", ConsoleColor.Green);
                        else
                            Console.WriteLine($"    {item}");
                    }
                }

            }
            Console.WriteLine("Press ENTER to exit...");
            Console.ReadKey();
        }

        static void ReadQuestionsAndAnswers(string file)
        {
            // Read the file
            using StreamReader r = new StreamReader(file);
            string json = r.ReadToEnd();

            // Parse the file as JSON
            JObject j = JObject.Parse(json);

            // Find an object labelled "questions" - this should be an array of objects
            JArray questions = (JArray)j["questions"];

            // Go through each object in the array
            foreach (JToken item in questions)
            {
                // Each object should have its own array for every possible answer
                string[] answers = item["answers"].ToObject<string[]>();
                // Each object should also have a single field for the name of the question
                qAndA.Add(item["name"].ToString(), answers);
            }

        }
    }
}
