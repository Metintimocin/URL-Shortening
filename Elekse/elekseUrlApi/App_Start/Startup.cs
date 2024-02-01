namespace elekseUrlApi.App_Start
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Servisleri konfigure edin
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{longUrl}",
                    defaults: new { controller = "Home", action = "ShortenUrl" });
            });
        }
    }
}

