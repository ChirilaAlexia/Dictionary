# Dictionary
The project is made using the programming language C# and WPF (.NET Framework).

The dictionary contains 3 modules:
1. Administrative
2. Word search
3. Entertainment
   
To access the administrative module, a username and password will be required. These
user accounts are taken from a predefined text file.
The administrative module involves adding, modifying and deleting words in/from the dictionary.
A word will have the associated description, a category and an image (if an image has not been added to a word, then it will have a predefined one). A word is always part of a single category.
When adding a new word, if there is already a category in which we want to insert it, then that
will be selected from a list. New categories will be introduced automatically when adding a word.
The images are selected from the computer and stored in a resource area of ​​the application.
Validations are made for the fields in the administration form.

The word search module involves searching for words from either a certain category
(selected by the user) or regardless of category. The user can first choose the category,
after which the user will enter the desired word in a textbox that has an autocompletion mechanism.
If a category has been chosen, only words from that category will appear. If all categories are selected, all
words will appear that begin with the text sequence entered by the user.
After selecting the desired word from the list, the following will appear on the window: the selected word, the description,
the category and the image. If a word does not have a picture, a predefined image will appear.

The entertainment module assumes the existence of a game in which the user must guess 5
words from the dictionary. He will receive either the explanation or the image of the word and will have to write the
associated word. For each word, it is determined randomly if the description is displayed
or the image. If there are words without an image, then the description will be displayed.
After each word, the user will be able to click on the "Next"/"Previous" button in order
to move to the next/previous word. When it reaches the 5th word, on the button
it will no longer say "Next", but "End Game", and when it reaches the first word, the "Previous" button will be
inactive or will not appear at all. The number of correct answers is displayed at the end, after it is given
click on "Finish".
After finishing each game (after clicking on "Finish") the game will be reset.
The 5 words of the game are randomly chosen from the dictionary.

