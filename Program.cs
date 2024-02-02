namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            //Production Environment
            #region Security
            // make the website more secure by hiding details when exception
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            #endregion

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();


            app.MapControllerRoute
                (
                name: "Default",
                pattern: "{Controller=Home}/{Action=Index}/{id?}"
                );

            app.Run();

        }
    }
}