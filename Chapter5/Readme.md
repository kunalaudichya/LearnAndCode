# Team Formatting Standards for C# projects

## 1. Horizontal Formatting

- Add spaces around operators like =, +, -, <, >.
- Break long lines over than 120 lines into multiple lines.
- Avoid adding multiple variables in a same line.
- Use curly braces even for single line statements i.e. for if-else, while blocks

## 2. Vertical Formatting

- Group related sections together in this order:
  1. Constants  
  2. Fields  
  3. Constructor  
  4. Public methods  
  5. Private helper methods

- Add blank lines between sections.
- Keep caller methods above the private helper methods they are using.
- Keep methods short and follow SRP.

## 3. Naming Conventions

- Classes - PascalCase
- Methods - PascalCase 
- Variables - camelCase
- Constants - UPPER_CASE

## 4. Strings and Logging

- Prefer string interpolation ($"{variable}") over concatenation.
- Logging and notifications should be informative but simple.

## 5. General Tips

- Keep the code readable for anyone in the team.
- Avoid magic numbers; use constants instead.
- One method should do only one job.
- Comment only when necessary, otherwise code should explain itself.
- Removed unused namespaces from top of the files.
- Keep same types of files in their respective type of folders EX: Models, Repositories, Services.