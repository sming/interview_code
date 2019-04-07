using System;
using Xunit;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LeadingCandidate;

namespace UnitTests
{
    public class UnitTest1
    {
        
        // NOTE: Tried using [ExpectedException(typeof(ArgumentException))] and it ostensibly worked but still marked the 
        // Unit test as failed. Looks like a bug.
        [Fact]
        public void LeadingCandidateHandlesBadInput()
        {
            var lc = new LeadingCandidate.LeadingCandidate();
            try
            {
                lc.GetLeadingCandidateAtTime(null, new DateTime(2019, 03, 20));
                throw new AssertFailedException();
            } catch (ArgumentException) { }
        }

        [Fact]
        public void LeadingCandidateHandlesBadInput2()
        {
            try
            {
                var lc = new LeadingCandidate.LeadingCandidate();
                var votes = new List<Tuple<char, DateTime>>();
                lc.GetLeadingCandidateAtTime(votes, new DateTime(2019, 03, 20));
            } catch (ArgumentException) { }
        }

        [Fact]
        public void LeadingCandidateFindsLeader()
        {
            var lc = new LeadingCandidate.LeadingCandidate();
            var votes = new List<Tuple<char, DateTime>> { Tuple.Create('a', new DateTime(2019, 03, 19))};
            lc.GetLeadingCandidateAtTime(votes, new DateTime(2019, 03, 20));
        }
    }
}
