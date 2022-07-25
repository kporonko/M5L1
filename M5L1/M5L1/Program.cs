using M5L1.Controllers;
// 1 LIST USERS
//UserController.ListUsersAsync();

// 2 SINGLE USER
//UserController.SingleUserAsync(2);

//3 SINGLE USER NOT FOUND
//UserController.SingleUserAsync(23);

//4 LIST <RESOURCE>
//ResourceController.ResourceListAsync();

//5 SINGLE <RESOURCE>
//ResourceController.SingleResourceAsync(2);

// 6 SINGLE <RESOURCE> NOT FOUND
//ResourceController.SingleResourceAsync(23);

// 7 CREATE
//UserController.CreateUser("John", "Programmer");

// 8 UPDATE
//UserController.UpdateUser("morpheus", "zion resident");

// 9 UPDATE PATCH
//UserController.UpdateUserPatch("morpheus", "zion resident");

// 10 DELETE
//UserController.DeleteUser();

// 11 REGISTER - SUCCESSFUL
//UserController.RegisterUser(true);

// 12 REGISTER - UNSUCCESSFUL
//UserController.RegisterUser(false);

// 13 LOGIN - SUCCESSFUL
//UserController.LoginUser(true);

// 14 LOGIN - UNSUCCESSFUL
UserController.LoginUser(false);
Console.ReadLine();