package org.psk.interview_code.doubleverify;

import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/*
 * User 1 visited ["cnn", "bbc", "abc", "cnn"]
 * User 2 visits ["abc", "cnn", "bbc", "bbc"]
 * User 1 and 2 have the same site visitation pattern?
 *
 * PSK
 * - ordering irrelevant
 * - size? very small
 * - duplicates? 
 * - null/empty? both empty - not same. 
 * - return value? bool
 * - 
 */

class Solution {
  public static void main(String[] args) {
    
    var siteList1 =  Arrays.asList("cnn", "bbc", "abc", "cnn");
    var siteList2 =  Arrays.asList("abc", "cnn", "bbc", "bbc");
    
    System.out.println("Sites are equal? " + IsSameVisitationPattern(siteList1, siteList2));

    siteList1 =  Arrays.asList("cnn", "bbc", "abc", "cnn");
    siteList2 =  Arrays.asList("abc", "cnn", "cnn", "bbc");
    
    System.out.println("Sites are equal? " + IsSameVisitationPattern(siteList1, siteList2));
    
    siteList1 =  null;
    siteList2 =  Arrays.asList("abc", "cnn", "cnn", "bbc");
    
    System.out.println("Sites are equal? " + IsSameVisitationPattern(siteList1, siteList2));
    
    
  }
  
  public static boolean IsSameVisitationPattern(List<String> user1, List<String> user2) {
    // O(1)
    if (user1 == null || user1.size() == 0 || user2 == null || user2.size() == 0)
      return false;
    // O(1)
    if (user1.size() != user2.size())
      return false;
    
    // 2 (O(N) + O(M))
    var siteCountUser1 = getSiteCounts(user1);
    var siteCountUser2 = getSiteCounts(user2); 
    
    
    // O(N) + O(M)
    return siteCountUser1.equals(siteCountUser2);
  }
  
  private static Map<String,Integer> getSiteCounts(List<String> sites) {
    var siteCounts = new HashMap<String,Integer>();
    
    // O(N) + O(M)
    for (String site : sites) {
      int currCount = 0;
      // O(1)
      if (siteCounts.containsKey(site)) {
        // O(1)
        currCount = siteCounts.get(site);
      }
      
      // O(1)
      siteCounts.put(site, currCount + 1);
    }
    
    return siteCounts;
      
  }
}
