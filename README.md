
# StringBuilderOperator
StringBuilder wrapper class. Execute Append() with operator +.

* extension cannot add operator (C # language specification)
* StringBuilder class is sealed and cannot be inherited
* There is no choice but to wrap it in another class. That is the StringBuilderOperator class!

Keep a StringBuilder instance inside this class and share it throughout your program code.

# How to use
Declare the following at the beginning of the file.

```
using SBO = StringBuilderOperator.StringBuilderOperator;
```

String concatenation

```
string s = SBO.i + "aaa" + 20 + "bbbb";
```

For multiple statements (loop, etc.)

```
 SBO s = SBO.i; // Hold string as SBO type
 for (int i = 0; i <100; i ++) s + = someString; // Concatenate with SBO type
```
Note: if you write ```s = SBO.i + s + someString; ``` in string type, SBO.ToString() will be executed for each loop and it will be slow.

Only available in the main thread. If called, it will give a LogError.

Developed with reference to [StringBuilderTemporary](https://github.com/wotakuro/StringBuilderTemporary)
