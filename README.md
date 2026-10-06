# Exam02 - Examination System (C#)

Console app for DEPI Exam 02. It builds an exam for a subject and lets the student take it.

## Features
- Base `Question` class with `TrueFalseQuestion` and `MCQQuestion`
- Base `Exam` class with `FinalExam` and `PracticalExam`
- `Answer` class (AnswerId, AnswerText)
- `Subject` class that creates its exam
- Final exam shows questions, answers and grade
- Practical exam shows the right answers at the end
- Uses ICloneable, IComparable, ToString override and constructor chaining

## Run
```
dotnet run
```
