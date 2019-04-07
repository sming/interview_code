using System;
using System.Linq;
using System.Collections.Generic;

// Click Therapeutics
/*
MY SOLUTION
-----------------------------
You are given an unordered set of votes, each containing a candidate and a timestamp.
// Votes example
Votes = [ {candidate: ‘a’, timestamp: 10}, {candidate: ‘b’, timestamp: 3}, {candidate: ‘c’, timestamp: 6}, {candidate: ‘b’, timestamp: 10}, {candidate: ‘a’, timestamp: 15}, {candidate: ‘a’, timestamp: 17}, {candidate: ‘c’, timestamp: 22}, {candidate: ‘b’, timestamp: 27}, {candidate: ‘a’, timestamp: 32} ]

 1. Write a function that takes votes and a timestamp and returns the leading candidate at that point in time
 return top K candidates
*/
// Write a function that takes votes, a timestamp, and a number k, and returns the k leading candidates at that point in time.

namespace LeadingCandidate
{
    public class LeadingCandidate
    {
        public List<char> GetLeadingCandidateAtTime(List<Tuple<char, DateTime>> votes, DateTime time, int numberOfLeadersToReturn = 1)
        {
            if (votes == null || !votes.Any()) //(votes?.Count() ?? 0) == 0)
            {
                throw new ArgumentException("votes");
            }

            if (numberOfLeadersToReturn == 0)
            {
                throw new ArgumentException("numberOfLeadersToReturn");
            }

            // pull out applicable votes, ordered by timestamp
            var applicableVotes = votes.Where(x => (x.Item2 <= time)).ToList();

            char leadingCandidate = 'x';
            int leadingNumberOfVotes = int.MinValue;
            var voteCount = new Dictionary<char, int>();
            foreach (var vote in applicableVotes)
            {
                char candidate = vote.Item1;
                if (voteCount.ContainsKey(candidate))
                {
                    voteCount[candidate] = voteCount[candidate] + 1;
                }
                else
                {
                    voteCount[candidate] = 1;
                }

                if (voteCount[candidate] > leadingNumberOfVotes)
                {
                    leadingCandidate = candidate;
                }
            }

            var topNcandidates = voteCount.OrderByDescending(x => x.Value).Take(numberOfLeadersToReturn).ToList();

            return topNcandidates.Select(x => x.Key).ToList();
        }
    }
}