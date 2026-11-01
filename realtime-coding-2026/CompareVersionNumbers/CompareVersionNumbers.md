Compare Version Numbers

Problem Description

You are given two version strings, version1 and version2.

A version string consists of one or more revisions separated by dots (.).

For example:

"1.0.3"

contains three revisions:

1, 0, 3

Each revision contains only digits and may contain leading zeros.

For example:

"001"

represents the same numeric value as:

"1"

Compare the two version strings revision by revision from left to right.

If one version contains fewer revisions than the other, treat the missing revisions as 0.

Return:

* -1 if version1 is smaller than version2.
* 1 if version1 is greater than version2.
* 0 if both versions are equivalent.

⸻

Function Signature

compareVersion(version1, version2)

Parameters

* version1: a string representing the first version.
* version2: a string representing the second version.

Return Value

Return an integer:

-1 if version1 < version2
 1 if version1 > version2
 0 if version1 == version2

⸻

Constraints

1 <= version1.length <= 500
1 <= version2.length <= 500
version1 and version2 contain only digits and dots.
version1 and version2 do not begin or end with a dot.
Every revision contains at least one digit.

⸻

Comparison Rules

For each revision index:

1. Read the corresponding revision from both versions.
2. Remove any leading zeros, or interpret the revision numerically.
3. Compare the two revision values.
4. If they are different, return the comparison result immediately.
5. If they are equal, continue to the next revision.
6. Missing revisions are treated as 0.

⸻

Example 1

Input

version1 = "1.01"
version2 = "1.001"

Output

0

Explanation

The versions contain the revisions:

version1: 1, 01
version2: 1, 001

After ignoring leading zeros:

version1: 1, 1
version2: 1, 1

Therefore, the two versions are equivalent.

⸻

Example 2

Input

version1 = "1.0"
version2 = "1.0.0"

Output

0

Explanation

The first version has two revisions:

1, 0

The second version has three revisions:

1, 0, 0

The missing third revision in version1 is treated as 0, so the versions are equivalent.

⸻

Example 3

Input

version1 = "0.1"
version2 = "1.1"

Output

-1

Explanation

The first revisions are:

0 and 1

Since 0 < 1, version1 is smaller than version2.

⸻

Example 4

Input

version1 = "1.0.1"
version2 = "1"

Output

1

Explanation

The first revisions are equal:

1 == 1

The second revisions are also equal because the missing revision is treated as 0:

0 == 0

At the third revision:

1 > 0

Therefore, version1 is greater than version2.

⸻

Example 5

Input

version1 = "7.5.2.4"
version2 = "7.5.3"

Output

-1

Explanation

The first two revisions are equal:

7 == 7
5 == 5

At the third revision:

2 < 3

Therefore, version1 is smaller than version2.

⸻

Test Cases

Test Case 1: Equal Simple Versions

Input

version1 = "1"
version2 = "1"

Expected Output

0

⸻

Test Case 2: Leading Zeros

Input

version1 = "01.002.0003"
version2 = "1.2.3"

Expected Output

0

⸻

Test Case 3: Missing Trailing Revisions

Input

version1 = "2.5"
version2 = "2.5.0.0"

Expected Output

0

⸻

Test Case 4: Greater Major Revision

Input

version1 = "10.0"
version2 = "2.999"

Expected Output

1

The first revision determines the result:

10 > 2

⸻

Test Case 5: Smaller Minor Revision

Input

version1 = "3.4.9"
version2 = "3.5.0"

Expected Output

-1

⸻

Test Case 6: Extra Non-Zero Revision

Input

version1 = "1.0.0.1"
version2 = "1"

Expected Output

1

⸻

Test Case 7: Extra Zero Revisions

Input

version1 = "1.0.0.0"
version2 = "1"

Expected Output

0

⸻

Test Case 8: Large Revision Values

Input

version1 = "2147483648.0"
version2 = "2147483647.999"

Expected Output

1

This test demonstrates that revision values may be larger than a 32-bit signed integer.

A robust solution should avoid relying only on int.

⸻

Test Case 9: Very Long Equal Revisions

Input

version1 = "000000000000000000000123"
version2 = "123"

Expected Output

0

⸻

Test Case 10: Very Long Different Revisions

Input

version1 = "999999999999999999999999"
version2 = "1000000000000000000000000"

Expected Output

-1

⸻

Edge Cases to Consider

* One version has more revisions than the other.
* The extra revisions are all zero.
* Revisions contain many leading zeros.
* A revision is larger than the maximum value of a 32-bit integer.
* The first revisions are different.
* The versions differ only at the final revision.
* Both versions contain only zero revisions.

⸻

Follow-up Questions

1. What is the time complexity of your solution?
2. What is the space complexity?
3. Can you solve the problem without calling Split?
4. How would you compare revisions that are too large to fit into a 64-bit integer?
5. How can you compare two revision strings after removing leading zeros without converting them to numbers?
6. What are the trade-offs between:
    * splitting both strings first,
    * and parsing both strings using two pointers?
7. How would your implementation change if empty revisions such as "1..2" were allowed?
8. How would you support semantic versions containing suffixes such as:

"1.0.0-alpha"