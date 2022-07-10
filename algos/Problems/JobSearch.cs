using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems
{
    public class JobSearch
    {
        // Use dictionary to hold job description
        // Holds index for jds
        IDictionary<string, HashSet<int>> jobDesriptions;


        public JobSearch()
        {
            jobDesriptions = new Dictionary<string, HashSet<int>>();
        }

        public void StoreDocument(string document, int document_number)
        {
            // split current document for each word
            var wordsArray = document.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in wordsArray)
            {
                //Avoid duplicate
                if (jobDesriptions.ContainsKey(word))
                {
                    if (!jobDesriptions[word].Contains(document_number)) jobDesriptions[word].Add(document_number);
                }
                else
                {
                    jobDesriptions.Add(word, new HashSet<int>() { document_number });
                }
            }
        }


        public void PerformSearch(string query)
        {
            // Search if there is any JD available
            if (jobDesriptions.Count == 0)
                return;

            // is there something to query?
            if (string.IsNullOrEmpty(query))
                return;

            var filters = query.Split(' ', StringSplitOptions.RemoveEmptyEntries);            
            var matches = new Dictionary<int, int>();
            foreach (var filter in filters)
            {
                if (jobDesriptions.ContainsKey(filter))
                {
                    foreach (var jd in jobDesriptions[filter])
                    {
                        if (!matches.ContainsKey(jd))
                            matches[jd] = 0;
                        matches[jd]++;
                    }
                }
            }

            var list = matches.ToList();

            list.Sort((t1, t2) => {
                if (t1.Value == t2.Value)
                    return t1.Key.CompareTo(t2.Key);
                return t2.Value.CompareTo(t1.Value);
            });


            // Sort based on count and then index
            if (list.Count == 0)
                Console.WriteLine("-1");
            else
                list.ForEach(item => { 
                    Console.WriteLine($"{item.Key} {item.Value}"); 
                });
        }
    }
}
