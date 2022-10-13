Soluton submitted by Michael Douglas

This solution requires Visual Studio for editing and execution. I will be honest, I am not all too familiar with the correct way to package and redist an ASP application for local usage.
I tried to keep my code as DRY as possible while maintain readability and the simplicity that was required, but I am sure there are better ways of accomplishing this.


Step 3 :

To accomplish a restful design, I would create a new function inside of my Home controller that accepts a post on the  api endpoint /api/:amount/:page
There would be validation to ensure that the page is valid for the amount spcified in this function and if everything is valid;
I would then past those parameters through my model into the view that I have created and used for Step 2.

The adjustment to my view would be in the for loop, variable i would start at page * 20 and the end criteria would be min(amount, page*20+20)

