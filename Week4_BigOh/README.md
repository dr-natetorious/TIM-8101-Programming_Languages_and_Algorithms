# Section 2: Week 4: Big O()

## What is Big-O

The de facto method for measuring the efficiency of a computer algorithm is called Big-O notation. The function describes the approximated maximum number of steps that are required to perform an action proportional to an input count. 

For instance, selection sort has a complexity of O(n^2), which means that to operate across 10 items is at most 100 steps (10*10). Binary search can be performed in O(log n) complexity and would only take 4 steps to operate across the same items. The improved runtime is the result of (1) additional constraints; and (2) eliminating redundant steps.

Along with the worst-case scenario it is also useful to understand the (1) best case and (2) average case. Consider a simple algorithm find(x, set) to check if value x is present in a given set. The best case (omega function) occurs when the first item checked is equal to x. The average case (theta function) of find will amortize into n/2 steps.

These three functions can then be used to describe the asymptotically bound range of required steps needed to perform any algorithm (Byrne, 2012) (Cormen & al, 2001). This helps to empirically state the cost in terms of time for per iteration of an algorithm.

Looking at the range also helps to drive the conversation around the supported size of N for the component. Extremely high complexities such as O(n^n);  can still be acceptable provided N is sufficiently limited. At the same time low complexities such as O(n) can become unusable as N grows into the millions of items.
