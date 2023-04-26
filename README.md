# Turing Machine Loop Checker

A small program that checks whether the given Turing Machine will halt or loop forever
for a given word. The important detail is that the given Turing Machine does not have an
infinite tape: it has a looped tape of size `n`. That means that when we are on position `n`
and want to move to the right, we'll loop around and end up in position `1`. This little
constraint allows us to solve the halting problem.

Made as a bonus task for my discrete math course (Hello, Kirill Vladimirovich!!!)

## Examples

```
Q: 1
M: 1
States:
q1 a -> q1 a +1
Word: aaa
n: 3
>>> Not OK
```

```
Q: 3
M: 6
States:
q1 1 -> q1 1 +1
q2 1 -> q1 1 -1
q3 1 -> q2 1 +1
q1 ^ -> q2 ^ +1
q2 ^ -> q3 ^ +1
q3 ^ -> q0 ^ 0
Word: 11^1
n: 4
>>> Not OK
```

```
Q: 3
M: 6
States:
q1 1 -> q1 1 +1
q2 1 -> q1 1 -1
q3 1 -> q2 1 +1
q1 ^ -> q2 ^ +1
q2 ^ -> q3 ^ +1
q3 ^ -> q0 ^ 0
Word: 1^^^
n: 4
>>> OK
```
