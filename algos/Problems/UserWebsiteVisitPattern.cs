using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems;

public class UserWebsiteVisitPattern
{
    class Visit
    {
        public string User { get; set; }
        public string Website { get; set; }
        public int Timestamp { get; set; }
    }

    //https://leetcode.com/problems/analyze-user-website-visit-pattern/
    public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
    {

        var map = new Dictionary<string, LinkedList<Visit>>();
        var visits = new List<Visit>();
        for (var i = 0; i < username.Length; i++)
        {
            visits.Add(new Visit()
            {
                Website = website[i],
                User = username[i],
                Timestamp = timestamp[i]
            });
        }

        //visits.Sort((t1, t2) => { return t1.Timestamp.CompareTo(t2.Timestamp); });
        var pageGroupMap = new Dictionary<string, int>();
        foreach (var visit in visits)
        {
            if ( !map.ContainsKey(visit.User) )
                map[visit.User] = new LinkedList<Visit>();

            map[visit.User].AddLast(visit);

            if (map[visit.User].Count == 3)
            {
                var group = map[visit.User].ToList();
                group.Sort((t1, t2)=> t1.Timestamp.CompareTo(t2.Timestamp));
                var key = string.Join('-', group.Select(s => s.Website).ToList());
                if (!pageGroupMap.ContainsKey(key))
                    pageGroupMap[key] = 0;
                pageGroupMap[key]++;
                map[visit.User].RemoveFirst();
            }
        }
        var orderList = pageGroupMap.ToList();
        orderList.Sort((t1, t2) => { 
            if ( t1.Value == t2.Value)
                return t1.Key.CompareTo(t2.Key); 
            return t2.Value.CompareTo(t1.Value);
        });

        return orderList[0].Key.Split('-');
    }

}
