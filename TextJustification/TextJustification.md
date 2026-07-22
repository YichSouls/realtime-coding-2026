Text Justification

Problem Description

Given an array of words and a maximum line width, format the text so that each line has exactly maxWidth characters and is fully justified.

Words should be packed greedily into each line. In other words, place as many words as possible into the current line before moving to the next one.

After determining the words in a line, distribute the spaces according to the following rules:

* Every line (except the last line) must be fully justified.
* Spaces should be distributed as evenly as possible between words.
* If the spaces cannot be evenly distributed, the extra spaces should be assigned to the leftmost gaps.
* The last line must be left-justified, meaning:
    * Words are separated by a single space.
    * Remaining spaces are appended to the end of the line.

Return the formatted text as a list of strings.

⸻

Function Signature

fullJustify(words, maxWidth)

Parameters

* words: an array of strings.
* maxWidth: an integer representing the width of every output line.

Return Value

Return a list of strings where each string has exactly maxWidth characters.

⸻

Constraints

1 <= words.length <= 300
1 <= words[i].length <= 20
words[i] contains only English letters.
1 <= maxWidth <= 100
The length of every word is less than or equal to maxWidth.

⸻

Example 1

Input

words =
[
"This",
"is",
"an",
"example",
"of",
"text",
"justification."
]
maxWidth = 16

Output

[
"This    is    an",
"example  of text",
"justification.  "
]

Explanation

The first line contains:

This
is
an

The total length of the words is:

4 + 2 + 2 = 8

There are

16 - 8 = 8

spaces to distribute across two gaps.

Each gap receives four spaces.

The final line is left-justified.

⸻

Example 2

Input

words =
[
"What",
"must",
"be",
"acknowledgment",
"shall",
"be"
]
maxWidth = 16

Output

[
"What   must   be",
"acknowledgment  ",
"shall be        "
]

Explanation

The second line contains only one word.

Single-word lines are left-justified.

⸻

Example 3

Input

words =
[
"Science",
"is",
"what",
"we",
"understand",
"well",
"enough",
"to",
"explain",
"to",
"a",
"computer.",
"Art",
"is",
"everything",
"else",
"we",
"do"
]
maxWidth = 20

Output

[
"Science  is  what we",
"understand      well",
"enough to explain to",
"a  computer.  Art is",
"everything  else  we",
"do                  "
]

⸻

Test Cases

Test Case 1

Input

words = ["Hello"]
maxWidth = 10

Expected Output

[
"Hello     "
]

⸻

Test Case 2

Input

words =
[
"Hello",
"World"
]
maxWidth = 11

Expected Output

[
"Hello World"
]

Exactly one space is needed.

⸻

Test Case 3

Input

words =
[
"Hello",
"World"
]
maxWidth = 15

Expected Output

[
"Hello World    "
]

Last line must be left-justified.

⸻

Test Case 4

Input

words =
[
"a",
"b",
"c",
"d",
"e"
]
maxWidth = 5

Expected Output

[
"a b c",
"d e  "
]

⸻

Test Case 5

Input

words =
[
"Listen",
"to",
"many",
"speak",
"to",
"a",
"few"
]
maxWidth = 15

Expected Output

[
"Listen      to",
"many speak to",
"a few        "
]

⸻

Test Case 6

Input

words =
[
"abcdef",
"gh",
"ij",
"klmnop"
]
maxWidth = 10

Expected Output

[
"abcdef  gh",
"ij      ",
"klmnop    "
]

⸻

Test Case 7

Input

words =
[
"a",
"bc",
"def",
"ghij",
"k"
]
maxWidth = 8

Expected Output

[
"a     bc",
"def ghij",
"k       "
]

⸻

Follow-up Questions

1. What is the time complexity of your solution?
2. What is the space complexity?
3. How would you organize your code into helper functions?
4. How would your solution change if words were streamed one at a time instead of being provided as an array?
5. How would you support right alignment or center alignment?
6. How would you handle Unicode characters with different display widths?
7. How would you modify your solution if hyphenation of long words were allowed?