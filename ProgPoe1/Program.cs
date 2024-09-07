// Muhammad Rahim
// ST10043611
// Group 3

// References: List your references here (and also it would be a good idea to list the references at the end of your readme file), for example:
//             https://chatgpt.com/c/66dc9eee-6e70-8009-923a-e0062ef15a07
//             https://www.w3schools.com/cs/cs_examples.php
//             https://www.geeksforgeeks.org/introduction-to-net-framework/
//             https://www.geeksforgeeks.org/c-sharp-methods/?ref=shm
//             https://www.geeksforgeeks.org/c-sharp-classes-and-objects/?ref=shm
//             https://www.geeksforgeeks.org/arraylist-in-c-sharp/?ref=shm



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//------------------------------------------...ooo000 END OF FILE 000ooo...----------------------------------------------------------------------------------------------------------------------//

