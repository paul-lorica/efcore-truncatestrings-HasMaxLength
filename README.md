# Automatically truncate strings in a EF Core Entity based on MaxLength property

Have you ever gotten that pesky "string or binary data would be truncated" exception when trying to save your entities in SQL?

As you may already know, this just means that your are trying insert data(commonly a string) which is more than the size of the column in SQL.

There are different and better ways to solve this which include 
1. simply increasing the size of the column, or 
2. adding validations before it evens reaches the code that saves to SQL.

But in my case, I was simply told to truncate the strings. The data that will be truncated is not important. 

The entity that I needed to truncate the strings from contained 50+ strings. Manually finding the length and truncating each property would be tedious. 

In the DBContext model builder, you will find that string properties are decorated with a HasMaxLength PropertyBuilder.

The code will cycle through all string properties of an entity and truncate them by their MaxLength.

