Soluton submitted by Michael Douglas

This solution requires Visual Studio for editing and execution. I will be honest, I am not all too familiar with the correct way to package and redist an ASP application for local usage.
I tried to keep my code as DRY as possible while maintain readability and the simplicity that was required, but I am sure there are better ways of accomplishing this.


Step 3 :

For a restful API, I would create a new Web API project and create a new controller. This controller would have a route for /api/:entries/:page.
The view for Step2 can be reused for this new project and can be served with ListDataModel containing the information requested in the route.
