using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems
{
    /*
    Given a log file of Amazon website requests,
    find the most frequent 3-page sequence visited
    by all users. 


    Example log file format:
    user1, pageA, Chrome, ...
    user2, pageE, Firefox, ...
    user1, pageB, Chrome, ...
    user2, pageB, Firefox, ...
    user2, pageC, Firefox, ...
    user1, pageC, Chrome, ...
    user2, pageD, Firefox, ...
    user1, pageD, Chrome, ...
    user1, pageE, Chrome, ...
    user2, pageA, Firefox, ...

    user1 visits A -> B -> C -> D -> E

    user1's 3-page sequences
    - A,B,C
    - B,C,D
    - C,D,E

    user2 visits E -> B -> C -> D -> A

    user2's 3-page sequences
    - E,B,C
    - B,C,D
    - C,D,A

    Most frequent 3-page sequence: B,C,D
    */

    public class FrequentKPagesGroup
    {
        public string[] FindTopFrequentGroup(string[] logs, int groupCount)
        {
            var result = new List<string>();
            var navigationMap = new Dictionary<string, LinkedList<string>>();
            var pageGroupCount = new Dictionary<string, int>();
            var maxPageGroupCount = 0;
            foreach (var log in logs)
            { 
                var logSplit = log.Split(',', StringSplitOptions.RemoveEmptyEntries);
                var user = logSplit[0].Trim();
                var page = logSplit[1].Trim();

                if (!navigationMap.ContainsKey(user))
                    navigationMap.Add(user, new LinkedList<string>());
                navigationMap[user].AddLast(page);

                if (navigationMap[user].Count == groupCount)
                {
                    var groupKey = string.Join(',', navigationMap[user].ToArray());
                    if(!pageGroupCount.ContainsKey(groupKey)) pageGroupCount.Add(groupKey, 0);

                    pageGroupCount[groupKey]++;
                    if (pageGroupCount[groupKey] > maxPageGroupCount)
                    {
                        maxPageGroupCount = pageGroupCount[groupKey];
                        result = navigationMap[user].ToList();
                    }
                    navigationMap[user].RemoveFirst();
                }
            }

            return result.ToArray();
        }
    }
}
